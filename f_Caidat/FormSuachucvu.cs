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

namespace Vietinak_Kho.f_Caidat
{
    public partial class FormSuachucvu : Form
    {
        public FormSuachucvu()
        {
            InitializeComponent();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewname.Text) ||
                string.IsNullOrWhiteSpace(cbChucvu.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedChucvuId = Convert.ToInt32(cbChucvu.SelectedValue);
            string newChucvuName = txtNewname.Text.ToUpper();

            // Call the ChangeName method to update the department's name
            bool success = ChucvuDAO.Instance.ChangeName(selectedChucvuId, newChucvuName);

            if (success)
            {
                MessageBox.Show("Đổi tên chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh the ComboBox to reflect the updated department name
                this.Close();
            }
        }

        private void FormSuachucvu_Load(object sender, EventArgs e)
        {
            List<Chucvu> listChucvu = ChucvuDAO.Instance.LoadTableList_Chucvu();
            // Set the ComboBox data source and display member
            cbChucvu.DataSource = listChucvu;
            cbChucvu.DisplayMember = "Name"; // Replace "TenBophan" with the actual property name representing the department name in your Bophan class
            cbChucvu.ValueMember = "Id"; // Assuming "Id" is the property representing the ID in your Bophan class

        }
    }
}
