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
            }
        }

        private void cbmavattu_Leave(object sender, EventArgs e)
        {
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(txtinvoiceno.Text) ||
                string.IsNullOrWhiteSpace(txtpartno.Text) ||
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
            int vattuid = infoThongtinvattu.Id;
            string mavattu = infoThongtinvattu.Mavattu;
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
            if (nhapvaokho == "VTN")
            {
                tonkhosaunhapVTN += soluongnhap; //Tăng tồn kho sau nhập vào VTN
            }
            else if (nhapvaokho == "DRAGON")
            {
                tonkhosaunhapDRG += soluongnhap; //Tăng tồn kho sau nhập vào DRAGON
            }
            else if (nhapvaokho == "NHẬP LẠI")
            {
                tonkhosaunhapDRG -= soluongnhap; //Giảm tồn kho DRAGON
                tonkhosaunhapVTN += soluongnhap; //Tăng tồn kho VTN
            }
            string trangthai = "CHỜ NGHIỆM THU";

            bool success1 = LichsunhapxuatDAO.Instance.Nhap(vattuid, mavattu, donvi, tennguoithaotac,
             manhanvien, bophan, loaithaotac, thoigian,
             soluongnhap.ToString().Replace(',', '.'), nhapvaokho, tonkhotruocnhapVTN.ToString().Replace(',', '.'), tonkhosaunhapVTN.ToString().Replace(',', '.'),
            tonkhotruocnhapDRG.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'), trangthai);

            bool success2 = ThongtinvattuDAO.Instance.UpdateTonkho(vattuid, tonkhosaunhapVTN.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'));
            if (success1 && success2)
            {
                allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
                txtinvoiceno.Text = "";
                txtpartno.Text = "";
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

  
    }
}
