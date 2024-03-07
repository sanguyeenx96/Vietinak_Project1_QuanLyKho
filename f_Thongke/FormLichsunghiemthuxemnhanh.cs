using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;

namespace Vietinak_Kho.f_Thongke
{
    public partial class FormLichsunghiemthuxemnhanh : Form
    {
        private string mavattu;
        private string nhapvaokho;
        private string soluongnhap;
        private string donvi;
        private int idValue;
        public FormLichsunghiemthuxemnhanh(int id, string mavattu, string nhapvaokho, string soluongnhap, string donvi)
        {
            InitializeComponent();
            this.idValue = id;
            this.mavattu = mavattu;
            this.nhapvaokho = nhapvaokho;
            this.soluongnhap = soluongnhap;
            this.donvi = donvi;
        }
        private void FormLichsunghiemthuxemnhanh_Load(object sender, EventArgs e)
        {
            txtMavattu.Text = mavattu;
            txtNhapvaokho.Text = nhapvaokho;
            txtSoluongnhap.Text = soluongnhap + " " + donvi;
            var lsnt = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunghiemthu(idValue);
            dgv.DataSource = lsnt;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Lichsunhapid"].Visible = false;
            dgv.Columns["Lotno"].HeaderText = "Lot No.";
            dgv.Columns["Soluong"].HeaderText = "Số lượng thực tế";

            float tongSoLuong = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongSoLuong += (float)Convert.ToDouble(row.Cells["Soluong"].Value.ToString().Replace('.', ','));
                }
            }
            txttongnghiemthu.Text = tongSoLuong.ToString() + " " + donvi;
            if (tongSoLuong != (float)Convert.ToDouble(soluongnhap.ToString().Replace('.', ',')))
            {
                panel3.BackColor = Color.Red;
            }
            else
            {
                panel3.BackColor = Color.Green;
            }
        }
    }
}
