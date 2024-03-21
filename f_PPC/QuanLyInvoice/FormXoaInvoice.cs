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
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_PPC.QuanLyInvoice
{
    public partial class FormXoaInvoice : Form
    {
        public event EventHandler<DialogClosedEventArgs> DialogClosed;

        private int id;

        public FormXoaInvoice(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormXoaInvoice_Load(object sender, EventArgs e)
        {
            DTO.Invoice iv = InvoiceDAO.Instance.LoadTableList_InvoiceById(id);
            if (iv != null)
            {
                txtInvoicedate.Text = iv.Invoicedate;
                txtInvoicenumber.Text = iv.Invoicenumber;
                txtInvoiceqty.Text = iv.Qty.ToString();
            };

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoice JOIN dbo.invoiceinfo ON invoice.id = invoiceinfo.invoiceid JOIN dbo.poinfo ON invoiceinfo.itemid = poinfo.id WHERE invoice.id = '" + id + "' ");
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

            // Thiết lập các cột chỉ đọc (readonly)
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "qty1") // Nếu không phải là cột qty1 thì đặt thành chỉ đọc
                    column.ReadOnly = true;
            }

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
        }

        private void btnXoaItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Kiểm tra xem có dòng nào được chọn không
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        // Lấy giá trị của cột ID trong dòng được chọn
                        int id = Convert.ToInt32(row.Cells["id1"].Value);

                        // Thực hiện câu truy vấn xóa dữ liệu của dòng có ID tương ứng
                        string deleteQuery = string.Format("DELETE FROM dbo.invoiceinfo WHERE id = '{0}'", id);
                        DataProvider.Instance.ExecuteNonQuery(deleteQuery);

                        // Xóa dòng khỏi DataGridView
                        dataGridView1.Rows.Remove(row);
                    }
                    float totalqty = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string qty1 = row.Cells["qty1"].Value.ToString().Replace(',', '.');
                        totalqty += (float)Convert.ToDouble(qty1.Replace('.', ','));
                    }
                    InvoiceDAO.Instance.Update(id, txtInvoicenumber.Text, txtInvoicedate.Text, totalqty.ToString().Replace(',', '.'));
                    MessageBox.Show("Xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoatoanbo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ Invoice?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string deleteQuery = string.Format("DELETE FROM dbo.invoice WHERE id = '{0}'", id);
                DataProvider.Instance.ExecuteNonQuery(deleteQuery);
                DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                this.Close();
                FormThanhcong fthanhcong = new FormThanhcong();
                fthanhcong.ShowDialog();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
