using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu;

namespace Vietinak_Kho.f_Nghiemthu
{
    public partial class FormNghiemthu : Form
    {
        private ToolStripButton activeButton;

        public FormNghiemthu()
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
        private void FormNghiemthu_Load(object sender, EventArgs e)
        {
            btnDanhsachchonghiemthu.PerformClick();
        }

        private void btnDanhsachchonghiemthu_Click(object sender, EventArgs e)
        {
            FormDanhsachchonghiemthu fThongtinnguyenvatlieu = new FormDanhsachchonghiemthu();
            loadform(fThongtinnguyenvatlieu);
            UpdateButtonColor(sender as ToolStripButton);
        }
    }
}
