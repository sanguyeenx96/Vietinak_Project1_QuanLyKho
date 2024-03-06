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
    public partial class FormLichsuxuat : Form
    {
        private List<Lichsunhapxuat> allLichsuxuat;

        public FormLichsuxuat()
        {
            InitializeComponent();
        }

        private void FormLichsuxuat_Load(object sender, EventArgs e)
        {
            groupBoxLichsunhap.Text = "Lịch sử xuất trong ngày hôm nay " + DateTime.Now.ToString("yyyy/MM/dd");
            allLichsuxuat = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuxuathomnay();
            UpdateDataGridView(allLichsuxuat);
        }

        private void UpdateDataGridView(List<Lichsunhapxuat> Lichsunhap)
        {
            dgvLichsuxuat.DataSource = Lichsunhap;

            txtTongso.Text = Lichsunhap.Count.ToString();

            dgvLichsuxuat.Columns["Id"].Visible = false;
            dgvLichsuxuat.Columns["Vattuid"].Visible = false;
            dgvLichsuxuat.Columns["Loaithaotac"].Visible = false;
            dgvLichsuxuat.Columns["Soluongnhap"].Visible = false;
            dgvLichsuxuat.Columns["Nhapvaokho"].Visible = false;
            dgvLichsuxuat.Columns["TonkhotruocnhapVTN"].Visible = false;
            dgvLichsuxuat.Columns["TonkhosaunhapVTN"].Visible = false;
            dgvLichsuxuat.Columns["TonkhotruocnhapDRG"].Visible = false;
            dgvLichsuxuat.Columns["TonkhosaunhapDRG"].Visible = false;

            dgvLichsuxuat.Columns["Mavattu"].DisplayIndex = 0;
            dgvLichsuxuat.Columns["Soluongxuat"].DisplayIndex = 1;
            dgvLichsuxuat.Columns["Donvi"].DisplayIndex = 2;
            dgvLichsuxuat.Columns["Mucdichxuat"].DisplayIndex = 3;
            dgvLichsuxuat.Columns["TonkhotruocxuatVTN"].DisplayIndex = 4;
            dgvLichsuxuat.Columns["TonkhosauxuatVTN"].DisplayIndex = 5;
            dgvLichsuxuat.Columns["TonkhotruocxuatDRG"].DisplayIndex = 6;
            dgvLichsuxuat.Columns["TonkhosauxuatDRG"].DisplayIndex = 7;
            dgvLichsuxuat.Columns["Tennguoithaotac"].DisplayIndex = 8;
            dgvLichsuxuat.Columns["Manhanvien"].DisplayIndex = 9;
            dgvLichsuxuat.Columns["Bophan"].DisplayIndex = 10;
            dgvLichsuxuat.Columns["Thoigian"].DisplayIndex = 11;

            dgvLichsuxuat.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgvLichsuxuat.Columns["Donvi"].HeaderText = "Đơn vị";
            dgvLichsuxuat.Columns["Tennguoithaotac"].HeaderText = "Người thao tác";
            dgvLichsuxuat.Columns["Manhanvien"].HeaderText = "Mã nhân viên";
            dgvLichsuxuat.Columns["Bophan"].HeaderText = "Bộ phận";
            dgvLichsuxuat.Columns["Thoigian"].HeaderText = "Thời gian";
            dgvLichsuxuat.Columns["Soluongxuat"].HeaderText = "Số lượng xuất";
            dgvLichsuxuat.Columns["Mucdichxuat"].HeaderText = "Mục đích xuất";
            dgvLichsuxuat.Columns["TonkhotruocxuatVTN"].HeaderText = "Tồn kho trước xuất VTN";
            dgvLichsuxuat.Columns["TonkhosauxuatVTN"].HeaderText = "Tồn kho sau xuất VTN";
            dgvLichsuxuat.Columns["TonkhotruocxuatDRG"].HeaderText = "Tồn kho trước xuất DRG";
            dgvLichsuxuat.Columns["TonkhosauxuatDRG"].HeaderText = "Tồn kho sau xuất DRG";
        }

        private void dgvLichsuxuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvLichsuxuat.Rows[e.RowIndex];
                txtMavattu.Text = selectedRow.Cells["Mavattu"].Value.ToString();
                txtSoluongxuat.Text = selectedRow.Cells["Soluongxuat"].Value.ToString();
                txtDonvi.Text = selectedRow.Cells["Donvi"].Value.ToString();
                txtMucdichxuat.Text = selectedRow.Cells["Mucdichxuat"].Value.ToString();
                txtTonkhotruocxuatVTN.Text = selectedRow.Cells["TonkhotruocxuatVTN"].Value.ToString();
                txtTonkhosauxuatVTN.Text = selectedRow.Cells["TonkhosauxuatVTN"].Value.ToString();
                txtTonkhotruocxuatDRG.Text = selectedRow.Cells["TonkhotruocxuatDRG"].Value.ToString();
                txtTonkhosauxuatDRG.Text = selectedRow.Cells["TonkhosauxuatDRG"].Value.ToString();
                txtNguoithaotac.Text = selectedRow.Cells["Tennguoithaotac"].Value.ToString();
                txtManhanvien.Text = selectedRow.Cells["Manhanvien"].Value.ToString();
                txtBophan.Text = selectedRow.Cells["Bophan"].Value.ToString();
                txtThoigian.Text = selectedRow.Cells["Thoigian"].Value.ToString();
            }
            else
            {
                txtMavattu.Text = "_";
                txtSoluongxuat.Text = "_";
                txtDonvi.Text = "_";
                txtMucdichxuat.Text = "_";
                txtTonkhotruocxuatVTN.Text = "_";
                txtTonkhosauxuatVTN.Text = "_";
                txtTonkhotruocxuatDRG.Text = "_";
                txtTonkhosauxuatDRG.Text = "_";
                txtNguoithaotac.Text = "_";
                txtManhanvien.Text = "_";
                txtBophan.Text = "_";
                txtThoigian.Text = "_";
            }
        }

        private void txtLoctukhoa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoctukhoa.Text.Trim();
            List<Lichsunhapxuat> filteredLichsuxuat;
            filteredLichsuxuat = allLichsuxuat.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredLichsuxuat = filteredLichsuxuat.Where(x =>
                    x.Mavattu.ToLower().Contains(searchText.ToLower()) ||
                    x.Donvi.ToLower().Contains(searchText.ToLower()) ||
                    x.Mucdichxuat.ToLower().Contains(searchText.ToLower()) ||
                    x.Tennguoithaotac.ToLower().Contains(searchText.ToLower()) ||
                    x.Bophan.ToLower().Contains(searchText.ToLower()) ||

                    x.TonkhotruocxuatVTN.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhosauxuatVTN.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhotruocxuatDRG.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.TonkhosauxuatDRG.ToString().ToLower().Contains(searchText.ToLower()) ||

                    x.Manhanvien.ToLower().Contains(searchText.ToLower())
                ).ToList();
            }

            // Update the DataGridView with the filtered users
            UpdateDataGridView(filteredLichsuxuat);
        }

        private void dtpXemtheongay_ValueChanged(object sender, EventArgs e)
        {
            string ngay = dtpXemtheongay.Value.ToString("yyyy/MM/dd");
            allLichsuxuat = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuxuattheongay(ngay);
            UpdateDataGridView(allLichsuxuat);
            groupBoxLichsunhap.Text = "Lịch sử xuất trong ngày " + ngay;
        }

        private void dtpTungay_ValueChanged(object sender, EventArgs e)
        {
            string tungay = dtpTungay.Value.ToString("yyyy/MM/dd");
            string denngay = dtpDenngay.Value.ToString("yyyy/MM/dd");
            allLichsuxuat = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuxuattheokhoangthoigian(tungay, denngay);
            UpdateDataGridView(allLichsuxuat);
            groupBoxLichsunhap.Text = "Lịch sử xuất từ " + tungay + " - " + denngay;
        }

        private void dtpDenngay_ValueChanged(object sender, EventArgs e)
        {
            string tungay = dtpTungay.Value.ToString("yyyy/MM/dd");
            string denngay = dtpDenngay.Value.ToString("yyyy/MM/dd");
            allLichsuxuat = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuxuattheokhoangthoigian(tungay, denngay);
            UpdateDataGridView(allLichsuxuat);
            groupBoxLichsunhap.Text = "Lịch sử xuất từ " + tungay + " - " + denngay;
        }
    }
}
