using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    public partial class FormSuanguyenvatlieu : Form
    {
        private List<Thongtinvattu> mavattuList;
        private string mavattucu;
        private int idvattu;

        public FormSuanguyenvatlieu()
        {
            InitializeComponent();
            LoadMavattuToComboBox();
        }
        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        private void LoadMavattuToComboBox()
        {
            mavattuList = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
            foreach (Thongtinvattu mavattu in mavattuList)
            {
                cbMavattu.Items.Add(mavattu.Mavattu);
            }
            // Thiết lập cho ComboBox tự động gợi ý các giá trị khi gõ
            cbMavattu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMavattu.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void FormSuanguyenvatlieu_Load(object sender, EventArgs e)
        {
            cbMavattu.Focus();
        }

        private void cbMavattu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMavattu = cbMavattu.SelectedItem.ToString();
            var info = mavattuList.Where(x => x.Mavattu == selectedMavattu).FirstOrDefault();
            if (info != null)
            {
                cbDonvi.SelectedItem = info.Donvi.ToString();
                txtKgtrenbao.Text = info.Kgtrenbao.ToString();
                txtDiengiai.Text = info.Diengiai.ToString();
                txtTonkhoVTN.Text = info.Tonkhovtn.ToString();
                txtTonkhoDRG.Text = info.Tonkhodrg.ToString();
                txtMavattumoi.Text = info.Mavattu.ToString();
                mavattucu = info.Mavattu;
                idvattu = info.Id;
            }
        }

        private void cbMavattu_Leave(object sender, EventArgs e)
        {
            string userInput = cbMavattu.Text;
            // Kiểm tra xem giá trị đã nhập có tồn tại trong danh sách không
            if (mavattuList.Where(x => x.Mavattu == userInput).Count() == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMavattumoi.Text = "";
                txtKgtrenbao.Text = "";
                txtDiengiai.Text = "";
                txtTonkhoVTN.Text = "";
                txtTonkhoDRG.Text = "";
                cbDonvi.SelectedValue = "";
                cbMavattu.Focus();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMavattu.Text) || string.IsNullOrEmpty(txtMavattumoi.Text)
                || string.IsNullOrEmpty(cbDonvi.Text) || string.IsNullOrEmpty(txtKgtrenbao.Text)
                || string.IsNullOrEmpty(txtDiengiai.Text) || string.IsNullOrEmpty(txtTonkhoVTN.Text)
                || string.IsNullOrEmpty(txtTonkhoDRG.Text)
                )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            int id = idvattu;
            string mavattu = txtMavattumoi.Text;
            string donvi = cbDonvi.Text;
            string kgtrenbao = txtKgtrenbao.Text;
            string diengiai = txtDiengiai.Text;
            string tonkhovtn = txtTonkhoVTN.Text;
            string tonkhodrg = txtTonkhoDRG.Text;

            bool success = ThongtinvattuDAO.Instance.Update(id, mavattu, donvi, kgtrenbao, diengiai,
            tonkhovtn, tonkhodrg, mavattucu);
            if (success)
            {
                MessageBox.Show("Cập nhật thông tin nguyên vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
            }
        }
    }
}