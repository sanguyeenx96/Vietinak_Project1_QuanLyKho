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

namespace Vietinak_Kho.f_PPC.QuanLyInvoice
{
    public partial class FormXemchitietInvoice : Form
    {
        private int id;

        public FormXemchitietInvoice(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormXemchitietInvoice_Load(object sender, EventArgs e)
        {
            DTO.Invoice iv = InvoiceDAO.Instance.LoadTableList_InvoiceById(id);
            if (iv != null)
            {
                txtInvoicedate.Text = iv.Invoicedate;
                txtInvoicenumber.Text = iv.Invoicenumber;
                txtInvoiceqty.Text = iv.Qty.ToString();
            };

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoice JOIN dbo.invoiceinfo ON invoice.id = invoiceinfo.invoiceid JOIN dbo.poinfo ON invoiceinfo.itemid = poinfo.id WHERE invoice.id = '" + id + "' ");

            // Thêm cột mới cho tên PO
            DataGridViewTextBoxColumn poNameColumn = new DataGridViewTextBoxColumn();
            poNameColumn.Name = "poName";
            poNameColumn.HeaderText = "PO No";
            dataGridView1.Columns.Add(poNameColumn);

            dataGridView1.DataSource = data;
            dataGridView1.AllowUserToAddRows = false;

            // Ẩn các cột không cần thiết
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["itemid"].Visible = false;
            dataGridView1.Columns["poid"].Visible = false;
            dataGridView1.Columns["id1"].Visible = false;
            dataGridView1.Columns["id2"].Visible = false;
            dataGridView1.Columns["total"].Visible = false;
            dataGridView1.Columns["invoiceid"].Visible = false;
            dataGridView1.Columns["qty"].Visible = false;
            dataGridView1.Columns["invoicenumber"].Visible = false;
            dataGridView1.Columns["invoicedate"].Visible = false;

            // Thiết lập màu nền cho cột qty1
            dataGridView1.Columns["qty1"].DefaultCellStyle.BackColor = Color.Yellow;

            // Đặt tiêu đề cho các cột
            dataGridView1.Columns["trangthai"].HeaderText = "Trạng thái";
            dataGridView1.Columns["dave"].HeaderText = "Số lượng đã về";
            dataGridView1.Columns["itemcode"].HeaderText = "Item code";
            dataGridView1.Columns["description"].HeaderText = "Description";
            dataGridView1.Columns["partno"].HeaderText = "Part No.";
            dataGridView1.Columns["qty1"].HeaderText = "Q'ty Invoice"; // Cột này đã được thiết lập màu vàng và cho phép sửa
            dataGridView1.Columns["qty2"].HeaderText = "Q'ty PO";
            dataGridView1.Columns["unit"].HeaderText = "Unit";
            dataGridView1.Columns["price"].HeaderText = "Item price";
            dataGridView1.Columns["amount"].HeaderText = "Item amount";
            dataGridView1.Columns["group"].HeaderText = "Item group";
            dataGridView1.Columns["requesteddepartment"].HeaderText = "Item requested department";
            dataGridView1.Columns["factory"].HeaderText = "Factory";
            dataGridView1.Columns["etd"].HeaderText = "ETD";
            dataGridView1.Columns["remark"].HeaderText = "Remark";


            // Lấy tên PO và gắn vào cột mới "poName"
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int poid = Convert.ToInt32(row.Cells["poid"].Value);
                var poInfo = PoDAO.Instance.LoadTableList_PoById(poid);
                string poName = poInfo.No;
                row.Cells["poName"].Value = poName;
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
