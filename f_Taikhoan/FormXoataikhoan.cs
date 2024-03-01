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

namespace Vietinak_Kho.f_Taikhoan
{
    public partial class FormXoataikhoan : Form
    {
        public User userInfo;

        public FormXoataikhoan(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void FormXoataikhoan_Load(object sender, EventArgs e)
        {
            txtHoten.Text = userInfo.Hoten;
            txtBophan.Text = userInfo.Bophan;
            txtChucvu.Text = userInfo.Chucvu;
            txtManhanvien.Text = userInfo.Manhanvien;
            txtMatkhau.Text = userInfo.Matkhau;
            txtRole.Text = userInfo.Role;
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int taikhoanId = Convert.ToInt32(userInfo.Id);
            // Call the ChangeName method to update the department's name
            bool success = UserDAO.Instance.DeleteTaikhoan(taikhoanId);
            if (success)
            {
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
