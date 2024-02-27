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

            List<Bophan> listBophan = BophanDAO.Instance.LoadTableList_Bophan();
            cbBophan.DataSource = listBophan;
            cbBophan.DisplayMember = "Name"; // Replace "TenBophan" with the actual property name representing the department name in your Bophan class
            cbBophan.ValueMember = "Id"; // Assuming "Id" is the property representing the ID in your Bophan class
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
