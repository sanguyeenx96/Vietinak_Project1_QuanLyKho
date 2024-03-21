using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Invoice
    {
        public Invoice(int id, string trangthai, string invoicenumber, string invoicedate, float qty)
        {
            this.Id = id;
            this.Trangthai = trangthai;
            this.Invoicenumber = invoicenumber;
            this.Invoicedate = invoicedate;
            this.Qty = qty;
        }
        public Invoice(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Trangthai = row["trangthai"].ToString();
            this.Invoicenumber = row["invoicenumber"].ToString();
            this.Invoicedate = row["invoicedate"].ToString();
            this.Qty = row["qty"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["qty"]);
        }

        public Invoice()
        {
        }

        private int id;
        private string trangthai;
        private string invoicenumber;
        private string invoicedate;
        private float qty;

        public int Id { get => id; set => id = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Invoicenumber { get => invoicenumber; set => invoicenumber = value; }
        public string Invoicedate { get => invoicedate; set => invoicedate = value; }
        public float Qty { get => qty; set => qty = value; }
    }
}
