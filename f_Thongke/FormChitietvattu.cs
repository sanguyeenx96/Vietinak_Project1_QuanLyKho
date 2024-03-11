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
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho.f_Thongke
{
    public partial class FormChitietvattu : Form
    {
        private string mavattu;
        private ToolStripButton activeButton;


        public FormChitietvattu(string mavattu)
        {
            InitializeComponent();
            this.mavattu = mavattu;
        }
        public void loadform(Form frm)
        {
            panelChinh.Controls.Clear();
            AddOwnedForm(frm);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelChinh.Tag = frm;
            panelChinh.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }
        private void UpdateButtonColor(ToolStripButton clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Transparent;
            }
            clickedButton.BackColor = SystemColors.ActiveBorder;
            activeButton = clickedButton;
        }
        private void FormChitietvattu_Load(object sender, EventArgs e)
        {
            var ttvtList = ThongtinvattuDAO.Instance.LoadThongtinvattu(mavattu);
            var ttchitietList = DanhsachnguyenvatlieuDAO.Instance.LoadThongtinvattu(mavattu);

            if (ttvtList.Count > 0 && ttchitietList.Count > 0)
            {
                Thongtinvattu firstItem = ttvtList[0]; // Lấy ra phần tử đầu tiên trong danh sách
                txtMavattu.Text = firstItem.Mavattu;
                txtDiengiai.Text = firstItem.Diengiai;
                txtDonvi.Text = firstItem.Donvi;
                txtKgtrenbao.Text = firstItem.Kgtrenbao.ToString();
                txtTonkhodrg.Text = firstItem.Tonkhodrg.ToString();
                txtTonkhovtn.Text = firstItem.Tonkhovtn.ToString();
                dgv.DataSource = ttchitietList;
            }
            else
            {
                // Xử lý trường hợp danh sách trả về là rỗng
                MessageBox.Show("Không tìm thấy thông tin vật tư có mã: " + mavattu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnThongtinsoluong.PerformClick();
        }

        private void btnXemlichsu_Click(object sender, EventArgs e)
        {
        
        }


        private void btnThongtinsoluong_Click(object sender, EventArgs e)
        {
            FormThongtinsoluong ftt = new FormThongtinsoluong(mavattu);
            loadform(ftt);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void btnLichsunhapxuat_Click(object sender, EventArgs e)
        {
            FormLichsunhapxuat flsnx = new FormLichsunhapxuat(mavattu);
            loadform(flsnx);
            UpdateButtonColor(sender as ToolStripButton);
        }
    }
}
