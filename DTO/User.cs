using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class User
    {
        public User(int id, string hoten, string manhanvien, string bophan, string chucvu, string matkhau, string role)
        {
            this.Id = id;
            this.Hoten = hoten;
            this.Manhanvien = manhanvien;
            this.Bophan = bophan;
            this.Chucvu = chucvu;
            this.Matkhau = matkhau;
            this.Role = role;
        }

        public User(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Hoten = row["hoten"].ToString();
            this.Manhanvien = row["manhanvien"].ToString();
            this.Bophan = row["bophan"].ToString();
            this.Chucvu = row["chucvu"].ToString();
            this.Matkhau = row["matkhau"].ToString();
            this.Role = row["role"].ToString();
        }

        public User()
        {
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private string hoten;
        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }

        private string manhanvien;
        public string Manhanvien
        {

            get { return manhanvien; }
            set { manhanvien = value; }

        }

        private string bophan;
        public string Bophan
        {

            get { return bophan; }
            set { bophan = value; }

        }

        private string chucvu;
        public string Chucvu
        {

            get { return chucvu; }
            set { chucvu = value; }

        }

        private string matkhau;
        public string Matkhau
        {

            get { return matkhau; }
            set { matkhau = value; }

        }

        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

    }
}
