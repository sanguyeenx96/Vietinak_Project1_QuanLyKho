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

namespace Vietinak_Kho.f_Nhapxuat
{
    public partial class FormThongtinxuat : Form
    {
        private string mavattu;
        private float soluongxuat;
        private string mucdichxuat;
        private string donvi;


        public FormThongtinxuat(string mavattu, float soluongxuat, string mucdichxuat, string donvi)
        {
            InitializeComponent();
            this.mavattu = mavattu;
            this.soluongxuat = soluongxuat;
            this.mucdichxuat = mucdichxuat;
            this.donvi = donvi;
        }

        private void FormThongtinxuat_Load(object sender, EventArgs e)
        {
            txtMavattu.Text = mavattu;
            txtSoluongxuat.Text = soluongxuat.ToString() + " " + donvi;
            txtMucdichxuat.Text = mucdichxuat;

            var danhsachlotno = LichsunhapchitietDAO.Instance.LoadTableList_Lichsunhaporderbyhsd(mavattu);
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
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }
    }
}
