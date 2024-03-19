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
    public class PoDAO
    {
        private static PoDAO instance;
        public static PoDAO Instance
        {
            get { if (instance == null) instance = new PoDAO(); return PoDAO.instance; }
            private set { PoDAO.instance = value; }
        }
        private PoDAO() { }
        public List<Po> LoadTableList_Po()
        {
            List<Po> tableList = new List<Po>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.po");
            foreach (DataRow item in data.Rows)
            {
                Po table = new Po(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public Po LoadTableList_PoById(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.po WHERE id = '" + id + "' ");
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                Po po = new Po(row);
                return po;
            }
            else
            {
                return null;
            }
        }

        public int CreateReturnId(string trangthai, string no, string code, string dept, string sec, string fromdate, string pageno,
            string orderto, string address, string tel, string attn, string fax, string issuedate,
            string paymentterm, string deliveryterm, string shippingmethod, string currency, string manv, string hoten, string bophan,
            string ngaygio)
        {
            string checkQuery1 = string.Format("SELECT COUNT(*) FROM dbo.po WHERE no = N'{0}'", no);
            int existing1 = (int)DataProvider.Instance.ExecuteScalar(checkQuery1);
            if (existing1 > 0)
            {
                MessageBox.Show("Mã PO đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            string query = string.Format("INSERT dbo.po (trangthai, no, code, dept, sec," +
                " fromdate, pageno, orderto, address, tel, attn," +
                " fax, issuedate, paymentterm, deliveryterm, shippingmethod," +
                " currency, manv, hoten,bophan,ngaygio) " +
                "OUTPUT INSERTED.ID " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}'" +
                ", N'{13}', N'{14}', N'{15}', N'{16}', N'{17}', N'{18}', N'{19}', N'{20}')",
                trangthai, no, code, dept, sec, fromdate, pageno, orderto, address, tel, attn,
                fax, issuedate, paymentterm, deliveryterm, shippingmethod, currency,
                manv, hoten, bophan, ngaygio);
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public bool Delete(int id)
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
