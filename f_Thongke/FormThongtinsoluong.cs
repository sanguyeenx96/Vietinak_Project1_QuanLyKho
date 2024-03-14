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

namespace Vietinak_Kho.f_Thongke
{
    public partial class FormThongtinsoluong : Form
    {
        private string mavattu;
        private List<Lichsunhapchitiet> listallttvt;
        public FormThongtinsoluong(string mavattu)
        {
            InitializeComponent();
            this.mavattu = mavattu;
        }

        private void FormThongtinsoluong_Load(object sender, EventArgs e)
        {
            var ttvtList = ThongtinvattuDAO.Instance.LoadThongtinvattu(mavattu);
            var ttchitietList = DanhsachnguyenvatlieuDAO.Instance.LoadThongtinvattu(mavattu);
            listallttvt = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhap(mavattu);
            listallttvt = listallttvt.Where(x => x.Conlai != 0).ToList();
            LoaddatatoDGV(listallttvt);
        }

        private void LoaddatatoDGV(List<Lichsunhapchitiet> ds)
        {
            dgvlotno.DataSource = ds;
            dgvlotno.Columns["Id"].Visible = false;
            dgvlotno.Columns["Lichsunhapid"].Visible = false;
            dgvlotno.Columns["Vitri"].HeaderText = "Vị trí";
            dgvlotno.Columns["Invoiceno"].HeaderText = "Invoice No.";
            dgvlotno.Columns["Partno"].HeaderText = "Part No.";
            dgvlotno.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgvlotno.Columns["Lotno"].HeaderText = "Lot No.";
            dgvlotno.Columns["Soluong"].HeaderText = "Số lượng nghiệm thu";
            dgvlotno.Columns["Conlai"].HeaderText = "Số lượng còn lại";
            dgvlotno.Columns["Donvi"].HeaderText = "Đơn vị";
            dgvlotno.Columns["Hansudung"].HeaderText = "Hạn sử dụng";
            dgvlotno.Columns["Ngaygionhap"].HeaderText = "Ngày giờ nhập";
            dgvlotno.Columns["Ngaygionghiemthu"].HeaderText = "Ngày giờ nghiệm thu";
            dgvlotno.Columns["Ngaygioqccheck"].HeaderText = "Ngày giờ QC Check";
            dgvlotno.Columns["Tennguoithaotacnghiemthu"].HeaderText = "Người thao tác nghiệm thu";
            dgvlotno.Columns["Manhanviennghiemthu"].HeaderText = "Mã nhân viên nghiệm thu";
            dgvlotno.Columns["Bophannghiemthu"].HeaderText = "Bộ phận nghiệm thu";
            dgvlotno.Columns["Tennguoithaotacqccheck"].HeaderText = "Người thao tác QC Check";
            dgvlotno.Columns["Manhanvienqccheck"].HeaderText = "Mã nhân viên QC Check";
            dgvlotno.Columns["Bophanqccheck"].HeaderText = "Bộ phận QC Check";
            dgvlotno.CellFormatting += dgvlotno_CellFormatting;
        }

        private void dgvlotno_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cellValue = dgvlotno.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    if (dgvlotno.Columns[e.ColumnIndex].Name == "Vitri")
                    {
                        string vitri = e.Value.ToString();
                        if (vitri == "VTN")
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                        if (vitri == "DRAGON")
                        {
                            e.CellStyle.BackColor = Color.LightCoral;
                        }
                    }
                }
            }

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cellValue = dgvlotno.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    if (dgvlotno.Columns[e.ColumnIndex].Name == "Hansudung")
                    {
                        // Chuyển đổi giá trị của ô sang kiểu DateTime
                        DateTime dateValue;
                        if (DateTime.TryParseExact(cellValue.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                        {
                            // Tính toán số ngày chênh lệch giữa ngày hiện tại và ngày trong ô
                            TimeSpan difference =  dateValue - DateTime.Now;
                            int daysDifference = (int)difference.TotalDays;

                            // Nếu số ngày chênh lệch nhỏ hơn 30, tô màu đỏ cho ô
                            if (daysDifference < 30)
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cellValue = dgvlotno.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    if (dgvlotno.Columns[e.ColumnIndex].Name == "Conlai")
                    {
                        int conlaiValue = Convert.ToInt32(e.Value);
                        if (conlaiValue != 0)
                        {
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.White;
                        }
                    }
                }
            }

            // Kiểm tra nếu cột hiện tại là cột "Conlai"
            if (dgvlotno.Columns[e.ColumnIndex].Name == "Conlai" && e.RowIndex >= 0)
            {
                // Lấy giá trị của ô cột "Conlai"
                int conlaiValue = Convert.ToInt32(e.Value);

                // Nếu giá trị là 0, vô hiệu hóa dòng hiện tại
                if (conlaiValue == 0)
                {
                    dgvlotno.Rows[e.RowIndex].ReadOnly = true; // Vô hiệu hóa chỉnh sửa
                    dgvlotno.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray; // Đổi màu nền
                }
                else
                {
                    dgvlotno.Rows[e.RowIndex].ReadOnly = false; // Cho phép chỉnh sửa
                }
            }
        }

        private void checkBoxHienthixuathet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienthixuathet.Checked)
            {
                listallttvt = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhap(mavattu);
                LoaddatatoDGV(listallttvt);
            }
            else
            {
                listallttvt = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhap(mavattu);
                listallttvt = listallttvt.Where(x => x.Conlai != 0).ToList();
                LoaddatatoDGV(listallttvt);
            }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoc.Text.Trim();
            List<Lichsunhapchitiet> filteredls;
            filteredls = listallttvt.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredls = filteredls.Where(x =>
                    x.Mavattu.ToLower().Contains(searchText.ToLower()) ||
                    x.Vitri.ToLower().Contains(searchText.ToLower()) ||
                    x.Invoiceno.ToLower().Contains(searchText.ToLower()) ||
                    x.Partno.ToLower().Contains(searchText.ToLower()) ||
                    x.Lotno.ToLower().Contains(searchText.ToLower()) ||
                    x.Soluong.ToString().Contains(searchText.ToLower()) ||
                    x.Conlai.ToString().Contains(searchText.ToLower()) ||
                    x.Donvi.ToLower().Contains(searchText.ToLower()) ||
                    x.Hansudung.ToLower().Contains(searchText.ToLower()) ||
                    x.Ngaygionhap.ToLower().Contains(searchText.ToLower()) ||
                    x.Ngaygionghiemthu.ToLower().Contains(searchText.ToLower()) ||
                    x.Ngaygioqccheck.ToLower().Contains(searchText.ToLower()) ||
                    x.Tennguoithaotacnghiemthu.ToLower().Contains(searchText.ToLower()) ||
                    x.Tennguoithaotacqccheck.ToLower().Contains(searchText.ToLower()) ||
                    x.Manhanviennghiemthu.ToLower().Contains(searchText.ToLower()) ||
                    x.Manhanvienqccheck.ToLower().Contains(searchText.ToLower()) ||
                    x.Bophannghiemthu.ToLower().Contains(searchText.ToLower()) ||
                    x.Bophanqccheck.ToLower().Contains(searchText.ToLower())                
                ).ToList();
            }
            // Update the DataGridView with the filtered 
            LoaddatatoDGV(filteredls);
        }

      
    }
}
