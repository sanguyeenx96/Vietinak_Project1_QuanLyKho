﻿using System;
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
using Vietinak_Kho.f_Nghiemthu;

namespace Vietinak_Kho.f_Qccheck
{
    public partial class FormDanhsachchoqccheck : Form
    {
        private User userInfo;
        private List<Lichsunhapxuat> allCQC;

        public FormDanhsachchoqccheck(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void FormDanhsachchoqccheck_Load(object sender, EventArgs e)
        {
            allCQC = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuchoqccheck();
            foreach (var lichsu in allCQC)
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
                if (sldanghiemthu != slnhap)
                {
                    itemButton.BackColor = Color.Orange;
                }
                else
                {
                    itemButton.BackColor = Color.Blue;
                    itemButton.ForeColor = Color.White;
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
            FormTienhanhqccheck fthqcc = new FormTienhanhqccheck(userInfo);
            fthqcc.DialogClosed += Dialog_DialogClosed;

            fthqcc.LoadData(lichsu); // Truyền thông tin vào form fthnt
            fthqcc.ShowDialog();
        }

        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            // Thực hiện xử lý thông tin được truyền từ form dialog
            string infoFromDialog = e.Info;
            // Thực hiện những công việc cần thiết với thông tin nhận được từ form dialog
            if (infoFromDialog.ToString() == "OK")
            {
                flowLayoutPanel.Controls.Clear();
                allCQC = LichsunhapxuatDAO.Instance.LoadTableList_Lichsuchoqccheck();
                foreach (var lichsu in allCQC)
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
                    if (sldanghiemthu != slnhap)
                    {
                        itemButton.BackColor = Color.Orange;
                    }
                    else
                    {
                        itemButton.BackColor = Color.Blue;
                        itemButton.ForeColor = Color.White;
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
