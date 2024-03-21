using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_PPC.Invoice
{
    public partial class FormTaoInvoice : Form
    {
        public event EventHandler<DialogClosedEventArgs> DialogClosed;

        private int id;
        private float itemqty;
        private List<DTO.Invoice> allInvoice;
        private DTO.Invoice selectInvoice;

        public FormTaoInvoice(int id, float itemqty)
        {
            InitializeComponent();
            this.id = id;
            this.itemqty = itemqty;
        }

        private void LoadMaInvoiceToComboBox(List<DTO.Invoice> allInvoice)
        {
            foreach (DTO.Invoice item in allInvoice)
            {
                cbInvoicenumber.Items.Add(item.Invoicenumber);
            }
            // Thiết lập cho ComboBox tự động gợi ý các giá trị khi gõ
            cbInvoicenumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbInvoicenumber.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int itemid = id;
            string trangthai = "Pending";
            string invoicenumber = cbInvoicenumber.Text;
            string invoicedate = txtInvoiceDate.Text;
            float qty = (float)Convert.ToDouble(txtItemqty.Text.ToString().Replace('.', ','));
            float invoiceqty = 0;

            if (selectInvoice != null)
            {
                invoiceqty = (float)Convert.ToDouble(selectInvoice.Qty.ToString().Replace('.', ',')) + (float)Convert.ToDouble(txtItemqty.Text.ToString().Replace('.', ','));
            }
            else
            {
                invoiceqty = qty;
            }

            int result1id = InvoiceDAO.Instance.CreateReturnId(trangthai, invoicenumber, invoicedate, invoiceqty.ToString().Replace(',', '.'));
            if(result1id != -1)
            {
                int result2 = InvoiceinfoDAO.Instance.CreateReturnId(result1id, itemid, qty.ToString().Replace(',', '.'),"0");
                if (result2 != -1)
                {
                    DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }

        }

        private void FormTaoInvoice_Load(object sender, EventArgs e)
        {
            allInvoice = InvoiceDAO.Instance.LoadTableList_Invoice();
            LoadMaInvoiceToComboBox(allInvoice);
            txtItemqty.Text = itemqty.ToString();
            txtTotalqty.Text = "";
        }

        private void cbInvoicenumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Invoicenumber = cbInvoicenumber.Text;
            selectInvoice = allInvoice.Where(x => x.Invoicenumber == Invoicenumber).FirstOrDefault();
            if (selectInvoice != null)
            {
                int Invoiceid = selectInvoice.Id;
                txtTotalqty.Text = selectInvoice.Qty.ToString();
                txtInvoiceDate.Text = selectInvoice.Invoicedate.ToString();

                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoiceinfo JOIN dbo.poinfo ON invoiceinfo.itemid = poinfo.id WHERE invoiceid = '" + Invoiceid + "' ");
                if (data.Rows.Count > 0)
                {
                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dataGridView1.DataSource = data;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["itemid"].Visible = false;
                    dataGridView1.Columns["poid"].Visible = false;
                    dataGridView1.Columns["id1"].Visible = false;
                    dataGridView1.Columns["total"].Visible = false;
                    dataGridView1.Columns["invoiceid"].Visible = false;

                    //dataGridView1.Columns["invoicenumber"].HeaderText = "Invoice number";
                    //dataGridView1.Columns["invoicedate"].HeaderText = "Invoice date";
                    dataGridView1.Columns["qty"].HeaderText = "Q'ty Invoice";
                    dataGridView1.Columns["dave"].HeaderText = "Số lượng đã về";

                    dataGridView1.Columns["itemcode"].HeaderText = "Item code";
                    dataGridView1.Columns["description"].HeaderText = "Description";
                    dataGridView1.Columns["partno"].HeaderText = "Part No.";
                    dataGridView1.Columns["qty1"].HeaderText = "Q'ty PO";
                    dataGridView1.Columns["unit"].HeaderText = "Unit";
                    dataGridView1.Columns["price"].HeaderText = "Item price";
                    dataGridView1.Columns["amount"].HeaderText = "Item amount";
                    dataGridView1.Columns["group"].HeaderText = "Item group";
                    dataGridView1.Columns["requesteddepartment"].HeaderText = "Item requested department";
                    dataGridView1.Columns["factory"].HeaderText = "Factory";
                    dataGridView1.Columns["etd"].HeaderText = "ETD";
                    dataGridView1.Columns["remark"].HeaderText = "Remark";
                }
            }
            else
            {
                // Xóa dữ liệu trên DataGridView
                dataGridView1.DataSource = null;

                // Xóa dữ liệu trên các TextBox
                txtItemqty.Text = itemqty.ToString();
                txtTotalqty.Text = "";
                txtInvoiceDate.Text = "";
            }

        }

        private void cbInvoicenumber_TextChanged(object sender, EventArgs e)
        {
            string Invoicenumber = cbInvoicenumber.Text;

            selectInvoice = allInvoice.Where(x => x.Invoicenumber == Invoicenumber).FirstOrDefault();
            if (selectInvoice == null)
            {
                // Xóa dữ liệu trên DataGridView
                dataGridView1.DataSource = null;

                // Xóa dữ liệu trên các TextBox
                txtItemqty.Text = itemqty.ToString();
                txtTotalqty.Text = "";
                txtInvoiceDate.Text = "";
            }
        }

        private void txtInvoiceDate_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
