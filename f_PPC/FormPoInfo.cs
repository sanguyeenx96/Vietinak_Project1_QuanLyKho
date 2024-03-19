using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_PPC
{
    public partial class FormPoInfo : Form
    {
        public event EventHandler<DialogClosedEventArgs> DialogClosed;

        private List<Danhsachnguyenvatlieu> allThongtinvattu;
        private Danhsachnguyenvatlieu infoThongtinvattu;

        private string orderto;
        private string no;
        private float total = 0;
        private int poid;
        public FormPoInfo(string orderto, string no,int poid)
        {
            InitializeComponent();
            this.orderto = orderto;
            this.no = no;
            this.poid = poid;
        }

        private void FormPoInfo_Load(object sender, EventArgs e)
        {
            allThongtinvattu = DanhsachnguyenvatlieuDAO.Instance.LoadTableList_Danhsachnguyenvatlieu();
            getItemcodeToCombobox(allThongtinvattu);
            txtOrderto.Text = orderto;
            txtNo.Text = no;
            txtTotal.Text = total.ToString();
        }
        private void getItemcodeToCombobox(List<Danhsachnguyenvatlieu> allThongtinvattu)
        {
            foreach (Danhsachnguyenvatlieu item in allThongtinvattu)
            {
                cbItemcode.Items.Add(item.Vtncode);
            }
            // Thiết lập cho ComboBox tự động gợi ý các giá trị khi gõ
            cbItemcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbItemcode.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbItemcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecteditemcode = cbItemcode.SelectedItem.ToString();
            infoThongtinvattu = allThongtinvattu.Where(x => x.Vtncode == selecteditemcode).FirstOrDefault();
            if (infoThongtinvattu != null)
            {
                txtDescription.Text = infoThongtinvattu.Materialppc.ToString();
                txtPartno.Text = infoThongtinvattu.Itemcode.ToString();
                txtUnit.Text = infoThongtinvattu.Unit.ToString();
                txtPrice.Text = infoThongtinvattu.Unitprice.ToString();
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if(txtQty.TextLength > 0)
            {
                float qty = (float)Convert.ToDouble(txtQty.Text.ToString().Replace('.', ','));
                float price = (float)Convert.ToDouble(txtPrice.Text.ToString().Replace('.', ','));
                float amount = qty * price;
                txtAmount.Text = amount.ToString();
            }
        
        }

        private int rowCounter = 1; // Biến đếm dùng để tự động tăng giá trị cột "No"
        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cbItemcode.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điển đầy đủ thông tin!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPartno.Text) ||
                string.IsNullOrWhiteSpace(txtQty.Text) ||
                string.IsNullOrWhiteSpace(txtUnit.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtAmount.Text) ||
                string.IsNullOrWhiteSpace(txtGroup.Text) ||
                string.IsNullOrWhiteSpace(txtRequesteddepartment.Text) ||
                string.IsNullOrWhiteSpace(txtfactory.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            string itemcode = cbItemcode.Text;
            string description = txtDescription.Text;
            string partNo = txtPartno.Text;
            string qty = txtQty.Text; 
            string unit = txtUnit.Text;
            string price = txtPrice.Text;
            string amount = txtAmount.Text;
            string group = txtGroup.Text;
            string requesteddepartment =txtRequesteddepartment.Text;
            string factory = txtfactory.Text;
            string etd = dtpetdngo.Value.ToString("dd-MMM-yyyy", new System.Globalization.CultureInfo("en-US"));

            // Tạo một hàng mới
            DataGridViewRow row = new DataGridViewRow();
            // Thêm các ô vào hàng mới
            row.CreateCells(dataGridView1); 
            row.Cells[0].Value = rowCounter++;
            row.Cells[1].Value = itemcode;
            row.Cells[2].Value = description;
            row.Cells[3].Value = partNo; 
            row.Cells[4].Value = qty; 
            row.Cells[5].Value = unit;
            row.Cells[6].Value = price;
            row.Cells[7].Value = amount;
            row.Cells[8].Value = group;
            row.Cells[9].Value = requesteddepartment;
            row.Cells[10].Value = factory;
            row.Cells[11].Value = etd;

            // Thêm hàng mới vào DataGridView
            dataGridView1.Rows.Add(row);

            // Xóa nội dung của các ô nhập liệu sau khi thêm dòng mới thành công
            cbItemcode.Text = "";
            txtDescription.Text = "";
            txtPartno.Text = "";
            txtQty.Text = "";
            txtUnit.Text = "";
            txtPrice.Text = "";
            txtAmount.Text = "";
            txtGroup.Text = "";
            txtRequesteddepartment.Text = "";
            txtfactory.Text = "";
            dtpetdngo.Text = "";
            UpdateTotalAmount();
        }
        private void UpdateTotalAmount()
        {
            float totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[7].Value != null) // Kiểm tra xem ô dữ liệu "Amount" không null
                {
                    float amount = 0;
                    if (float.TryParse(row.Cells[7].Value.ToString(), out amount)) // Kiểm tra xem dữ liệu có thể chuyển đổi thành số thực không
                    {
                        totalAmount += amount;
                    }
                }
            }
            txtTotal.Text = totalAmount.ToString();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemcode = row.Cells["ItemCode"].Value.ToString();
                    string description = row.Cells["description"].Value.ToString();
                    string partNo = row.Cells["partNo"].Value.ToString();
                    string qty = row.Cells["qty"].Value.ToString().Replace(',', '.');
                    string unit = row.Cells["unit"].Value.ToString();
                    string price = row.Cells["price"].Value.ToString().Replace(',', '.');
                    string amount = row.Cells["amount"].Value.ToString().Replace(',', '.');
                    string group = row.Cells["group"].Value.ToString();
                    string requesteddepartment = row.Cells["requesteddepartment"].Value.ToString();
                    string factory = row.Cells["factory"].Value.ToString();
                    string etd = row.Cells["etd"].Value.ToString();
                    string remark = txtRemark.Text;
                    string total = txtTotal.Text.Replace(',', '.');

                    PoInfoDAO.Instance.Create(poid, itemcode, description, partNo, qty, unit,
                        price, amount, group, requesteddepartment, factory, etd, total, remark);
                }
            }
            DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));

            this.Close();
            FormThanhcong fthanhcong = new FormThanhcong();
            fthanhcong.ShowDialog();
        }
    }
}
