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
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    public partial class FormThongtinnguyenvatlieu : Form
    {
        private List<Thongtinvattu> allThongtinvattu;

        public FormThongtinnguyenvatlieu()
        {
            InitializeComponent();
            LoadDienGiaiVaDonViToComboBox();
        }
        private void LoadDienGiaiVaDonViToComboBox()
        {
            allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
            cbLocdiengiai.Items.Insert(0, "Tất cả");
            cbLocdonvi.Items.Insert(0, "Tất cả");
            foreach (Thongtinvattu item in allThongtinvattu)
            {
                if (!cbLocdiengiai.Items.Contains(item.Diengiai))
                {
                    cbLocdiengiai.Items.Add(item.Diengiai);
                }
                if (!cbLocdonvi.Items.Contains(item.Donvi))
                {
                    cbLocdonvi.Items.Add(item.Donvi);
                }
            }
        }

        private void UpdateDataGridViewThongtinvattu(List<Thongtinvattu> thongtinvattus)
        {
            dgvDanhsachnguyenvatlieu.DataSource = thongtinvattus;
            dgvDanhsachnguyenvatlieu.Columns["Id"].Visible = false;
            dgvDanhsachnguyenvatlieu.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgvDanhsachnguyenvatlieu.Columns["Donvi"].HeaderText = "Đơn vị";
            dgvDanhsachnguyenvatlieu.Columns["Kgtrenbao"].HeaderText = "Kg/Bao";
            dgvDanhsachnguyenvatlieu.Columns["Diengiai"].HeaderText = "Diễn giải";
            dgvDanhsachnguyenvatlieu.Columns["TonkhoVTN"].HeaderText = "Tồn kho VTN";
            dgvDanhsachnguyenvatlieu.Columns["TonkhoDRG"].HeaderText = "Tồn kho DRG";
        }
        private void FormThongtinnguyenvatlieu_Load(object sender, EventArgs e)
        {
            cbLocdiengiai.SelectedIndexChanged -= cbLocdiengiai_SelectedIndexChanged;
            cbLocdonvi.SelectedIndexChanged -= cbLocdonvi_SelectedIndexChanged;

            allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
            UpdateDataGridViewThongtinvattu(allThongtinvattu);
            txtCount.Text = allThongtinvattu.Count().ToString();
            cbLocdiengiai.SelectedItem = "Tất cả";
            cbLocdonvi.SelectedItem = "Tất cả";

            cbLocdiengiai.SelectedIndexChanged += cbLocdiengiai_SelectedIndexChanged;
            cbLocdonvi.SelectedIndexChanged += cbLocdonvi_SelectedIndexChanged;
        }

        private void btnThemnguyenvatlieu_Click(object sender, EventArgs e)
        {
            FormThemnguyenvatlieu f = new FormThemnguyenvatlieu();
            f.ShowDialog();
        }

        private void btnSuanguyenvatlieu_Click(object sender, EventArgs e)
        {
            FormSuanguyenvatlieu f = new FormSuanguyenvatlieu();
            f.ShowDialog();
        }

        private void btnXoanguyenvatlieu_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachnguyenvatlieu.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvDanhsachnguyenvatlieu.SelectedRows[0];
                // Extract values from the selected row and assign them to the User object
                Thongtinvattu ttvt = new Thongtinvattu()
                {
                    Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                    Mavattu = Convert.ToString(selectedRow.Cells["Mavattu"].Value),
                    Donvi = Convert.ToString(selectedRow.Cells["Donvi"].Value),
                    Diengiai = Convert.ToString(selectedRow.Cells["Diengiai"].Value),
                    Kgtrenbao = float.Parse(selectedRow.Cells["Kgtrenbao"].Value.ToString()),
                    Tonkhovtn = float.Parse(selectedRow.Cells["Tonkhovtn"].Value.ToString()),
                    Tonkhodrg = float.Parse(selectedRow.Cells["Tonkhodrg"].Value.ToString()),
                };
                // Open the FormSua dialog with the userInfo object
                FormXoanguyenvatlieu f = new FormXoanguyenvatlieu(ttvt);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtLoctukhoa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoctukhoa.Text.Trim();
            List<Thongtinvattu> filteredttvt;

            string selectedValue = cbLocdiengiai.Text;
            if (selectedValue == "Tất cả")
            {
                filteredttvt = allThongtinvattu.ToList();
            }
            else
            {
                filteredttvt = allThongtinvattu.Where(x => x.Diengiai == selectedValue).ToList();
            }

            string selectedValueDonvi = cbLocdonvi.Text;
            if (selectedValueDonvi != "Tất cả")
            {
                filteredttvt = filteredttvt.Where(x => x.Donvi == selectedValueDonvi).ToList();
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredttvt = filteredttvt.Where(x =>
                    x.Mavattu.ToLower().Contains(searchText.ToLower()) ||
                    x.Donvi.ToLower().Contains(searchText.ToLower()) ||
                    x.Kgtrenbao.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.Diengiai.ToLower().Contains(searchText.ToLower()) ||
                    x.Tonkhovtn.ToString().ToLower().Contains(searchText.ToLower()) ||
                    x.Tonkhodrg.ToString().ToLower().Contains(searchText.ToLower())
                ).ToList();
            }

            // Update the DataGridView with the filtered users
            UpdateDataGridViewThongtinvattu(filteredttvt);
            txtCount.Text = filteredttvt.Count().ToString();

        }

        private void cbLocdiengiai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbLocdiengiai.Text;
            List<Thongtinvattu> filteredttvt;
            if (selectedValue == "Tất cả")
            {
                filteredttvt = allThongtinvattu.ToList();
            }
            else
            {
                filteredttvt = allThongtinvattu.Where(x => x.Diengiai == selectedValue).ToList();
            }

            string selectedValueDonvi = cbLocdonvi.Text;
            if (selectedValueDonvi != "Tất cả")
            {
                filteredttvt = filteredttvt.Where(x => x.Donvi == selectedValueDonvi).ToList();
            }
            UpdateDataGridViewThongtinvattu(filteredttvt);
            txtCount.Text = filteredttvt.Count().ToString();
        }

        private void cbLocdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbLocdiengiai.Text;
            List<Thongtinvattu> filteredttvt;
            if (selectedValue == "Tất cả")
            {
                filteredttvt = allThongtinvattu.ToList();
            }
            else
            {
                filteredttvt = allThongtinvattu.Where(x => x.Diengiai == selectedValue).ToList();
            }

            string selectedValueDonvi = cbLocdonvi.Text;
            if (selectedValueDonvi != "Tất cả")
            {
                filteredttvt = filteredttvt.Where(x => x.Donvi == selectedValueDonvi).ToList();
            }
            UpdateDataGridViewThongtinvattu(filteredttvt);
            txtCount.Text = filteredttvt.Count().ToString();
        }
    }
}
