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
    public partial class FormSua : Form
    {
        public User userInfo;

        public FormSua(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void FormSua_Load(object sender, EventArgs e)
        {
            txtHoten.Text = userInfo.Hoten;
            txtManhanvien.Text = userInfo.Manhanvien;
            txtMatkhau.Text = userInfo.Matkhau;

            List<Bophan> listBophan = BophanDAO.Instance.LoadTableList_Bophan();
            cbBophan.DataSource = listBophan;
            cbBophan.DisplayMember = "Name"; 
            cbBophan.ValueMember = "Name";
            cbBophan.SelectedValue = userInfo.Bophan;

            List<Chucvu> listChucvu = ChucvuDAO.Instance.LoadTableList_Chucvu();
            cbChucvu.DataSource = listChucvu;
            cbChucvu.DisplayMember = "Name"; 
            cbChucvu.ValueMember = "Name";
            cbChucvu.SelectedValue = userInfo.Chucvu;

            cbRole.SelectedItem = userInfo.Role;
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra null cho các chuỗi và giá trị được chọn từ ComboBox
            string hoten = string.IsNullOrWhiteSpace(txtHoten.Text) ? null : txtHoten.Text;
            string manhanvien = string.IsNullOrWhiteSpace(txtManhanvien.Text) ? null : txtManhanvien.Text;
            string matkhau = string.IsNullOrWhiteSpace(txtMatkhau.Text) ? null : txtMatkhau.Text;
            string bophan = cbBophan.SelectedItem == null ? null : cbBophan.SelectedValue.ToString();
            string chucvu = cbChucvu.SelectedItem == null ? null : cbChucvu.SelectedValue.ToString();
            string role = cbRole.SelectedItem == null ? null : cbRole.SelectedItem.ToString();

            // Kiểm tra nếu một trong các giá trị bị null, hiển thị thông báo và không thực hiện cập nhật
            if (string.IsNullOrWhiteSpace(hoten) || string.IsNullOrWhiteSpace(manhanvien) || string.IsNullOrWhiteSpace(matkhau) || string.IsNullOrWhiteSpace(bophan) || string.IsNullOrWhiteSpace(chucvu) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo một đối tượng User mới với thông tin đã được cập nhật
            User updatedUser = new User()
            {
                Hoten = hoten,
                Manhanvien = manhanvien,
                Matkhau = matkhau,
                Bophan = bophan,
                Chucvu = chucvu,
                Role = role
            };

            // Gọi phương thức update để cập nhật thông tin người dùng
            bool success = UserDAO.Instance.Update(updatedUser);

            // Kiểm tra kết quả và hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
            }
        }


    }
}
