using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.DAO
{
    public class ThongtinvattuDAO
    {
        private static ThongtinvattuDAO instance;
        public static ThongtinvattuDAO Instance
        {
            get { if (instance == null) instance = new ThongtinvattuDAO(); return ThongtinvattuDAO.instance; }
            private set { ThongtinvattuDAO.instance = value; }
        }
        private ThongtinvattuDAO() { }
        public List<Thongtinvattu> LoadTableList_Thongtinvattu()
        {
            List<Thongtinvattu> tableList = new List<Thongtinvattu>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tblthongtinvattu");
            foreach (DataRow item in data.Rows)
            {
                Thongtinvattu table = new Thongtinvattu(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Thongtinvattu> LoadThongtinvattu(string mavattu)
        {
            List<Thongtinvattu> tableList = new List<Thongtinvattu>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tblthongtinvattu WHERE mavattu =N'"+mavattu+"' ");
            foreach (DataRow item in data.Rows)
            {
                Thongtinvattu table = new Thongtinvattu(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Create(string mavattu, string donvi, string kgtrenbao, string diengiai,
            string tonkhovtn, string tonkhodrg)
        {
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tblthongtinvattu WHERE mavattu = N'{0}'", mavattu);
            int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (existingUserCount > 0)
            {
                MessageBox.Show("Mã vật tư này đã tồn tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = string.Format("INSERT dbo.tblthongtinvattu (mavattu, donvi, kgtrenbao, diengiai, tonkhovtn, tonkhodrg) " +
                "VALUES  (N'{0}', N'{1}', N'{2}',N'{3}', N'{4}', N'{5}')",
                mavattu, donvi, kgtrenbao, diengiai, tonkhovtn, tonkhodrg);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool Update(int id, string mavattu, string donvi, string kgtrenbao, string diengiai,
            string tonkhovtn, string tonkhodrg, string currentMavattu)
        {
            try
            {
                if (mavattu != currentMavattu)
                {
                    // Xây dựng câu truy vấn kiểm tra
                    string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tblthongtinvattu WHERE mavattu = N'{0}'", mavattu);
                    // Thực hiện truy vấn
                    int existingMavattuCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                    // Kiểm tra kết quả trả về từ truy vấn
                    if (existingMavattuCount > 0)
                    {
                        // Hiển thị thông báo khi mã vật tư mới đã tồn tại trong cơ sở dữ liệu
                        MessageBox.Show("Mã vật tư mới đã bị trùng trong cơ sở dữ liệu!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; // Trả về false để ngăn không cho tiếp tục thực hiện thêm
                    }
                }             
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tblthongtinvattu SET mavattu = N'{0}', donvi = N'{1}', kgtrenbao = N'{2}', diengiai = N'{3}', tonkhovtn = N'{4}', tonkhodrg = N'{5}' " +
                    "WHERE id = N'{6}'", mavattu, donvi, kgtrenbao, diengiai, tonkhovtn, tonkhodrg, id);
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

        public bool Delete(int id)
        {
            try
            {
                string deleteQuery = $"DELETE FROM dbo.tblthongtinvattu WHERE id = {id}";
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thông tin vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateTonkho(int id, string newtonkhoVTN, string newtonkhoDRG)
        {
            try
            {
                string query = string.Format("UPDATE dbo.tblthongtinvattu SET tonkhovtn = N'{0}', tonkhodrg = N'{1}' " +
                    "WHERE id = N'{2}'", newtonkhoVTN, newtonkhoDRG, id);
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
