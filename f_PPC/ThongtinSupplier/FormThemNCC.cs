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

namespace Vietinak_Kho.f_PPC.ThongtinSupplier
{
    public partial class FormThemNCC : Form
    {
        public FormThemNCC()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtSuppliername.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string code = txtCode.Text;
            string name = txtSuppliername.Text;
            string pic = txtPIC.Text;
            string tel = ttxTelephone.Text;
            string address = txtAddress.Text;
            string lastupdate = DateTime.Now.ToString("yyyy/MM/dd");
            bool result = SupplierInfoDAO.Instance.Create(code, name, pic, tel, address, lastupdate);
            if (result)
            {
                MessageBox.Show("Tạo supplier mới thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
