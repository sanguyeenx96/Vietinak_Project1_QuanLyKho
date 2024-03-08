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
using Vietinak_Kho.f_Thongke;

namespace Vietinak_Kho.f_Khohang
{
    public partial class FormLichsunhap : Form
    {
        private List<Lichsunhapxuat> allLichsunhap;

        public FormLichsunhap()
        {
            InitializeComponent();
        }

        private void FormLichsunhap_Load(object sender, EventArgs e)
        {
            groupBoxLichsunhap.Text = "Lịch sử nhập trong ngày hôm nay " + DateTime.Now.ToString("yyyy/MM/dd");
            allLichsunhap = LichsunhapxuatDAO.Instance.LoadTableList_Lichsunhaphomnay();
            UpdateDataGridView(allLichsunhap);
            dgvLichsunhap.RowPrePaint += dgvLichsunhap_RowPrePaint;
        }

        private void UpdateDataGridView(List<Lichsunhapxuat> Lichsunhap)
        {
            dgvLichsunhap.DataSource = Lichsunhap;

            txtTongso.Text = Lichsunhap.Count.ToString();

            dgvLichsunhap.Columns["Id"].Visible = false;
            dgvLichsunhap.Columns["Vattuid"].Visible = false;
            dgvLichsunhap.Columns["Loaithaotac"].Visible = false;
            dgvLichsunhap.Columns["Soluongxuat"].Visible = false;
            dgvLichsunhap.Columns["Mucdichxuat"].Visible = false;
            dgvLichsunhap.Columns["TonkhotruocxuatVTN"].Visible = false;
            dgvLichsunhap.Columns["TonkhosauxuatVTN"].Visible = false;
            dgvLichsunhap.Columns["TonkhotruocxuatDRG"].Visible = false;
            dgvLichsunhap.Columns["TonkhosauxuatDRG"].Visible = false;

            dgvLichsunhap.Columns["Trangthai"].DisplayIndex = 0;
            dgvLichsunhap.Columns["Mavattu"].DisplayIndex = 1;
            dgvLichsunhap.Columns["Soluongnhap"].DisplayIndex = 2;
            dgvLichsunhap.Columns["Donvi"].DisplayIndex = 3;
            dgvLichsunhap.Columns["Nhapvaokho"].DisplayIndex = 4;
            dgvLichsunhap.Columns["TonkhotruocnhapVTN"].DisplayIndex = 5;
            dgvLichsunhap.Columns["TonkhosaunhapVTN"].DisplayIndex = 6;
            dgvLichsunhap.Columns["TonkhotruocnhapDRG"].DisplayIndex = 7;
            dgvLichsunhap.Columns["TonkhosaunhapDRG"].DisplayIndex = 8;
            dgvLichsunhap.Columns["Tennguoithaotac"].DisplayIndex = 9;
            dgvLichsunhap.Columns["Manhanvien"].DisplayIndex = 10;
            dgvLichsunhap.Columns["Bophan"].DisplayIndex = 11;
            dgvLichsunhap.Columns["Thoigian"].DisplayIndex = 12;

            dgvLichsunhap.Columns["Trangthai"].HeaderText = "Trạng thái";
            dgvLichsunhap.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgvLichsunhap.Columns["Donvi"].HeaderText = "Đơn vị";
            dgvLichsunhap.Columns["Tennguoithaotac"].HeaderText = "Người thao tác";
            dgvLichsunhap.Columns["Manhanvien"].HeaderText = "Mã nhân viên";
            dgvLichsunhap.Columns["Bophan"].HeaderText = "Bộ phận";
            dgvLichsunhap.Columns["Thoigian"].HeaderText = "Thời gian nhập";
            dgvLichsunhap.Columns["Soluongnhap"].HeaderText = "Số lượng nhập";
            dgvLichsunhap.Columns["Nhapvaokho"].HeaderText = "Nhập vào kho";
            dgvLichsunhap.Columns["TonkhotruocnhapVTN"].HeaderText = "Tồn kho trước nhập VTN";
            dgvLichsunhap.Columns["TonkhosaunhapVTN"].HeaderText = "Tồn kho sau nhập VTN";
            dgvLichsunhap.Columns["TonkhotruocnhapDRG"].HeaderText = "Tồn kho trước nhập DRG";
            dgvLichsunhap.Columns["TonkhosaunhapDRG"].HeaderText = "Tồn kho sau nhập DRG";
        }

        private void dgvLichsunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvLichsunhap.Rows[e.RowIndex];
                txtMavattu.Text = selectedRow.Cells["Mavattu"].Value.ToString();
                txtSoluongnhap.Text = selectedRow.Cells["Soluongnhap"].Value.ToString();
                txtDonvi.Text = selectedRow.Cells["Donvi"].Value.ToString();
                txtNhapvaokho.Text = selectedRow.Cells["Nhapvaokho"].Value.ToString();
                txtTonkhotruocnhapVTN.Text = selectedRow.Cells["TonkhotruocnhapVTN"].Value.ToString();
                txtTonkhosaunhapVTN.Text = selectedRow.Cells["TonkhosaunhapVTN"].Value.ToString();
                txtTonkhotruocnhapDRG.Text = selectedRow.Cells["TonkhotruocnhapDRG"].Value.ToString();
                txtTonkhosaunhapDRG.Text = selectedRow.Cells["TonkhosaunhapDRG"].Value.ToString();
                txtNguoithaotac.Text = selectedRow.Cells["Tennguoithaotac"].Value.ToString();
                txtManhanvien.Text = selectedRow.Cells["Manhanvien"].Value.ToString();
                txtBophan.Text = selectedRow.Cells["Bophan"].Value.ToString();
                txtThoigian.Text = selectedRow.Cells["Thoigian"].Value.ToString();

