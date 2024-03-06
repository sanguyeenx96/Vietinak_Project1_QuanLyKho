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
    public class DanhsachnguyenvatlieuDAO
    {
        private static DanhsachnguyenvatlieuDAO instance;
        public static DanhsachnguyenvatlieuDAO Instance
        {
            get { if (instance == null) instance = new DanhsachnguyenvatlieuDAO(); return DanhsachnguyenvatlieuDAO.instance; }
            private set { DanhsachnguyenvatlieuDAO.instance = value; }
        }
        private DanhsachnguyenvatlieuDAO() { }
        public List<Danhsachnguyenvatlieu> LoadTableList_Danhsachnguyenvatlieu()
        {
            List<Danhsachnguyenvatlieu> tableList = new List<Danhsachnguyenvatlieu>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbldanhsachnguyenvatlieu");
            foreach (DataRow item in data.Rows)
            {
                Danhsachnguyenvatlieu table = new Danhsachnguyenvatlieu(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool Create(string code, int materialno, string suppliername, string materialppc,
          string materialvtn, string maker, string addressiso, string addresscoabox,
          bool diachitrencoacotrenisokhong, string isoiatfcertificate, string expirydate, string note,
          string vtncode, string itemcode, string vietnamesename, string unit, string unitprice, string currency)
        {
            string checkQuery1 = string.Format("SELECT COUNT(*) FROM dbo.tbldanhsachnguyenvatlieu WHERE materialppc = N'{0}'", materialppc);
            string checkQuery2 = string.Format("SELECT COUNT(*) FROM dbo.tbldanhsachnguyenvatlieu WHERE materialvtn = N'{0}'", materialvtn);
            int existing1 = (int)DataProvider.Instance.ExecuteScalar(checkQuery1);
            int existing2 = (int)DataProvider.Instance.ExecuteScalar(checkQuery2);
            if (existing1 > 0)
            {
                MessageBox.Show("Mã Material PPC đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (existing2 > 0)
            {
                MessageBox.Show("Mã Material VTN đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.tbldanhsachnguyenvatlieu (code, materialno, suppliername, materialppc," +
                " materialvtn, maker, addressiso, addresscoabox, diachitrencoacotrenisokhong, isoiatfcertificate, expirydate, note, vtncode, itemcode, vietnamesename," +
                " unit, unitprice, currency) " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}'" +
                ", N'{13}', N'{14}', N'{15}', N'{16}', N'{17}')",
                code, materialno, suppliername, materialppc, materialvtn, maker, addressiso, addresscoabox, diachitrencoacotrenisokhong,
                isoiatfcertificate, expirydate, note, vtncode, itemcode,
                vietnamesename, unit, unitprice, currency);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool Delete(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.tbldanhsachnguyenvatlieu WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thông tin vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool Update(int id, string currentmaterialvtn, string currentmaterialppc, string code, int materialno, string suppliername, string materialppc,
          string materialvtn, string maker, string addressiso, string addresscoabox,
          bool diachitrencoacotrenisokhong, string isoiatfcertificate, string expirydate, string note,
          string vtncode, string itemcode, string vietnamesename, string unit, string unitprice, string currency)
        {
            try
            {
                if (materialvtn != currentmaterialvtn)
                {
                    string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbldanhsachnguyenvatlieu WHERE materialvtn = N'{0}'", materialvtn);
                    int existingmaterialvtnCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                    if (existingmaterialvtnCount > 0)
                    {
                        MessageBox.Show("Mã vật tư materialvtn mới đã bị trùng trong cơ sở dữ liệu!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; // Trả về false để ngăn không cho tiếp tục thực hiện thêm
                    }
                }
                if (materialppc != currentmaterialppc)
                {
                    string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbldanhsachnguyenvatlieu WHERE materialppc = N'{0}'", materialppc);
                    int existingmaterialvtnCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                    if (existingmaterialvtnCount > 0)
                    {
                        MessageBox.Show("Mã vật tư materialppc mới đã bị trùng trong cơ sở dữ liệu!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; // Trả về false để ngăn không cho tiếp tục thực hiện thêm
                    }
                }

                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbldanhsachnguyenvatlieu SET code = N'{0}', " +
                    "materialno = N'{1}', suppliername = N'{2}', materialppc = N'{3}', materialvtn = N'{4}'," +
                    " maker = N'{5}', addressiso = N'{6}', addresscoabox = N'{7}', " +
                    "diachitrencoacotrenisokhong = N'{8}', isoiatfcertificate = N'{9}'," +
                    " expirydate = N'{10}', note = N'{11}', vtncode = N'{12}', itemcode = N'{13}'," +
                    " vietnamesename = N'{14}',unit = N'{15}', unitprice = N'{16}', currency = N'{17}' " +
                    "WHERE id = N'{18}'", code, materialno, suppliername, materialppc, materialvtn, maker,
                    addressiso, addresscoabox, diachitrencoacotrenisokhong,
                    isoiatfcertificate, expirydate, note, vtncode, itemcode,
                    vietnamesename, unit, unitprice, currency, id);
                    int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin vật tư!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin vật tư: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
