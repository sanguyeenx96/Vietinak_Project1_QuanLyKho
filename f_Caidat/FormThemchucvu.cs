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

namespace Vietinak_Kho.f_Caidat
{
    public partial class FormThemchucvu : Form
    {
        public FormThemchucvu()
        {
            InitializeComponent();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenchucvu.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenchucvu = txtTenchucvu.Text.ToUpper();

            bool success = ChucvuDAO.Instance.Create(tenchucvu);
            if (success)
            {
                MessageBox.Show("Tạo chức vụ mới thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
