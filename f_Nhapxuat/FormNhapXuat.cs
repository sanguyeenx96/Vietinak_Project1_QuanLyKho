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
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho
{
    public partial class FormNhapXuat : Form
    {
        public User userInfo;
        public FormNhapXuat(User userInfo)
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

        private void btnNhapkho_Click_1(object sender, EventArgs e)
        {
            FormNhapkho fNhapkho = new FormNhapkho(userInfo);
            loadform(fNhapkho);
        }

        private void btnXuatkho_Click(object sender, EventArgs e)
        {
            FormXuatkho fXuatkho = new FormXuatkho(userInfo);
            loadform(fXuatkho);
        }

        private void FormNhapXuat_Load(object sender, EventArgs e)
        {
            string todayDate = DateTime.Now.ToString("yyyy/MM/dd"); 

            string queryCountNhap = "SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Nhập' AND Thoigian LIKE '" + todayDate + "%'";
            int countNhap = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCountNhap));
            string queryCountXuat = "SELECT COUNT(*) FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Xuất' AND Thoigian LIKE '" + todayDate + "%'";
            int countXuat = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCountXuat));
            txtsolannhap.Text = countNhap.ToString();
            txtsolanxuat.Text = countXuat.ToString();
        }
    }
}
