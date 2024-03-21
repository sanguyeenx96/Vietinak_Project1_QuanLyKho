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
    public class InvoiceinfoDAO
    {
        private static InvoiceinfoDAO instance;
        public static InvoiceinfoDAO Instance
        {
            get { if (instance == null) instance = new InvoiceinfoDAO(); return InvoiceinfoDAO.instance; }
            private set { InvoiceinfoDAO.instance = value; }
        }
        private InvoiceinfoDAO() { }

        public Invoiceinfo LoadTableList_InvoiceinfoById(int invoiceid)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoiceinfo WHERE invoiceid = '" + invoiceid + "' ");
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                Invoiceinfo list = new Invoiceinfo(row);
                return list;
            }
            else
            {
                return null;
            }
        }
        public bool UpdateQty(int id,  string qty)
        {
            string updateQuery = string.Format("UPDATE dbo.invoiceinfo SET qty = N'{0}' WHERE id = N'{1}'", qty, id);
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(updateQuery);
            return rowsAffected > 0;
        }

        public bool UpdateSoluongDaveSauNhap(int id, float qtyToAdd)
        {
            // Lấy giá trị hiện tại của qty từ cơ sở dữ liệu
            string selectQuery = $"SELECT dave FROM dbo.invoiceinfo WHERE id = {id}";
            float currentDave = Convert.ToSingle(DataProvider.Instance.ExecuteScalar(selectQuery));

            // Cộng giá trị hiện tại với giá trị mới
            float newQtyDave = currentDave + qtyToAdd;

            // Cập nhật giá trị mới vào cơ sở dữ liệu
            string updateQuery = string.Format("UPDATE dbo.invoiceinfo SET dave = N'{0}' WHERE id = N'{1}'", newQtyDave, id);
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(updateQuery);

            return rowsAffected > 0;
        }
        public int CreateReturnId(int invoiceid, int itemid, string qty, string dave)
        {
            //string checkQuery1 = string.Format("SELECT COUNT(*) FROM dbo.po WHERE itemid = N'{0}'", itemid);
            //int existing1 = (int)DataProvider.Instance.ExecuteScalar(checkQuery1);
            //if (existing1 > 0)
            //{
            //    MessageBox.Show("Mã PO đã tồn tại!",
            //        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return -1;
            //}
            string query = string.Format("INSERT dbo.invoiceinfo ( invoiceid, itemid, qty, dave) " +
                "OUTPUT INSERTED.ID " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}')",
                 invoiceid, itemid, qty, dave);
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public bool Delete(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.invoiceinfo WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa invoice info: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
