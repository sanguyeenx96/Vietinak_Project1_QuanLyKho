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

namespace Vietinak_Kho.f_PPC
{
    public partial class FormXemchitietPO : Form
    {
        private int id;
        public FormXemchitietPO(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormXemchitietPO_Load(object sender, EventArgs e)
        {
            var thongtinPO = PoDAO.Instance.LoadTableList_PoById(id);
            if (thongtinPO != null)
            {
                txtNo.Text = thongtinPO.No;
                txtCode.Text = thongtinPO.Code;
                txtDept.Text = thongtinPO.Dept;
                txtSec.Text = thongtinPO.Sec;
                txtFromdate.Text = thongtinPO.Fromdate;
                txtPageno.Text = thongtinPO.Pageno;
                txtOrderto.Text = thongtinPO.Orderto;
                txtAddress.Text = thongtinPO.Address;
                txtTel.Text = thongtinPO.Tel;
                txtAttn.Text = thongtinPO.Attn;
                txtFax.Text = thongtinPO.Fax;
                txtIssuedate.Text = thongtinPO.Issuedate;
                txtPaymentTerm.Text = thongtinPO.Paymentterm;
                txtDeliveryTerm.Text = thongtinPO.Deliveryterm;
                txtShippingmethod.Text = thongtinPO.Shippingmethod;
                txtCurrency.Text = thongtinPO.Currency;
            }
            var chitietPO = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(thongtinPO.Id);
            if(chitietPO.Count > 0)
            {
                txtTotal.Text = chitietPO.FirstOrDefault().Total.ToString();
                txtRemark.Text = chitietPO.FirstOrDefault().Remark.ToString();
            }
            dgvPoInfo.DataSource = chitietPO;
            dgvPoInfo.Columns["Id"].Visible = false;
            dgvPoInfo.Columns["Total"].Visible = false;
            dgvPoInfo.Columns["Remark"].Visible = false;
        }
    }
}
