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
    public class ChucvuDAO
    {
        private static ChucvuDAO instance;
        public static ChucvuDAO Instance
        {
            get { if (instance == null) instance = new ChucvuDAO(); return ChucvuDAO.instance; }
            private set { ChucvuDAO.instance = value; }
        }
        private ChucvuDAO() { }
        public List<Chucvu> LoadTableList_Chucvu()
        {
            List<Chucvu> tableList = new List<Chucvu>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tblchucvu");
            foreach (DataRow item in data.Rows)
            {
                Chucvu table = new Chucvu(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool Create(string name)
        {
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tblchucvu WHERE name = N'{0}'", name);
            int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (existingUserCount > 0)
            {
                MessageBox.Show("Tên chức vụ này đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.tblchucvu (name) VALUES  (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ChangeName(int id, string newName)
        {
            try
            {
                string checkQuery = $"SELECT COUNT(*) FROM dbo.tblchucvu WHERE name = '{newName}' AND id != {id}";
                int existingDepartmentCount = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(checkQuery));

                if (existingDepartmentCount > 0)
                {
                    MessageBox.Show("Tên chức vụ mới đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string updateQuery = $"UPDATE dbo.tblchucvu SET name = '{newName}' WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(updateQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thay đổi tên chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Deletechucvu(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.tblchucvu WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
