using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho.f_PPC
{
    public partial class FormSuaPO : Form
    {
        private int id;
        private Po thongtinPO;
        private List<SupplierInfo> allsuppliers;
        private SupplierInfo supinfo;

        public FormSuaPO(int id)
        {
            InitializeComponent();
            LoadSupNameToComboBox();

            this.id = id;
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
        private void FormSuaPO_Load(object sender, EventArgs e)
        {
            thongtinPO = PoDAO.Instance.LoadTableList_PoById(id);
            if (thongtinPO != null)
            {
                txtNo.Text = thongtinPO.No;
                txtCode.Text = thongtinPO.Code;
                txtDept.Text = thongtinPO.Dept;
                txtSec.Text = thongtinPO.Sec;
                txtFromdate.Text = thongtinPO.Fromdate;
                txtPageno.Text = thongtinPO.Pageno;
                cbOderto.Text = thongtinPO.Orderto;
                txtAddress.Text = thongtinPO.Address;
                txtTel.Text = thongtinPO.Tel;
                txtAttn.Text = thongtinPO.Attn;
                txtFax.Text = thongtinPO.Fax;
                txtIssuedate.Text = thongtinPO.Issuedate;
                txtPaymentTerm.Text = thongtinPO.Paymentterm;
                cbDeliveryTerm.Text = thongtinPO.Deliveryterm;
                cbShippingmethod.Text = thongtinPO.Shippingmethod;
                cbCurrency.Text = thongtinPO.Currency;
            }
            var chitietPO = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(thongtinPO.Id);
            if (chitietPO.Count > 0)
            {
                txtTotal.Text = chitietPO.FirstOrDefault().Total.ToString();
                txtRemark.Text = chitietPO.FirstOrDefault().Remark.ToString();
            }
            dgvPoInfo.DataSource = chitietPO;
            dgvPoInfo.Columns["Id"].Visible = false;
            dgvPoInfo.Columns["Total"].Visible = false;
            dgvPoInfo.Columns["Remark"].Visible = false;
        }

        private void UpdateTotalAmount()
        {
            float totalAmount = 0;

            foreach (DataGridViewRow row in dgvPoInfo.Rows)
            {
                if (row.Cells["Total"].Value != null) 
                {
                    float amount = 0;
                    if (float.TryParse(row.Cells["Total"].Value.ToString(), out amount)) 
                    {
                        totalAmount += amount;
                    }
                }
            }
            txtTotal.Text = totalAmount.ToString();

            foreach (DataGridViewRow row in dgvPoInfo.Rows)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                string total = totalAmount.ToString().Replace(",", ".");
                PoInfoDAO.Instance.UpdateTotalAmount(id, total);
            }

        }

        private void btnLuulai_Click(object sender, EventArgs e)
        {
            UpdateTotalAmount();
            string no = thongtinPO.No;
            string newNo = txtNo.Text;
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
            int id = thongtinPO.Id;
            bool update = PoDAO.Instance.Update(no, newNo, code, dept, sec, fromdate, pageno, orderto, address, tel,
                attn, fax, issuedate, paymentterm, deliveryterm, shippingmethod, currency, id);
            if (update)
            {
                MessageBox.Show("Cập nhật thông tin PO thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
            }


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

        private void btnXoaItem_Click(object sender, EventArgs e)
        {
            if (dgvPoInfo.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvPoInfo.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string name = selectedRow.Cells["Itemcode"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu Itemcode: " + name + " ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    bool success = PoInfoDAO.Instance.Delete(id);
                    if (success)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var chitietPO = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(thongtinPO.Id);
                        if (chitietPO.Count > 0)
                        {
                            txtTotal.Text = chitietPO.FirstOrDefault().Total.ToString();
                            txtRemark.Text = chitietPO.FirstOrDefault().Remark.ToString();
                        }
                        dgvPoInfo.DataSource = chitietPO;
                        dgvPoInfo.Columns["Id"].Visible = false;
                        dgvPoInfo.Columns["Total"].Visible = false;
                        dgvPoInfo.Columns["Remark"].Visible = false;
                        float totalAmount = 0;

                        foreach (DataGridViewRow row in dgvPoInfo.Rows)
                        {
                            if (row.Cells["Total"].Value != null)
                            {
                                float amount = 0;
                                if (float.TryParse(row.Cells["Total"].Value.ToString(), out amount))
                                {
                                    totalAmount += amount;
                                }
                            }
                        }
                        txtTotal.Text = totalAmount.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemItem_Click(object sender, EventArgs e)
        {
            FormPoInfo fpif = new FormPoInfo(thongtinPO.Orderto, thongtinPO.No, thongtinPO.Id);
            fpif.DialogClosed += Dialog_DialogClosed;
            fpif.ShowDialog();
        }
        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            string infoFromDialog = e.Info;
            if (infoFromDialog.ToString() == "OK")
            {
                var chitietPO = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(thongtinPO.Id);
                if (chitietPO.Count > 0)
                {
                    txtTotal.Text = chitietPO.FirstOrDefault().Total.ToString();
                    txtRemark.Text = chitietPO.FirstOrDefault().Remark.ToString();
                }
                dgvPoInfo.DataSource = chitietPO;
                dgvPoInfo.Columns["Id"].Visible = false;
                dgvPoInfo.Columns["Total"].Visible = false;
                dgvPoInfo.Columns["Remark"].Visible = false;
                float totalAmount = 0;

                foreach (DataGridViewRow row in dgvPoInfo.Rows)
                {
                    if (row.Cells["Total"].Value != null)
                    {
                        float amount = 0;
                        if (float.TryParse(row.Cells["Total"].Value.ToString(), out amount))
                        {
                            totalAmount += amount;
                        }
                    }
                }
                txtTotal.Text = totalAmount.ToString();
            }
        }
    }
}
