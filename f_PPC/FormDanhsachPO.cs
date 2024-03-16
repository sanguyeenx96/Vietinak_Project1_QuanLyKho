using System;
using System.CodeDom;
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

namespace Vietinak_Kho.f_PPC
{
    public partial class FormDanhsachPO : Form
    {
        private List<Po> allds;
        private User userInfo;
        public FormDanhsachPO(User userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void FormDanhsachPO_Load(object sender, EventArgs e)
        {
            allds = PoDAO.Instance.LoadTableList_Po();
            dgvDspo.DataSource = allds;

            dgvDspo.Columns["No"].HeaderText = "No.";
            dgvDspo.Columns["Code"].HeaderText = "Code";
            dgvDspo.Columns["Dept"].HeaderText = "Dept.";
            dgvDspo.Columns["Sec"].HeaderText = "Sec.";
            dgvDspo.Columns["Fromdate"].HeaderText = "From date";
            dgvDspo.Columns["Pageno"].HeaderText = "Page No.";
            dgvDspo.Columns["Orderno"].HeaderText = "Order No.";
            dgvDspo.Columns["Address"].HeaderText = "Address";
            dgvDspo.Columns["Tel"].HeaderText = "Tel";
            dgvDspo.Columns["Attn"].HeaderText = "Attn";
            dgvDspo.Columns["Fax"].HeaderText = "Fax";
            dgvDspo.Columns["Issuedate"].HeaderText = "Issue date";
            dgvDspo.Columns["Paymentterm"].HeaderText = "Payment Term";
            dgvDspo.Columns["Deliveryterm"].HeaderText = "Delivery Term";
            dgvDspo.Columns["Shippingmethod"].HeaderText = "Shipping method";
            dgvDspo.Columns["Currency"].HeaderText = "Currency";
            dgvDspo.Columns["Manv"].HeaderText = "Mã nhân viên";
            dgvDspo.Columns["Hoten"].HeaderText = "Họ tên";
            dgvDspo.Columns["Ngaygio"].HeaderText = "Thời gian thao tác";

        }

        private void btnTaoPo_Click(object sender, EventArgs e)
        {
            FormTaoPo ftpo = new FormTaoPo();
            ftpo.ShowDialog();
        }
    }
}
