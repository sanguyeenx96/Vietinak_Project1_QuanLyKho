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

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu.Moi
{
    public partial class FormThemNVL : Form
    {
        public FormThemNVL()
        {
            InitializeComponent();
            getSupplierNameToCombobox();
        }

        private void getSupplierNameToCombobox()
        {
            List<SupplierInfo> listSup = SupplierInfoDAO.Instance.LoadTableList_Sup();
            foreach (SupplierInfo item in listSup)
            {
                cbsuppliername.Items.Add(item.Name);
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (
               string.IsNullOrEmpty(txtmaterialno.Text) && 
               string.IsNullOrEmpty(txtunitprice.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu số cho các trường Material No và Unit Price!",
               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string code = txtcode.Text.ToString();
            int materialno = Convert.ToInt32(txtmaterialno.Text.ToString());
            string suppliername = cbsuppliername.Text.ToString();
            string materialppc = txtmaterialppc.Text.ToString();
            string materialvtn = txtmaterialvtn.Text.ToString();
            string maker = txtmaker.Text.ToString();
            string addressiso = txtaddressiso.Text.ToString();
            string addresscoabox = txtaddresscoabox.Text.ToString();
            bool diachitrencoacotrenisokhong = checkBoxCOAISO.Checked;
            string isoiatfcertificate = txtisoiatfcertificate.Text.ToString();
            string expirydate = dtp.Value.ToString("yyyy/MM/dd");
            string note = txtnote.Text.ToString();
            string vtncode = txtvtncode.Text.ToString();
            string itemcode = txtitemcode.Text.ToString();
            string vietnamesename = txtvietnamesename.Text.ToString();
            string unit = cbUnit.Text.ToString();
            string unitprice = txtunitprice.Text.ToString();
            string currency = cbCurrency.Text.ToString();


            bool success = DanhsachnguyenvatlieuDAO.Instance.Create(
            code,  materialno,  suppliername,  materialppc,
            materialvtn,  maker,  addressiso,  addresscoabox,
            diachitrencoacotrenisokhong, isoiatfcertificate,  expirydate,  note,
            vtncode,  itemcode,  vietnamesename,  unit,  unitprice,  currency
          );
            if (success)
            {
                MessageBox.Show("Tạo thông tin nguyên vật liệu mới thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void FormThemNVL_Load(object sender, EventArgs e)
        {
            cbUnit.SelectedItem = "Kg";
            cbCurrency.SelectedItem = "USD";

        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmaterialno_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu ký tự không phải là số, dấu chấm hoặc phím Backspace, loại bỏ ký tự đó
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            // Nếu có dấu chấm và đã có một dấu chấm khác trong TextBox, loại bỏ ký tự đó
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void txtunitprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu ký tự không phải là số, dấu chấm hoặc phím Backspace, loại bỏ ký tự đó
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            // Nếu có dấu chấm và đã có một dấu chấm khác trong TextBox, loại bỏ ký tự đó
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }


    }
}
