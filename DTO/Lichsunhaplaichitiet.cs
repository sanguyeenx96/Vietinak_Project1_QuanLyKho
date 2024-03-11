using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Lichsunhaplaichitiet
    {
        public Lichsunhaplaichitiet(int id, int lichsunhapid, string mavattu, string vitri, string invoiceno,
            string partno, string lotno, float soluong,
          string donvi, string ngaygionhap, string ngaygionghiemthu,
          string tennguoithaotacnghiemthu, string manhanviennghiemthu, string bophannghiemthu)
        {
            this.Id = id;
            this.Lichsunhapid = lichsunhapid;
            this.Mavattu = mavattu;
            this.Vitri = vitri;
            this.Invoiceno = invoiceno;
            this.Partno = partno;
            this.Lotno = lotno;
            this.Soluong = soluong;
            this.Donvi = donvi;
            this.Ngaygionhap = ngaygionhap;
            this.Ngaygionghiemthu = ngaygionghiemthu;
            this.Tennguoithaotacnghiemthu = tennguoithaotacnghiemthu;
            this.Manhanviennghiemthu = manhanviennghiemthu;
            this.Bophannghiemthu = bophannghiemthu;
        }

        public Lichsunhaplaichitiet(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Lichsunhapid = Convert.ToInt32(row["lichsunhapid"]);
            this.Mavattu = row["mavattu"].ToString();
            this.Vitri = row["vitri"].ToString();
            this.Invoiceno = row["invoiceno"].ToString();
            this.Partno = row["partno"].ToString();
            this.Lotno = row["lotno"].ToString();
            this.Soluong = row["soluong"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluong"]);
            this.Donvi = row["donvi"].ToString();
            this.Ngaygionhap = row["ngaygionhap"].ToString();
            this.Ngaygionghiemthu = row["ngaygionghiemthu"].ToString();
            this.Tennguoithaotacnghiemthu = row["tennguoithaotacnghiemthu"].ToString();
            this.Manhanviennghiemthu = row["manhanviennghiemthu"].ToString();
            this.Bophannghiemthu = row["bophannghiemthu"].ToString();
        }

        private int id;
        private int lichsunhapid;
        private string mavattu;
        private string vitri;
        private string invoiceno;
        private string partno;
        private string lotno;
        private float soluong;
        private string donvi;
        private string ngaygionhap;
        private string ngaygionghiemthu;
        private string tennguoithaotacnghiemthu;
        private string manhanviennghiemthu;
        private string bophannghiemthu;

        public int Id { get => id; set => id = value; }
        public int Lichsunhapid { get => lichsunhapid; set => lichsunhapid = value; }
        public string Mavattu { get => mavattu; set => mavattu = value; }
        public string Vitri { get => vitri; set => vitri = value; }
        public string Invoiceno { get => invoiceno; set => invoiceno = value; }
        public string Partno { get => partno; set => partno = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public float Soluong { get => soluong; set => soluong = value; }
        public string Donvi { get => donvi; set => donvi = value; }
        public string Ngaygionhap { get => ngaygionhap; set => ngaygionhap = value; }
        public string Ngaygionghiemthu { get => ngaygionghiemthu; set => ngaygionghiemthu = value; }
        public string Tennguoithaotacnghiemthu { get => tennguoithaotacnghiemthu; set => tennguoithaotacnghiemthu = value; }
        public string Manhanviennghiemthu { get => manhanviennghiemthu; set => manhanviennghiemthu = value; }
        public string Bophannghiemthu { get => bophannghiemthu; set => bophannghiemthu = value; }
    }
}
