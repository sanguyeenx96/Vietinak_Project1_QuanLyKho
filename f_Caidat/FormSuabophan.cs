using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Vietinak_Kho.DTO;
using Vietinak_Kho.DAO;

namespace Vietinak_Kho.f_Caidat
{
    public partial class FormSuabophan : Form
    {
        public FormSuabophan()
        {
            InitializeComponent();
        }

        private void FormSuabophan_Load(object sender, EventArgs e)
        {
            List<Bophan> listBophan = BophanDAO.Instance.LoadTableList_Bophan();
            // Set the ComboBox data source and display member
            cbBophan.DataSource = listBophan;
            cbBophan.DisplayMember = "Name"; // Replace "TenBophan" with the actual property name representing the department name in your Bophan class
            cbBophan.ValueMember = "Id"; // Assuming "Id" is the property representing the ID in your Bophan class
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewname.Text) ||
                string.IsNullOrWhiteSpace(cbBophan.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedBophanId = Convert.ToInt32(cbBophan.SelectedValue);
            string newBophanName = txtNewname.Text.ToUpper();

            // Call the ChangeName method to update the department's name
            bool success = BophanDAO.Instance.ChangeName(selectedBophanId, newBophanName);

            if (success)
            {
                MessageBox.Show("Đổi tên bộ phận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh the ComboBox to reflect the updated department name
                this.Close();
            }
        }
    }
}
