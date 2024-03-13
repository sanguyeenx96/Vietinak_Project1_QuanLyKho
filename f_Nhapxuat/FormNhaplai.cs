using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.f_Nhapxuat
{
    public partial class FormNhaplai : Form
    {
        private int lichsunhapid;
        private string mavattu;
        private string donvi;
        private Thongtinvattu infoThongtinvattu;
        public User userInfo;
        private float soluong;
        private string ngaygionhap;

        public FormNhaplai(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        public void LoadData(Lichsunhapxuat lichsu)
        {
            donvi = lichsu.Donvi;
            mavattu = lichsu.Mavattu;
            soluong = lichsu.Soluongnhap;
            lichsunhapid = lichsu.Id;
            ngaygionhap = lichsu.Thoigian;
        }

        private void FormNhaplai_Load(object sender, EventArgs e)
        {
            txtMavattu.Text = mavattu;
            txtSoluongnhaplai.Text = soluong.ToString() + " " + donvi;

            var ttchitietlotnoList = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhaporderbyhsd(mavattu);
            dgvNhaplai.DataSource = ttchitietlotnoList;
            dgvNhaplai.Columns["Id"].Visible = false;
            dgvNhaplai.Columns["Lichsunhapid"].Visible = false;
            dgvNhaplai.Columns["Ngaygionhap"].Visible = false;
            dgvNhaplai.Columns["Soluong"].Visible = false;
            dgvNhaplai.Columns["Ngaygionghiemthu"].Visible = false;
            dgvNhaplai.Columns["Ngaygioqccheck"].Visible = false;
            dgvNhaplai.Columns["Tennguoithaotacnghiemthu"].Visible = false;
            dgvNhaplai.Columns["Manhanviennghiemthu"].Visible = false;
            dgvNhaplai.Columns["Bophannghiemthu"].Visible = false;
            dgvNhaplai.Columns["Tennguoithaotacqccheck"].Visible = false;
            dgvNhaplai.Columns["Manhanvienqccheck"].Visible = false;
            dgvNhaplai.Columns["Bophanqccheck"].Visible = false;

            dgvNhaplai.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgvNhaplai.Columns["Vitri"].HeaderText = "Vị trí";
            dgvNhaplai.Columns["Invoiceno"].HeaderText = "Invoice No.";
            dgvNhaplai.Columns["Partno"].HeaderText = "Part No.";
            dgvNhaplai.Columns["Lotno"].HeaderText = "Lot No.";
            dgvNhaplai.Columns["Conlai"].HeaderText = "Số lượng còn lại";
            dgvNhaplai.Columns["Donvi"].HeaderText = "Đơn vị";
            dgvNhaplai.Columns["Hansudung"].HeaderText = "Hạn sử dụng";

            DataGridViewTextBoxColumn columnSoluongNhapLai = new DataGridViewTextBoxColumn();
            columnSoluongNhapLai.HeaderText = "Số lượng nhập lại";
            columnSoluongNhapLai.Name = "Soluongnhaplai";
            columnSoluongNhapLai.DefaultCellStyle.BackColor = Color.Yellow;

            dgvNhaplai.Columns.Insert(0, columnSoluongNhapLai);

            foreach (DataGridViewColumn column in dgvNhaplai.Columns)
            {
                if (column.Name != "Soluongnhaplai")
                {
                    column.ReadOnly = true;
                }
            }
        }
        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            float tongsoluongnhaplai = 0;
            float tongsoluongcongthemvtn = 0;
            float tongsoluongcongthemdrg = 0;
            foreach (DataGridViewRow row in dgvNhaplai.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng trống hoặc dòng header
                if (!row.IsNewRow)
                {
                    string Soluongnhaplai = Convert.ToString(row.Cells["Soluongnhaplai"].Value);
                    if (!string.IsNullOrWhiteSpace(Soluongnhaplai))
                    {
                        if (!IsNumeric(Soluongnhaplai))
                        {
                            MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break; 
                        }
                        else
                        {
                            tongsoluongnhaplai += (float)Convert.ToDouble(Soluongnhaplai.Replace('.', ','));
                            string vitri = Convert.ToString(row.Cells["Vitri"].Value);
                            if(vitri == "VTN")
                            {
                                tongsoluongcongthemvtn += (float)Convert.ToDouble(Soluongnhaplai.Replace('.', ','));
                            }
                            if (vitri == "DRAGON")
                            {
                                tongsoluongcongthemdrg += (float)Convert.ToDouble(Soluongnhaplai.Replace('.', ','));
                            }
                        }
                    }                   
                }
            }
            if(tongsoluongnhaplai != soluong)
            {
                MessageBox.Show("Tổng số lượng nhập lại ("+ tongsoluongnhaplai +" "+ donvi+") không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow row in dgvNhaplai.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string Soluongnhaplai = Convert.ToString(row.Cells["Soluongnhaplai"].Value);
                        if (!string.IsNullOrWhiteSpace(Soluongnhaplai))
                        {
                            int id = Convert.ToInt32(row.Cells["Id"].Value.ToString());

                            string lotno = Convert.ToString(row.Cells["lotno"].Value);
                            string vitri = Convert.ToString(row.Cells["vitri"].Value);
                            string invoiceno = Convert.ToString(row.Cells["invoiceno"].Value);
                            string partno = Convert.ToString(row.Cells["partno"].Value);

                            string soluong = Convert.ToString(row.Cells["Soluongnhaplai"].Value);
                            
                            float tonkhomoi = (float)Convert.ToDouble(row.Cells["Conlai"].Value.ToString().Replace('.', ',')) + (float)Convert.ToDouble(row.Cells["Soluongnhaplai"].Value.ToString().Replace('.', ','));
                            string ngaygionghiemthu = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

                            //thêm dữ liệu vào bảng lịch sử NHẬP LẠI 
                            bool created = LichsunhaplaichitietDAO.Instance.Create(lichsunhapid, mavattu, vitri, invoiceno, partno, lotno, soluong,
                                donvi, ngaygionhap, ngaygionghiemthu, userInfo.Hoten, userInfo.Manhanvien, userInfo.Bophan);
                            // Nếu không thể tạo mới một dòng nào đó, đặt biến cờ thành false
                            if (!created)
                            {
                                break; // Dừng vòng lặp vì không cần thêm dữ liệu nữa
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
                bool result = LichsunhapxuatDAO.Instance.UpdateXacNhanNhaplai(lichsunhapid);
                if (result)
                {
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }
        }
    }
}
