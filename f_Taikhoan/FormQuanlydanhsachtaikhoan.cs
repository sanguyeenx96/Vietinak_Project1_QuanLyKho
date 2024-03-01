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
    public partial class FormQuanlydanhsachtaikhoan : Form
    {
        private Button activeButton;
        private List<User> allUsers; // Sử dụng để lưu trữ tất cả các tài khoản
        public FormQuanlydanhsachtaikhoan()
        {
            InitializeComponent();
        }
        private void FormQuanlydanhsachtaikhoan_Load(object sender, EventArgs e)
        {
            cbLocbophan.SelectedIndexChanged -= cbLocbophan_SelectedIndexChanged;

            List<Bophan> listBophan = BophanDAO.Instance.LoadTableList_Bophan();
            listBophan.Insert(0, new Bophan { Id = -1, Name = "Không chọn" }); // Adjust the default text as needed
            cbLocbophan.DataSource = listBophan;
            cbLocbophan.DisplayMember = "Name"; // Replace "TenBophan" with the actual property name representing the department name in your Bophan class
            cbLocbophan.ValueMember = "Name"; // Assuming "Id" is the property representing the ID in your Bophan class
            cbLocbophan.SelectedIndexChanged += cbLocbophan_SelectedIndexChanged;

            // Load tất cả các tài khoản và hiển thị trên DataGridView
            allUsers = UserDAO.Instance.LoadTableList_User();
            UpdateButtonCounts(allUsers);
            btnTotalAcc.PerformClick();
        }
        private void UpdateButtonColor(Button clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.White;
            }
            clickedButton.BackColor = SystemColors.ActiveBorder;
            activeButton = clickedButton;
        }
        private void btnTotalAcc_Click(object sender, EventArgs e)
        {
            string selectedValue = cbLocbophan.SelectedValue.ToString();
            if (selectedValue != "Không chọn")
            {
                List<User> newallUsers = allUsers.Where(x => x.Bophan == selectedValue).ToList();
                UpdateDataGridView(newallUsers);
            }
            else
            {
                UpdateDataGridView(allUsers);
            }
            UpdateButtonColor(sender as Button);
        }
        private void btnAdminAcc_Click(object sender, EventArgs e)
        {
            string selectedValue = cbLocbophan.SelectedValue.ToString();
            if (selectedValue != "Không chọn")
            {
                List<User> newallUsers = allUsers.Where(x => x.Bophan == selectedValue).ToList();
                List<User> adminAccounts = newallUsers.Where(x => x.Role == "Admin").ToList();
                UpdateDataGridView(adminAccounts);
            }
            else
            {
                List<User> adminAccounts = allUsers.Where(x => x.Role == "Admin").ToList();
                UpdateDataGridView(adminAccounts);
            }
            UpdateButtonColor(sender as Button);
        }
        private void btnUserAcc_Click(object sender, EventArgs e)
        {
            string selectedValue = cbLocbophan.SelectedValue.ToString();
            if (selectedValue != "Không chọn")
            {
                List<User> newallUsers = allUsers.Where(x => x.Bophan == selectedValue).ToList();
                List<User> userAccounts = newallUsers.Where(x => x.Role == "User").ToList();
                UpdateDataGridView(userAccounts);
            }
            else
            {
                List<User> userAccounts = allUsers.Where(x => x.Role == "User").ToList();
                UpdateDataGridView(userAccounts);
            }            
            UpdateButtonColor(sender as Button);
        }
        private void UpdateDataGridView(List<User> users)
        {
            dgvDanhsachtaikhoan.DataSource = users;
            dgvDanhsachtaikhoan.Columns["Id"].Visible = false;
            dgvDanhsachtaikhoan.Columns["Hoten"].HeaderText = "Họ và tên";
            dgvDanhsachtaikhoan.Columns["Bophan"].HeaderText = "Bộ phận";
            dgvDanhsachtaikhoan.Columns["Role"].HeaderText = "Vai trò";
            dgvDanhsachtaikhoan.Columns["Manhanvien"].HeaderText = "Mã nhân viên";
            dgvDanhsachtaikhoan.Columns["Chucvu"].HeaderText = "Chức vụ";
            dgvDanhsachtaikhoan.Columns["Matkhau"].HeaderText = "Mật khẩu";
        }
        private void UpdateButtonCounts(List<User> users)
        {
            btnTotalAcc.Text = "Tất cả tài khoản: " + users.Count().ToString();
            btnAdminAcc.Text = "Tài khoản quản trị: " + users.Count(x => x.Role == "Admin").ToString();
            btnUserAcc.Text = "Tài khoản người dùng: " + users.Count(x => x.Role == "User").ToString();
        }
        private void cbLocbophan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbLocbophan.SelectedValue.ToString();
            List<User> filteredUsers;

            // Kiểm tra nút nào đang được chọn
            if (btnTotalAcc.BackColor == SystemColors.ActiveBorder)
            {
                // Nếu nút "Tất cả tài khoản" đang được chọn, lọc dữ liệu tất cả các tài khoản
                filteredUsers = selectedValue == "Không chọn" ? allUsers.ToList() : allUsers.Where(x => x.Bophan == selectedValue).ToList();
            }
            else if (btnAdminAcc.BackColor == SystemColors.ActiveBorder)
            {
                // Nếu nút "Tài khoản quản trị" đang được chọn, lọc dữ liệu các tài khoản quản trị
                filteredUsers = selectedValue == "Không chọn" ? allUsers.Where(x => x.Role == "Admin").ToList() : allUsers.Where(x => x.Bophan == selectedValue && x.Role == "Admin").ToList();
            }
            else if (btnUserAcc.BackColor == SystemColors.ActiveBorder)
            {
                // Nếu nút "Tài khoản người dùng" đang được chọn, lọc dữ liệu các tài khoản người dùng
                filteredUsers = selectedValue == "Không chọn" ? allUsers.Where(x => x.Role == "User").ToList() : allUsers.Where(x => x.Bophan == selectedValue && x.Role == "User").ToList();
            }
            else
            {
                // Trường hợp mặc định, lọc dữ liệu tất cả các tài khoản
                filteredUsers = selectedValue == "Không chọn" ? allUsers.ToList() : allUsers.Where(x => x.Bophan == selectedValue).ToList();
            }

            UpdateDataGridView(filteredUsers);
        }

        private void txtLoctukhoa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoctukhoa.Text.Trim();
            List<User> filteredUsers;

            // Get the selected value from the ComboBox
            string selectedValue = cbLocbophan.SelectedValue.ToString();

            // Kiểm tra nút nào đang được chọn
            if (btnTotalAcc.BackColor == SystemColors.ActiveBorder)
            {
                // Nếu nút "Tất cả tài khoản" đang được chọn, lọc dữ liệu tất cả các tài khoản
                if (selectedValue == "Không chọn")
                {
                    filteredUsers = allUsers.ToList();
                }
                else
                {
                    filteredUsers = allUsers.Where(x => x.Bophan == selectedValue).ToList();
                }
            }
            else if (btnAdminAcc.BackColor == SystemColors.ActiveBorder)
            {
                // Nếu nút "Tài khoản quản trị" đang được chọn, lọc dữ liệu các tài khoản quản trị
                if (selectedValue == "Không chọn")
                {
                    filteredUsers = allUsers.Where(x => x.Role == "Admin").ToList();
                }
                else
                {
                    filteredUsers = allUsers.Where(x => x.Bophan == selectedValue && x.Role == "Admin").ToList();
                }
            }
            else if (btnUserAcc.BackColor == SystemColors.ActiveBorder)
            {
                // Nếu nút "Tài khoản người dùng" đang được chọn, lọc dữ liệu các tài khoản người dùng
                if (selectedValue == "Không chọn")
                {
                    filteredUsers = allUsers.Where(x => x.Role == "User").ToList();
                }
                else
                {
                    filteredUsers = allUsers.Where(x => x.Bophan == selectedValue && x.Role == "User").ToList();
                }
            }
            else
            {
                // Trường hợp mặc định, lọc dữ liệu tất cả các tài khoản
                if (selectedValue == "Không chọn")
                {
                    filteredUsers = allUsers.ToList();
                }
                else
                {
                    filteredUsers = allUsers.Where(x => x.Bophan == selectedValue).ToList();
                }
            }

            // Nếu có dữ liệu tìm kiếm, lọc dữ liệu tương ứng
            if (!string.IsNullOrEmpty(searchText))
            {
                filteredUsers = filteredUsers.Where(user =>
                    user.Hoten.ToLower().Contains(searchText.ToLower()) || // Check if the user's name contains the search text (case-insensitive)
                    user.Bophan.ToLower().Contains(searchText.ToLower()) || // Check if the user's department contains the search text (case-insensitive)
                    user.Role.ToLower().Contains(searchText.ToLower()) || // Check if the user's role contains the search text (case-insensitive)
                    user.Manhanvien.ToLower().Contains(searchText.ToLower()) || // Check if the user's ID contains the search text (case-insensitive)
                    user.Chucvu.ToLower().Contains(searchText.ToLower()) || // Check if the user's position contains the search text (case-insensitive)
                    user.Matkhau.ToLower().Contains(searchText.ToLower()) // Check if the user's password contains the search text (case-insensitive)
                ).ToList();
            }

            // Update the DataGridView with the filtered users
            UpdateDataGridView(filteredUsers);

        }




    }
}
