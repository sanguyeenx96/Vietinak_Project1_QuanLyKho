using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Lichsunhapchitiet
    {
        public Lichsunhapchitiet(int id, int lichsunhapid,string mavattu, string lotno, float soluong, string hansudung, string ngaygio, string tennguoithaotac,
            string manhanvien, string bophan)
        {
            this.Id = id;
            this.Lichsunhapid = lichsunhapid;
            this.Mavattu = mavattu;
            this.Lotno = lotno;
            this.Soluong = soluong;
            this.Hansudung = hansudung;
            this.Ngaygio = ngaygio;
            this.Tennguoithaotac = tennguoithaotac;
            this.Manhanvien = manhanvien;
            this.Bophan = bophan;
        }

        public Lichsunhapchitiet(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Lichsunhapid = Convert.ToInt32(row["lichsunhapid"]);
            this.Mavattu = row["mavattu"].ToString();
            this.Lotno = row["lotno"].ToString();
            this.Soluong = row["soluong"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluong"]);
            this.Hansudung = row["hansudung"].ToString();
            this.Ngaygio = row["ngaygio"].ToString();
            this.Tennguoithaotac = row["tennguoithaotac"].ToString();
            this.Manhanvien = row["manhanvien"].ToString();
            this.Bophan = row["bophan"].ToString();
        }

        private int id;
        private int lichsunhapid;
        private string mavattu;
        private string lotno;
        private float soluong;
        private string hansudung;
        private string ngaygio;
        private string tennguoithaotac;
        private string manhanvien;
        private string bophan;

        public int Id { get => id; set => id = value; }
        public int Lichsunhapid { get => lichsunhapid; set => lichsunhapid = value; }
        public string Mavattu { get => mavattu; set => mavattu = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public float Soluong { get => soluong; set => soluong = value; }
        public string Hansudung { get => hansudung; set => hansudung = value; }
        public string Ngaygio { get => ngaygio; set => ngaygio = value; }
        public string Tennguoithaotac { get => tennguoithaotac; set => tennguoithaotac = value; }
        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public string Bophan { get => bophan; set => bophan = value; }
    }
}
