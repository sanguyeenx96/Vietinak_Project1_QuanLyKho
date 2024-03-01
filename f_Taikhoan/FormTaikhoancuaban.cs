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
    public partial class FormTaikhoancuaban : Form
    {
        public User userInfo;
        private List<Userlogs> alllogs;

        public FormTaikhoancuaban(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void UpdateDataGridViewLog(List<Userlogs> logs)
        {
            dgvUserlogs.DataSource = logs;
            dgvUserlogs.Columns["Id"].Visible = false;
            dgvUserlogs.Columns["Userid"].Visible = false;
            dgvUserlogs.Columns["Noidung"].HeaderText = "Nội dung";
            dgvUserlogs.Columns["Phuongthuc"].HeaderText = "Phương thức";
            dgvUserlogs.Columns["Ngaygio"].HeaderText = "Ngày giờ";
        }

        private void FormTaikhoancuaban_Load(object sender, EventArgs e)
        {
            groupboxDoimatkhau.Visible = false;
            txtHoten.Text = userInfo.Hoten;
            txtBophan.Text = userInfo.Bophan;
            txtChucvu.Text = userInfo.Chucvu;
            txtManhanvien.Text = userInfo.Manhanvien;
            txtRole.Text = userInfo.Role;

            alllogs = UserlogsDAO.Instance.LoadTableList_Loc(userInfo.Id,"","");
            UpdateDataGridViewLog(alllogs);
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            groupboxDoimatkhau.Visible = true;
        }

        private void btnHuybodoimatkhau_Click(object sender, EventArgs e)
        {
            groupboxDoimatkhau.Visible = false;
        }

        private void btnXacnhandoimatkhau_Click(object sender, EventArgs e)
        {
            string currentPass = txtMatkhauhientai.Text;
            if(currentPass != userInfo.Matkhau)
            {
                MessageBox.Show("Mật khẩu hiện tại không chính xác!",
                       "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatkhauhientai.Text = "";
                txtMatkhaumoi.Text = "";
            }
            else
            {
                string newPass = txtMatkhaumoi.Text;
                bool result = UserDAO.Instance.UpdatePassword(userInfo.Id, newPass);
                if (result)
                {
                    UserlogsDAO.Instance.InsertUserLog(userInfo.Id, "Thay đổi mật khẩu", "Update");
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatkhauhientai.Text = "";
                    txtMatkhaumoi.Text = "";
                    btnHuybodoimatkhau.PerformClick();
                }
            }

        }
    }
}
