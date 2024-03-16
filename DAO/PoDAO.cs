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

        public bool Create( string no, string code, string dept, string sec, string fromdate, string pageno,
            string orderno, string address, string tel, string attn, string fax, string issuedate,
            string paymentterm, string deliveryterm, string shippingmethod, string currency, string manv, string hoten, string bophan,
            string ngaygio)
        {
            string checkQuery1 = string.Format("SELECT COUNT(*) FROM dbo.po WHERE no = N'{0}'", no);
            int existing1 = (int)DataProvider.Instance.ExecuteScalar(checkQuery1);
            if (existing1 > 0)
            {
                MessageBox.Show("Mã PO đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.po (no, code, dept, sec," +
                " fromdate, pageno, orderno, address, tel, attn," +
                " fax, issuedate, paymentterm, deliveryterm, shippingmethod," +
                " currency, manv, hoten,bophan,ngaygio) " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}'" +
                ", N'{13}', N'{14}', N'{15}', N'{16}', N'{17}', N'{18}', N'{19}')",
                no, code, dept, sec, fromdate, pageno, orderno, address, tel, attn,
                fax, issuedate, paymentterm, deliveryterm, shippingmethod,currency, 
                manv, hoten,bophan,ngaygio);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
