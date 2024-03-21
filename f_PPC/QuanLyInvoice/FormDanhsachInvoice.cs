using Microsoft.Office.Interop.Excel;
using OfficeOpenXml.FormulaParsing.Ranges;
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
using Vietinak_Kho.f_PPC.QuanLyInvoice;

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
                System.Data.DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.invoice JOIN dbo.invoiceinfo  ON invoice.id = invoiceinfo.invoiceid JOIN dbo.poinfo ON invoiceinfo.itemid = poinfo.id WHERE itemid = '" + item.Id + "' ");
                List<DTO.Invoice> invoiceInfoList = new List<DTO.Invoice>();
                foreach (DataRow row in data.Rows)
                {
                    DTO.Invoice invoice = new DTO.Invoice()
                    {
                        Id = Convert.ToInt32(row["id"].ToString()),
                        Invoicedate = row["invoicedate"].ToString(),
                        Invoicenumber = row["invoicenumber"].ToString(),
                        Trangthai = row["trangthai"].ToString(),
                        Qty = (float)Convert.ToDouble(row["qty"].ToString())
                    };
                    invoiceInfoList.Add(invoice);
                };
                var invoicesForItem = invoiceInfoList;

                string nodeText = "Item code: " + item.Itemcode + " - " + item.Description + " - ETD" + item.Etd;
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
                    parentNode.Tag = new NodeInfo(item.Id, item.Qty); // Tạo đối tượng NodeInfo và gán vào Tag
                    treeViewInvoice.Nodes.Add(parentNode);
                }

                // Thêm các Invoice làm nút con cho nút cha
                // Thêm các Invoice làm nút con cho nút cha
                foreach (var invoice in invoicesForItem)
                {
                    // Kiểm tra xem có nút con nào giống nhau đã được thêm vào parentNode hay không
                    bool nodeExists = false;
                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Text == "Invoice Number: " + invoice.Invoicenumber.ToString() + " / Invoice Date: " + invoice.Invoicedate + " / Trạng thái: " + invoice.Trangthai)
                        {
                            nodeExists = true;
                            break;
                        }
                    }

                    // Nếu nút con không tồn tại, thêm nút con mới vào parentNode
                    if (!nodeExists)
                    {
                        TreeNode childNode = new TreeNode("Invoice Number: " + invoice.Invoicenumber.ToString() + " / Invoice Date: " + invoice.Invoicedate + " / Trạng thái: " + invoice.Trangthai); // Sử dụng số hóa đơn của Invoice làm nút con
                        childNode.Tag = invoice.Id;
                        if (invoice.Trangthai == "Pending")
                        {
                            childNode.BackColor = Color.Yellow;
                        }
                        if (invoice.Trangthai == "Done")
                        {
                            childNode.BackColor = Color.LightGreen;
                        }
                        parentNode.Nodes.Add(childNode);
                    }
                }

            }

            treeViewInvoice.EndUpdate(); // Kết thúc việc cập nhật và cho phép TreeView hiển thị dữ liệu
        }


        private void btnTao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một note cha nào trong TreeView chưa
            if (treeViewInvoice.SelectedNode != null && treeViewInvoice.SelectedNode.Parent == null)
            {
                NodeInfo nodeInfo = (NodeInfo)treeViewInvoice.SelectedNode.Tag;
                int id = nodeInfo.Id;
                float selectedNodeqty= nodeInfo.Qty;
                // Thực hiện các hành động cần thiết với selectedNodeText (ví dụ: truyền thông tin này vào FormTaoInvoice)
                FormTaoInvoice f = new FormTaoInvoice(id, selectedNodeqty);
                f.DialogClosed += Dialog_DialogClosed;

                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Itemcode trong danh sách trước khi tạo Invoice.");
            }

        }

        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            allInvoice = InvoiceDAO.Instance.LoadTableList_Invoice();

            poinfo = PoDAO.Instance.LoadTableList_PoById(id);
            txtIssuedate.Text = poinfo.Issuedate.ToString();
            txtNo.Text = poinfo.No.ToString();
            txtOrderto.Text = poinfo.Orderto.ToString();

            poinfolist = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(id); // Giả sử LoadTableList_Po() trả về một danh sách các mục PO
            LoadDataIntoTreeView(poinfolist);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một nút và nút đó có phải là nút gốc (parent node) hay không
            if (treeViewInvoice.SelectedNode != null && treeViewInvoice.SelectedNode.Parent != null)
            {
                int id = (int)treeViewInvoice.SelectedNode.Tag;
                FormSuaInvoice f = new FormSuaInvoice(id);
                f.DialogClosed += Dialog_DialogClosed;

                f.ShowDialog();
            }
            else
            {
                // Nếu không, hiển thị thông báo yêu cầu chọn một nút con
                MessageBox.Show("Vui lòng chọn một Invoice trong danh sách trước khi sửa Invoice.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một nút và nút đó có phải là nút gốc (parent node) hay không
            if (treeViewInvoice.SelectedNode != null && treeViewInvoice.SelectedNode.Parent != null)
            {
                int id = (int)treeViewInvoice.SelectedNode.Tag;
                FormXoaInvoice f = new FormXoaInvoice(id);
                f.DialogClosed += Dialog_DialogClosed;

                f.ShowDialog();
            }
            else
            {
                // Nếu không, hiển thị thông báo yêu cầu chọn một nút con
                MessageBox.Show("Vui lòng chọn một Invoice trong danh sách trước khi xóa Invoice.");
            }
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một nút và nút đó có phải là nút gốc (parent node) hay không
            if (treeViewInvoice.SelectedNode != null && treeViewInvoice.SelectedNode.Parent != null)
            {
                int id = (int)treeViewInvoice.SelectedNode.Tag;
                FormXemchitietInvoice f = new FormXemchitietInvoice(id);
                f.ShowDialog();
            }
            else
            {
                // Nếu không, hiển thị thông báo yêu cầu chọn một nút con
                MessageBox.Show("Vui lòng chọn một Invoice trong danh sách!");
            }
        }
    }
}
