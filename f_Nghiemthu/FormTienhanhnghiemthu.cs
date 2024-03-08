using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Vietinak_Kho.DTO;
using Vietinak_Kho.DAO;
using System.Text.RegularExpressions;
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_Nghiemthu
{
    public partial class FormTienhanhnghiemthu : Form
    {
        private User userInfo;
        private int lichsunhapid;
        private string mavattu;
        private string ngaygionhap;
        private string donvi;
        private float soluongnhap;
        private string vitri;
        public FormTienhanhnghiemthu(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        public void LoadData(Lichsunhapxuat lichsu)
        {
            donvi = lichsu.Donvi;
            lichsunhapid = lichsu.Id;
            mavattu = lichsu.Mavattu;
            ngaygionhap = lichsu.Thoigian;
            soluongnhap = lichsu.Soluongnhap;
            vitri = lichsu.Nhapvaokho;
            txtMavattu.Text = lichsu.Mavattu;
            txtSoluongnhap.Text = lichsu.Soluongnhap + " " + lichsu.Donvi;
            txtNhapvaokho.Text = lichsu.Nhapvaokho;
        }
        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
    
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //Kiểm tra số lượng
            float tongSoLuong = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongSoLuong += (float)Convert.ToDouble(row.Cells["soluong"].Value.ToString().Replace('.', ','));
                }
            }
            if (tongSoLuong != soluongnhap)
            {
                MessageBox.Show("Tổng số lượng nghiệm thu (" + tongSoLuong + ") và số lượng nhập (" + soluongnhap + ") không trùng! Kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool allRowsValid = true; // Biến cờ để theo dõi xem tất cả các dòng đã hợp lệ hay không
                bool anyRowEmpty = false; // Biến cờ để kiểm tra xem có dòng nào bị trống hay không
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // Kiểm tra nếu dòng không phải là dòng trống hoặc dòng header
                    if (!row.IsNewRow)
                    {
                        string soluong = Convert.ToString(row.Cells["soluong"].Value);
                        string lotno = Convert.ToString(row.Cells["lotno"].Value);
                        // Kiểm tra xem ô "soluong" hoặc "lotno" có giá trị null hoặc rỗng hay không
                        if (string.IsNullOrWhiteSpace(soluong) || string.IsNullOrWhiteSpace(lotno))
                        {
                            anyRowEmpty = true; // Nếu có, đặt biến cờ thành true
                            break; // Dừng vòng lặp vì không cần kiểm tra các dòng nữa
                        }
                        // Kiểm tra xem ô "soluong" có chứa số hay không
                        if (!IsNumeric(soluong))
                        {
                            allRowsValid = false; // Nếu không, đặt biến cờ thành false
                            break; // Dừng vòng lặp vì không cần kiểm tra các dòng nữa
                        }
                        bool checktrung = LichsunhapchitietDAO.Instance.Checktrung(mavattu, lotno);
                        if (!checktrung)
                        {
                            MessageBox.Show("Lotno của mavattu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            allRowsValid = false; // Đặt biến cờ thành false khi có lỗi
                            break; // Dừng vòng lặp vì không cần kiểm tra các dòng nữa
                        }
                    }
                }
                // Nếu có dòng nào đó bị trống, hiển thị thông báo
                if (anyRowEmpty)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cho tất cả các dòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            string lotno = Convert.ToString(row.Cells["lotno"].Value);
                            string soluong = Convert.ToString(row.Cells["soluong"].Value);
                            string ngaygionghiemthu = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                            // Thực hiện tạo mới dữ liệu trong cơ sở dữ liệu
                            bool created = LichsunhapchitietDAO.Instance.Create(lichsunhapid, mavattu,vitri, lotno, soluong, donvi, ngaygionhap, ngaygionghiemthu, userInfo.Hoten, userInfo.Manhanvien, userInfo.Bophan);
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
                        bool result = LichsunhapxuatDAO.Instance.UpdateXacNhanNghiemThu(lichsunhapid);
                        if (result)
                        {
                            this.Close();
                            FormThanhcong fthanhcong = new FormThanhcong();
                            fthanhcong.ShowDialog();
                        }
                    }
                    // Sau khi kiểm tra và cập nhật dữ liệu, tiến hành cập nhật trạng thái
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng thực tế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["stt"].Value = (i + 1).ToString();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
