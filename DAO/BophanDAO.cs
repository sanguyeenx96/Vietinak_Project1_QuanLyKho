using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vietinak_Kho.DAO
{
    public class BophanDAO
    {
        private static BophanDAO instance;
        public static BophanDAO Instance
        {
            get { if (instance == null) instance = new BophanDAO(); return BophanDAO.instance; }
            private set { BophanDAO.instance = value; }
        }
        private BophanDAO() { }
        public List<Bophan> LoadTableList_Bophan()
        {
            List<Bophan> tableList = new List<Bophan>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tblbophan");
            foreach (DataRow item in data.Rows)
            {
                Bophan table = new Bophan(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool Create(string name)
        {
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tblbophan WHERE name = N'{0}'", name);
            int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (existingUserCount > 0)
            {
                MessageBox.Show("Tên bộ phận này đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.tblbophan (name) VALUES  (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ChangeName(int id, string newName)
        {
            try
            {
                string checkQuery = $"SELECT COUNT(*) FROM dbo.tblbophan WHERE name = '{newName}' AND id != {id}";
                int existingDepartmentCount = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(checkQuery));

                if (existingDepartmentCount > 0)
                {
                    MessageBox.Show("Tên bộ phận mới đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string updateQuery = $"UPDATE dbo.tblbophan SET name = '{newName}' WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(updateQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thay đổi tên bộ phận: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteBophan(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.tblbophan WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa bộ phận: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
