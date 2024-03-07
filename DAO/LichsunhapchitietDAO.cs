using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.DAO
{
    public class LichsunhapchitietDAO
    {
        private static LichsunhapchitietDAO instance;
        public static LichsunhapchitietDAO Instance
        {
            get { if (instance == null) instance = new LichsunhapchitietDAO(); return LichsunhapchitietDAO.instance; }
            private set { LichsunhapchitietDAO.instance = value; }
        }
        private LichsunhapchitietDAO() { }

        public List<Lichsunhapchitiet> LoadTableList_Lichsunghiemthu()
        {
            List<Lichsunhapchitiet> tableList = new List<Lichsunhapchitiet>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapchitiet");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapchitiet table = new Lichsunhapchitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<Lichsunhapchitiet> LoadTableList_Lichsunghiemthu(int id)
        {
            List<Lichsunhapchitiet> tableList = new List<Lichsunhapchitiet>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapchitiet WHERE lichsunhapid ='" + id+"'");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapchitiet table = new Lichsunhapchitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Create(int lichsunhapid, string mavattu, string lotno, string soluong, string ngaygio, string tennguoithaotac,
         string manhanvien, string bophan)
        {        
            string query = string.Format("INSERT dbo.tbllichsunhapchitiet (lichsunhapid, mavattu, lotno, soluong, ngaygio,tennguoithaotac,manhanvien,bophan) VALUES  (N'{0}', N'{1}', N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}')", lichsunhapid, mavattu, lotno, soluong, ngaygio, tennguoithaotac, manhanvien, bophan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
