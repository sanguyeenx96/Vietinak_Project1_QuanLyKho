using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Po
    {
        public Po(int id, string no,string code, string dept, string sec, string fromdate, string pageno,
            string orderno, string address, string tel, string attn, string fax, string issuedate,
            string paymentterm, string deliveryterm, string shippingmethod, string currency, string manv, string hoten, string bophan,
            string ngaygio)
        {
            this.Id = id;
            this.No = no;
            this.Code = code;
            this.Dept = dept;
            this.Sec = sec;
            this.Fromdate = fromdate;
            this.Pageno = pageno;
            this.Orderno = orderno;
            this.Address = address;
            this.Tel = tel;
            this.Attn = attn;
            this.Fax = fax;
            this.Issuedate = issuedate;
            this.Paymentterm = paymentterm;
            this.Deliveryterm = deliveryterm;
            this.Shippingmethod = shippingmethod;
            this.Currency = currency;
            this.Manv = manv;
            this.Hoten = hoten;
            this.Bophan = bophan;
            this.Ngaygio = ngaygio;
        }
        public Po(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.No = row["no"].ToString();
            this.Code = row["code"].ToString();
            this.Dept = row["dept"].ToString();
            this.Sec = row["sec"].ToString();
            this.Fromdate = row["fromdate"].ToString();
            this.Pageno = row["pageno"].ToString();
            this.Orderno = row["orderno"].ToString();
            this.Address = row["address"].ToString();
            this.Tel = row["tel"].ToString();
            this.Attn = row["attn"].ToString();
            this.Fax = row["fax"].ToString();
            this.Issuedate = row["issuedate"].ToString();
            this.Paymentterm = row["paymentterm"].ToString();
            this.Deliveryterm = row["deliveryterm"].ToString();
            this.Shippingmethod = row["shippingmethod"].ToString();
            this.Currency = row["currency"].ToString();
            this.Manv = row["manv"].ToString();
            this.Hoten = row["hoten"].ToString();
            this.Bophan = row["bophan"].ToString();
            this.Ngaygio = row["ngaygio"].ToString();
        }

        private int id;
        private string no;
        private string code;
        private string dept;
        private string sec;
        private string fromdate;
        private string pageno;
        private string orderno;
        private string address;
        private string tel;
        private string attn;
        private string fax;
        private string issuedate;
        private string paymentterm;
        private string deliveryterm;
        private string shippingmethod;
        private string currency;
        private string manv;
        private string hoten;
        private string bophan;
        private string ngaygio;

        public int Id { get => id; set => id = value; }
        public string No { get => no; set => no = value; }
        public string Code { get => code; set => code = value; }
        public string Dept { get => dept; set => dept = value; }
        public string Sec { get => sec; set => sec = value; }
        public string Fromdate { get => fromdate; set => fromdate = value; }
        public string Pageno { get => pageno; set => pageno = value; }
        public string Orderno { get => orderno; set => orderno = value; }
        public string Address { get => address; set => address = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Attn { get => attn; set => attn = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Issuedate { get => issuedate; set => issuedate = value; }
        public string Paymentterm { get => paymentterm; set => paymentterm = value; }
        public string Deliveryterm { get => deliveryterm; set => deliveryterm = value; }
        public string Shippingmethod { get => shippingmethod; set => shippingmethod = value; }
        public string Currency { get => currency; set => currency = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Bophan { get => bophan; set => bophan = value; }
        public string Ngaygio { get => ngaygio; set => ngaygio = value; }
    }
}
