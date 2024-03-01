using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return UserDAO.instance; }
            private set { UserDAO.instance = value; }
        }
        private UserDAO() { }


        public List<User> LoadTableList_User()
        {
            List<User> tableList = new List<User>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbluser");
            foreach (DataRow item in data.Rows)
            {
                User table = new User(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public User Login(string manv, string pwd)
        {
            string query = $"SELECT * FROM dbo.tbluser WHERE manhanvien = '{manv}' AND matkhau = '{pwd}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0]; 
                User user = new User(row);
                return user;
            }
            else
            {
                return null; 
            }
        }

        public bool Create(User newuser)
        {
            // Check if the employee code already exists in the database
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbluser WHERE manhanvien = N'{0}'", newuser.Manhanvien);
            int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (existingUserCount > 0)
            {
                MessageBox.Show("Mã nhân viên này đã có tài khoản!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.tbluser (hoten, manhanvien, bophan, chucvu, matkhau, role) VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}')", newuser.Hoten, newuser.Manhanvien, newuser.Bophan, newuser.Chucvu, newuser.Matkhau, newuser.Role);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<User> FindById(string manhanvien)
        {
            List<User> tableList = new List<User>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbluser WHERE manhanvien ='" + manhanvien + "' ");
            if(data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu mã nhân viên này!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            foreach (DataRow item in data.Rows)
            {
                User table = new User(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Update(User updatedUser)
        {
            try
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbluser WHERE manhanvien = N'{0}'", updatedUser.Manhanvien);
                int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                if (existingUserCount == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng có mã nhân viên này!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbluser SET hoten = N'{0}', bophan = N'{1}', chucvu = N'{2}', matkhau = N'{3}', role = N'{4}' WHERE manhanvien = N'{5}'", updatedUser.Hoten, updatedUser.Bophan, updatedUser.Chucvu, updatedUser.Matkhau, updatedUser.Role, updatedUser.Manhanvien);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {                    
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin người dùng!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin người dùng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteTaikhoan(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.tbluser WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdatePassword(int id, string newPassword)
        {
            try
            {            
                string query = string.Format("UPDATE dbo.tbluser SET matkhau = N'{0}' WHERE id = N'{1}'", newPassword,id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin người dùng!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin người dùng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
