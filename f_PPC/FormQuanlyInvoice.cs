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
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_PPC.QuanLyInvoice;

namespace Vietinak_Kho.f_PPC
{
    public partial class FormQuanlyInvoice : Form
    {
        private List<DTO.Invoice> allInvoices;
        public FormQuanlyInvoice()
        {
            InitializeComponent();
        }

        private void FormQuanlyInvoice_Load(object sender, EventArgs e)
        {
            allInvoices = InvoiceDAO.Instance.LoadTableList_Invoice();
            txttotal.Text = "Total: " + allInvoices.Count().ToString();
            txtdone.Text = "Done: " + allInvoices.Where(x => x.Trangthai == "Done").Count().ToString();
            txtpending.Text = "Pending: " + allInvoices.Where(x => x.Trangthai == "Pending").Count().ToString();

            UpdateDataGridViewThongtinvattu(allInvoices);
            
        }

        private void UpdateDataGridViewThongtinvattu(List<DTO.Invoice> allInvoices)
        {
            dataGridView1.DataSource = allInvoices;
            dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);

        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["trangthai"].Index && e.Value != null)
            {
                string trangthai = e.Value.ToString();
                if (trangthai == "Pending")
                {
                    e.CellStyle.BackColor = Color.Orange; // Tô màu cam cho trạng thái "Pending"
                }
                else if (trangthai == "Done")
                {
                    e.CellStyle.BackColor = Color.LightGreen; // Tô màu xanh lá cho trạng thái "Done"
                }
            }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtLoc.Text.Trim();
            List<DTO.Invoice> filteredttvt;
            filteredttvt = allInvoices;

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredttvt = filteredttvt.Where(x =>
                    x.Invoicedate.ToLower().Contains(searchText.ToLower()) ||
                    x.Invoicenumber.ToLower().Contains(searchText.ToLower()) ||
                    x.Trangthai.ToString().ToLower().Contains(searchText.ToLower()) 
                ).ToList();
            }

            // Update the DataGridView with the filtered users
            UpdateDataGridViewThongtinvattu(filteredttvt);
            txttotal.Text = "Total: "+ filteredttvt.Count().ToString();
            txtdone.Text = "Done: " + filteredttvt.Where(x => x.Trangthai == "Done").Count().ToString();
            txtpending.Text = "Pending: " + filteredttvt.Where(x => x.Trangthai == "Pending").Count().ToString();
        }
        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            allInvoices = InvoiceDAO.Instance.LoadTableList_Invoice();
            string searchText = txtLoc.Text.Trim();
            List<DTO.Invoice> filteredttvt;
            filteredttvt = allInvoices;

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredttvt = filteredttvt.Where(x =>
                    x.Invoicedate.ToLower().Contains(searchText.ToLower()) ||
                    x.Invoicenumber.ToLower().Contains(searchText.ToLower()) ||
                    x.Trangthai.ToString().ToLower().Contains(searchText.ToLower())
                ).ToList();
            }

            // Update the DataGridView with the filtered users
            UpdateDataGridViewThongtinvattu(filteredttvt);
            txttotal.Text = "Total: " + filteredttvt.Count().ToString();
            txtdone.Text = "Done: " + filteredttvt.Where(x => x.Trangthai == "Done").Count().ToString();
            txtpending.Text = "Pending: " + filteredttvt.Where(x => x.Trangthai == "Pending").Count().ToString();
        }
        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                FormXemchitietInvoice f = new FormXemchitietInvoice(id);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                FormSuaInvoice f = new FormSuaInvoice(id);
                f.DialogClosed += Dialog_DialogClosed;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                FormXoaInvoice f = new FormXoaInvoice(id);
                f.DialogClosed += Dialog_DialogClosed;

                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
