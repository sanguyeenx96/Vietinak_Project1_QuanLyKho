using Microsoft.Office.Interop.Excel;
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

namespace Vietinak_Kho.f_PPC
{
    public partial class FormTaoPo : Form
    {
        private List<SupplierInfo> allsuppliers;
        private SupplierInfo supinfo;
        public User userInfo;

        public FormTaoPo(User userInfo)
        {
            InitializeComponent();
            LoadSupNameToComboBox();
            this.userInfo = userInfo;
        }

        private void FormTaoPo_Load(object sender, EventArgs e)
        {
            txtDept.Text = "PPC";
            txtSec.Text = "EXIM";
            txtCode.Text = "P-PPC-0003-01Rev02";
            txtFromdate.Text = "1/12/2018";
            txtPageno.Text = "1/1";
            txtPaymentTerm.Text = "Transfer remittance";
            txtIssuedate.Text = DateTime.Now.ToString("dd-MMM-yyyy", new System.Globalization.CultureInfo("en-US"));

        }
        private void LoadSupNameToComboBox()
        {
            allsuppliers = SupplierInfoDAO.Instance.LoadTableList_Sup();
            foreach (SupplierInfo item in allsuppliers)
            {
                cbOderto.Items.Add(item.Name);
            }
            // Thiết lập cho ComboBox tự động gợi ý các giá trị khi gõ
            cbOderto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbOderto.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbOderto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSup = cbOderto.SelectedItem.ToString();
            supinfo = allsuppliers.Where(x => x.Name == selectedSup).FirstOrDefault();
            if (supinfo != null)
            {
                txtAddress.Text = supinfo.Address.ToString();
                txtTel.Text = supinfo.Tel.ToString();
                txtAttn.Text = supinfo.Pic.ToString();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNo.Text) ||
                string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtDept.Text) ||
                string.IsNullOrWhiteSpace(txtSec.Text) ||
                string.IsNullOrWhiteSpace(txtFromdate.Text) ||
                string.IsNullOrWhiteSpace(txtPageno.Text) ||
                string.IsNullOrWhiteSpace(cbOderto.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtTel.Text) ||
                string.IsNullOrWhiteSpace(txtAttn.Text) ||
                string.IsNullOrWhiteSpace(txtFax.Text) ||
                string.IsNullOrWhiteSpace(txtIssuedate.Text) ||
                string.IsNullOrWhiteSpace(txtPaymentTerm.Text) ||
                string.IsNullOrWhiteSpace(cbDeliveryTerm.Text) ||
                string.IsNullOrWhiteSpace(cbShippingmethod.Text) ||
                string.IsNullOrWhiteSpace(cbCurrency.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            string trangthai = "Chờ confirm";
            string no = txtNo.Text;
            string code = txtCode.Text;
            string dept = txtDept.Text;
            string sec = txtSec.Text;
            string fromdate = txtFromdate.Text;
            string pageno = txtPageno.Text;
            string orderto = cbOderto.Text;
            string address = txtAddress.Text;
            string tel = txtTel.Text;
            string attn = txtAttn.Text;
            string fax = txtFax.Text;
            string issuedate = txtIssuedate.Text;
            string paymentterm = txtPaymentTerm.Text;
            string deliveryterm = cbDeliveryTerm.Text;
            string shippingmethod = cbShippingmethod.Text;
            string currency = cbCurrency.Text;
            string manv = userInfo.Manhanvien;
            string hoten = userInfo.Hoten;
            string bophan = userInfo.Bophan;
            string ngaygio = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

            int poid = PoDAO.Instance.CreateReturnId(trangthai, no, code, dept, sec, fromdate, pageno,
            orderto, address, tel, attn, fax, issuedate,
            paymentterm, deliveryterm, shippingmethod, currency, manv, hoten, bophan,
            ngaygio);
            if (poid != -1)
            {
                FormPoInfo fpif = new FormPoInfo(orderto, no,poid);
                fpif.DialogClosed += Dialog_DialogClosed;

                fpif.ShowDialog();
            }
        }
        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            string infoFromDialog = e.Info;
            if (infoFromDialog.ToString() == "OK")
            {
                this.Close();
            }
        }
    }
}
