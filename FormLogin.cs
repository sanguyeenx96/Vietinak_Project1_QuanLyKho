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

namespace Vietinak_Kho
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void login()
        {
            string manv = txtUsername.Text;
            string pwd = txtPassword.Text;
            if (manv.Length == 0 || pwd.Length == 0)
            {

                MessageBox.Show("Cần nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (manv.Length == 0)
                {
                    txtUsername.Focus();
                }
                if (manv.Length != 0 && pwd.Length == 0)
                {
                    txtPassword.Focus();
                }
            }
            else
            {
                User userInfo = UserDAO.Instance.Login(manv, pwd);
                if (userInfo != null)
                {
                    FormMain f = new FormMain(userInfo);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

    }
}
