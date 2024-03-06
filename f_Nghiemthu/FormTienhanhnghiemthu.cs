using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Vietinak_Kho.DTO;
using Vietinak_Kho.DAO;

namespace Vietinak_Kho.f_Nghiemthu
{
    public partial class FormTienhanhnghiemthu : Form
    {
        private int lichsunhapid;
        public FormTienhanhnghiemthu()
        {
            InitializeComponent();
        }
        public void LoadData(Lichsunhapxuat lichsu)
        {
            lichsunhapid = lichsu.Id;
            txtMavattu.Text = lichsu.Mavattu;
            txtSoluongnhap.Text = lichsu.Soluongnhap + " " + lichsu.Donvi;
            txtNhapvaokho.Text = lichsu.Nhapvaokho;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng trống hoặc dòng header
                if (!row.IsNewRow)
                {
                    string lotno = row.Cells["lotno"].Value.ToString(); 
                    string soluong = row.Cells["soluong"].Value.ToString();
                    bool success = LichsunghiemthuDAO.Instance.Create(lichsunhapid);
                    if (success)
                    {
                        MessageBox.Show("Tạo tài khoản mới thành công!",
                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

     
    }
}
