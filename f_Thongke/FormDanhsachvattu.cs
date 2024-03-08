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
    public partial class FormDanhsachvattu : Form
    {
        private List<Thongtinvattu> allThongtinvattu;

        public FormDanhsachvattu()
        {
            InitializeComponent();
        }

        private void FormDanhsachvattu_Load(object sender, EventArgs e)
        {
            allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
            UpdateDataGridViewThongtinvattu(allThongtinvattu);
            txtTongsovattu.Text = allThongtinvattu.Count().ToString();
            txtTongsovattuVTN.Text = allThongtinvattu.Count(x => x.Tonkhovtn != 0).ToString();
            txtTongsovattuDRG.Text = allThongtinvattu.Count(x => x.Tonkhodrg != 0).ToString();
            float tongSoLuongKgvtn = 0;
            float tongSoLuongPcsvtn = 0;
            float tongSoLuongKgdrg = 0;
            float tongSoLuongPcsdrg = 0;

            foreach (var item in allThongtinvattu)
            {
                if (item.Donvi == "Kg")
                {
                    tongSoLuongKgvtn += item.Tonkhovtn;
                    tongSoLuongKgdrg += item.Tonkhodrg;
                }
                if (item.Donvi == "Pcs")
                {
                    tongSoLuongPcsvtn += item.Tonkhovtn;
                    tongSoLuongPcsdrg += item.Tonkhodrg;
                }
            }
            txttongkgvtn.Text = tongSoLuongKgvtn.ToString() + " Kg";
            txttongpcsvtn.Text = tongSoLuongPcsvtn.ToString() + " Pcs";
            txttongkgdrg.Text = tongSoLuongKgdrg.ToString() + " Kg";
            txttongpcsdrg.Text = tongSoLuongPcsdrg.ToString() + " Pcs";
        }

        private void UpdateDataGridViewThongtinvattu(List<Thongtinvattu> thongtinvattus)
        {
            dgvDanhsachvattu.DataSource = thongtinvattus;
            dgvDanhsachvattu.Columns["Id"].Visible = false;
            dgvDanhsachvattu.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgvDanhsachvattu.Columns["Donvi"].HeaderText = "Đơn vị";
            dgvDanhsachvattu.Columns["Kgtrenbao"].HeaderText = "Kg/Bao";
            dgvDanhsachvattu.Columns["Diengiai"].HeaderText = "Diễn giải";
            dgvDanhsachvattu.Columns["TonkhoVTN"].HeaderText = "Tồn kho VTN";
            dgvDanhsachvattu.Columns["TonkhoDRG"].HeaderText = "Tồn kho DRG";
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoc.Text.Trim();
            List<Thongtinvattu> filteredttvt;
            filteredttvt = allThongtinvattu.ToList();

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
        }

        private void dgvDanhsachvattu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDanhsachvattu.Rows[e.RowIndex];               
                string mavattu = selectedRow.Cells["Mavattu"].Value.ToString();
                string idValue = selectedRow.Cells["Id"].Value.ToString();

                FormChitietvattu fls = new FormChitietvattu(mavattu);
                fls.ShowDialog();
            }
        }
    }
}
