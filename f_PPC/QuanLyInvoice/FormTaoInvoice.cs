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

namespace Vietinak_Kho.f_PPC.Invoice
{
    public partial class FormTaoInvoice : Form
    {
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
            float qty = (float)Convert.ToDouble(txtTotalQty.Text.ToString().Replace('.', ',')) + itemqty;

            int result = InvoiceDAO.Instance.CreateReturnId(itemid, trangthai, invoicenumber, invoicedate, qty);
            if(result != -1)
            {
                MessageBox.Show("Thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

        }

        private void FormTaoInvoice_Load(object sender, EventArgs e)
        {
            allInvoice = InvoiceDAO.Instance.LoadTableList_Invoice();
            LoadMaInvoiceToComboBox(allInvoice);
            txtTotalQty.Text = itemqty.ToString();
        }

        private void cbInvoicenumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Invoicenumber = cbInvoicenumber.SelectedItem.ToString();
            selectInvoice = allInvoice.Where(x => x.Invoicenumber == Invoicenumber).FirstOrDefault();
            if (selectInvoice != null)
            {
                txtTotalQty.Text = selectInvoice.Qty.ToString();
                txtInvoiceDate.Text = selectInvoice.Invoicedate.ToString();
                List<DTO.Invoice> invoices = allInvoice.Where(x => x.Invoicenumber == Invoicenumber).ToList();
                dataGridView1.DataSource = invoices;
            }

        }
    }
}
