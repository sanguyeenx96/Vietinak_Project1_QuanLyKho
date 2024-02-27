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
    public partial class FormXoachucvu : Form
    {
        public FormXoachucvu()
        {
            InitializeComponent();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhanXoa_Click(object sender, EventArgs e)
        {
            int selectedChucvuId = Convert.ToInt32(cbChucvu.SelectedValue);
            bool success = ChucvuDAO.Instance.Deletechucvu(selectedChucvuId);
            if (success)
            {
                MessageBox.Show("Xóa chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void FormXoachucvu_Load(object sender, EventArgs e)
        {
            List<Chucvu> listChucvu = ChucvuDAO.Instance.LoadTableList_Chucvu();
            cbChucvu.DataSource = listChucvu;
            cbChucvu.DisplayMember = "Name";
            cbChucvu.ValueMember = "Id";
        }
    }
}
