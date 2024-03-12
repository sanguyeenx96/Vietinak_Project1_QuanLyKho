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
    public partial class FormLichsuxuatchitiet : Form
    {
        private string mavattu;
        private string mucdichxuat;
        private string soluongxuat;
        private string donvi;
        private int idValue;
        public FormLichsuxuatchitiet(int id, string mavattu, string mucdichxuat, string soluongxuat, string donvi)
        {
            InitializeComponent();
            this.idValue = id;
            this.mavattu = mavattu;
            this.mucdichxuat = mucdichxuat;
            this.soluongxuat = soluongxuat;
            this.donvi = donvi;
        }

        private void FormLichsuxuatchitiet_Load(object sender, EventArgs e)
        {
            txtMavattu.Text = mavattu;
            txtMucdichxuat.Text = mucdichxuat;
            txtSoluongxuat.Text = soluongxuat + " " + donvi;
            var ls = LichsuxuatchitietDAO.Instance.LoadTableList_Lichsuxuatchitiet(idValue);
            dgv.DataSource = ls;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Lichsuxuatid"].Visible = false;
            dgv.Columns["Mavattu"].HeaderText = "Mã vật tư";
            dgv.Columns["Invoiceno"].HeaderText = "Invoice No.";
            dgv.Columns["Partno"].HeaderText = "Part No.";
            dgv.Columns["Lotno"].HeaderText = "Lot No.";
            dgv.Columns["Soluong"].HeaderText = "Số lượng";
            dgv.Columns["Conlai"].HeaderText = "Còn lại";
            dgv.Columns["Donvi"].HeaderText = "Đơn vị";
            dgv.Columns["Hansudung"].HeaderText = "Hạn sử dụng";
            dgv.Columns["Ngaygioxuat"].HeaderText = "Ngày giờ xuất";
            float tongSoLuong = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongSoLuong += (float)Convert.ToDouble(row.Cells["Soluong"].Value.ToString().Replace('.', ','));
                }
            }
            txttongxuat.Text = tongSoLuong.ToString() + " " + donvi;
            if (tongSoLuong != (float)Convert.ToDouble(soluongxuat.ToString().Replace('.', ',')))
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
