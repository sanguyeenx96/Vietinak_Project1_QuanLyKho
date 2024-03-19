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
    public class PoInfoDAO
    {
        private static PoInfoDAO instance;
        public static PoInfoDAO Instance
        {
            get { if (instance == null) instance = new PoInfoDAO(); return PoInfoDAO.instance; }
            private set { PoInfoDAO.instance = value; }
        }
        private PoInfoDAO() { }
        public List<PoInfo> LoadTableList_PoInfoFromPo(int id)
        {
            List<PoInfo> tableList = new List<PoInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.poinfo WHERE poid = '"+id+"' ");
            foreach (DataRow item in data.Rows)
            {
                PoInfo table = new PoInfo(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Create(int poid, string itemcode, string description, string partno, string qty, string unit,
            string price, string amount, string group, string requesteddepartment, string factory, string etd,
            string total, string remark)
        {          
            string query = string.Format("INSERT dbo.poinfo (poid, itemcode, description, partno," +
                " qty, unit, price, amount, [group], requesteddepartment," +
                " factory, etd, total, remark) " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}'" +
                ", N'{13}')",
                poid, itemcode, description, partno, qty, unit, price, amount, group, requesteddepartment, factory, etd, total, remark);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
