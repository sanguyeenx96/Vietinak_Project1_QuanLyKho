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
using Vietinak_Kho.f_Nghiemthu;

namespace Vietinak_Kho.f_Qccheck
{
    public partial class FormQccheck : Form
    {
        private ToolStripButton activeButton;
        private User userInfo;

        public FormQccheck(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
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
        private void FormQccheck_Load(object sender, EventArgs e)
        {
            btnDanhsach.PerformClick();

        }

        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            FormDanhsachchoqccheck fcnt = new FormDanhsachchoqccheck(userInfo);
            loadform(fcnt);
            UpdateButtonColor(sender as ToolStripButton);
        }
    }
}
