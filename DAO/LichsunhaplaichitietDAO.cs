using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.DAO
{
    public class LichsunhaplaichitietDAO
    {
        private static LichsunhaplaichitietDAO instance;

        public static LichsunhaplaichitietDAO Instance
        {
            get { if (instance == null) instance = new LichsunhaplaichitietDAO(); return LichsunhaplaichitietDAO.instance; }
            private set { LichsunhaplaichitietDAO.instance = value; }
        }

        private LichsunhaplaichitietDAO() { }

        public List<Lichsunhaplaichitiet> LoadTableList_Lichsunhap(int lichsunhapid)
        {
            List<Lichsunhaplaichitiet> tableList = new List<Lichsunhaplaichitiet>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhaplaichitiet WHERE lichsunhapid ='" + lichsunhapid + "'  ORDER BY ngaygionhap DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhaplaichitiet table = new Lichsunhaplaichitiet(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Create(int lichsunhapid, string mavattu, string vitri, string invoiceno, string partno, 
            string lotno, string soluong, string donvi, string ngaygionhap, string ngaygionghiemthu,
            string tennguoithaotacnghiemthu,
        string manhanviennghiemthu, string bophannghiemthu)
        {
        string query = string.Format("INSERT dbo.tbllichsunhaplaichitiet (lichsunhapid, mavattu,vitri," +
            " invoiceno, partno, lotno, soluong, donvi, ngaygionhap, ngaygionghiemthu, " +
            "tennguoithaotacnghiemthu,manhanviennghiemthu,bophannghiemthu) VALUES  (N'{0}', N'{1}', N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}')", lichsunhapid, mavattu, vitri, invoiceno, partno, lotno, soluong, donvi, ngaygionhap, ngaygionghiemthu, tennguoithaotacnghiemthu,manhanviennghiemthu,bophannghiemthu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
