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
    public partial class FormTaotaikhoanmoi : Form
    {
        public FormTaotaikhoanmoi()
        {
            InitializeComponent();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtHoten.Clear();
            txtManhanvien.Clear();
            txtMatkhau.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoten.Text) ||
                string.IsNullOrWhiteSpace(txtManhanvien.Text) ||
                string.IsNullOrWhiteSpace(cbBophan.Text) ||
                string.IsNullOrWhiteSpace(cbChucvu.Text) ||
                string.IsNullOrWhiteSpace(txtMatkhau.Text) ||
                string.IsNullOrWhiteSpace(cbRole.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            var newUser = new User()
            {
                Hoten = txtHoten.Text,
                Manhanvien = txtManhanvien.Text,
                Bophan = cbBophan.Text,
                Chucvu = cbChucvu.Text,
                Matkhau = txtMatkhau.Text,
                Role = cbRole.Text,
            };

            bool success = UserDAO.Instance.Create(newUser);
            if (success)
            {
                MessageBox.Show("Tạo tài khoản mới thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}
