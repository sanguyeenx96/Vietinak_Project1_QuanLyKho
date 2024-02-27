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

namespace Vietinak_Kho.f_Taikhoan
{
    public partial class FormSuaxoataikhoan : Form
    {
        public FormSuaxoataikhoan()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string manhanvien = txtManhanvien.Text;
            List<User> listUser = UserDAO.Instance.FindById(manhanvien);
            UpdateDataGridView(listUser);
        }
        private void UpdateDataGridView(List<User> users)
        {
            dgvThongtintaikhoan.DataSource = users;
            dgvThongtintaikhoan.Columns["Id"].Visible = false;
            dgvThongtintaikhoan.Columns["Hoten"].HeaderText = "Họ và tên";
            dgvThongtintaikhoan.Columns["Bophan"].HeaderText = "Bộ phận";
            dgvThongtintaikhoan.Columns["Role"].HeaderText = "Vai trò";
            dgvThongtintaikhoan.Columns["Manhanvien"].HeaderText = "Mã nhân viên";
            dgvThongtintaikhoan.Columns["Chucvu"].HeaderText = "Chức vụ";
            dgvThongtintaikhoan.Columns["Matkhau"].HeaderText = "Mật khẩu";
        }

        private void btnSuathongtin_Click(object sender, EventArgs e)
        {
            if (dgvThongtintaikhoan.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvThongtintaikhoan.SelectedRows[0];

                // Extract values from the selected row and assign them to the User object
                User userInfo = new User()
                {
                    Hoten = Convert.ToString(selectedRow.Cells["Hoten"].Value),
                    Bophan = Convert.ToString(selectedRow.Cells["Bophan"].Value),
                    Role = Convert.ToString(selectedRow.Cells["Role"].Value),
                    Manhanvien = Convert.ToString(selectedRow.Cells["Manhanvien"].Value),
                    Chucvu = Convert.ToString(selectedRow.Cells["Chucvu"].Value),
                    Matkhau = Convert.ToString(selectedRow.Cells["Matkhau"].Value)
                };

                // Open the FormSua dialog with the userInfo object
                FormSua f = new FormSua(userInfo);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
