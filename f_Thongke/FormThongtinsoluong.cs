using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FormThongtinsoluong(string mavattu)
        {
            InitializeComponent();
            this.mavattu = mavattu;
        }

        private void FormThongtinsoluong_Load(object sender, EventArgs e)
        {
            var ttvtList = ThongtinvattuDAO.Instance.LoadThongtinvattu(mavattu);
            var ttchitietList = DanhsachnguyenvatlieuDAO.Instance.LoadThongtinvattu(mavattu);
            var ttchitietlotnoList = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhap(mavattu);

            if (ttvtList.Count > 0 && ttchitietList.Count > 0)
            {              
                dgvlotno.DataSource = ttchitietlotnoList;
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
            else
            {
                // Xử lý trường hợp danh sách trả về là rỗng
                MessageBox.Show("Không tìm thấy thông tin vật tư có mã: " + mavattu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvlotno_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột hiện tại là cột "Conlai"
            if (dgvlotno.Columns[e.ColumnIndex].Name == "Conlai" && e.RowIndex >= 0)
            {
                // Lấy giá trị của ô cột "Conlai"
                int conlaiValue = Convert.ToInt32(e.Value);

                // Nếu giá trị là 0, vô hiệu hóa dòng hiện tại620
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
    }
}
