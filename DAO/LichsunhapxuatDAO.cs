﻿using System;
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
    public class LichsunhapxuatDAO
    {
        private static LichsunhapxuatDAO instance;
        public static LichsunhapxuatDAO Instance
        {
            get { if (instance == null) instance = new LichsunhapxuatDAO(); return LichsunhapxuatDAO.instance; }
            private set { LichsunhapxuatDAO.instance = value; }
        }
        private LichsunhapxuatDAO() { }

        public List<Lichsunhapxuat> LoadTableList_Lichsunhapxuat()
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapxuat");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<Lichsunhapxuat> LoadTableList_Lichsunhapxuat(string mavattu)
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapxuat WHERE mavattu ='"+mavattu+ "' ORDER BY Thoigian DESC ");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsunhaphomnay()
        {
            string todayDate = DateTime.Now.ToString("yyyy/MM/dd"); // Chuỗi ngày hôm nay
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery
            ("SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Nhập' AND Thoigian LIKE '" + todayDate + "%' ORDER BY Thoigian DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsunhaptheongay(string ngay)
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery
            ("SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Nhập' AND Thoigian LIKE '" + ngay + "%' ORDER BY Thoigian DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsunhaptheokhoangthoigian(string tungay, string denngay)
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery
            ("SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Nhập' AND Thoigian BETWEEN('" + tungay + "') AND('" + denngay + "') ORDER BY Thoigian DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool Nhap(int vattuid, string mavattu,string invoiceno, string partno,string donvi, string tennguoithaotac,
         string manhanvien, string bophan, string loaithaotac, string thoigian,
         string soluongnhap, string nhapvaokho, string tonkhotruocnhapVTN, string tonkhosaunhapVTN,
         string tonkhotruocnhapDRG, string tonkhosaunhapDRG,string trangthai)
        {
            string query = string.Format("INSERT INTO dbo.tbllichsunhapxuat " +
            "(vattuid, mavattu, invoiceno, partno, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac," +
            " thoigian, soluongnhap, nhapvaokho,soluongdanghiemthu, tonkhotruocnhapVTN, tonkhosaunhapVTN," +
            " tonkhotruocnhapDRG, tonkhosaunhapDRG, trangthai) " +
            "VALUES " +
            "(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}')",
            vattuid, mavattu, invoiceno, partno, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac,
            thoigian, soluongnhap, nhapvaokho, 0, tonkhotruocnhapVTN, tonkhosaunhapVTN,
            tonkhotruocnhapDRG, tonkhosaunhapDRG, trangthai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int NhapReturnId(int vattuid, string mavattu, string invoiceno, string partno, string donvi, string tennguoithaotac,
         string manhanvien, string bophan, string loaithaotac, string thoigian,
         string soluongnhap, string nhapvaokho, string tonkhotruocnhapVTN, string tonkhosaunhapVTN,
         string tonkhotruocnhapDRG, string tonkhosaunhapDRG, string trangthai)
        {
            string query = string.Format("INSERT INTO dbo.tbllichsunhapxuat " +
            "(vattuid, mavattu, invoiceno, partno, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac," +
            " thoigian, soluongnhap, nhapvaokho,soluongdanghiemthu, tonkhotruocnhapVTN, tonkhosaunhapVTN," +
            " tonkhotruocnhapDRG, tonkhosaunhapDRG, trangthai) " +
            "OUTPUT INSERTED.ID " +
            "VALUES " +
            "(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}')",
            vattuid, mavattu, invoiceno, partno, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac,
            thoigian, soluongnhap, nhapvaokho, 0, tonkhotruocnhapVTN, tonkhosaunhapVTN,
            tonkhotruocnhapDRG, tonkhosaunhapDRG, trangthai);

            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public int Nhaplai(int vattuid, string mavattu, string invoiceno, string partno, string donvi, string tennguoithaotac,
        string manhanvien, string bophan, string loaithaotac, string thoigian,
        string soluongnhap, string nhapvaokho, string tonkhotruocnhapVTN, string tonkhosaunhapVTN,
        string tonkhotruocnhapDRG, string tonkhosaunhapDRG, string trangthai)
        {
            string query = string.Format("INSERT INTO dbo.tbllichsunhapxuat " +
                "(vattuid, mavattu, invoiceno, partno, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac," +
                " thoigian, soluongnhap, nhapvaokho, tonkhotruocnhapVTN, tonkhosaunhapVTN," +
                " tonkhotruocnhapDRG, tonkhosaunhapDRG, trangthai) " +
                "OUTPUT INSERTED.ID " +
                "VALUES " +
                "(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}',N'{13}',N'{14}',N'{15}',N'{16}')",
                vattuid, mavattu, invoiceno, partno, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac,
                thoigian, soluongnhap, nhapvaokho, tonkhotruocnhapVTN, tonkhosaunhapVTN,
                tonkhotruocnhapDRG, tonkhosaunhapDRG, trangthai);

            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }


        public bool Xuat(int vattuid, string mavattu, string donvi, string tennguoithaotac,
        string manhanvien, string bophan, string loaithaotac, string thoigian,
        string soluongxuat, string mucdichxuat, string tonkhotruocxuatVTN, string tonkhosauxuatVTN,
        string tonkhotruocxuatDRG, string tonkhosauxuatDRG,string trangthai)
        {
            string query = string.Format("INSERT INTO dbo.tbllichsunhapxuat " +
                "(vattuid, mavattu, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac," +
                " thoigian, soluongxuat, mucdichxuat, tonkhotruocxuatVTN, tonkhosauxuatVTN," +
                " tonkhotruocxuatDRG, tonkhosauxuatDRG,trangthai) " +
                "VALUES " +
                "(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}',N'{13}',N'{14}')",
                vattuid, mavattu, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac,
                thoigian, soluongxuat, mucdichxuat, tonkhotruocxuatVTN, tonkhosauxuatVTN,
                tonkhotruocxuatDRG, tonkhosauxuatDRG,trangthai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int XuatReturnId(int vattuid, string mavattu, string donvi, string tennguoithaotac,
        string manhanvien, string bophan, string loaithaotac, string thoigian,
        string soluongxuat, string mucdichxuat, string tonkhotruocxuatVTN, string tonkhosauxuatVTN,
        string tonkhotruocxuatDRG, string tonkhosauxuatDRG, string trangthai)
        {
            string query = string.Format("INSERT INTO dbo.tbllichsunhapxuat " +
                "(vattuid, mavattu, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac," +
                " thoigian, soluongxuat, mucdichxuat, tonkhotruocxuatVTN, tonkhosauxuatVTN," +
                " tonkhotruocxuatDRG, tonkhosauxuatDRG,trangthai) " +
                "OUTPUT INSERTED.ID " +
                "VALUES " +
                "(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}',N'{13}',N'{14}')",
                vattuid, mavattu, donvi, tennguoithaotac, manhanvien, bophan, loaithaotac,
                thoigian, soluongxuat, mucdichxuat, tonkhotruocxuatVTN, tonkhosauxuatVTN,
                tonkhotruocxuatDRG, tonkhosauxuatDRG, trangthai);

            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;      
        }


        public List<Lichsunhapxuat> LoadTableList_Lichsuxuathomnay()
        {
            string todayDate = DateTime.Now.ToString("yyyy/MM/dd"); // Chuỗi ngày hôm nay
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery
("SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Xuất' AND Thoigian LIKE '" + todayDate + "%' ORDER BY Thoigian DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsuxuattheongay(string ngay)
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery
("SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Xuất' AND Thoigian LIKE '" + ngay + "%' ORDER BY Thoigian DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsuxuattheokhoangthoigian(string tungay, string denngay)
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery
("SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Xuất' AND Thoigian BETWEEN('" + tungay + "') AND('" + denngay + "') ORDER BY Thoigian DESC");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsuchonghiemthu()
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapxuat WHERE trangthai= N'CHỜ NGHIỆM THU' OR trangthai = N'NGHIỆM THU MỘT PHẦN' ORDER BY Thoigian");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Lichsunhapxuat> LoadTableList_Lichsuchoqccheck()
        {
            List<Lichsunhapxuat> tableList = new List<Lichsunhapxuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.tbllichsunhapxuat WHERE trangthai= N'CHỜ QC CHECK' OR trangthai = N'NGHIỆM THU MỘT PHẦN' ORDER BY Thoigian");
            foreach (DataRow item in data.Rows)
            {
                Lichsunhapxuat table = new Lichsunhapxuat(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool UpdateSoLuongDaNghiemThu(int id, string soluongdanghiemthu)
        {
            try
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE id = N'{0}'", id);
                int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                if (existingUserCount == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu lịch sử nghiệm thu này!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbllichsunhapxuat SET soluongdanghiemthu = N'{0}' WHERE id = N'{1}'", soluongdanghiemthu, id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu số lượng đã nghiệm thu!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật dữ liệu số lượng đã nghiệm thu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdateXacNhanNghiemThuChuaXong(int id)
        {
            try
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE id = N'{0}'", id);
                int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                if (existingUserCount == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu lịch sử nghiệm thu này!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbllichsunhapxuat SET trangthai = N'{0}' WHERE id = N'{1}'", "NGHIỆM THU MỘT PHẦN", id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu nghiệm thu!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật dữ liệu nghiệm thu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateXacNhanNghiemThu(int id)
        {
            try
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE id = N'{0}'", id);
                int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                if (existingUserCount == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu lịch sử nghiệm thu này!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbllichsunhapxuat SET trangthai = N'{0}' WHERE id = N'{1}'", "CHỜ QC CHECK", id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu nghiệm thu!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật dữ liệu nghiệm thu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateXacNhanQcCheck(int id)
        {
            try
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE id = N'{0}'", id);
                int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                if (existingUserCount == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu này!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbllichsunhapxuat SET trangthai = N'{0}' WHERE id = N'{1}'", "NHẬP HOÀN THÀNH", id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu QC Check!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật dữ liệu QC Check: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateXacNhanNhaplai(int id)
        {
            try
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE id = N'{0}'", id);
                int existingUserCount = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
                if (existingUserCount == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu này!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Update the user's information in the database
                string query = string.Format("UPDATE dbo.tbllichsunhapxuat SET trangthai = N'{0}' WHERE id = N'{1}'", "NHẬP LẠI HOÀN THÀNH", id);
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu QC Check!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật dữ liệu QC Check: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
