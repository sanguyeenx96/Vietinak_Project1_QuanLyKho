﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.f_Caidat;
using Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu;
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho
{
    public partial class FormCaidat : Form
    {
        private ToolStripButton activeButton;

        public FormCaidat()
        {
            InitializeComponent();
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
        private void btnBophanchucvu_Click(object sender, EventArgs e)
        {
            FormBophanvachucvu fBophanvachucvu = new FormBophanvachucvu();
            loadform(fBophanvachucvu);
            UpdateButtonColor(sender as ToolStripButton);
        }
        
        private void FormCaidat_Load(object sender, EventArgs e)
        {
            btnDanhsachNVL.PerformClick();
        }

        private void btnThongtinnguyenvatlieu_Click(object sender, EventArgs e)
        {
            FormThongtinnguyenvatlieu fThongtinnguyenvatlieu = new FormThongtinnguyenvatlieu();
            loadform(fThongtinnguyenvatlieu);
            UpdateButtonColor(sender as ToolStripButton);
        }

        private void btnDanhsachNVL_Click(object sender, EventArgs e)
        {
            FormDanhsachnguyenvatlieu fDanhsachnguyenvatlieu = new FormDanhsachnguyenvatlieu();
            loadform(fDanhsachnguyenvatlieu);
            UpdateButtonColor(sender as ToolStripButton);
        }
    }
}
