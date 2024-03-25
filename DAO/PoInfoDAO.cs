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
    public class PoInfoDAO
    {
        private static PoInfoDAO instance;
        public static PoInfoDAO Instance
        {
            get { if (instance == null) instance = new PoInfoDAO(); return PoInfoDAO.instance; }
            private set { PoInfoDAO.instance = value; }
        }
        private PoInfoDAO() { }
        public List<PoInfo> LoadTableList_PoInfoFromPo(int id)
        {
            List<PoInfo> tableList = new List<PoInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.poinfo WHERE poid = '"+id+"' ");
            foreach (DataRow item in data.Rows)
            {
                PoInfo table = new PoInfo(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Create(int poid, string itemcode, string description, string partno, string qty, string unit,
            string price, string amount, string group, string requesteddepartment, string factory, string etd,
            string total, string remark)
        {          
            string query = string.Format("INSERT dbo.poinfo (poid, itemcode, description, partno," +
                " qty, unit, price, amount, [group], requesteddepartment," +
                " factory, etd, total, remark) " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}'" +
                ", N'{13}')",
                poid, itemcode, description, partno, qty, unit, price, amount, group, requesteddepartment, factory, etd, total, remark);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTotalAmount(int id, string total)
        {
            string query = string.Format("UPDATE dbo.poinfo SET total = N'{0}' " +
                   "WHERE id = N'{1}'", total, id);
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Không thể cập nhật thông tin total amount!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                string deleteQuery2 = $"DELETE FROM dbo.poinfo OUTPUT DELETED.id WHERE id = {id}";
                DataTable deletedIDsTable = DataProvider.Instance.ExecuteQuery(deleteQuery2);

                List<int> deletedIDs = new List<int>();
                foreach (DataRow row in deletedIDsTable.Rows)
                {
                    deletedIDs.Add(Convert.ToInt32(row["id"]));
                }
                foreach (int deletedID in deletedIDs)
                {
                    string deleteQuery3 = $"DELETE FROM dbo.invoiceinfo WHERE itemid = {deletedID}";
                    int rowsAffected3 = DataProvider.Instance.ExecuteNonQuery(deleteQuery3);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
