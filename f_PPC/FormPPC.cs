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
using Vietinak_Kho.f_Qccheck;

namespace Vietinak_Kho.f_PPC
{
    public partial class FormPPC : Form
    {
        private ToolStripButton activeButton;
        private User userInfo;

        public FormPPC(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        public void loadform(Form frm)
        {
            panelMain.Controls.Clear();
            AddOwnedForm(frm);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelMain.Tag = frm;
            panelMain.Controls.Add(frm);
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
        private void btnDanhsachPO_Click(object sender, EventArgs e)
        {
            FormDanhsachPO fds = new FormDanhsachPO(userInfo);
            loadform(fds);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void FormPPC_Load(object sender, EventArgs e)
        {
            btnDanhsachPO.PerformClick();
        }

        private void btnThongtinNCC_Click(object sender, EventArgs e)
        {
            FormThongtinNCC fncc = new FormThongtinNCC(userInfo);
            loadform(fncc);
            UpdateButtonColor(sender as ToolStripButton);
        }
    }
}
