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
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho.f_Caidat
{
    public partial class FormBophanvachucvu : Form
    {
        private List<Bophan> allBophan;
        private List<Chucvu> allChucvu;

        public FormBophanvachucvu()
        {
            InitializeComponent();
        }
        private void UpdateDataGridViewBophan(List<Bophan> bophans)
        {
            dgvBophan.DataSource = bophans;
            dgvBophan.Columns["Id"].Visible = false;
            dgvBophan.Columns["Name"].HeaderText = "Tên bộ phận";
        }
        private void UpdateDataGridViewChucvu(List<Chucvu> chucvus)
        {
            dgvChucvu.DataSource = chucvus;
            dgvChucvu.Columns["Id"].Visible = false;
            dgvChucvu.Columns["Name"].HeaderText = "Tên chức vụ";
        }
        private void FormBophanvachucvu_Load(object sender, EventArgs e)
        {
            allBophan = BophanDAO.Instance.LoadTableList_Bophan();
            allChucvu = ChucvuDAO.Instance.LoadTableList_Chucvu();
            UpdateDataGridViewBophan(allBophan);
            UpdateDataGridViewChucvu(allChucvu);
        }

        private void btnThembophan_Click(object sender, EventArgs e)
        {
            FormThembophan f = new FormThembophan();
            f.ShowDialog();
        }

        private void btnSuabophan_Click(object sender, EventArgs e)
        {
            FormSuabophan f = new FormSuabophan();
            f.ShowDialog();
        }

        private void btnXoabophan_Click(object sender, EventArgs e)
        {
            FormXoabophan f = new FormXoabophan();
            f.ShowDialog();
        }

        private void btnThemchucvu_Click(object sender, EventArgs e)
        {
            FormThemchucvu f = new FormThemchucvu();
            f.ShowDialog();
        }

        private void btnSuachucvu_Click(object sender, EventArgs e)
        {
            FormSuachucvu f = new FormSuachucvu();
            f.ShowDialog();
        }

        private void btnXoachucvu_Click(object sender, EventArgs e)
        {
            FormXoachucvu f = new FormXoachucvu();
            f.ShowDialog();
        }
    }
}
