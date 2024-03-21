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
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Thongke;
using static OfficeOpenXml.ExcelErrorValue;

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
            allds = PoDAO.Instance.LoadTableList_Po(); // Giả sử LoadTableList_Po() trả về một danh sách các mục PO
            // Load dữ liệu từ cơ sở dữ liệu vào TreeView
            LoadDataIntoTreeView(allds);
            countpo(allds);
            treeViewPO.NodeMouseClick += treeViewPO_NodeMouseClick;
        }
        private void countpo(List<Po> poItems)
        {
            txttotalpo.Text = "Total PO : " + poItems.Count().ToString();
            txtpowaitconfirm.Text = "Waiting for confirmation : " + poItems.Where(x => x.Trangthai == "Chờ confirm").Count().ToString();
            txtpopending.Text = "Pending : " + poItems.Where(x => x.Trangthai == "Pending").Count().ToString();
            txtponoinvoice.Text = "No Invoice : " + poItems.Where(x => x.Trangthai == "No Invoice").Count().ToString();
            txtpodone.Text = "Done: " + poItems.Where(x => x.Trangthai == "Done").Count().ToString();
        }
        private void treeViewPO_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                string idValue = e.Node.Tag.ToString();
                FormChucnangPO fpo = new FormChucnangPO(Convert.ToInt32(idValue));
                fpo.DialogClosed += Dialog_DialogClosed;

                fpo.ShowDialog();
            }
        }
        private void Dialog_DialogClosed(object sender, DialogClosedEventArgs e)
        {
            foreach (TreeNode parentNode in treeViewPO.Nodes)
            {
                parentNode.Nodes.Clear();
            }
            string from = dtpFrom.Value.ToString("yyyy/MM") + "/01";
            string to = dtpTo.Value.ToString("yyyy/MM") + "/31";
            allds = PoDAO.Instance.LoadTableList_Po(from, to);
            LoadDataIntoTreeView(allds);
            countpo(allds);
            groupBoxDulieu.Text = "Danh sách PO từ " + dtpFrom.Value.ToString("yyyy/MM") + " đến " + dtpTo.Value.ToString("yyyy/MM");

        }
        private void LoadDataIntoTreeView(List<Po> poItems)
        {
            // Duyệt qua từng mục PO và thêm vào nút cha hoặc nút con tương ứng
            foreach (Po item in poItems)
            {
                if (item.Trangthai == "Chờ confirm")
                {
                    TreeNode parentNode = FindParentNode("Nodepowaitingconfirm");
                    // Nếu không tìm thấy nút cha, bỏ qua và chuyển đến mục tiếp theo
                    if (parentNode == null)
                        continue;
                    // Thêm nút con cho nút cha "note1"
                    TreeNode childNode = new TreeNode("No.:" + item.No + "  (Issue date:" + item.Issuedate + ")"); // Sử dụng số No của mục PO làm nút con
                    childNode.Tag = item.Id;
                    parentNode.Nodes.Add(childNode);
                }
                if (item.Trangthai == "Pending")
                {
                    TreeNode parentNode = FindParentNode("Nodepopending");
                    // Nếu không tìm thấy nút cha, bỏ qua và chuyển đến mục tiếp theo
                    if (parentNode == null)
                        continue;
                    // Thêm nút con cho nút cha "note1"
                    TreeNode childNode = new TreeNode("No.:" + item.No + "  (Issue date:" + item.Issuedate + ")"); // Sử dụng số No của mục PO làm nút con
                    childNode.Tag = item.Id;
                    parentNode.Nodes.Add(childNode);
                }
                if (item.Trangthai == "Done")
                {
                    TreeNode parentNode = FindParentNode("Nodepodone");
                    // Nếu không tìm thấy nút cha, bỏ qua và chuyển đến mục tiếp theo
                    if (parentNode == null)
                        continue;
                    // Thêm nút con cho nút cha "note1"
                    TreeNode childNode = new TreeNode("No.:" + item.No + "  (Issue date:" + item.Issuedate + ")"); // Sử dụng số No của mục PO làm nút con
                    childNode.Tag = item.Id;
                    parentNode.Nodes.Add(childNode);
                }
            }
            UpdateParentNodeText(treeViewPO.Nodes);
        }

        private TreeNode FindParentNode(string trangThai)
        {
            foreach (TreeNode node in treeViewPO.Nodes)
            {
                if (node.Name == trangThai)
                {
                    return node;
                }
            }
            return null; 
        }

        private void UpdateParentNodeText(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                int index = node.Text.LastIndexOf('(');
                if (index != -1)
                {
                    if (node.Nodes.Count > 0)
                    {
                        // Nếu có ít nhất một nút con, thì hiển thị số lượng nút con
                        node.Text = $"{node.Text.Substring(0, index)}({node.Nodes.Count})";
                    }
                    else
                    {
                        // Nếu không có nút con, chỉ giữ lại phần văn bản không chứa số lượng
                        node.Text = node.Text.Substring(0, index).Trim();
                    }
                }
                else
                {
                    if (node.Nodes.Count > 0)
                    {
                        // Nếu có ít nhất một nút con, thêm số lượng nút con vào cuối văn bản
                        node.Text = $"{node.Text} ({node.Nodes.Count})";
                    }
                    // Không cần làm gì nếu không có số lượng và không có dấu '(' trong văn bản
                }
            }
        }



        private void btnTaoPo_Click(object sender, EventArgs e)
        {
            FormTaoPo ftpo = new FormTaoPo(userInfo);
            ftpo.ShowDialog();
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            foreach (TreeNode parentNode in treeViewPO.Nodes)
            {
                parentNode.Nodes.Clear();
            }
            string from = dtpFrom.Value.ToString("yyyy/MM") +"/01";
            string to = dtpTo.Value.ToString("yyyy/MM") + "/31";
            allds = PoDAO.Instance.LoadTableList_Po(from,to); 
            LoadDataIntoTreeView(allds);
            countpo(allds);
            groupBoxDulieu.Text = "Danh sách PO từ " + dtpFrom.Value.ToString("yyyy/MM") + " đến " + dtpTo.Value.ToString("yyyy/MM");
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            foreach (TreeNode parentNode in treeViewPO.Nodes)
            {
                parentNode.Nodes.Clear();
            }
            string from = dtpFrom.Value.ToString("yyyy/MM") + "/01";
            string to = dtpTo.Value.ToString("yyyy/MM") + "/31";
            allds = PoDAO.Instance.LoadTableList_Po(from, to);
            LoadDataIntoTreeView(allds);
            countpo(allds);
            groupBoxDulieu.Text = "Danh sách PO từ " + dtpFrom.Value.ToString("yyyy/MM") + " đến " + dtpTo.Value.ToString("yyyy/MM");

        }
    }
}