                object trangThaiValue = dgvLichsunhap.Rows[e.RowIndex].Cells["Trangthai"].Value;
                string mavattu = selectedRow.Cells["Mavattu"].Value.ToString();
                string nhapvaokho = selectedRow.Cells["Nhapvaokho"].Value.ToString();
                string soluongnhap = selectedRow.Cells["Soluongnhap"].Value.ToString();
                string donvi = selectedRow.Cells["Donvi"].Value.ToString();

                string idValue = selectedRow.Cells["Id"].Value.ToString();
                if (trangThaiValue != null && trangThaiValue.ToString() == "CHỜ QC CHECK")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xem chi tiết nghiệm thu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        FormLichsunghiemthuxemnhanh fls = new FormLichsunghiemthuxemnhanh(Convert.ToInt32(idValue), mavattu, nhapvaokho,soluongnhap, donvi);
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
            }
            else
            {
                txtMavattu.Text = "_";
                txtSoluongnhap.Text = "_";
                txtDonvi.Text = "_";
                txtNhapvaokho.Text = "_";
                txtTonkhotruocnhapVTN.Text = "_";
                txtTonkhosaunhapVTN.Text = "_";
                txtTonkhotruocnhapDRG.Text = "_";
                txtTonkhosaunhapDRG.Text = "_";
                txtNguoithaotac.Text = "_";
                txtManhanvien.Text = "_";
                txtBophan.Text = "_";
                txtThoigian.Text = "_";
            }
        }

        private void txtLoctukhoa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoctukhoa.Text.Trim();
            List<Lichsunhapxuat> filteredLichsunhap;
            filteredLichsunhap = allLichsunhap.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredLichsunhap = filteredLichsunhap.Where(x =>
                    x.Mavattu.ToLower().Contains(searchText.ToLower()) || 
                    x.Donvi.ToLower().Contains(searchText.ToLower()) || 
                    x.Nhapvaokho.ToLower().Contains(searchText.ToLower()) || 
                    x.Tennguoithaotac.ToLower().Contains(searchText.ToLower()) ||
                    x.Bophan.ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhotruocnhapVTN.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhosaunhapVTN.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhotruocnhapDRG.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhosaunhapDRG.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.Manhanvien.ToLower().Contains(searchText.ToLower()) 
                ).ToList();
            }
            // Update the DataGridView with the filtered users
            UpdateDataGridView(filteredLichsunhap);
        }

        private void dtpTungay_ValueChanged(object sender, EventArgs e)
        {
            string tungay = dtpTungay.Value.ToString("yyyy/MM/dd");
            string denngay = dtpDenngay.Value.ToString("yyyy/MM/dd");
            allLichsunhap = LichsunhapxuatDAO.Instance.LoadTableList_Lichsunhaptheokhoangthoigian(tungay,denngay);
            UpdateDataGridView(allLichsunhap);
            groupBoxLichsunhap.Text = "Lịch sử nhập từ " + tungay + " - " + denngay;
        }

        private void dtpDenngay_ValueChanged(object sender, EventArgs e)
        {
            string tungay = dtpTungay.Value.ToString("yyyy/MM/dd");
            string denngay = dtpDenngay.Value.ToString("yyyy/MM/dd");
            allLichsunhap = LichsunhapxuatDAO.Instance.LoadTableList_Lichsunhaptheokhoangthoigian(tungay, denngay);
            UpdateDataGridView(allLichsunhap);
            groupBoxLichsunhap.Text = "Lịch sử nhập từ " + tungay + " - " + denngay;
        }

        private void dtpXemtheongay_ValueChanged(object sender, EventArgs e)
        {
            string ngay = dtpXemtheongay.Value.ToString("yyyy/MM/dd");
            allLichsunhap = LichsunhapxuatDAO.Instance.LoadTableList_Lichsunhaptheongay(ngay);
            UpdateDataGridView(allLichsunhap);
            groupBoxLichsunhap.Text = "Lịch sử nhập trong ngày "+ ngay;
        }

        private void dgvLichsunhap_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!dgvLichsunhap.Rows[e.RowIndex].IsNewRow && dgvLichsunhap.Rows[e.RowIndex].Cells["Trangthai"].Value.ToString() == "CHỜ NGHIỆM THU")
            {
                dgvLichsunhap.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            if (!dgvLichsunhap.Rows[e.RowIndex].IsNewRow && dgvLichsunhap.Rows[e.RowIndex].Cells["Trangthai"].Value.ToString() == "CHỜ QC CHECK")
            {
                dgvLichsunhap.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                dgvLichsunhap.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            if (!dgvLichsunhap.Rows[e.RowIndex].IsNewRow && dgvLichsunhap.Rows[e.RowIndex].Cells["Trangthai"].Value.ToString() == "NHẬP HOÀN THÀNH")
            {
                dgvLichsunhap.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dgvLichsunhap.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
