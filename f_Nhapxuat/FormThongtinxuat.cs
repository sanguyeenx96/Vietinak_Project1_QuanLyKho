﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.f_Nhapxuat
{
    public partial class FormThongtinxuat : Form
    {
        private int vattuid;
        private string mavattu;
        private float soluongxuat;
        private string mucdichxuat;
        private string donvi;
        public User userInfo;
        private float tonkhotruocxuatVTN;
        private float tonkhotruocxuatDRG;
        private List<Thongtinvattu> allThongtinvattu;
        private Thongtinvattu infoThongtinvattu;
        private string invoiceno;
        public FormThongtinxuat(int vattuid, string mavattu, float soluongxuat, string mucdichxuat,
            string donvi, User userInfo, float tonkhotruocxuatVTN, float tonkhotruocxuatDRG)
        {
            InitializeComponent();
            this.vattuid = vattuid;
            this.mavattu = mavattu;
            this.soluongxuat = soluongxuat;
            this.mucdichxuat = mucdichxuat;
            this.donvi = donvi;
            this.userInfo = userInfo;
            this.tonkhotruocxuatVTN = tonkhotruocxuatVTN;
            this.tonkhotruocxuatDRG = tonkhotruocxuatDRG;

        }

        private void FormThongtinxuat_Load(object sender, EventArgs e)
        {
            txtMavattu.Text = mavattu;
            txtSoluongxuat.Text = soluongxuat.ToString() + " " + donvi;
            txtMucdichxuat.Text = mucdichxuat;

            if (mucdichxuat == "XUẤT SẢN XUẤT")
            {
                var danhsachlotno = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhaporderbyhsd(mavattu);
                var dsVTN = danhsachlotno.Where(x => (x.Vitri == "VTN" && x.Hansudung != "")).ToList();

                dgv.DataSource = dsVTN;

                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Lichsunhapid"].Visible = false;
                dgv.Columns["Ngaygionhap"].Visible = false;
                dgv.Columns["Soluong"].Visible = false;
                dgv.Columns["Ngaygionghiemthu"].Visible = false;
                dgv.Columns["Ngaygioqccheck"].Visible = false;
                dgv.Columns["Tennguoithaotacnghiemthu"].Visible = false;
                dgv.Columns["Manhanviennghiemthu"].Visible = false;
                dgv.Columns["Bophannghiemthu"].Visible = false;
                dgv.Columns["Tennguoithaotacqccheck"].Visible = false;
                dgv.Columns["Manhanvienqccheck"].Visible = false;
                dgv.Columns["Bophanqccheck"].Visible = false;

                dgv.Columns["Mavattu"].HeaderText = "Mã vật tư";
                dgv.Columns["Vitri"].HeaderText = "Vị trí";
                dgv.Columns["Invoiceno"].HeaderText = "Invoice No.";
                dgv.Columns["Partno"].HeaderText = "Part No.";
                dgv.Columns["Lotno"].HeaderText = "Lot No.";
                dgv.Columns["Conlai"].HeaderText = "Số lượng còn lại";
                dgv.Columns["Donvi"].HeaderText = "Đơn vị";
                dgv.Columns["Hansudung"].HeaderText = "Hạn sử dụng";

                DataGridViewTextBoxColumn columnSoluongxuat = new DataGridViewTextBoxColumn();
                columnSoluongxuat.HeaderText = "Số lượng xuất";
                columnSoluongxuat.Name = "Soluongxuat";
                columnSoluongxuat.DefaultCellStyle.BackColor = Color.Yellow;
                dgv.Columns.Insert(0, columnSoluongxuat);
                dgv.CellFormatting += dgv_CellFormatting;
            }
            if (mucdichxuat == "XUẤT DRG - NHẬP VTN")
            {
                allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
                infoThongtinvattu = allThongtinvattu.Where(x => x.Mavattu == mavattu).FirstOrDefault();

                var lichsunhapxuat = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhaporderbyhsd(mavattu);
                var dsDRG = lichsunhapxuat.Where(x => x.Vitri == "DRAGON").ToList();
                dgv.DataSource = dsDRG;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Lichsunhapid"].Visible = false;
                dgv.Columns["Ngaygionhap"].Visible = false;
                dgv.Columns["Ngaygionghiemthu"].Visible = false;
                dgv.Columns["Ngaygioqccheck"].Visible = false;
                dgv.Columns["Tennguoithaotacnghiemthu"].Visible = false;
                dgv.Columns["Manhanviennghiemthu"].Visible = false;
                dgv.Columns["Bophannghiemthu"].Visible = false;
                dgv.Columns["Tennguoithaotacqccheck"].Visible = false;
                dgv.Columns["Manhanvienqccheck"].Visible = false;
                dgv.Columns["Bophanqccheck"].Visible = false;
                dgv.Columns["Lotno"].Visible = false;
                dgv.Columns["Hansudung"].Visible = false;

                dgv.Columns["Mavattu"].HeaderText = "Mã vật tư";
                dgv.Columns["Vitri"].HeaderText = "Vị trí";
                dgv.Columns["Invoiceno"].HeaderText = "Invoice No.";
                dgv.Columns["Partno"].HeaderText = "Part No.";
                dgv.Columns["Soluong"].HeaderText = "Số lượng nhập";
                dgv.Columns["Conlai"].HeaderText = "Số lượng còn lại";
                dgv.Columns["Donvi"].HeaderText = "Đơn vị";
                dgv.Columns["Hansudung"].HeaderText = "Hạn sử dụng";

                DataGridViewTextBoxColumn columnSoluongxuat = new DataGridViewTextBoxColumn();
                columnSoluongxuat.HeaderText = "Số lượng xuất";
                columnSoluongxuat.Name = "Soluongxuat";
                columnSoluongxuat.DefaultCellStyle.BackColor = Color.Yellow;
                dgv.Columns.Insert(0, columnSoluongxuat);
                dgv.CellFormatting += dgv_CellFormatting;
            }
            if (mucdichxuat == "XUẤT NG")
            {
                var danhsachlotno = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhaporderbyhsd(mavattu);
                danhsachlotno = danhsachlotno.Where(x => x.Hansudung != "").ToList();
                dgv.DataSource = danhsachlotno;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Lichsunhapid"].Visible = false;
                dgv.Columns["Ngaygionhap"].Visible = false;
                dgv.Columns["Soluong"].Visible = false;
                dgv.Columns["Ngaygionghiemthu"].Visible = false;
                dgv.Columns["Ngaygioqccheck"].Visible = false;
                dgv.Columns["Tennguoithaotacnghiemthu"].Visible = false;
                dgv.Columns["Manhanviennghiemthu"].Visible = false;
                dgv.Columns["Bophannghiemthu"].Visible = false;
                dgv.Columns["Tennguoithaotacqccheck"].Visible = false;
                dgv.Columns["Manhanvienqccheck"].Visible = false;
                dgv.Columns["Bophanqccheck"].Visible = false;

                dgv.Columns["Mavattu"].HeaderText = "Mã vật tư";
                dgv.Columns["Vitri"].HeaderText = "Vị trí";
                dgv.Columns["Invoiceno"].HeaderText = "Invoice No.";
                dgv.Columns["Partno"].HeaderText = "Part No.";
                dgv.Columns["Lotno"].HeaderText = "Lot No.";
                dgv.Columns["Conlai"].HeaderText = "Số lượng còn lại";
                dgv.Columns["Donvi"].HeaderText = "Đơn vị";
                dgv.Columns["Hansudung"].HeaderText = "Hạn sử dụng";

                DataGridViewTextBoxColumn columnSoluongxuat = new DataGridViewTextBoxColumn();
                columnSoluongxuat.HeaderText = "Số lượng xuất";
                columnSoluongxuat.Name = "Soluongxuat";
                columnSoluongxuat.DefaultCellStyle.BackColor = Color.Yellow;
                dgv.Columns.Insert(0, columnSoluongxuat);
                dgv.CellFormatting += dgv_CellFormatting;
            }
        }
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cellValue = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    if (dgv.Columns[e.ColumnIndex].Name == "Hansudung")
                    {
                        // Chuyển đổi giá trị của ô sang kiểu DateTime
                        DateTime dateValue;
                        if (DateTime.TryParseExact(cellValue.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                        {
                            // Tính toán số ngày chênh lệch giữa ngày hiện tại và ngày trong ô
                            TimeSpan difference = dateValue - DateTime.Now;
                            int daysDifference = (int)difference.TotalDays;

                            // Nếu số ngày chênh lệch nhỏ hơn 30, tô màu đỏ cho ô
                            if (daysDifference < 30)
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
            // Kiểm tra nếu cột hiện tại là cột "Conlai"
            if (dgv.Columns[e.ColumnIndex].Name == "Conlai" && e.RowIndex >= 0)
            {
                // Lấy giá trị của ô cột "Conlai"
                int conlaiValue = Convert.ToInt32(e.Value);

                // Nếu giá trị là 0, vô hiệu hóa dòng hiện tại620
                if (conlaiValue == 0)
                {
                    dgv.Rows[e.RowIndex].ReadOnly = true; // Vô hiệu hóa chỉnh sửa
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray; // Đổi màu nền
                }
                else
                {
                    dgv.Rows[e.RowIndex].ReadOnly = false; // Cho phép chỉnh sửa
                }
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (mucdichxuat == "XUẤT SẢN XUẤT")
            {
                float tongsoluongxuat = 0;
                float tongsoluongxuatvtn = 0;
                float tongsoluongxuatdrg = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string soluongxuat = Convert.ToString(row.Cells["Soluongxuat"].Value);
                        if (!string.IsNullOrWhiteSpace(soluongxuat))
                        {
                            if (!IsNumeric(soluongxuat))
                            {
                                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                float checksoluongxuat = (float)Convert.ToDouble(row.Cells["Soluongxuat"].Value.ToString().Replace('.', ','));
                                float checkconlai = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ','));
                                if(checksoluongxuat > checkconlai)
                                {
                                    MessageBox.Show("Số lượng xuất vượt quá số lượng còn lại của Lot No.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                tongsoluongxuat += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                string vitri = Convert.ToString(row.Cells["Vitri"].Value);
                                if (vitri == "VTN")
                                {
                                    tongsoluongxuatvtn += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                }
                                if (vitri == "DRAGON")
                                {
                                    tongsoluongxuatdrg += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                }
                            }
                        }
                    }
                }
                if (tongsoluongxuat != soluongxuat)
                {
                    MessageBox.Show("Tổng số lượng xuất (" + tongsoluongxuat + " " + donvi + ") không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float tonkhosauxuatVTN = tonkhotruocxuatVTN - tongsoluongxuatvtn;
                    float tonkhosauxuatDRG = tonkhotruocxuatDRG - tongsoluongxuatdrg;
                    //Lưu dữ liệu vào bảng lịch sử NHẬP XUẤT
                    int lichsuxuatid = LichsunhapxuatDAO.Instance.XuatReturnId(vattuid, mavattu, donvi, userInfo.Hoten,
                    userInfo.Manhanvien, userInfo.Bophan, "Xuất", DateTime.Now.ToString("yyyy/MM/dd HH:mm"),
                    soluongxuat.ToString().Replace(',', '.'), mucdichxuat, tonkhotruocxuatVTN.ToString().Replace(',', '.'), tonkhosauxuatVTN.ToString().Replace(',', '.'),
                    tonkhotruocxuatDRG.ToString().Replace(',', '.'), tonkhosauxuatDRG.ToString().Replace(',', '.'), "XUẤT HOÀN THÀNH");
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string soluongxuat = Convert.ToString(row.Cells["Soluongxuat"].Value);
                            if (!string.IsNullOrWhiteSpace(soluongxuat))
                            {
                                int id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                                string lotno = Convert.ToString(row.Cells["lotno"].Value);
                                string vitri = Convert.ToString(row.Cells["vitri"].Value);
                                string invoiceno = Convert.ToString(row.Cells["invoiceno"].Value);
                                string partno = Convert.ToString(row.Cells["partno"].Value);
                                string hansudung = Convert.ToString(row.Cells["Hansudung"].Value);

                                float tonkhomoi = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ',')) - (float)Convert.ToDouble(row.Cells["Soluongxuat"].Value.ToString().Replace('.', ','));

                                //Lưu lịch sử xuất chi tiết sau khi có lichsuxuatid
                                bool created = LichsuxuatchitietDAO.Instance.Create(lichsuxuatid, mavattu, invoiceno, partno, lotno, soluongxuat.Replace(',', '.'),
                                    tonkhomoi.ToString().Replace(',', '.'), donvi, hansudung, DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                                if (!created)
                                {
                                    break;
                                }
                                //Cập nhật số lượng vào bảng lịch sử NHẬP 
                                bool updatetonkho = LichsunhapchitietDAO.Instance.UpdateTonkho(tonkhomoi.ToString().Replace(',', '.'), id);
                                if (!updatetonkho)
                                {
                                    break; // Dừng vòng lặp vì không cần thêm dữ liệu nữa
                                }
                            }
                        }
                    }
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }

            if (mucdichxuat == "XUẤT DRG - NHẬP VTN")
            {
                float tongsoluongxuat = 0;
                float tongsoluongxuatvtn = 0;
                float tongsoluongxuatdrg = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string soluongxuat = Convert.ToString(row.Cells["Soluongxuat"].Value);
                        if (!string.IsNullOrWhiteSpace(soluongxuat))
                        {
                            if (!IsNumeric(soluongxuat))
                            {
                                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                float checksoluongxuat = (float)Convert.ToDouble(row.Cells["Soluongxuat"].Value.ToString().Replace('.', ','));
                                float checkconlai = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ','));
                                if (checksoluongxuat > checkconlai)
                                {
                                    MessageBox.Show("Số lượng xuất vượt quá số lượng còn lại của Lot No.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                tongsoluongxuat += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                string vitri = Convert.ToString(row.Cells["Vitri"].Value);
                                if (vitri == "VTN")
                                {
                                    tongsoluongxuatvtn += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                }
                                if (vitri == "DRAGON")
                                {
                                    tongsoluongxuatdrg += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                }
                            }
                        }
                    }
                }
                if (tongsoluongxuat != soluongxuat)
                {
                    MessageBox.Show("Tổng số lượng xuất (" + tongsoluongxuat + " " + donvi + ") không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float tonkhosauxuatVTN = tonkhotruocxuatVTN - tongsoluongxuatvtn;
                    float tonkhosauxuatDRG = tonkhotruocxuatDRG - tongsoluongxuatdrg;
                    //Lưu dữ liệu vào bảng lịch sử NHẬP XUẤT
                    int lichsuxuatid = LichsunhapxuatDAO.Instance.XuatReturnId(vattuid, mavattu, donvi, userInfo.Hoten,
                    userInfo.Manhanvien, userInfo.Bophan, "Xuất", DateTime.Now.ToString("yyyy/MM/dd HH:mm"),
                    soluongxuat.ToString().Replace(',', '.'), mucdichxuat, tonkhotruocxuatVTN.ToString().Replace(',', '.'), tonkhosauxuatVTN.ToString().Replace(',', '.'),
                    tonkhotruocxuatDRG.ToString().Replace(',', '.'), tonkhosauxuatDRG.ToString().Replace(',', '.'), "XUẤT HOÀN THÀNH");
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string soluongxuat = Convert.ToString(row.Cells["Soluongxuat"].Value);
                            if (!string.IsNullOrWhiteSpace(soluongxuat))
                            {
                                int id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                                string vitri = Convert.ToString(row.Cells["vitri"].Value);
                                string invoiceno = Convert.ToString(row.Cells["invoiceno"].Value);
                                string partno = Convert.ToString(row.Cells["partno"].Value);
                                string donvi = Convert.ToString(row.Cells["donvi"].Value);

                                float tonkhomoi = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ',')) - (float)Convert.ToDouble(row.Cells["Soluongxuat"].Value.ToString().Replace('.', ','));

                                //Lưu lịch sử xuất chi tiết sau khi có lichsuxuatid
                                bool created = LichsuxuatchitietDAO.Instance.Create(lichsuxuatid, mavattu, invoiceno, partno, "", soluongxuat.Replace(',', '.'),
                                    tonkhomoi.ToString().Replace(',', '.'), donvi, "", DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                                if (!created)
                                {
                                    break;
                                }
                                //Cập nhật số lượng vào bảng lịch sử NHẬP 
                                bool updatetonkho = LichsunhapchitietDAO.Instance.UpdateTonkho(tonkhomoi.ToString().Replace(',', '.'), id);
                                if (!updatetonkho)
                                {
                                    break; // Dừng vòng lặp vì không cần thêm dữ liệu nữa
                                }

                                string tennguoithaotac = userInfo.Hoten;
                                string manhanvien = userInfo.Manhanvien;
                                string bophan = userInfo.Bophan;
                                string loaithaotac = "Nhập";
                                string thoigian = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                                float soluongnhap = (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                string nhapvaokho = "VTN";
                                //Tính toán sô lượng hàng nhập
                                float tonkhotruocnhapVTN = (float)Convert.ToDouble(infoThongtinvattu.Tonkhovtn.ToString());
                                float tonkhotruocnhapDRG = (float)Convert.ToDouble(infoThongtinvattu.Tonkhodrg.ToString());
                                float tonkhosaunhapVTN = tonkhotruocnhapVTN;
                                float tonkhosaunhapDRG = tonkhotruocnhapDRG;
                                string trangthai = "CHỜ NGHIỆM THU";
                                if (nhapvaokho == "VTN")
                                {
                                    tonkhosaunhapVTN += soluongnhap; //Tăng tồn kho sau nhập vào VTN
                                    tonkhosaunhapDRG -= soluongnhap; 

                                    bool success1 = LichsunhapxuatDAO.Instance.Nhap(vattuid, mavattu, invoiceno, mavattu, donvi, tennguoithaotac,
                                    manhanvien, bophan, loaithaotac, thoigian,
                                    soluongnhap.ToString().Replace(',', '.'), nhapvaokho, tonkhotruocnhapVTN.ToString().Replace(',', '.'), tonkhosaunhapVTN.ToString().Replace(',', '.'),
                                    tonkhotruocnhapDRG.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'), trangthai);

                                    bool success2 = ThongtinvattuDAO.Instance.UpdateTonkho(vattuid, tonkhosaunhapVTN.ToString().Replace(',', '.'), tonkhosaunhapDRG.ToString().Replace(',', '.'));
                                    if (success1 && success2)
                                    {
                                        this.Close();
                                        FormThanhcong fthanhcong = new FormThanhcong();
                                        fthanhcong.ShowDialog();
                                    }
                                }
                            }
                        }
                    }
                    
                    
                }
            }

            if (mucdichxuat == "XUẤT NG")
            {
                float tongsoluongxuat = 0;
                float tongsoluongxuatvtn = 0;
                float tongsoluongxuatdrg = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string soluongxuat = Convert.ToString(row.Cells["Soluongxuat"].Value);
                        if (!string.IsNullOrWhiteSpace(soluongxuat))
                        {
                            if (!IsNumeric(soluongxuat))
                            {
                                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                float checksoluongxuat = (float)Convert.ToDouble(row.Cells["Soluongxuat"].Value.ToString().Replace('.', ','));
                                float checkconlai = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ','));
                                if (checksoluongxuat > checkconlai)
                                {
                                    MessageBox.Show("Số lượng xuất vượt quá số lượng còn lại của Lot No.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                tongsoluongxuat += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                string vitri = Convert.ToString(row.Cells["Vitri"].Value);
                                if (vitri == "VTN")
                                {
                                    tongsoluongxuatvtn += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                }
                                if (vitri == "DRAGON")
                                {
                                    tongsoluongxuatdrg += (float)Convert.ToDouble(soluongxuat.Replace('.', ','));
                                }
                            }
                        }
                    }
                }
                if (tongsoluongxuat != soluongxuat)
                {
                    MessageBox.Show("Tổng số lượng xuất (" + tongsoluongxuat + " " + donvi + ") không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float tonkhosauxuatVTN = tonkhotruocxuatVTN - tongsoluongxuatvtn;
                    float tonkhosauxuatDRG = tonkhotruocxuatDRG - tongsoluongxuatdrg;
                    //Lưu dữ liệu vào bảng lịch sử NHẬP XUẤT
                    int lichsuxuatid = LichsunhapxuatDAO.Instance.XuatReturnId(vattuid, mavattu, donvi, userInfo.Hoten,
                    userInfo.Manhanvien, userInfo.Bophan, "Xuất", DateTime.Now.ToString("yyyy/MM/dd HH:mm"),
                    soluongxuat.ToString().Replace(',', '.'), mucdichxuat, tonkhotruocxuatVTN.ToString().Replace(',', '.'), tonkhosauxuatVTN.ToString().Replace(',', '.'),
                    tonkhotruocxuatDRG.ToString().Replace(',', '.'), tonkhosauxuatDRG.ToString().Replace(',', '.'), "XUẤT HOÀN THÀNH");
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string soluongxuat = Convert.ToString(row.Cells["Soluongxuat"].Value);
                            if (!string.IsNullOrWhiteSpace(soluongxuat))
                            {
                                int id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                                string lotno = Convert.ToString(row.Cells["lotno"].Value);
                                string vitri = Convert.ToString(row.Cells["vitri"].Value);
                                string invoiceno = Convert.ToString(row.Cells["invoiceno"].Value);
                                string partno = Convert.ToString(row.Cells["partno"].Value);
                                string hansudung = Convert.ToString(row.Cells["Hansudung"].Value);

                                float tonkhomoi = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ',')) - (float)Convert.ToDouble(row.Cells["Soluongxuat"].Value.ToString().Replace('.', ','));

                                //Lưu lịch sử xuất chi tiết sau khi có lichsuxuatid
                                bool created = LichsuxuatchitietDAO.Instance.Create(lichsuxuatid, mavattu, invoiceno, partno, lotno, soluongxuat.Replace(',', '.'),
                                    tonkhomoi.ToString().Replace(',', '.'), donvi, hansudung, DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                                if (!created)
                                {
                                    break;
                                }
                                //Cập nhật số lượng vào bảng lịch sử NHẬP 
                                bool updatetonkho = LichsunhapchitietDAO.Instance.UpdateTonkho(tonkhomoi.ToString().Replace(',', '.'), id);
                                if (!updatetonkho)
                                {
                                    break; // Dừng vòng lặp vì không cần thêm dữ liệu nữa
                                }
                            }
                        }
                    }
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }
        }
    }
}
