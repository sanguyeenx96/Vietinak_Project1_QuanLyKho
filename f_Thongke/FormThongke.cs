using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.f_Taikhoan;
using Vietinak_Kho.f_Thongke;

namespace Vietinak_Kho.f_Khohang
{
    public partial class FormThongke : Form
    {
        private ToolStripButton activeButton;

        public FormThongke()
        {
            InitializeComponent();
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

        private void btnDanhsachvattu_Click(object sender, EventArgs e)
        {
            FormDanhsachvattu fDanhsachvattu = new FormDanhsachvattu();
            loadform(fDanhsachvattu);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void btnLichsunhap_Click(object sender, EventArgs e)
        {
            FormLichsunhap fLichsunhap = new FormLichsunhap();
            loadform(fLichsunhap);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void btnLichsuxuat_Click(object sender, EventArgs e)
        {
            FormLichsuxuat fLichsuxuat = new FormLichsuxuat();
            loadform(fLichsuxuat);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void FormThongke_Load(object sender, EventArgs e)
        {
            btnDanhsachvattu.PerformClick();
        }
    }
}
