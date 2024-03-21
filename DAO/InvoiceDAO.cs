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

        public int CreateReturnId(string trangthai, string invoicenumber, string invoicedate, string qty)
        {
            // Kiểm tra xem invoicenumber đã tồn tại trong bảng invoice hay chưa
            string checkQuery = string.Format("SELECT ID FROM dbo.invoice WHERE invoicenumber = N'{0}'", invoicenumber);
            object existingInvoiceId = DataProvider.Instance.ExecuteScalar(checkQuery);

            if (existingInvoiceId != null) // Nếu invoicenumber đã tồn tại, cập nhật thông tin
            {
                string updateQuery = string.Format("UPDATE dbo.invoice SET trangthai = N'{0}', invoicedate = N'{1}', qty = N'{2}' WHERE invoicenumber = N'{3}'", trangthai, invoicedate, qty, invoicenumber);
                DataProvider.Instance.ExecuteNonQuery(updateQuery);
                return Convert.ToInt32(existingInvoiceId);
            }
            else // Nếu invoicenumber chưa tồn tại, thêm mới thông tin
            {
                string insertQuery = string.Format("INSERT dbo.invoice (trangthai, invoicenumber, invoicedate, qty) " +
                    "OUTPUT INSERTED.ID " +
                    "VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", trangthai, invoicenumber, invoicedate, qty);
                object result = DataProvider.Instance.ExecuteScalar(insertQuery);
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public bool Update(int id,string invoicenumber, string invoicedate, string qty)
        {
            string updateQuery = string.Format("UPDATE dbo.invoice SET invoicenumber = N'{0}', invoicedate = N'{1}', qty = N'{2}' WHERE id = N'{3}'", invoicenumber, invoicedate, qty, id);
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(updateQuery);
            return rowsAffected > 0;
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
