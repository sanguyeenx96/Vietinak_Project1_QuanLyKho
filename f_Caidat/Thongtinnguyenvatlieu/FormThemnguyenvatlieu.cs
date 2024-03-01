using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    public partial class FormThemnguyenvatlieu : Form
    {
        public FormThemnguyenvatlieu()
        {
            InitializeComponent();
        }
        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMavattu.Text) ||
                string.IsNullOrWhiteSpace(cbDonvi.Text) ||
                string.IsNullOrWhiteSpace(txtKgtrenbao.Text) ||
                string.IsNullOrWhiteSpace(txtDiengiai.Text) ||
                string.IsNullOrWhiteSpace(txtTonkhoVTN.Text) ||
                string.IsNullOrWhiteSpace(txtTonkhoDRG.Text))
            {
                MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mavattu = txtMavattu.Text;
            string donvi = cbDonvi.Text.ToString();
            string diengiai = txtDiengiai.Text;
            string kgtrenbao = txtKgtrenbao.Text;
            string tonkhovtn = txtTonkhoVTN.Text;
            string tonkhodrg = txtTonkhoDRG.Text;

            if (!IsNumeric(kgtrenbao))
            {
                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường Kg/bao!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsNumeric(tonkhovtn))
            {
                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường Tồn kho VTN!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsNumeric(tonkhodrg))
            {
                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường Tồn kho DRG!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = ThongtinvattuDAO.Instance.Create(
                mavattu,donvi,kgtrenbao,diengiai,tonkhovtn,tonkhodrg);
            if (success)
            {
                MessageBox.Show("Tạo thông tin nguyên vật liệu mới thành công!",
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
