using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Userlogs
    {
        public Userlogs(int id, int userid, string noidung, string phuongthuc, string ngaygio)
        {
            this.Id = id;
            this.Userid = userid;
            this.Noidung = noidung;
            this.Phuongthuc = phuongthuc;
            this.Ngaygio = ngaygio;
        }

        public Userlogs(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Userid = (int)row["userid"];
            this.Noidung = row["noidung"].ToString();
            this.Phuongthuc = row["phuongthuc"].ToString();
            this.Ngaygio = row["ngaygio"].ToString();

        }

        public Userlogs()
        {
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int userid;
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        private string noidung;
        public string Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }

        private string phuongthuc;
        public string Phuongthuc
        {
            get { return phuongthuc; }
            set { phuongthuc = value; }
        }

        private string ngaygio;
        public string Ngaygio
        {
            get { return ngaygio; }
            set { ngaygio = value; }
        }
    }
}
