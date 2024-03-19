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
    public class InvoiceDAO
    {
        private static InvoiceDAO instance;
        public static InvoiceDAO Instance
        {
            get { if (instance == null) instance = new InvoiceDAO(); return InvoiceDAO.instance; }
            private set { InvoiceDAO.instance = value; }
        }
        private InvoiceDAO() { }

        public List<Invoice> LoadTableList_Invoice()
        {
            List<Invoice> tableList = new List<Invoice>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoice");
            foreach (DataRow item in data.Rows)
            {
                Invoice table = new Invoice(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public Invoice LoadTableList_InvoiceById(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoice WHERE id = '" + id + "' ");
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                Invoice po = new Invoice(row);
                return po;
            }
            else
            {
                return null;
            }
        }
        public int CreateReturnId(int itemid, string trangthai, string invoicenumber, string invoicedate, float qty)
        {
            //string checkQuery1 = string.Format("SELECT COUNT(*) FROM dbo.po WHERE itemid = N'{0}'", itemid);
            //int existing1 = (int)DataProvider.Instance.ExecuteScalar(checkQuery1);
            //if (existing1 > 0)
            //{
            //    MessageBox.Show("Mã PO đã tồn tại!",
            //        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return -1;
            //}
            string query = string.Format("INSERT dbo.invoice (itemid, trangthai, invoicenumber, invoicedate, qty) " +
                "OUTPUT INSERTED.ID " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}')",
                itemid, trangthai, invoicenumber, invoicedate, qty);
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public bool Delete(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.invoice WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa invoice: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
