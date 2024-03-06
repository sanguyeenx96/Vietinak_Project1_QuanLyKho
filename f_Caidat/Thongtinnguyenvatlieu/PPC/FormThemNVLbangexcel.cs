using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietinak_Kho.DTO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu.Moi
{
    public partial class FormThemNVLbangexcel : Form
    {
        public FormThemNVLbangexcel()
        {
            InitializeComponent();
        }

        private void FormThemNVLbangexcel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Thiết lập các thuộc tính cho hộp thoại mở tệp
            openFileDialog1.InitialDirectory = "c:\\"; // Thư mục mặc định khi mở hộp thoại
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"; // Bộ lọc các loại tệp
            openFileDialog1.FilterIndex = 2; // Chỉ định loại tệp mặc định
            openFileDialog1.RestoreDirectory = true; // Lưu thư mục gần nhất được truy cập

            // Hiển thị hộp thoại mở tệp và kiểm tra kết quả
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của tệp tin đã chọn
                string filePath = openFileDialog1.FileName;
                txtPath.Text = filePath;
            }
        }

        private List<Danhsachnguyenvatlieu> ImportFromExcel(string filePath)
        {
            List<Danhsachnguyenvatlieu> dataList = new List<Danhsachnguyenvatlieu>();

            // Khởi tạo ứng dụng Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet worksheet = workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;

            // Xác định số dòng và cột có dữ liệu
            int rowCount = range.Rows.Count;
            int columnCount = range.Columns.Count;

            // Đọc dữ liệu từ Excel và thêm vào danh sách
            for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng thứ 2 vì hàng đầu tiên thường là tiêu đề
            {
                //Danhsachnguyenvatlieu data = new Danhsachnguyenvatlieu(
                //code: range.Cells[row, 1].Value.ToString(), // Bỏ qua trường ID ở đây
                //materialno: Convert.ToInt32(range.Cells[row, 2].Value),
                //suppliername: range.Cells[row, 3].Value.ToString(),
                //materialppc: range.Cells[row, 4].Value.ToString(),
                //materialvtn: range.Cells[row, 5].Value.ToString(),
                //maker: range.Cells[row, 6].Value.ToString(),
                //addressiso: range.Cells[row, 7].Value.ToString(),
                //addresscoabox: range.Cells[row, 8].Value.ToString(),
                //diachitrencoacotrenisokhong: Convert.ToBoolean(range.Cells[row, 9].Value),
                //isoiatfcertificate: range.Cells[row, 17].Value.ToString(),
                //expirydate: range.Cells[row, 18].Value.ToString(),
                //note: range.Cells[row, 19].Value.ToString(),
                //vtncode: range.Cells[row, 20].Value.ToString(),
                //itemcode: range.Cells[row, 21].Value.ToString(),
                //vietnamesename: range.Cells[row, 22].Value.ToString(),
                //unit: range.Cells[row, 23].Value.ToString(),
                //unitprice: Convert.ToSingle(range.Cells[row, 24].Value),
                //currency: range.Cells[row, 25].Value.ToString()
                //);
                //dataList.Add(data);
            }

            // Đóng workbook và ứng dụng Excel
            workbook.Close();
            excelApp.Quit();

            // Giải phóng bộ nhớ
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);

            return dataList;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
