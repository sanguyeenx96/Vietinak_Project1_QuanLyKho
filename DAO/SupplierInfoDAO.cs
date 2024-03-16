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
    public class SupplierInfoDAO
    {
        private static SupplierInfoDAO instance;
        public static SupplierInfoDAO Instance
        {
            get { if (instance == null) instance = new SupplierInfoDAO(); return SupplierInfoDAO.instance; }
            private set { SupplierInfoDAO.instance = value; }
        }
        private SupplierInfoDAO() { }
        public List<SupplierInfo> LoadTableList_Sup()
        {
            List<SupplierInfo> tableList = new List<SupplierInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.supplierinfo");
            foreach (DataRow item in data.Rows)
            {
                SupplierInfo table = new SupplierInfo(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool Create(string code, string name, string pic, string tel, string address, string lastupdate)
        {
            string check1 = string.Format("SELECT COUNT(*) FROM dbo.supplierinfo WHERE code = N'{0}'", code);
            string check2 = string.Format("SELECT COUNT(*) FROM dbo.supplierinfo WHERE name = N'{0}'", name);

            int existingcode = (int)DataProvider.Instance.ExecuteScalar(check1);
            int existingname = (int)DataProvider.Instance.ExecuteScalar(check2);

            if (existingcode > 0)
            {
                MessageBox.Show("Code supplier này đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (existingcode > 0)
            {
                MessageBox.Show("Tên supplier này đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.supplierinfo (code, name, pic, tel,address, lastupdate) " +
               "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}')",
                code, name, pic, tel, address, lastupdate);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool Update(int id, string code, string name, string pic, string tel,
            string address, string lastupdate, string currentName, string currentCode)
        {
            try
            {
                if (name != currentName)
                {
                    string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.supplierinfo WHERE name = N'{0}'", name);
                    int existing = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                    if (existing > 0)
                    {
                        MessageBox.Show("Tên mới đã bị trùng trong cơ sở dữ liệu!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (code != currentCode)
                {
                    string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.supplierinfo WHERE code = N'{0}'", code);
                    int existing = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                    if (existing > 0)
                    {
                        MessageBox.Show("Mã code mới đã bị trùng trong cơ sở dữ liệu!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                string query = string.Format("UPDATE dbo.supplierinfo SET code = N'{0}', name = N'{1}', pic = N'{2}', tel = N'{3}', address = N'{4}', lastupdate = N'{5}' " +
                    "WHERE id = N'{6}'", code, name, pic, tel, address, lastupdate, id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin supplier!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin supplier: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.supplierinfo WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thông tin supplier: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
