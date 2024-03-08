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
        public Lichsunhapchitiet(int id, int lichsunhapid,string mavattu,string vitri, string lotno, float soluong,float conlai,
            string donvi, string hansudung, string ngaygionhap, string ngaygionghiemthu, string ngaygioqccheck,
            string tennguoithaotacnghiemthu, string manhanviennghiemthu, string bophannghiemthu,
            string tennguoithaotacqccheck, string manhanvienqccheck, string bophanqccheck)
        {
            this.Id = id;
            this.Lichsunhapid = lichsunhapid;
            this.Mavattu = mavattu;
            this.Vitri = vitri;
            this.Lotno = lotno;
            this.Soluong = soluong;
            this.Conlai = conlai;
            this.Donvi = donvi;
            this.Hansudung = hansudung;
            this.Ngaygionhap = ngaygionhap;
            this.Ngaygionghiemthu = ngaygionghiemthu;
            this.Ngaygioqccheck = ngaygioqccheck;
            this.Tennguoithaotacnghiemthu = tennguoithaotacnghiemthu;
            this.Manhanviennghiemthu = manhanviennghiemthu;
            this.Bophannghiemthu = bophannghiemthu;
            this.Tennguoithaotacqccheck = tennguoithaotacqccheck;
            this.Manhanvienqccheck = manhanvienqccheck;
            this.Bophanqccheck = bophanqccheck;
        }

        public Lichsunhapchitiet(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Lichsunhapid = Convert.ToInt32(row["lichsunhapid"]);
            this.Mavattu = row["mavattu"].ToString();
            this.Vitri = row["vitri"].ToString();
            this.Lotno = row["lotno"].ToString();
            this.Soluong = row["soluong"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluong"]);
            this.Conlai = row["conlai"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["conlai"]);
            this.Donvi = row["donvi"].ToString();
            this.Hansudung = row["hansudung"].ToString();
            this.Ngaygionhap = row["ngaygionhap"].ToString();
            this.Ngaygionghiemthu = row["ngaygionghiemthu"].ToString();
            this.Ngaygioqccheck = row["ngaygioqccheck"].ToString();
            this.Tennguoithaotacnghiemthu = row["tennguoithaotacnghiemthu"].ToString();
            this.Manhanviennghiemthu = row["manhanviennghiemthu"].ToString();
            this.Bophannghiemthu = row["bophannghiemthu"].ToString();
            this.Tennguoithaotacqccheck = row["tennguoithaotacqccheck"].ToString();
            this.Manhanvienqccheck = row["manhanvienqccheck"].ToString();
            this.Bophanqccheck = row["bophanqccheck"].ToString();
        }

        private int id;
        private int lichsunhapid;
        private string mavattu;
        private string vitri;
        private string lotno;
        private float soluong;
        private float conlai;
        private string donvi;
        private string hansudung;
        private string ngaygionhap;
        private string ngaygionghiemthu;
        private string ngaygioqccheck;
        private string tennguoithaotacnghiemthu;
        private string manhanviennghiemthu;
        private string bophannghiemthu;
        private string tennguoithaotacqccheck;
        private string manhanvienqccheck;
        private string bophanqccheck;

        public int Id { get => id; set => id = value; }
        public int Lichsunhapid { get => lichsunhapid; set => lichsunhapid = value; }
        public string Mavattu { get => mavattu; set => mavattu = value; }
        public string Vitri { get => vitri; set => vitri = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public float Soluong { get => soluong; set => soluong = value; }
        public float Conlai { get => conlai; set => conlai = value; }
        public string Donvi { get => donvi; set => donvi = value; }
        public string Hansudung { get => hansudung; set => hansudung = value; }
        public string Ngaygionhap { get => ngaygionhap; set => ngaygionhap = value; }
        public string Ngaygionghiemthu { get => ngaygionghiemthu; set => ngaygionghiemthu = value; }
        public string Ngaygioqccheck { get => ngaygioqccheck; set => ngaygioqccheck = value; }
        public string Tennguoithaotacnghiemthu { get => tennguoithaotacnghiemthu; set => tennguoithaotacnghiemthu = value; }
        public string Manhanviennghiemthu { get => manhanviennghiemthu; set => manhanviennghiemthu = value; }
        public string Bophannghiemthu { get => bophannghiemthu; set => bophannghiemthu = value; }
        public string Tennguoithaotacqccheck { get => tennguoithaotacqccheck; set => tennguoithaotacqccheck = value; }
        public string Manhanvienqccheck { get => manhanvienqccheck; set => manhanvienqccheck = value; }
        public string Bophanqccheck { get => bophanqccheck; set => bophanqccheck = value; }
    }
}
