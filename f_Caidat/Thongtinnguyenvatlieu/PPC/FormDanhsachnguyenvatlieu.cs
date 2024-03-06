using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;
using Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu;
using Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu.Moi;
using Vietinak_Kho.f_Taikhoan;

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    public partial class FormDanhsachnguyenvatlieu : Form
    {
        private Danhsachnguyenvatlieu selectedNguyenvatlieu;

        private List<Danhsachnguyenvatlieu> allThongtinvattu;

        public FormDanhsachnguyenvatlieu()
        {
            InitializeComponent();
        }

        private void FormDanhsachnguyenvatlieu_Load(object sender, EventArgs e)
        {
            //this.tbldanhsachnguyenvatlieuTableAdapter.Fill(this.quanLyKhoDataSet.tbldanhsachnguyenvatlieu);

            allThongtinvattu = DanhsachnguyenvatlieuDAO.Instance.LoadTableList_Danhsachnguyenvatlieu();
            UpdateDataGridViewThongtinvattu(allThongtinvattu);
            txtCount.Text = allThongtinvattu.Count().ToString();
        }
        private void UpdateDataGridViewThongtinvattu(List<Danhsachnguyenvatlieu> thongtinvattus)
        {
            dgv.DataSource = thongtinvattus;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Materialno"].HeaderText = "Material no";
            dgv.Columns["Suppliername"].HeaderText = "Supplier name";
            dgv.Columns["Materialppc"].HeaderText = "Material PPC";
            dgv.Columns["Materialvtn"].HeaderText = "Material VTM";
            dgv.Columns["Maker"].HeaderText = "Maker";
            dgv.Columns["Addressiso"].HeaderText = "Addressiso";
            dgv.Columns["Addresscoabox"].HeaderText = "Addresscoabox";
            dgv.Columns["Diachitrencoacotrenisokhong"].HeaderText = "Địa chỉ trên COA có trên ISO không?";   
            dgv.Columns["Isoiatfcertificate"].HeaderText = "Isoiatfcertificate";
            dgv.Columns["Expirydate"].HeaderText = "Expirydate";
            dgv.Columns["Note"].HeaderText = "Note";
            dgv.Columns["Vtncode"].HeaderText = "VTN code";
            dgv.Columns["Itemcode"].HeaderText = "Itemcode";
            dgv.Columns["Vietnamesename"].HeaderText = "Vietnamese name";
            dgv.Columns["Unit"].HeaderText = "Unit";
            dgv.Columns["Unitprice"].HeaderText = "Unitprice";
            dgv.Columns["Currency"].HeaderText = "Currency";
        }

        private void btnThemnguyenvatlieu_Click(object sender, EventArgs e)
        {
            FormThemNVL fthem = new FormThemNVL();
            fthem.ShowDialog();
            //try
            //{
            //    int CurrentIndex = dgv.CurrentCell.RowIndex;
            //    string code = Convert.ToString(dgv.Rows[CurrentIndex].Cells[0].Value.ToString());
            //    int materialno = Convert.ToInt32(dgv.Rows[CurrentIndex].Cells[1].Value.ToString());
            //    string suppliername = Convert.ToString(dgv.Rows[CurrentIndex].Cells[2].Value.ToString());
            //    string materialppc = Convert.ToString(dgv.Rows[CurrentIndex].Cells[3].Value.ToString());
            //    string materialvtn = Convert.ToString(dgv.Rows[CurrentIndex].Cells[4].Value.ToString());
            //    string maker = Convert.ToString(dgv.Rows[CurrentIndex].Cells[5].Value.ToString());
            //    string addressiso = Convert.ToString(dgv.Rows[CurrentIndex].Cells[6].Value.ToString());
            //    string addresscoabox = Convert.ToString(dgv.Rows[CurrentIndex].Cells[7].Value.ToString());
            //    bool diachitrencoacotrenisokhong = (bool)dgv.Rows[CurrentIndex].Cells[8].Value;
            //    int q = Convert.ToInt32(dgv.Rows[CurrentIndex].Cells[9].Value.ToString());
            //    int d = Convert.ToInt32(dgv.Rows[CurrentIndex].Cells[10].Value.ToString());
            //    int total = Convert.ToInt32(dgv.Rows[CurrentIndex].Cells[11].Value.ToString());
            //    string riskrank = Convert.ToString(dgv.Rows[CurrentIndex].Cells[12].Value.ToString());
            //    bool phamvi = (bool)dgv.Rows[CurrentIndex].Cells[13].Value;
            //    bool dauhieucongnhan = (bool)dgv.Rows[CurrentIndex].Cells[14].Value;
            //    string remark = Convert.ToString(dgv.Rows[CurrentIndex].Cells[15].Value.ToString());
            //    string isoiatfcertificate = Convert.ToString(dgv.Rows[CurrentIndex].Cells[16].Value.ToString());
            //    string expirydate = Convert.ToString(dgv.Rows[CurrentIndex].Cells[17].Value.ToString());
            //    string note = Convert.ToString(dgv.Rows[CurrentIndex].Cells[18].Value.ToString());
            //    string vtncode = Convert.ToString(dgv.Rows[CurrentIndex].Cells[19].Value.ToString());
            //    string itemcode = Convert.ToString(dgv.Rows[CurrentIndex].Cells[20].Value.ToString());
            //    string vietnamesename = Convert.ToString(dgv.Rows[CurrentIndex].Cells[21].Value.ToString());
            //    string unit = Convert.ToString(dgv.Rows[CurrentIndex].Cells[22].Value.ToString());
            //    string unitprice = Convert.ToString(dgv.Rows[CurrentIndex].Cells[23].Value.ToString());
            //    string currency = Convert.ToString(dgv.Rows[CurrentIndex].Cells[24].Value.ToString());

            //    MessageBox.Show(diachitrencoacotrenisokhong.ToString());
            //    //string insertStr = "Insert into Sinhvien Values('" + Masv + "','" + Holot + "','" + Ten + "','" + Phai + "','" + Ngaysinh + "','" + Makhoa + "')";
            //    //SqlCommand insertCmd = new SqlCommand(insertStr, conn);
            //    //insertCmd.CommandType = CommandType.Text;
            //    //insertCmd.ExecuteNonQuery();
            //    //LoadData();
            //    //MessageBox.Show("Bạn đã lưu thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            //    //conn.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSuanguyenvatlieu_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv.SelectedRows[0];
                selectedNguyenvatlieu = (Danhsachnguyenvatlieu)selectedRow.DataBoundItem;
                FormSuaNVL fsua = new FormSuaNVL();
                fsua.LoadData(selectedNguyenvatlieu); // Truyền dữ liệu vào form sửa
                fsua.ShowDialog();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra chỉ số của cột và dòng
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô
                object value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Kiểm tra nếu giá trị của ô là null hoặc chuỗi rỗng
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    // Tô màu đỏ cho ô
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnNhaptuexcel_Click(object sender, EventArgs e)
        {
            FormThemNVLbangexcel fthemexcel = new FormThemNVLbangexcel();
            fthemexcel.ShowDialog();
        }

        private void btnXoanguyenvatlieu_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string name = selectedRow.Cells["Materialvtn"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu "+ name +" ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    bool success = DanhsachnguyenvatlieuDAO.Instance.Delete(id);
                    if (success)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        allThongtinvattu = DanhsachnguyenvatlieuDAO.Instance.LoadTableList_Danhsachnguyenvatlieu();
                        UpdateDataGridViewThongtinvattu(allThongtinvattu);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            // Lấy nội dung từ TextBox để sử dụng làm điều kiện lọc
            string searchText = txtLoc.Text.ToLower();

            // Lọc danh sách thongtinvattus dựa trên điều kiện tìm kiếm
            List<Danhsachnguyenvatlieu> filteredList = allThongtinvattu.Where(item =>
                item.Materialno.ToString().ToLower().Contains(searchText) ||
                item.Suppliername.ToLower().Contains(searchText) ||
                item.Materialppc.ToLower().Contains(searchText) ||
                item.Materialvtn.ToLower().Contains(searchText) ||
                item.Maker.ToLower().Contains(searchText) ||
                item.Addressiso.ToLower().Contains(searchText) ||
                item.Addresscoabox.ToLower().Contains(searchText) ||
                item.Isoiatfcertificate.ToLower().Contains(searchText) ||
                item.Expirydate.ToLower().Contains(searchText) ||
                item.Note.ToLower().Contains(searchText) ||
                item.Vtncode.ToLower().Contains(searchText) ||
                item.Itemcode.ToLower().Contains(searchText) ||
                item.Vietnamesename.ToLower().Contains(searchText) ||
                item.Unit.ToLower().Contains(searchText) ||
                item.Unitprice.ToString().Contains(searchText) ||
                item.Currency.ToLower().Contains(searchText)
            ).ToList();
            txtCount.Text = filteredList.Count().ToString();

            // Cập nhật DataGridView với danh sách đã lọc
            UpdateDataGridViewThongtinvattu(filteredList);
        }

    }
}
