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

namespace Vietinak_Kho.f_Thongke
{
    public partial class FormLichsunhapxuat : Form
    {
        private string mavattu;
        public FormLichsunhapxuat(string mavattu)
        {
            InitializeComponent();
            this.mavattu = mavattu;
        }

        private void FormLichsunhapxuat_Load(object sender, EventArgs e)
        {
            var lichsunhapxuat = LichsunhapxuatDAO.Instance.LoadTableList_Lichsunhapxuat(mavattu);
            var ls = lichsunhapxuat.Where(x => (x.Trangthai == "NHẬP HOÀN THÀNH" || x.Trangthai == "XUẤT HOÀN THÀNH")).ToList();
            dgv.DataSource = ls;

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Vattuid"].Visible = false;

            dgv.Columns["Loaithaotac"].DisplayIndex = 0;
            dgv.Columns["Trangthai"].DisplayIndex = 1;
            dgv.Columns["Mavattu"].DisplayIndex = 2;
            dgv.Columns["Invoiceno"].DisplayIndex = 3;
            dgv.Columns["Partno"].DisplayIndex = 4;
            dgv.Columns["Soluongnhap"].DisplayIndex = 5;
            dgv.Columns["Donvi"].DisplayIndex = 6;
            dgv.Columns["Nhapvaokho"].DisplayIndex = 7;
            dgv.Columns["TonkhotruocnhapVTN"].DisplayIndex = 8;
            dgv.Columns["TonkhosaunhapVTN"].DisplayIndex = 9;
            dgv.Columns["TonkhotruocnhapDRG"].DisplayIndex = 10;
            dgv.Columns["TonkhosaunhapDRG"].DisplayIndex = 11;
            dgv.Columns["Tennguoithaotac"].DisplayIndex = 12;
            dgv.Columns["Manhanvien"].DisplayIndex = 13;
            dgv.Columns["Bophan"].DisplayIndex = 14;
            dgv.Columns["Thoigian"].DisplayIndex = 15;

            dgv.Columns["Trangthai"].HeaderText = "Trạng thái";
            dgv.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgv.Columns["Invoiceno"].HeaderText = "Invoice No.";
            dgv.Columns["Partno"].HeaderText = "Part No.";
            dgv.Columns["Donvi"].HeaderText = "Đơn vị";
            dgv.Columns["Tennguoithaotac"].HeaderText = "Người thao tác";
            dgv.Columns["Manhanvien"].HeaderText = "Mã nhân viên";
            dgv.Columns["Bophan"].HeaderText = "Bộ phận";
            dgv.Columns["Thoigian"].HeaderText = "Thời gian nhập";
            dgv.Columns["Soluongnhap"].HeaderText = "Số lượng nhập";
            dgv.Columns["Nhapvaokho"].HeaderText = "Nhập vào kho";
            dgv.Columns["TonkhotruocnhapVTN"].HeaderText = "Tồn kho trước nhập VTN";
            dgv.Columns["TonkhosaunhapVTN"].HeaderText = "Tồn kho sau nhập VTN";
            dgv.Columns["TonkhotruocnhapDRG"].HeaderText = "Tồn kho trước nhập DRG";
            dgv.Columns["TonkhosaunhapDRG"].HeaderText = "Tồn kho sau nhập DRG";
            dgv.Columns["Soluongxuat"].HeaderText = "Số lượng xuất";
            dgv.Columns["Mucdichxuat"].HeaderText = "Mục đích xuất";
            dgv.Columns["TonkhotruocxuatVTN"].HeaderText = "Tồn kho trước xuất VTN";
            dgv.Columns["TonkhosauxuatVTN"].HeaderText = "Tồn kho sau xuất VTN";
            dgv.Columns["TonkhotruocxuatDRG"].HeaderText = "Tồn kho trước xuất DRG";
            dgv.Columns["TonkhosauxuatDRG"].HeaderText = "Tồn kho sau xuất DRG";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
               

                object trangThaiValue = dgv.Rows[e.RowIndex].Cells["Trangthai"].Value;
                string mavattu = selectedRow.Cells["Mavattu"].Value.ToString();
                string nhapvaokho = selectedRow.Cells["Nhapvaokho"].Value.ToString();
                string soluongnhap = selectedRow.Cells["Soluongnhap"].Value.ToString();
                string donvi = selectedRow.Cells["Donvi"].Value.ToString();
                string mucdichxuat = selectedRow.Cells["Mucdichxuat"].Value.ToString();
                string soluongxuat = selectedRow.Cells["Soluongxuat"].Value.ToString();


                string idValue = selectedRow.Cells["Id"].Value.ToString();
                if (trangThaiValue != null && trangThaiValue.ToString() == "CHỜ QC CHECK")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xem chi tiết nghiệm thu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        FormLichsunghiemthuxemnhanh fls = new FormLichsunghiemthuxemnhanh(Convert.ToInt32(idValue), mavattu, nhapvaokho, soluongnhap, donvi);
                        fls.ShowDialog();
                    }
                }
                if (trangThaiValue != null && trangThaiValue.ToString() == "NHẬP HOÀN THÀNH")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xem chi tiết nghiệm thu & QC Check không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        FormLichsunghiemthuxemnhanh fls = new FormLichsunghiemthuxemnhanh(Convert.ToInt32(idValue), mavattu, nhapvaokho, soluongnhap, donvi);
                        fls.ShowDialog();
                    }
                }
                if (trangThaiValue != null && trangThaiValue.ToString() == "NHẬP LẠI HOÀN THÀNH")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xem chi tiết nghiệm thu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        FormLichsunhaplaixemnhanh fls = new FormLichsunhaplaixemnhanh(Convert.ToInt32(idValue), mavattu, nhapvaokho, soluongnhap, donvi);
                        fls.ShowDialog();
                    }
                }
                if (trangThaiValue != null && trangThaiValue.ToString() == "XUẤT HOÀN THÀNH")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xem chi tiết lịch sử xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        FormLichsuxuatchitiet flsx = new FormLichsuxuatchitiet(Convert.ToInt32(idValue), mavattu, mucdichxuat, soluongxuat, donvi);
                        flsx.ShowDialog();
                    }
                }
            }
          
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!dgv.Rows[e.RowIndex].IsNewRow && dgv.Rows[e.RowIndex].Cells["Trangthai"].Value.ToString() == "XUẤT HOÀN THÀNH")
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Goldenrod;
            }
            if (!dgv.Rows[e.RowIndex].IsNewRow && dgv.Rows[e.RowIndex].Cells["Trangthai"].Value.ToString() == "NHẬP HOÀN THÀNH")
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }       
        }
    }
}
