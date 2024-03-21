using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Invoiceinfo
    {
        public Invoiceinfo(int id, int invoiceid, int itemid, float qty, float dave)
        {
            this.Id = id;
            this.Invoiceid = invoiceid;
            this.Itemid = itemid;
            this.Qty = qty;
            this.Dave = dave;
        }
        public Invoiceinfo(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Invoiceid = Convert.ToInt32(row["invoiceid"]);
            this.Itemid = Convert.ToInt32(row["itemid"]);
            this.Qty = row["qty"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["qty"]);
            this.Dave = row["qty"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["dave"]);
        }

        private int id;
        private int invoiceid;
        private int itemid;
        private float qty;
        private float dave;

        public int Id { get => id; set => id = value; }
        public int Invoiceid { get => invoiceid; set => invoiceid = value; }
        public int Itemid { get => itemid; set => itemid = value; }
        public float Qty { get => qty; set => qty = value; }
        public float Dave { get => dave; set => dave = value; }
    }
}
