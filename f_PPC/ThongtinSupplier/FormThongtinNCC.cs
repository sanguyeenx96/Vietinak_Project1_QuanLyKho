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
using Vietinak_Kho.f_PPC.ThongtinSupplier;
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho.f_PPC
{
    public partial class FormThongtinNCC : Form
    {
        private User userInfo;
        private List<SupplierInfo> allds;
        public FormThongtinNCC(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        private void FormThongtinNCC_Load(object sender, EventArgs e)
        {
            allds = SupplierInfoDAO.Instance.LoadTableList_Sup();
            UpdateDataGridView(allds);
            btnSoluongSup.Text = "Tổng số lượng Supplier : " + allds.Count().ToString();
        }

        private void UpdateDataGridView(List<SupplierInfo> ds)
        {
            dgvDssup.DataSource = ds;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemNCC ft = new FormThemNCC();
            ft.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDssup.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvDssup.SelectedRows[0];

                // Extract values from the selected row and assign them to the User object
                SupplierInfo info = new SupplierInfo()
                {                    
                    Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                    Code = Convert.ToString(selectedRow.Cells["Code"].Value),
                    Name = Convert.ToString(selectedRow.Cells["Name"].Value),
                    Pic = Convert.ToString(selectedRow.Cells["Pic"].Value),
                    Tel = Convert.ToString(selectedRow.Cells["Tel"].Value),
                    Address = Convert.ToString(selectedRow.Cells["Address"].Value),
                    Lastupdate = Convert.ToString(selectedRow.Cells["Lastupdate"].Value),

                };
                FormSuaNCC f = new FormSuaNCC(info);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDssup.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvDssup.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string name = selectedRow.Cells["Name"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu " + name + " ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    bool success = SupplierInfoDAO.Instance.Delete(id);
                    if (success)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoc.Text.Trim();
            List < SupplierInfo > filtered;
            filtered = allds.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(x =>
                    x.Name.ToLower().Contains(searchText.ToLower()) ||
                    x.Pic.ToLower().Contains(searchText.ToLower()) ||
                    x.Tel.ToLower().Contains(searchText.ToLower()) ||
                    x.Address.ToLower().Contains(searchText.ToLower()) ||
                    x.Code.ToLower().Contains(searchText.ToLower()) 
                ).ToList();
            }
            // Update the DataGridView with the filtered users
            UpdateDataGridView(filtered);
        }
    }
}
