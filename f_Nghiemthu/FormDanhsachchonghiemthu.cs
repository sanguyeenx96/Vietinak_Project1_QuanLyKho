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
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_Nghiemthu
{
    public partial class FormDanhsachchonghiemthu : Form
    {
        private User userInfo;

        private List<Lichsunhapxuat> allCNT;
        public FormDanhsachchonghiemthu(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void FormDanhsachchonghiemthu_Load(object sender, EventArgs e)
        {
            allCNT = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuchonghiemthu();
            foreach (var lichsu in allCNT)
            {
                float slnhap = (float)Convert.ToDouble(lichsu.Soluongnhap.ToString());
                float sldanghiemthu = (float)Convert.ToDouble(lichsu.Soluongdanghiemthu.ToString());
                float slchuanghiemthu = slnhap - sldanghiemthu;
                // Tạo một Button để hiển thị thông tin của mỗi phần tử
                Button itemButton = new Button();
                itemButton.Size = new Size(220, 150);
                itemButton.Text =
                    "\n"
                    + lichsu.Mavattu + "\n"
                    + "Invoice No.: " + lichsu.Invoiceno + "\n"
                    + "Part No.: " + lichsu.Partno + "\n"
                    + "\n"
                    + "Số lượng nhập: " + lichsu.Soluongnhap + " " + lichsu.Donvi + "\n"
                    + "Số lượng chưa nghiệm thu: " + slchuanghiemthu.ToString() + " " + lichsu.Donvi + "\n"
                    + "\n"
                    + "Nhập vào kho: " + lichsu.Nhapvaokho + "\n"
                    + "Thời gian nhập: " + lichsu.Thoigian + "\n"
                    + "\n"
                    ;
                if (lichsu.Nhapvaokho == "NHẬP LẠI")
                {
                    itemButton.BackColor = Color.Purple;
                    itemButton.ForeColor = Color.White;
                }
                else if(sldanghiemthu != 0)
                {
                    itemButton.BackColor = Color.Orange;
                }
                else
                {
                    itemButton.BackColor = Color.Gold; // Tuỳ chỉnh màu nền và kích thước
                }
                itemButton.Tag = lichsu;
                itemButton.Click += ItemButtonClick;
                // Thêm Button vào FlowLayoutPanel
                flowLayoutPanel.Controls.Add(itemButton);
            }
        }

        private void ItemButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Lichsunhapxuat lichsu = (Lichsunhapxuat)clickedButton.Tag;

            if(lichsu.Nhapvaokho == "NHẬP LẠI")
            {
                FormNhaplai fnl = new FormNhaplai(userInfo);
                fnl.DialogClosed += Dialog_DialogClosed;
                fnl.LoadData(lichsu); // Truyền thông tin vào form fthnt
                fnl.ShowDialog();
            }
            else
            {
                FormTienhanhnghiemthu fthnt = new FormTienhanhnghiemthu(userInfo);
                fthnt.DialogClosed += Dialog_DialogClosed;

                fthnt.LoadData(lichsu); // Truyền thông tin vào form fthnt
                fthnt.ShowDialog();
            }
        }

        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            // Thực hiện xử lý thông tin được truyền từ form dialog
            string infoFromDialog = e.Info;
            // Thực hiện những công việc cần thiết với thông tin nhận được từ form dialog
            if(infoFromDialog.ToString() == "OK")
            {
                flowLayoutPanel.Controls.Clear();
                allCNT = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuchonghiemthu();
                foreach (var lichsu in allCNT)
                {
                    float slnhap = (float)Convert.ToDouble(lichsu.Soluongnhap.ToString());
                    float sldanghiemthu = (float)Convert.ToDouble(lichsu.Soluongdanghiemthu.ToString());
                    float slchuanghiemthu = slnhap - sldanghiemthu;
                    // Tạo một Button để hiển thị thông tin của mỗi phần tử
                    Button itemButton = new Button();
                    itemButton.Size = new Size(220, 150);
                    itemButton.Text =
                        "\n"
                        + lichsu.Mavattu + "\n"
                        + "Invoice No.: " + lichsu.Invoiceno + "\n"
                        + "Part No.: " + lichsu.Partno + "\n"
                        + "\n"
                        + "Số lượng nhập: " + lichsu.Soluongnhap + " " + lichsu.Donvi + "\n"
                        + "Số lượng chưa nghiệm thu: " + slchuanghiemthu.ToString() + " " + lichsu.Donvi + "\n"
                        + "\n"
                        + "Nhập vào kho: " + lichsu.Nhapvaokho + "\n"
                        + "Thời gian nhập: " + lichsu.Thoigian + "\n"
                        + "\n"
                        ;
                    if (lichsu.Nhapvaokho == "NHẬP LẠI")
                    {
                        itemButton.BackColor = Color.Purple;
                        itemButton.ForeColor = Color.White;
                    }
                    else if (slchuanghiemthu != slnhap)
                    {
                        itemButton.BackColor = Color.Orange;
                    }
                    else
                    {
                        itemButton.BackColor = Color.Gold; // Tuỳ chỉnh màu nền và kích thước
                    }
                    itemButton.Tag = lichsu;
                    itemButton.Click += ItemButtonClick;
                    // Thêm Button vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(itemButton);
                }
            }
        }

    }
}
