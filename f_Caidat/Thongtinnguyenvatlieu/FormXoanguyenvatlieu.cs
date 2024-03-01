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

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    public partial class FormXoanguyenvatlieu : Form
    {
        public Thongtinvattu ttvt;

        public FormXoanguyenvatlieu(Thongtinvattu ttvt)
        {
            InitializeComponent();
            this.ttvt = ttvt;
        }

        private void FormXoanguyenvatlieu_Load(object sender, EventArgs e)
        {
            txtMavattu.Text = ttvt.Mavattu;
            txtDonvi.Text = ttvt.Donvi;
            txtKgtrenbao.Text = ttvt.Kgtrenbao.ToString();
            txtDiengiai.Text = ttvt.Diengiai;
            txtTonkhoVTN.Text = ttvt.Tonkhovtn.ToString();
            txtTonkhoDRG.Text = ttvt.Tonkhodrg.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int vattuId = Convert.ToInt32(ttvt.Id);

            // Call the ChangeName method to update the department's name
            bool success = ThongtinvattuDAO.Instance.Delete(vattuId);
            if (success)
            {
                MessageBox.Show("Xóa thông tin vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
