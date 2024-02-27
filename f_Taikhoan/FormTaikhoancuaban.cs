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

namespace Vietinak_Kho.f_Taikhoan
{
    public partial class FormTaikhoancuaban : Form
    {
        public User userInfo;

        public FormTaikhoancuaban(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void FormTaikhoancuaban_Load(object sender, EventArgs e)
        {
            groupboxDoimatkhau.Visible = false;
            txtHoten.Text = userInfo.Hoten;
            txtBophan.Text = userInfo.Bophan;
            txtChucvu.Text = userInfo.Chucvu;
            txtManhanvien.Text = userInfo.Manhanvien;
            txtRole.Text = userInfo.Role;
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            groupboxDoimatkhau.Visible = true;
        }

        private void btnHuybodoimatkhau_Click(object sender, EventArgs e)
        {
            groupboxDoimatkhau.Visible = false;
        }
    }
}
