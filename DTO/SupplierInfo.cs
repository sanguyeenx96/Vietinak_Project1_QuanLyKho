using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class SupplierInfo
    {
        public SupplierInfo(int id, string code, string name, string pic, string tel, string address, string lastupdate)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.Pic = pic;
            this.Tel = tel;
            this.Address = address;
            this.Lastupdate = lastupdate;
        }

        public SupplierInfo()
        {
                   
        }

        public SupplierInfo(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
            this.Pic = row["pic"].ToString();
            this.Tel = row["tel"].ToString();
            this.Address = row["address"].ToString();
            this.Lastupdate = row["lastupdate"].ToString();
        }

        private int id;
        private string code;
        private string name;
        private string pic;
        private string tel;
        private string address;
        private string lastupdate;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Pic { get => pic; set => pic = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Address { get => address; set => address = value; }
        public string Lastupdate { get => lastupdate; set => lastupdate = value; }
    }
}
