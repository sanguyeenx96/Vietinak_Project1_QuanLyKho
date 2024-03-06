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
    public class LichsunghiemthuDAO
    {
        private static LichsunghiemthuDAO instance;
        public static LichsunghiemthuDAO Instance
        {
            get { if (instance == null) instance = new LichsunghiemthuDAO(); return LichsunghiemthuDAO.instance; }
            private set { LichsunghiemthuDAO.instance = value; }
        }
        private LichsunghiemthuDAO() { }

        public List<Lichsunghiemthu> LoadTableList_Lichsunghiemthu()
        {
            List<Lichsunghiemthu> tableList = new List<Lichsunghiemthu>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunghiemthu");
            foreach (DataRow item in data.Rows)
            {
                Lichsunghiemthu table = new Lichsunghiemthu(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Create(int lichsunhapid, string lotno, string soluong, string ngaygio)
        {        
            string query = string.Format("INSERT dbo.tbllichsunghiemthu (lichsunhapid, lotno, soluong, ngaygio) VALUES  (N'{0}', N'{1}', N'{2}',N'{3}')", lichsunhapid, lotno, soluong, ngaygio);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
