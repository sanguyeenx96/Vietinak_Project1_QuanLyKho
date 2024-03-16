using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_Qccheck
{
    public partial class FormTienhanhqccheck : Form
    {
        public event EventHandler<DialogClosedEventArgs> DialogClosed;

        private User userInfo;
        private int lichsunhapid;
        private string tennguoithaotac;
        private string manhanvien;
        private string bophan;

        private float soluongnhap;
        private float soluongchuanghiemthu;
        private float soluongdanghiemthu;
        public FormTienhanhqccheck(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        public void LoadData(Lichsunhapxuat lichsu)
        {
            lichsunhapid = lichsu.Id;
            tennguoithaotac = userInfo.Hoten;
            manhanvien = userInfo.Manhanvien;
            bophan = userInfo.Bophan;

            soluongnhap = (float)Convert.ToDouble(lichsu.Soluongnhap.ToString());
            soluongdanghiemthu = (float)Convert.ToDouble(lichsu.Soluongdanghiemthu.ToString());
            soluongchuanghiemthu = soluongnhap - soluongdanghiemthu;
        }
        private void FormTienhanhqccheck_Load(object sender, EventArgs e)
        {
            var danhsach = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunghiemthu(lichsunhapid);
            dgv.DataSource = danhsach;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Lichsunhapid"].Visible = false;
            dgv.Columns["Ngaygioqccheck"].Visible = false;
            dgv.Columns["Tennguoithaotacqccheck"].Visible = false;
            dgv.Columns["Manhanvienqccheck"].Visible = false;
            dgv.Columns["Bophanqccheck"].Visible = false;

            dgv.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgv.Columns["Invoiceno"].HeaderText = "Invoice No.";
            dgv.Columns["Partno"].HeaderText = "Part No,";
            dgv.Columns["Lotno"].HeaderText = "Lot No.";
            dgv.Columns["Soluong"].HeaderText = "Số lượng";
            dgv.Columns["Donvi"].HeaderText = "Đơn vị";
            dgv.Columns["Hansudung"].HeaderText = "Hạn sử dụng";
            dgv.Columns["Ngaygionhap"].HeaderText = "Ngày giờ nhập";
            dgv.Columns["Ngaygionghiemthu"].HeaderText = "Ngày giờ nghiệm thu";
            dgv.Columns["Tennguoithaotacnghiemthu"].HeaderText = "Người thao tác nghiệm thu";
            dgv.Columns["Manhanviennghiemthu"].HeaderText = "Mã nhân viên nghiệm thu";
            dgv.Columns["Bophannghiemthu"].HeaderText = "Bộ phận nghiệm thu";
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name != "Hansudung")
                {
                    column.ReadOnly = true;
                }
            }
            dgv.CellEndEdit += dgv_CellEndEdit;

        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            //{
            //    var cellValue = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    if (cellValue != null)
            //    {
            //        if (dgv.Columns[e.ColumnIndex].Name == "Hansudung")
            //        {
            //            if (string.IsNullOrWhiteSpace(cellValue.ToString()))
            //            {
            //                // Nếu ô trống và có màu vàng, không làm gì cả
            //                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
            //            }
            //            else
            //            {
            //                // Nếu ô không trống, chuyển màu thành xanh
            //                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
            //            }
            //        }
            //    }
            //}
        }
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cellValue = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    if (dgv.Columns[e.ColumnIndex].Name == "Hansudung")
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }
        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsValidDateFormat(string input)
        {
            // Mảng các định dạng ngày tháng có thể chấp nhận
            string[] formats = { "yyyy/MM/dd" };

            // Kiểm tra xem chuỗi đầu vào có thể được chuyển đổi thành ngày tháng không
            DateTime result;
            return DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            bool allRowsValid = true; // Biến cờ để theo dõi xem tất cả các dòng đã hợp lệ hay không
            bool anyRowEmpty = false; // Biến cờ để kiểm tra xem có dòng nào bị trống hay không

            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng trống hoặc dòng header
                if (!row.IsNewRow)
                {
                    string hansudung = Convert.ToString(row.Cells["hansudung"].Value);
                    if (string.IsNullOrWhiteSpace(hansudung))
                    {
                        anyRowEmpty = true; // Nếu có, đặt biến cờ thành true
                        break; // Dừng vòng lặp vì không cần kiểm tra các dòng nữa
                    }
                    // Kiểm tra xem ô "soluong" có chứa số hay không
                    if (!IsValidDateFormat(hansudung))
                    {
                        allRowsValid = false; // Nếu không, đặt biến cờ thành false
                        break; // Dừng vòng lặp vì không cần kiểm tra các dòng nữa
                    }
                }
            }
            // Nếu có dòng nào đó bị trống, hiển thị thông báo
            if (anyRowEmpty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hạn sử dụng cho tất cả các dòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Nếu tất cả các dòng đều hợp lệ, tiến hành cập nhật trạng thái
            else if (allRowsValid)
            {
                bool allRowsSavedSuccessfully = true; // Biến cờ để theo dõi xem tất cả các dòng đã được lưu thành công hay không
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // Thực hiện cập nhật trạng thái
                    if (!row.IsNewRow)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                        string hansudung = Convert.ToString(row.Cells["hansudung"].Value);
                        string ngaygioqccheck = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

                        // Thực hiện tạo mới dữ liệu trong cơ sở dữ liệu
                        bool created = LichsunhapchitietDAO.Instance.UpdateHSD(id, hansudung, ngaygioqccheck,tennguoithaotac,manhanvien,bophan);
                        // Nếu không thể tạo mới một dòng nào đó, đặt biến cờ thành false
                        if (!created)
                        {
                            allRowsSavedSuccessfully = false;
                            break; // Dừng vòng lặp vì không cần thêm dữ liệu nữa
                        }
                    }
                }
                // Nếu tất cả các dòng đã được lưu thành công, hiển thị FormThanhcong
                if (allRowsSavedSuccessfully)
                {
                    if(soluongchuanghiemthu != 0)
                    {
                        DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                        this.Close();
                        FormThanhcong fthanhcong = new FormThanhcong();
                        fthanhcong.ShowDialog();
                    }
                    else
                    {
                        bool result = LichsunhapxuatDAO.Instance.UpdateXacNhanQcCheck(lichsunhapid);
                        if (result)
                        {
                            DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                            this.Close();
                            FormThanhcong fthanhcong = new FormThanhcong();
                            fthanhcong.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Định dạng ngày tháng không hợp lệ. Vui lòng nhập theo định dạng yyyy/MM/dd (Ví dụ: 2024/07/28)" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
