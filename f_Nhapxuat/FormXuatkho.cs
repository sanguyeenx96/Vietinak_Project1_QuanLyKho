using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.f_Nhapxuat
{
    public partial class FormXuatkho : Form
    {
        public User userInfo;
        private List<Thongtinvattu> allThongtinvattu;
        private Thongtinvattu infoThongtinvattu;
        public FormXuatkho(User userInfo)
        {
            InitializeComponent();
            LoadMavattuToComboBox();
            this.userInfo = userInfo;
        }
        private bool IsNumeric(string input)
        {
            // Biểu thức chính quy kiểm tra chuỗi chỉ chứa chữ số và dấu chấm
            string pattern = @"^[0-9]*\.?[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        private void LoadMavattuToComboBox()
        {
            allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();
            foreach (Thongtinvattu item in allThongtinvattu)
            {
                cbmavattu.Items.Add(item.Mavattu);
            }
            // Thiết lập cho ComboBox tự động gợi ý các giá trị khi gõ
            cbmavattu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbmavattu.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void FormXuatkho_Load(object sender, EventArgs e)
        {
            txtNgaygioxuat.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            txtNguoithaotac.Text = userInfo.Hoten;
            cbmavattu.Focus();
        }

        private void cbmavattu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMavattu = cbmavattu.SelectedItem.ToString();
            infoThongtinvattu = allThongtinvattu.Where(x => x.Mavattu == selectedMavattu).FirstOrDefault();
            if (infoThongtinvattu != null)
            {
                txtDiengiai.Text = infoThongtinvattu.Diengiai.ToString();
                txtDonvitinh.Text = infoThongtinvattu.Donvi.ToString();
                txtKgtrenbao.Text = infoThongtinvattu.Kgtrenbao.ToString();
                txtTonkhovtn.Text = infoThongtinvattu.Tonkhovtn.ToString();
                txttonkhodrg.Text = infoThongtinvattu.Tonkhodrg.ToString();
                txtdonvi2.Text = infoThongtinvattu.Donvi.ToString();
            }
        }

        private void cbmavattu_Leave(object sender, EventArgs e)
        {

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbmavattu.Text) ||
                string.IsNullOrWhiteSpace(txtSoluongxuat.Text) ||
                string.IsNullOrWhiteSpace(cbMucdichxuat.Text)
                )
            {
                MessageBox.Show("Cần nhập đầy đủ các thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsNumeric(txtSoluongxuat.Text))
            {
                MessageBox.Show("Vui lòng chỉ nhập số và dấu chấm cho trường số lượng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int vattuid = infoThongtinvattu.Id;
            string mavattu = infoThongtinvattu.Mavattu;
            string donvi = infoThongtinvattu.Donvi;
            string tennguoithaotac = userInfo.Hoten;
            string manhanvien = userInfo.Manhanvien;
            string bophan = userInfo.Bophan;
            string loaithaotac = "Xuất";
            string thoigian = txtNgaygioxuat.Text;
            float soluongxuat = (float)Convert.ToDouble(txtSoluongxuat.Text.ToString().Replace('.', ','));
            string mucdichxuat = cbMucdichxuat.Text;
            //Tính toán sô lượng hàng nhập
            float tonkhotruocxuatVTN = (float)Convert.ToDouble(infoThongtinvattu.Tonkhovtn.ToString());
            float tonkhotruocxuatDRG = (float)Convert.ToDouble(infoThongtinvattu.Tonkhodrg.ToString());
            float tonkhosauxuatVTN = tonkhotruocxuatVTN;
            float tonkhosauxuatDRG = tonkhotruocxuatDRG;

            if (mucdichxuat == "XUẤT DRG - NHẬP VTN")
            {
                tonkhosauxuatVTN += soluongxuat;
                tonkhosauxuatDRG -= soluongxuat;
            }
            else if (mucdichxuat == "XUẤT VTN - NHẬP DRG")
            {
                tonkhosauxuatVTN -= soluongxuat;
                tonkhosauxuatDRG += soluongxuat;
            }
            else if (mucdichxuat == "XUẤT SẢN XUẤT")
            {
                tonkhosauxuatVTN -= soluongxuat;
            }
            else if (mucdichxuat == "XUẤT NG")
            {
                tonkhosauxuatVTN -= soluongxuat;
            }

            FormThongtinxuat fttx = new FormThongtinxuat(mavattu,soluongxuat,mucdichxuat,donvi);
            fttx.ShowDialog();

            //bool success1 = LichsunhapxuatDAO.Instance.Xuat(vattuid, mavattu, donvi, tennguoithaotac,
            // manhanvien, bophan, loaithaotac, thoigian,
            // soluongxuat.ToString().Replace(',', '.'), mucdichxuat, tonkhotruocxuatVTN.ToString().Replace(',', '.'), tonkhosauxuatVTN.ToString().Replace(',', '.'),
            //tonkhotruocxuatDRG.ToString().Replace(',', '.'), tonkhosauxuatDRG.ToString().Replace(',', '.'));

            //bool success2 = ThongtinvattuDAO.Instance.UpdateTonkho(vattuid, tonkhosauxuatVTN.ToString().Replace(',', '.'), tonkhosauxuatDRG.ToString().Replace(',', '.'));
            //if (success1 && success2)
            //{
            //    allThongtinvattu = ThongtinvattuDAO.Instance.LoadTableList_Thongtinvattu();

            //    txtDiengiai.Text = "";
            //    txtDonvitinh.Text = "";
            //    txtKgtrenbao.Text = "";
            //    txtTonkhovtn.Text = "";
            //    txttonkhodrg.Text = "";
            //    txtSoluongxuat.Text = "";
            //    txtdonvi2.Text = "_";
            //    cbmavattu.Text = "";
            //    cbmavattu.Focus();
            //    FormThanhcong fthanhcong = new FormThanhcong();
            //    fthanhcong.ShowDialog();
            //}
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            txtDiengiai.Text = "";
            txtDonvitinh.Text = "";
            txtKgtrenbao.Text = "";
            txtTonkhovtn.Text = "";
            txttonkhodrg.Text = "";
            txtSoluongxuat.Text = "";
            txtdonvi2.Text = "_";
            cbmavattu.Text = "";
            cbmavattu.Focus();
        }

        private void txtSoluongxuat_Enter(object sender, EventArgs e)
        {
            string userInput = cbmavattu.Text;
            if (allThongtinvattu.Where(x => x.Mavattu == userInput).Count() == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin vật tư liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiengiai.Text = "";
                txtDonvitinh.Text = "";
                txtKgtrenbao.Text = "";
                txtTonkhovtn.Text = "";
                txttonkhodrg.Text = "";
                txtdonvi2.Text = "_";
                cbmavattu.Focus();
            }
        }
    }
}


// Firstly, I want to thank everyone for giving me the opportunity to be here today.
// I studied Information Technology for two years at Hanoi Vocational College of Technology
// Then i was retook the university exam and passed to national economic university, business manager major.
// during university studies time, i has a job at pumpkin jsc, its an outsourcing company that develops software and I discovered my passion for coding and software development.
// After about 2 year working at that about develop winform application,I joined Canon Electronics Vietnam in the Product Engineering Department.
// My job is making website using asp .net , making application using c# winform and python application to computer vision.
// and after about 3 year working at that, i know mektec are hiring employee and i draw my cv to mektec. 
// I am confident in my experience and knowledge, please give me the opportunity to show my abilities to you. Thank you!