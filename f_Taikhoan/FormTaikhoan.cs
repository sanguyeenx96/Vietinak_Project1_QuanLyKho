using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho
{
    public partial class FormTaikhoan : Form
    {
        private ToolStripButton activeButton;
        private User userInfo;

        public FormTaikhoan(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        public void loadform(Form frm)
        {
            panelTaikhoan_Tong.Controls.Clear();
            AddOwnedForm(frm);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelTaikhoan_Tong.Tag = frm;
            panelTaikhoan_Tong.Controls.Add(frm);
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

        private void btnTaikhoancuaban_Click(object sender, EventArgs e)
        {
            FormTaikhoancuaban fTaikhoancuaban = new FormTaikhoancuaban(userInfo);
            loadform(fTaikhoancuaban);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void btnQuanlydanhsachtaikhoan_Click(object sender, EventArgs e)
        {
            loadform(new FormQuanlydanhsachtaikhoan());
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void FormTaikhoan_Load(object sender, EventArgs e)
        {
            btnTaikhoancuaban.PerformClick();
        }

        private void btnTimkiemtaikhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnSuathongtintaikhoan_Click(object sender, EventArgs e)
        {
            loadform(new FormSuaxoataikhoan());
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void btnTaotaikhoanmoi_Click(object sender, EventArgs e)
        {
            FormTaotaikhoanmoi f = new FormTaotaikhoanmoi();
            f.ShowDialog();
        }
    }
}
