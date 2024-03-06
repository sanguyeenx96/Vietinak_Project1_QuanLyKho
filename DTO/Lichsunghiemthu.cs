using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Lichsunghiemthu
    {
        public Lichsunghiemthu(int id, int lichsunhapid, string lotno, float soluong, string ngaygio)
        {
            this.Id = id;
            this.Lichsunhapid = lichsunhapid;
            this.Lotno = lotno;
            this.Soluong = soluong;
            this.Ngaygio = ngaygio;
        }

        public Lichsunghiemthu(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Lichsunhapid = Convert.ToInt32(row["lichsunhapid"]);
            this.Lotno = row["lotno"].ToString();
            this.Soluong = row["soluong"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluong"]);
            this.Ngaygio = row["ngaygio"].ToString();

        }

        private int id;
        private int lichsunhapid;
        private string lotno;
        private float soluong;
        private string ngaygio;

        public int Id { get => id; set => id = value; }
        public int Lichsunhapid { get => lichsunhapid; set => lichsunhapid = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public float Soluong { get => soluong; set => soluong = value; }
        public string Ngaygio { get => ngaygio; set => ngaygio = value; }

    }
}
