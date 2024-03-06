using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Thongtinvattu
    {
        public Thongtinvattu(int id, string mavattu, string donvi, float kgtrenbao,
            string diengiai, float tonkhovtn, float tonkhodrg)
        {
            this.Id = id;
            this.Mavattu = mavattu;
            this.Donvi = donvi;
            this.Kgtrenbao = kgtrenbao;
            this.Diengiai = diengiai;
            this.Tonkhovtn = tonkhovtn;
            this.Tonkhodrg = tonkhodrg;
        }

        public Thongtinvattu(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Mavattu = row["mavattu"].ToString(); 
            this.Donvi = row["donvi"].ToString();
            this.Kgtrenbao = (float)Convert.ToDouble(row["kgtrenbao"]);
            this.Diengiai = row["diengiai"].ToString();
            this.Tonkhovtn = (float)Convert.ToDouble(row["tonkhovtn"]);
            this.Tonkhodrg = (float)Convert.ToDouble(row["tonkhodrg"]);
        }

        public Thongtinvattu()
        {
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private string mavattu;
        public string Mavattu
        {
            get { return mavattu; }
            set { mavattu = value; }
        }

        private string donvi;
        public string Donvi
        {
            get { return donvi; }
            set { donvi = value; }
        }

        private float kgtrenbao;
        public float Kgtrenbao
        {
            get { return kgtrenbao; }
            set { kgtrenbao = value; }
        }

        private string diengiai;
        public string Diengiai
        {
            get { return diengiai; }
            set { diengiai = value; }
        }

        private float tonkhovtn;
        public float Tonkhovtn
        {
            get { return tonkhovtn; }
            set { tonkhovtn = value; }
        }

        private float tonkhodrg;
        public float Tonkhodrg
        {
            get { return tonkhodrg; }
            set { tonkhodrg = value; }
        }
    }
}
