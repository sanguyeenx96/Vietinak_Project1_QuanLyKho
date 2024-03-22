using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.f_Nhapxuat
{
    public partial class FormNhapkho : Form
    {
        public User userInfo;
        private List<Thongtinvattu> allThongtinvattu;
        private Thongtinvattu infoThongtinvattu;
        private float checkconlaiinvoice;
        private int invoiceid;
        private int invoiceinfoid;
        public FormNhapkho(User userInfo)
        {
            InitializeComponent();
            LoadMavattuToComboBox();
            this.userInfo = userInfo;
        }

        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }

        private void LoadMavattuToComboBox()
        {
            allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
            foreach (Thongtinvattu item in allThongtinvattu)
            {
                cbmavattu.Items.Add(item.Mavattu);
            }
            // Thiết lập cho ComboBox tự động gợi ý các giá trị khi gõ
            cbmavattu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbmavattu.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void FormNhapkho_Load(object sender, EventArgs e)
        {
            txtNgaygionhap.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            txtNguoithaotac.Text = userInfo.Hoten;
            cbmavattu.Focus();
        }

        private void cbmavattu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMavattu = cbmavattu.SelectedItem.ToString();
            infoThongtinvattu = allThongtinvattu.Where(x => x.Mavattu == selectedMavattu).FirstOrDefault();
            if (infoThongtinvattu != null)
            {
                txtDiengiai.Text = infoThongtinvattu.Diengiai.ToString();
                txtDonvitinh.Text = infoThongtinvattu.Donvi.ToString();
                txtKgtrenbao.Text = infoThongtinvattu.Kgtrenbao.ToString();
                txtTonkhovtn.Text = infoThongtinvattu.Tonkhovtn.ToString();
                txttonkhodrg.Text = infoThongtinvattu.Tonkhodrg.ToString();
                txtdonvi2.Text = infoThongtinvattu.Donvi.ToString();

                System.Data.DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoice JOIN dbo.invoiceinfo ON invoice.id = invoiceinfo.invoiceid JOIN dbo.poinfo ON invoiceinfo.itemid = poinfo.id WHERE poinfo.description  = '" + selectedMavattu + "' AND invoice.trangthai != 'Done' ");
                // Xóa các mục hiện tại trong ComboBox trước khi thêm các mục mới
                cbinvoiceno.Items.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm giá trị của cột "invoice.invoicenumber" vào ComboBox
                foreach (DataRow row in data.Rows)
                {
                    // Kiểm tra xem cột "invoice.invoicenumber" có tồn tại và không rỗng
                    if (row["invoicenumber"] != null && row["invoicenumber"] != DBNull.Value)
                    {
                        string invoicenumber = row["invoicenumber"].ToString();
                        cbinvoiceno.Items.Add(invoicenumber);
                    }
                }

            }
        }

        private void cbmavattu_Leave(object sender, EventArgs e)
        {
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (cbNhapvaokho.Text == "NHẬP LẠI")
            {
                if (
                string.IsNullOrWhiteSpace(cbmavattu.Text) ||
                string.IsNullOrWhiteSpace(txtSoluongnhap.Text)
                )
                {
                    MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumeric(txtSoluongnhap.Text))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //tonkhosaunhapDRG -= soluongnhap; //Giảm tồn kho DRAGON
                //tonkhosaunhapVTN += soluongnhap; //Tăng tồn kho VTN
                int vattuid = infoThongtinvattu.Id;
                string mavattu = infoThongtinvattu.Mavattu;
                string invoiceno = cbinvoiceno.Text;
                string donvi = infoThongtinvattu.Donvi;
                string tennguoithaotac = userInfo.Hoten;
                string manhanvien = userInfo.Manhanvien;
                string bophan = userInfo.Bophan;
                string loaithaotac = "Nhập";
                string thoigian = txtNgaygionhap.Text;
                float soluongnhap = (float)Convert.ToDouble(txtSoluongnhap.Text.ToString().Replace('.', ','));
                string nhapvaokho = cbNhapvaokho.Text;
                //Tính toán sô lượng hàng nhập
                float tonkhotruocnhapVTN = (float)Convert.ToDouble(infoThongtinvattu.Tonkhovtn.ToString());
                float tonkhotruocnhapDRG = (float)Convert.ToDouble(infoThongtinvattu.Tonkhodrg.ToString());
                float tonkhosaunhapVTN = tonkhotruocnhapVTN;
                float tonkhosaunhapDRG = tonkhotruocnhapDRG;
                if (nhapvaokho == "NHẬP LẠI")
                {
                    tonkhosaunhapVTN += soluongnhap; //Tăng tồn kho sau nhập vào VTN
                }
                string trangthai = "CHỜ NGHIỆM THU";
                bool success1 = LichsunhapxuatDAO.Instance.Nhap(vattuid, mavattu, invoiceno, mavattu, donvi, tennguoithaotac,
                 manhanvien, bophan, loaithaotac, thoigian,
                 soluongnhap.ToString().Replace(',', '.'), nhapvaokho, tonkhotruocnhapVTN.ToString().Replace(',', '.'), tonkhosaunhapVTN.ToString().Replace(',', '.'),
                tonkhotruocnhapDRG.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'), trangthai);
                bool success2 = ThongtinvattuDAO.Instance.UpdateTonkho(vattuid, tonkhosaunhapVTN.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'));
                if (success1 && success2)
                {
                    allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
                    cbinvoiceno.Text = "";
                    txtDiengiai.Text = "";
                    txtDonvitinh.Text = "";
                    txtKgtrenbao.Text = "";
                    txtTonkhovtn.Text = "";
                    txttonkhodrg.Text = "";
                    txtSoluongnhap.Text = "";
                    txtdonvi2.Text = "_";
                    cbmavattu.Text = "";
                    cbmavattu.Focus();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }
            else
            {
                if (
                string.IsNullOrWhiteSpace(cbinvoiceno.Text) ||
                string.IsNullOrWhiteSpace(cbmavattu.Text) ||
                string.IsNullOrWhiteSpace(txtSoluongnhap.Text) ||
                string.IsNullOrWhiteSpace(cbNhapvaokho.Text)
                )
                {
                    MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumeric(txtSoluongnhap.Text))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float checkslinvoice = (float)Convert.ToDouble(txtSoluongtrongInovice.Text);
                int vattuid = infoThongtinvattu.Id;
                string mavattu = infoThongtinvattu.Mavattu;
                string invoiceno = cbinvoiceno.Text;
                string partno = infoThongtinvattu.Mavattu;
                string donvi = infoThongtinvattu.Donvi;
                string tennguoithaotac = userInfo.Hoten;
                string manhanvien = userInfo.Manhanvien;
                string bophan = userInfo.Bophan;
                string loaithaotac = "Nhập";
                string thoigian = txtNgaygionhap.Text;
                float soluongnhap = (float)Convert.ToDouble(txtSoluongnhap.Text.ToString().Replace('.', ','));
                string nhapvaokho = cbNhapvaokho.Text;
                //Tính toán sô lượng hàng nhập
                float tonkhotruocnhapVTN = (float)Convert.ToDouble(infoThongtinvattu.Tonkhovtn.ToString());
                float tonkhotruocnhapDRG = (float)Convert.ToDouble(infoThongtinvattu.Tonkhodrg.ToString());
                float tonkhosaunhapVTN = tonkhotruocnhapVTN;
                float tonkhosaunhapDRG = tonkhotruocnhapDRG;
                string trangthai = "CHỜ NGHIỆM THU";

                if(soluongnhap > checkconlaiinvoice)
                {
                    MessageBox.Show("Số lượng nhập lớn hơn số lượng invoice!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nhapvaokho == "VTN")
                {
                    tonkhosaunhapVTN += soluongnhap; //Tăng tồn kho sau nhập vào VTN
                    bool success1 = LichsunhapxuatDAO.Instance.Nhap(vattuid, mavattu, invoiceno, mavattu, donvi, tennguoithaotac,
                    manhanvien, bophan, loaithaotac, thoigian,
                    soluongnhap.ToString().Replace(',', '.'), nhapvaokho, tonkhotruocnhapVTN.ToString().Replace(',', '.'), tonkhosaunhapVTN.ToString().Replace(',', '.'),
                    tonkhotruocnhapDRG.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'), trangthai);

                    bool success2 = ThongtinvattuDAO.Instance.UpdateTonkho(vattuid, tonkhosaunhapVTN.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'));
                    bool success3 = InvoiceinfoDAO.Instance.UpdateSoluongDaveSauNhap(invoiceinfoid, soluongnhap);
                    if (success1 && success2 && success3)
                    {
                        allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
                        txtSoluongtrongInovice.Text = "";

                        cbinvoiceno.Text = "";
                        txtDiengiai.Text = "";
                        txtDonvitinh.Text = "";
                        txtKgtrenbao.Text = "";
                        txtTonkhovtn.Text = "";
                        txttonkhodrg.Text = "";
                        txtSoluongnhap.Text = "";
                        txtdonvi2.Text = "_";
                        cbmavattu.Text = "";
                        cbmavattu.Focus();
                        FormThanhcong fthanhcong = new FormThanhcong();
                        fthanhcong.ShowDialog();
                    }
                }
                else if (nhapvaokho == "DRAGON")
                {
                    tonkhosaunhapDRG += soluongnhap; //Tăng tồn kho sau nhập vào DRAGON
                    trangthai = "NHẬP HOÀN THÀNH";
                    int lichsunhapid = LichsunhapxuatDAO.Instance.NhapReturnId(vattuid, mavattu, invoiceno, mavattu, donvi, tennguoithaotac,
                    manhanvien, bophan, loaithaotac, thoigian,
                    soluongnhap.ToString().Replace(',', '.'), nhapvaokho, tonkhotruocnhapVTN.ToString().Replace(',', '.'), tonkhosaunhapVTN.ToString().Replace(',', '.'),
                    tonkhotruocnhapDRG.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'), trangthai);

                    bool created = LichsunhapchitietDAO.Instance.Create(lichsunhapid, mavattu, "DRAGON", invoiceno, partno, "", soluongnhap.ToString().Replace(',', '.'), donvi, thoigian, "", userInfo.Hoten, userInfo.Manhanvien, userInfo.Bophan);
                    bool success2 = ThongtinvattuDAO.Instance.UpdateTonkho(vattuid, tonkhosaunhapVTN.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'));
                    bool success3 = InvoiceinfoDAO.Instance.UpdateSoluongDaveSauNhap(invoiceinfoid, soluongnhap);
                    if (created && success2 && success3)
                    {
                        allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
                        txtSoluongtrongInovice.Text = "";

                        cbinvoiceno.Text = "";
                        txtDiengiai.Text = "";
                        txtDonvitinh.Text = "";
                        txtKgtrenbao.Text = "";
                        txtTonkhovtn.Text = "";
                        txttonkhodrg.Text = "";
                        txtSoluongnhap.Text = "";
                        txtdonvi2.Text = "_";
                        cbmavattu.Text = "";
                        cbmavattu.Focus();
                        FormThanhcong fthanhcong = new FormThanhcong();
                        fthanhcong.ShowDialog();
                    }
                }
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            txtDiengiai.Text = "";
            txtDonvitinh.Text = "";
            txtKgtrenbao.Text = "";
            txtTonkhovtn.Text = "";
            txttonkhodrg.Text = "";
            txtSoluongnhap.Text = "";
            txtdonvi2.Text = "_";
            cbmavattu.Text = "";
            cbmavattu.Focus();
        }

        private void txtSoluongnhap_Enter(object sender, EventArgs e)
        {
            string userInput = cbmavattu.Text;
            if (allThongtinvattu.Where(x => x.Mavattu == userInput).Count() == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin vật tư liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiengiai.Text = "";
                txtDonvitinh.Text = "";
                txtKgtrenbao.Text = "";
                txtTonkhovtn.Text = "";
                txttonkhodrg.Text = "";
                txtdonvi2.Text = "_";
                cbmavattu.Focus();
            }
        }

        private void cbNhapvaokho_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nhapvaokho = cbNhapvaokho.Text;
            if (nhapvaokho == "NHẬP LẠI")
            {
                cbinvoiceno.Enabled = false;
                txtSoluongtrongInovice.Text = "";
                txtSoluongnhap.Focus();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cbinvoiceno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedInvoicenumber = cbinvoiceno.SelectedItem.ToString();
            // Thực hiện truy vấn SQL để lấy invoiceinfo.dave dựa trên số hóa đơn đã chọn
            string query = "SELECT invoiceinfo.qty,invoiceinfo.dave,invoiceinfo.id,invoice.id as invoiceid FROM dbo.invoice JOIN dbo.invoiceinfo ON invoice.id = invoiceinfo.invoiceid JOIN dbo.poinfo ON invoiceinfo.itemid = poinfo.id WHERE invoice.invoicenumber  = '" + selectedInvoicenumber + "' AND invoice.trangthai != 'Done' AND poinfo.description = '"+ cbmavattu.Text +"'   ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            // Kiểm tra xem kết quả truy vấn có dữ liệu không
            if (result.Rows.Count > 0)
            {
                // Lấy giá trị invoiceinfo.dave từ kết quả truy vấn và hiển thị nó
                string sltronginv = result.Rows[0]["qty"].ToString();
                string sltronginvdave = result.Rows[0]["dave"].ToString();
                invoiceid = Convert.ToInt32(result.Rows[0]["invoiceid"].ToString());
                invoiceinfoid = Convert.ToInt32(result.Rows[0]["id"].ToString());

                checkconlaiinvoice = (float)Convert.ToDouble(sltronginv) - (float)Convert.ToDouble(sltronginvdave);
                txtSoluongtrongInovice.Text = checkconlaiinvoice.ToString();
            }
            else
            {
                // Xử lý trường hợp không tìm thấy dữ liệu
            }
        }

    }
}
