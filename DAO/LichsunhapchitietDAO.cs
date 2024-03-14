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
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapchitiet WHERE lichsunhapid ='" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapchitiet table = new Lichsunhapchitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapchitiet> LoadTableList_Lichsunhap(string mavattu)
        {
            List<Lichsunhapchitiet> tableList = new List<Lichsunhapchitiet>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapchitiet WHERE mavattu ='" + mavattu + "'  ORDER BY hansudung");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapchitiet table = new Lichsunhapchitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapchitiet> LoadTableList_Lichsunhaporderbyhsd(string mavattu)
        {
            List<Lichsunhapchitiet> tableList = new List<Lichsunhapchitiet>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapchitiet WHERE mavattu ='" + mavattu + "'  ORDER BY hansudung");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapchitiet table = new Lichsunhapchitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Checktrung(string mavattu, string lotno)
        {
            // Kiểm tra xem lotno của mavattu có bị trùng không
            string queryCheck = string.Format("SELECT COUNT(*) FROM dbo.tbllichsunhapchitiet WHERE lotno = N'{0}' AND mavattu = N'{1}'", lotno, mavattu);
            int count = (int)DataProvider.Instance.ExecuteScalar(queryCheck);
            if (count > 0)
            {
                return false;
            }
            else
            {                
                return true; //Không trùng
            }
        }

        public bool Create(int lichsunhapid, string mavattu, string vitri,string invoiceno, string partno, string lotno, string soluong, string donvi, string ngaygionhap, string ngaygionghiemthu, string tennguoithaotac,
         string manhanvien, string bophan)
        {
            string query = string.Format("INSERT dbo.tbllichsunhapchitiet (lichsunhapid, mavattu,vitri, invoiceno, partno, lotno, soluong, conlai, donvi, ngaygionhap, ngaygionghiemthu, tennguoithaotacnghiemthu,manhanviennghiemthu,bophannghiemthu) VALUES  (N'{0}', N'{1}', N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}')", lichsunhapid, mavattu,vitri, invoiceno, partno, lotno, soluong, soluong, donvi, ngaygionhap, ngaygionghiemthu, tennguoithaotac, manhanvien, bophan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateHSD(int id, string hansudung, string ngaygioqccheck, string tennguoithaotac,
         string manhanvien, string bophan)
        {
            string query = string.Format("UPDATE dbo.tbllichsunhapchitiet SET hansudung = N'{0}', ngaygioqccheck = N'{1}', tennguoithaotacqccheck = N'{2}', manhanvienqccheck = N'{3}', bophanqccheck = N'{4}' WHERE id = N'{5}'", hansudung, ngaygioqccheck, tennguoithaotac, manhanvien, bophan, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTonkho(string soluongtonkho, int id)
        {
            string query = string.Format("UPDATE dbo.tbllichsunhapchitiet SET conlai = N'{0}' WHERE id = N'{1}'", soluongtonkho, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
