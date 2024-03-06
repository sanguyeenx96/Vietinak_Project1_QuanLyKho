using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Vietinak_Kho.DTO
{
    public class Lichsunhapxuat
    {
        public Lichsunhapxuat(int id, int vattuid, string mavattu, string donvi, string tennguoithaotac,
            string manhanvien, string bophan, string loaithaotac, string thoigian, 
            float soluongnhap, string nhapvaokho, float tonkhotruocnhapVTN, float tonkhosaunhapVTN,
            float tonkhotruocnhapDRG, float tonkhosaunhapDRG,float soluongxuat, string mucdichxuat, float tonkhotruocxuatVTN,
            float tonkhosauxuatVTN, float tonkhotruocxuatDRG,float tonkhosauxuatDRG,string trangthai)
        {
            this.Id = id;
            this.Vattuid = vattuid;
            this.Mavattu = mavattu;
            this.Donvi = donvi;
            this.Tennguoithaotac = tennguoithaotac;
            this.Manhanvien = manhanvien;
            this.Bophan = bophan;
            this.Loaithaotac = loaithaotac;
            this.Thoigian = thoigian;
            this.Soluongnhap = soluongnhap;
            this.Nhapvaokho = nhapvaokho;
            this.TonkhotruocnhapVTN = tonkhotruocnhapVTN;
            this.TonkhosaunhapVTN = tonkhosaunhapVTN;
            this.TonkhotruocnhapDRG = tonkhotruocnhapDRG;
            this.TonkhosaunhapDRG = tonkhosaunhapDRG;
            this.Soluongxuat = soluongxuat;
            this.Mucdichxuat = mucdichxuat;
            this.TonkhotruocxuatVTN = tonkhotruocxuatVTN;
            this.TonkhosauxuatVTN = tonkhosauxuatVTN;
            this.TonkhotruocxuatDRG = tonkhotruocxuatDRG;
            this.TonkhosauxuatDRG = tonkhosauxuatDRG;
            this.Trangthai = trangthai;
        }
        public Lichsunhapxuat(DataRow row)
        {
            // Kiểm tra và gán giá trị cho các thuộc tính
            this.Id = Convert.ToInt32(row["id"]);
            this.Trangthai = row["trangthai"].ToString();
            this.Vattuid = Convert.ToInt32(row["vattuid"]);
            this.Mavattu = row["mavattu"].ToString();
            this.Donvi = row["donvi"].ToString();
            this.Tennguoithaotac = row["tennguoithaotac"].ToString();
            this.Manhanvien = row["manhanvien"].ToString();
            this.Bophan = row["bophan"].ToString();
            this.Loaithaotac = row["loaithaotac"].ToString();
            this.Thoigian = row["thoigian"].ToString();

            // Kiểm tra và chuyển đổi giá trị từ DBNull sang float
            this.Soluongnhap = row["soluongnhap"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluongnhap"]);
            this.Nhapvaokho = row["nhapvaokho"].ToString();
            this.TonkhotruocnhapVTN = row["tonkhotruocnhapVTN"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhotruocnhapVTN"]);
            this.TonkhosaunhapVTN = row["tonkhosaunhapVTN"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhosaunhapVTN"]);
            this.TonkhotruocnhapDRG = row["tonkhotruocnhapDRG"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhotruocnhapDRG"]);
            this.TonkhosaunhapDRG = row["tonkhosaunhapDRG"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhosaunhapDRG"]);
            this.Soluongxuat = row["soluongxuat"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["soluongxuat"]);
            this.Mucdichxuat = row["mucdichxuat"].ToString();
            this.TonkhotruocxuatVTN = row["tonkhotruocxuatVTN"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhotruocxuatVTN"]);
            this.TonkhosauxuatVTN = row["tonkhosauxuatVTN"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhosauxuatVTN"]);
            this.TonkhotruocxuatDRG = row["tonkhotruocxuatDRG"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhotruocxuatDRG"]);
            this.TonkhosauxuatDRG = row["tonkhosauxuatDRG"] == DBNull.Value ? 0 : (float)Convert.ToDouble(row["tonkhosauxuatDRG"]);
        }

        private int id;
        private int vattuid;
        private string mavattu;
        private string donvi;
        private string tennguoithaotac;
        private string manhanvien;
        private string bophan;
        private string loaithaotac;
        private string thoigian;
        private float soluongnhap;
        private string nhapvaokho;
        private float tonkhotruocnhapVTN;
        private float tonkhosaunhapVTN;
        private float tonkhotruocnhapDRG;
        private float tonkhosaunhapDRG;

        private float soluongxuat;
        private string mucdichxuat;
        private float tonkhotruocxuatVTN;
        private float tonkhosauxuatVTN;
        private float tonkhotruocxuatDRG;
        private float tonkhosauxuatDRG;
        private string trangthai;

        public int Id { get => id; set => id = value; }
        public int Vattuid { get => vattuid; set => vattuid = value; }
        public string Mavattu { get => mavattu; set => mavattu = value; }
        public string Donvi { get => donvi; set => donvi = value; }
        public string Tennguoithaotac { get => tennguoithaotac; set => tennguoithaotac = value; }
        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public string Bophan { get => bophan; set => bophan = value; }
        public string Loaithaotac { get => loaithaotac; set => loaithaotac = value; }
        public string Thoigian { get => thoigian; set => thoigian = value; }
        public float Soluongnhap { get => soluongnhap; set => soluongnhap = value; }
        public string Nhapvaokho { get => nhapvaokho; set => nhapvaokho = value; }
        public float TonkhotruocnhapVTN { get => tonkhotruocnhapVTN; set => tonkhotruocnhapVTN = value; }
        public float TonkhosaunhapVTN { get => tonkhosaunhapVTN; set => tonkhosaunhapVTN = value; }
        public float TonkhotruocnhapDRG { get => tonkhotruocnhapDRG; set => tonkhotruocnhapDRG = value; }
        public float TonkhosaunhapDRG { get => tonkhosaunhapDRG; set => tonkhosaunhapDRG = value; }
        public float Soluongxuat { get => soluongxuat; set => soluongxuat = value; }
        public string Mucdichxuat { get => mucdichxuat; set => mucdichxuat = value; }
        public float TonkhotruocxuatVTN { get => tonkhotruocxuatVTN; set => tonkhotruocxuatVTN = value; }
        public float TonkhosauxuatVTN { get => tonkhosauxuatVTN; set => tonkhosauxuatVTN = value; }
        public float TonkhotruocxuatDRG { get => tonkhotruocxuatDRG; set => tonkhotruocxuatDRG = value; }
        public float TonkhosauxuatDRG { get => tonkhosauxuatDRG; set => tonkhosauxuatDRG = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }

    }
}
