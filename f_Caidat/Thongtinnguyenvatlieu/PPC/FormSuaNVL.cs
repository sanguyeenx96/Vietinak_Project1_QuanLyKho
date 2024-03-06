using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu.Moi
{
    public partial class FormSuaNVL : Form
    {
        private string xcurrentmaterialvtn;
        private string xcurrentmaterialppc;
        private int xid;


        public FormSuaNVL()
        {
            InitializeComponent();
        }
        public void LoadData(Danhsachnguyenvatlieu nguyenvatlieu)
        {
            xid = nguyenvatlieu.Id;
            xcurrentmaterialvtn = nguyenvatlieu.Materialvtn.ToString();
            xcurrentmaterialppc = nguyenvatlieu.Materialppc.ToString();
            // Gán dữ liệu từ hàng đã chọn vào các controls trong form sửa
            txtcode.Text = nguyenvatlieu.Code;
            txtmaterialno.Text = nguyenvatlieu.Materialno.ToString();
            txtsuppliername.Text = nguyenvatlieu.Suppliername;
            txtmaterialppc.Text = nguyenvatlieu.Materialppc.ToString();
            txtmaterialvtn.Text = nguyenvatlieu.Materialvtn.ToString();
            txtmaker.Text = nguyenvatlieu.Maker.ToString();
            txtaddressiso.Text = nguyenvatlieu.Addressiso.ToString();
            txtaddresscoabox.Text = nguyenvatlieu.Addresscoabox.ToString();
            txtisoiatfcertificate.Text = nguyenvatlieu.Isoiatfcertificate.ToString();

            string dateFormat = "yyyy/MM/dd";
            if (DateTime.TryParseExact(nguyenvatlieu.Expirydate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate))
            {
                dtp.Value = expiryDate;
            }

            txtnote.Text = nguyenvatlieu.Note.ToString();
            txtvtncode.Text = nguyenvatlieu.Vtncode.ToString();
            txtitemcode.Text = nguyenvatlieu.Itemcode.ToString();
            txtvietnamesename.Text = nguyenvatlieu.Vietnamesename.ToString();
            cbUnit.SelectedItem = nguyenvatlieu.Unit.ToString();
            string unitPriceText = nguyenvatlieu.Unitprice.ToString();
            if (unitPriceText.Contains(','))
            {
                // Nếu có dấu phẩy, thì chuyển đổi thành dấu chấm
                txtunitprice.Text = unitPriceText.Replace(',', '.');
            }
            else
            {
                // Nếu không có dấu phẩy, gán giá trị như bình thường
                txtunitprice.Text = unitPriceText;
            }
            cbCurrency.SelectedItem = nguyenvatlieu.Currency.ToString();
        }

        private void FormSuaNVL_Load(object sender, EventArgs e)
        {

        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int id = xid;
            string currentmaterialvtn = xcurrentmaterialvtn;
            string currentmaterialppc = xcurrentmaterialppc;
            string code = txtcode.Text;
            int materialno = Convert.ToInt32(txtmaterialno.Text);
            string suppliername = txtsuppliername.Text;
            string materialppc = txtmaterialppc.Text;
            string materialvtn = txtmaterialvtn.Text;
            string maker = txtmaker.Text;
            string addressiso = txtaddressiso.Text;
            string addresscoabox = txtaddresscoabox.Text;
            bool diachitrencoacotrenisokhong = checkBoxCOAISO.Checked;
            string isoiatfcertificate = txtisoiatfcertificate.Text;
            string expirydate = dtp.Value.ToString("yyyy/MM/dd");
            string note = txtnote.Text;
            string vtncode = txtvtncode.Text;
            string itemcode = txtitemcode.Text;
            string vietnamesename = txtvietnamesename.Text;
            string unit = cbUnit.Text;
            string unitprice = txtunitprice.Text;
            string currency = cbCurrency.Text;

            // Gọi phương thức Update từ lớp DAO để cập nhật dữ liệu
            bool success = DanhsachnguyenvatlieuDAO.Instance.Update(id, currentmaterialvtn, currentmaterialppc, code, materialno,
            suppliername,  materialppc, materialvtn, maker, addressiso, addresscoabox,
            diachitrencoacotrenisokhong,  isoiatfcertificate,  expirydate,  note,
            vtncode,  itemcode,  vietnamesename,  unit,  unitprice,  currency);

            // Kiểm tra xem việc cập nhật có thành công hay không và hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
