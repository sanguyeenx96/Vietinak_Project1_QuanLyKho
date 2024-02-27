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
    public partial class FormXoabophan : Form
    {
        public FormXoabophan()
        {
            InitializeComponent();
        }

        private void FormXoabophan_Load(object sender, EventArgs e)
        {
            List<Bophan> listBophan = BophanDAO.Instance.LoadTableList_Bophan();
            cbBophan.DataSource = listBophan;
            cbBophan.DisplayMember = "Name"; 
            cbBophan.ValueMember = "Id";

        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhanXoa_Click(object sender, EventArgs e)
        {         
            int selectedBophanId = Convert.ToInt32(cbBophan.SelectedValue);

            // Call the ChangeName method to update the department's name
            bool success = BophanDAO.Instance.DeleteBophan(selectedBophanId);
            if (success)
            {
                MessageBox.Show("Xóa bộ phận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
