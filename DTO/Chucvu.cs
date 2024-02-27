using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Chucvu
    {
        public Chucvu(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Chucvu(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
        }

        public Chucvu()
        {
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
