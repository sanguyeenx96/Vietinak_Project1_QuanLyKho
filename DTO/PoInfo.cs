using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class PoInfo
    {
        public PoInfo(int id, int poid, string itemcode, string description, string partno, float qty, string unit,
            float price, float amount, string group, string requesteddepartment, string factory, string etd,
            float total, string remark)
        {
            this.Id = id;
            this.Poid = poid;
            this.Itemcode = itemcode;
            this.Description = description;
            this.Partno = partno;
            this.Qty = qty;
            this.Unit = unit;
            this.Price = price;
            this.Amount = amount;
            this.Group = group;
            this.Requesteddepartment = requesteddepartment;
            this.Factory = factory;
            this.Etd = etd;
            this.Total = total;
            this.Remark = remark;
        }

        public PoInfo(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Poid = Convert.ToInt32(row["poid"]);
            this.Itemcode = row["itemcode"].ToString();
            this.Description = row["description"].ToString();
            this.Partno = row["partno"].ToString();
            this.Qty = row["qty"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["qty"]);
            this.Unit = row["unit"].ToString();
            this.Price = row["price"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["price"]);
            this.Amount = row["amount"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["amount"]);
            this.Group = row["group"].ToString();
            this.Requesteddepartment = row["requesteddepartment"].ToString();
            this.Factory = row["factory"].ToString();
            this.Etd = row["etd"].ToString();
            this.Total = row["total"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["total"]);
            this.Remark = row["remark"].ToString();
        }

        private int id;
        private int poid;
        private string itemcode;
        private string description;
        private string partno;
        private float qty;
        private string unit;
        private float price;
        private float amount;
        private string group;
        private string requesteddepartment;
        private string factory;
        private string etd;
        private float total;
        private string remark;

        public int Id { get => id; set => id = value; }
        public int Poid { get => poid; set => poid = value; }
        public string Itemcode { get => itemcode; set => itemcode = value; }
        public string Description { get => description; set => description = value; }
        public string Partno { get => partno; set => partno = value; }
        public float Qty { get => qty; set => qty = value; }
        public string Unit { get => unit; set => unit = value; }
        public float Price { get => price; set => price = value; }
        public float Amount { get => amount; set => amount = value; }
        public string Group { get => group; set => group = value; }
        public string Requesteddepartment { get => requesteddepartment; set => requesteddepartment = value; }
        public string Factory { get => factory; set => factory = value; }
        public string Etd { get => etd; set => etd = value; }
        public float Total { get => total; set => total = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
