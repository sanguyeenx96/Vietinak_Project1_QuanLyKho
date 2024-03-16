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

namespace Vietinak_Kho.f_PPC
{
    public partial class FormTaoPo : Form
    {
        private List<SupplierInfo> allsuppliers;
        private SupplierInfo supinfo;

        public FormTaoPo()
        {
            InitializeComponent();
            LoadSupNameToComboBox();
        }

        private void FormTaoPo_Load(object sender, EventArgs e)
        {
            txtDept.Text = "PPC";
            txtSec.Text = "EXIM";
            txtCode.Text = "P-PPC-0003-01Rev02";
            txtFromdate.Text = "1/12/2018";
            txtPageno.Text = "1/1";
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
    }
}
