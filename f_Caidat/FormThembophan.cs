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
    public partial class FormThembophan : Form
    {
        public FormThembophan()
        {
            InitializeComponent();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenbophan.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenbophan = txtTenbophan.Text.ToUpper();

            bool success = BophanDAO.Instance.Create(tenbophan);
            if (success)
            {
                MessageBox.Show("Tạo bộ phận mới thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
