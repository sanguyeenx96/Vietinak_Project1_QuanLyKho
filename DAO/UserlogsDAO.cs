using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.DAO
{
    public class UserlogsDAO
    {
        private static UserlogsDAO instance;
        public static UserlogsDAO Instance
        {
            get { if (instance == null) instance = new UserlogsDAO(); return UserlogsDAO.instance; }
            private set { UserlogsDAO.instance = value; }
        }
        private UserlogsDAO() { }

        public List<Userlogs> LoadTableList_AllUserlogs()
        {
            List<Userlogs> tableList = new List<Userlogs>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbluserlogs");
            foreach (DataRow item in data.Rows)
            {
                Userlogs table = new Userlogs(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<Userlogs> LoadTableList_Loc(int? userid, string phuongthuc, string ngaygio)
        {
            List<Userlogs> tableList = new List<Userlogs>();
            string query = "SELECT * FROM dbo.tbluserlogs WHERE 1 = 1";
            if (userid != 0)
            {
                query += " AND userid = " + userid;
            }
            if (!string.IsNullOrEmpty(phuongthuc))
            {
                query += " AND phuongthuc = '" + phuongthuc + "'";
            }
            if (!string.IsNullOrEmpty(ngaygio))
            {
                query += " AND ngaygio = '" + ngaygio + "'";
            }
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Userlogs table = new Userlogs(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool InsertUserLog(int userid, string noidung, string phuongthuc)
        {
            try
            {
                string ngaygio = DateTime.Now.ToString("yyyy/MM/dd");
                string query = string.Format("INSERT INTO dbo.tbluserlogs (userid, noidung, phuongthuc, ngaygio) VALUES ({0}, N'{1}', N'{2}', '{3}')",
                                                userid, noidung, phuongthuc, ngaygio);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm dữ liệu vào bảng userlogs: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
