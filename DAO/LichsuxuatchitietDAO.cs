using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.DAO
{
    public class LichsuxuatchitietDAO
    {
        private static LichsuxuatchitietDAO instance;
        public static LichsuxuatchitietDAO Instance
        {
            get { if (instance == null) instance = new LichsuxuatchitietDAO(); return LichsuxuatchitietDAO.instance; }
            private set { LichsuxuatchitietDAO.instance = value; }
        }
        private LichsuxuatchitietDAO() { }
        public List<Lichsuxuatchitiet> LoadTableList_Lichsuxuatchitiet(int id)
        {
            List<Lichsuxuatchitiet> tableList = new List<Lichsuxuatchitiet>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapchitiet WHERE lichsuxuatid ='" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                Lichsuxuatchitiet table = new Lichsuxuatchitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool Create(int lichsuxuatid, string mavattu, string lotno, string soluong,string conlai, string donvi, string hansudung, string ngaygioxuat)
        {
            string query = string.Format("INSERT dbo.tbllichsuxuatchitiet (lichsuxuatid, mavattu, lotno, soluong, conlai, donvi, hansudung, ngaygioxuat) VALUES  (N'{0}', N'{1}', N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}')", lichsuxuatid, mavattu, lotno, soluong, conlai, donvi, hansudung, ngaygioxuat);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
