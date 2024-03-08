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
using Vietinak_Kho.f_Khohang;
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Qccheck;

namespace Vietinak_Kho
{
    public partial class FormMain : Form
    {
        public User userInfo;
        private Button activeButton;
        public FormMain(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Hide();
            //FormLogin login = new FormLogin();
            //if (login.ShowDialog() != DialogResult.OK)
            //{
            //    Application.Exit();
            //}
            //else
            //{
            //    this.Show();
            //}
            //List<User> TableList = UserDAO.Instance.LoadTableList_User();
            //dataGridView1.DataSource = TableList;
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHoten.Text = userInfo.Hoten;
            txtBophan.Text = userInfo.Bophan;
            txtRole.Text = userInfo.Role;
            txtCode.Text = userInfo.Manhanvien;

            btnNhapXuat.PerformClick();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        private void UpdateButtonColor(Button clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Transparent;
            }
            clickedButton.BackColor = SystemColors.ActiveCaption;
            activeButton = clickedButton;
        }

        public void loadform(Form frm)
        {
            panelTong.Controls.Clear();
            AddOwnedForm(frm);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelTong.Tag = frm;
            panelTong.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void btnTrangchinh_Click(object sender, EventArgs e)
        {
            loadform(new FormBieudo());
            UpdateButtonColor(sender as Button);
        }

        private void btnTaikhoan_Click(object sender, EventArgs e)
        {
            FormTaikhoan fTaikhoan = new FormTaikhoan(userInfo);
            loadform(fTaikhoan);
            UpdateButtonColor(sender as Button);
        }

        private void btnDonhang_Click(object sender, EventArgs e)
        {
            FormNhapXuat fNhapxuat = new FormNhapXuat(userInfo);
            loadform(fNhapxuat);
            UpdateButtonColor(sender as Button);
        }

        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            loadform(new FormThongke());
            UpdateButtonColor(sender as Button);
        }

        private void btnCaidat_Click(object sender, EventArgs e)
        {
            if (userInfo.Role != "Admin")
            {
                MessageBox.Show("Chỉ tài khoản quản trị được phép truy cập!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loadform(new FormCaidat());
                UpdateButtonColor(sender as Button);
            }
        }

        private void btnNghiemthu_Click(object sender, EventArgs e)
        {
            FormNghiemthu fnt = new FormNghiemthu(userInfo);
            loadform(fnt);
            UpdateButtonColor(sender as Button);
        }

        private void btnqccheck_Click(object sender, EventArgs e)
        {
            FormQccheck fqcc = new FormQccheck(userInfo);
            loadform(fqcc);
            UpdateButtonColor(sender as Button);
        }
    }
}
