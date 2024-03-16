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

namespace Vietinak_Kho.f_PPC.ThongtinSupplier
{
    public partial class FormSuaNCC : Form
    {
        public SupplierInfo info;
        private int id;
        public FormSuaNCC(SupplierInfo info)
        {
            InitializeComponent();
            this.info = info;
        }

        private void FormSuaNCC_Load(object sender, EventArgs e)
        {
            txtCode.Text = info.Code;
            txtSuppliername.Text = info.Name;
            txtPIC.Text = info.Tel;
            ttxTelephone.Text = info.Tel;
            txtAddress.Text = info.Address;
            id = info.Id;
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtSuppliername.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string curentname = info.Name;
            string curentcode = info.Code;
            string code = txtCode.Text;
            string name = txtSuppliername.Text;
            string pic = txtPIC.Text;
            string tel = ttxTelephone.Text;
            string address = txtAddress.Text;
            string lastupdate = DateTime.Now.ToString("yyyy/MM/dd");
            bool result = SupplierInfoDAO.Instance.Update(id,code, name, pic, tel, address, lastupdate,curentname,curentcode);
            if (result)
            {
                MessageBox.Show("Sửa supplier thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
