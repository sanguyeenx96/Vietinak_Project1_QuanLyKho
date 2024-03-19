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

namespace Vietinak_Kho.f_PPC.Invoice
{
    public partial class FormDanhsachInvoice : Form
    {
        private int id;
        private string pono;
        private string poissuedate;
        private string poorderto;

        private Po poinfo;
        private List<PoInfo> poinfolist;
        private List<DTO.Invoice> allInvoice;

        public FormDanhsachInvoice(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormDanhsachInvoice_Load(object sender, EventArgs e)
        {
            allInvoice = InvoiceDAO.Instance.LoadTableList_Invoice();

            poinfo = PoDAO.Instance.LoadTableList_PoById(id);
            txtIssuedate.Text = poinfo.Issuedate.ToString();
            txtNo.Text = poinfo.No.ToString();
            txtOrderto.Text = poinfo.Orderto.ToString();

            poinfolist = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(id); // Giả sử LoadTableList_Po() trả về một danh sách các mục PO
            LoadDataIntoTreeView(poinfolist);
        }
        private void LoadDataIntoTreeView(List<PoInfo> poinfolist)
        {
            treeViewInvoice.BeginUpdate();
            foreach (PoInfo item in poinfolist)
            {
                // Kiểm tra xem đã có Invoice cho mục PO này chưa
                var invoicesForItem = allInvoice.Where(x => x.Itemid == item.Id).ToList();

                string nodeText = item.Etd + item.Id;
                // Kiểm tra xem nút cha đã tồn tại trong cây chưa
                TreeNode parentNode = null;
                foreach (TreeNode node in treeViewInvoice.Nodes)
                {
                    if (node.Text == nodeText)
                    {
                        parentNode = node;
                        break;
                    }
                }

                // Nếu nút cha chưa tồn tại, thêm nút cha vào cây
                if (parentNode == null)
                {
                    parentNode = new TreeNode(nodeText);
                    parentNode.Tag = item.Amount;
                    treeViewInvoice.Nodes.Add(parentNode);
                }

                // Thêm các Invoice làm nút con cho nút cha
                foreach (var invoice in invoicesForItem)
                {
                    TreeNode childNode = new TreeNode("Invoice: " + invoice.Invoicenumber); // Sử dụng số hóa đơn của Invoice làm nút con
                    //childNode.Tag = invoice.InvoiceNumber; // Lưu thông tin liên quan của Invoice vào Tag (ví dụ: InvoiceNumber)
                    parentNode.Nodes.Add(childNode);
                }
            }

            treeViewInvoice.EndUpdate(); // Kết thúc việc cập nhật và cho phép TreeView hiển thị dữ liệu
        }

      
        private void btnTao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một note cha nào trong TreeView chưa
            if (treeViewInvoice.SelectedNode != null && treeViewInvoice.SelectedNode.Parent == null)
            {
                float selectedNodeAmount = (float)treeViewInvoice.SelectedNode.Tag;
                // Thực hiện các hành động cần thiết với selectedNodeText (ví dụ: truyền thông tin này vào FormTaoInvoice)
                FormTaoInvoice f = new FormTaoInvoice(id, selectedNodeAmount);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ETD trong danh sách trước khi tạo Invoice.");
            }

        }
    }
}
