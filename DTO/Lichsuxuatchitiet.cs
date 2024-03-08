using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Lichsuxuatchitiet
    {
        public Lichsuxuatchitiet(int id, int lichsuxuatid, string mavattu, string lotno, float soluong, float conlai,
           string donvi, string hansudung, string ngaygioxuat)
        {
            this.Id = id;
            this.Lichsuxuatid = lichsuxuatid;
            this.Mavattu = mavattu;
            this.Lotno = lotno;
            this.Soluong = soluong;
            this.Conlai = conlai;
            this.Donvi = donvi;
            this.Hansudung = hansudung;
            this.Ngaygioxuat = ngaygioxuat;
        }

        public Lichsuxuatchitiet(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Lichsuxuatid = Convert.ToInt32(row["lichsuxuatid"]);
            this.Mavattu = row["mavattu"].ToString();
            this.Lotno = row["lotno"].ToString();
            this.Soluong = row["soluong"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluong"]);
            this.Conlai = row["conlai"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["conlai"]);
            this.Donvi = row["donvi"].ToString();
            this.Hansudung = row["hansudung"].ToString();
            this.Ngaygioxuat = row["ngaygioxuat"].ToString();
        }

        private int id;
        private int lichsuxuatid;
        private string mavattu;
        private string lotno;
        private float soluong;
        private float conlai;
        private string donvi;
        private string hansudung;
        private string ngaygioxuat;

        public int Id { get => id; set => id = value; }
        public int Lichsuxuatid { get => lichsuxuatid; set => lichsuxuatid = value; }
        public string Mavattu { get => mavattu; set => mavattu = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public float Soluong { get => soluong; set => soluong = value; }
        public float Conlai { get => conlai; set => conlai = value; }
        public string Donvi { get => donvi; set => donvi = value; }
        public string Hansudung { get => hansudung; set => hansudung = value; }
        public string Ngaygioxuat { get => ngaygioxuat; set => ngaygioxuat = value; }
    }
}
