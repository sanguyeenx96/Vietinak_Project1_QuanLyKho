using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Vietinak_Kho.DAO;
using Vietinak_Kho.DTO;

namespace Vietinak_Kho
{
    public partial class FormBieudo : Form
    {
        private DataTable dataNhap;
        private DataTable dataXuat;
        private DataTable originalDataNhap;
        private DataTable originalDataXuat;

        public FormBieudo()
        {
            InitializeComponent();
        }

        public void DisplayDataOnChart(DataTable dataNhap, DataTable dataXuat, Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // Tạo ChartArea
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Tạo series cho dữ liệu nhập
            Series seriesNhap = new Series("Nhập kho");
            seriesNhap.Color = Color.LightGreen;
            seriesNhap.ChartType = SeriesChartType.Column;
            seriesNhap.CustomProperties = "DrawingStyle=Cylinder";

            chart.Series.Add(seriesNhap);

            // Tạo series cho dữ liệu xuất
            Series seriesXuat = new Series("Xuất kho");
            seriesXuat.Color = Color.Goldenrod;
            seriesXuat.ChartType = SeriesChartType.Column;
            seriesXuat.CustomProperties = "DrawingStyle=Cylinder";

            chart.Series.Add(seriesXuat);

            // Thêm dữ liệu từ DataTable nhập vào series nhập
            for (int i = 0; i < dataNhap.Rows.Count; i++)
            {
                DataRow row = dataNhap.Rows[i];
                double soluongNhap = Convert.ToDouble(row["Soluongnhap"]);
                string donvi = row["Donvi"].ToString();

                // Thêm điểm dữ liệu và đặt nhãn giá trị dưới cột
                seriesNhap.Points.Add(soluongNhap).Label = soluongNhap.ToString() + " " + donvi;
            }

            // Thêm dữ liệu từ DataTable xuất vào series xuất
            for (int i = 0; i < dataXuat.Rows.Count; i++)
            {
                DataRow row = dataXuat.Rows[i];
                double soluongXuat = Convert.ToDouble(row["Soluongxuat"]);
                string donvi = row["Donvi"].ToString();

                // Thêm điểm dữ liệu và đặt nhãn giá trị dưới cột
                seriesXuat.Points.Add(soluongXuat).Label = soluongXuat.ToString() + " " + donvi;
            }

            // Cài đặt trục x
            chartArea.AxisX.Interval = 0.1; // Cài đặt khoảng cách giữa các cột là 1
            chartArea.AxisX.LabelStyle.Angle = -45; // Xoay nhãn trục x để tránh chồng chéo
            chartArea.AxisX.Title = "Ngày"; // Đặt tiêu đề cho trục X
            chartArea.AxisX.Enabled = AxisEnabled.False; // Tắt hiển thị trục X
            // Cài đặt trục y
            chartArea.AxisY.Interval = 0.5; // Đặt khoảng cách giữa các bước của trục Y là 0.1
            //chartArea.AxisY.Minimum = 0; // Đặt giá trị tối thiểu của trục Y
            //chartArea.AxisY.Maximum = 1; // Đặt giá trị tối đa của trục Y
            chartArea.AxisY.Title = "Số lượng"; // Đặt tiêu đề cho trục Y
            chartArea.AxisY.Enabled = AxisEnabled.False; // Tắt hiển thị trục X
            chartArea.AxisX.MajorGrid.Enabled = false; // Tắt dòng kẻ trên trục X
            chartArea.AxisY.MajorGrid.Enabled = false; // Tắt dòng kẻ trên trục Y
            chartArea.BackColor = Color.White;
            chartArea.BackGradientStyle = GradientStyle.LeftRight;
        }

        public Tuple<DataTable, DataTable> GetDataForDay(string date)
        {
            string queryNhap = "SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Nhập' AND Thoigian LIKE '" + date + "%' ORDER BY Thoigian ";
            string queryXuat = "SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Xuất' AND Thoigian LIKE '" + date + "%' ORDER BY Thoigian ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            dataNhap = DataProvider.Instance.ExecuteQuery(queryNhap);
            dataXuat = DataProvider.Instance.ExecuteQuery(queryXuat);
            originalDataNhap = dataNhap.Copy();
            originalDataXuat = dataXuat.Copy();
            if (cbloc.Text != "Tất cả")
            {
                // Lọc dữ liệu theo trường Donvi trong DataTable dataNhap
                DataRow[] rowsNhap = originalDataNhap.Select("Donvi = '" + cbloc.Text + "'");
                DataTable filteredDataNhap = originalDataNhap.Clone(); // Tạo một bản sao của schema (cấu trúc) của DataTable originalDataNhap
                foreach (DataRow row in rowsNhap)
                {
                    filteredDataNhap.ImportRow(row); // Thêm các dòng đã lọc vào DataTable mới
                }

                // Lọc dữ liệu theo trường Donvi trong DataTable dataXuat
                DataRow[] rowsXuat = originalDataXuat.Select("Donvi = '" + cbloc.Text + "'");
                DataTable filteredDataXuat = originalDataXuat.Clone(); // Tạo một bản sao của schema (cấu trúc) của DataTable originalDataXuat
                foreach (DataRow row in rowsXuat)
                {
                    filteredDataXuat.ImportRow(row); // Thêm các dòng đã lọc vào DataTable mới
                }
                dataNhap = filteredDataNhap;
                dataXuat = filteredDataXuat;
            }

            txtTongsolannhapkho.Text = dataNhap.Rows.Count.ToString();
            txtTongsolanxuatkho.Text = dataXuat.Rows.Count.ToString();
            double totalNhapKg = 0;
            double totalNhapPcs = 0;
            foreach (DataRow row in dataNhap.Rows)
            {
                string donvi = row["Donvi"].ToString();
                double soluongNhap = Convert.ToDouble(row["Soluongnhap"]);
                if (donvi == "Kg")
                {
                    totalNhapKg += soluongNhap;
                }
                if (donvi == "Pcs")
                {
                    totalNhapPcs += soluongNhap;
                }
            }
            txtTongkhoiluongnhapkg.Text = totalNhapKg.ToString() + " Kg";
            txtTongkhoiluongnhappcs.Text = totalNhapPcs.ToString() + " Pcs";

            double totalXuatKg = 0;
            double totalXuatPcs = 0;
            foreach (DataRow row in dataXuat.Rows)
            {
                string donvi = row["Donvi"].ToString();
                double soluongXuat = Convert.ToDouble(row["Soluongxuat"]);
                if (donvi == "Kg")
                {
                    totalXuatKg += soluongXuat;
                }
                if (donvi == "Pcs")
                {
                    totalXuatPcs += soluongXuat;
                }
            }
            txtTongkhoiluongxuatkg.Text = totalXuatKg.ToString() + " Kg";
            txtTongkhoiluongxuatpcs.Text = totalXuatPcs.ToString() + " Pcs";

            return Tuple.Create(dataNhap, dataXuat);
        }

        public Tuple<DataTable, DataTable> GetDataForKhoangthoigian(string tungay, string denngay)
        {
            string queryNhap = "SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Nhập' AND Thoigian BETWEEN('" + tungay + "') AND('" + denngay + "') ORDER BY Thoigian ";
            string queryXuat = "SELECT * FROM dbo.tbllichsunhapxuat WHERE Loaithaotac = N'Xuất' AND Thoigian BETWEEN('" + tungay + "') AND('" + denngay + "') ORDER BY Thoigian ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            dataNhap = DataProvider.Instance.ExecuteQuery(queryNhap);
            dataXuat = DataProvider.Instance.ExecuteQuery(queryXuat);
            originalDataNhap = dataNhap.Copy();
            originalDataXuat = dataXuat.Copy();
            if (cbloc.Text != "Tất cả")
            {
                // Lọc dữ liệu theo trường Donvi trong DataTable dataNhap
                DataRow[] rowsNhap = originalDataNhap.Select("Donvi = '" + cbloc.Text + "'");
                DataTable filteredDataNhap = originalDataNhap.Clone(); // Tạo một bản sao của schema (cấu trúc) của DataTable originalDataNhap
                foreach (DataRow row in rowsNhap)
                {
                    filteredDataNhap.ImportRow(row); // Thêm các dòng đã lọc vào DataTable mới
                }

                // Lọc dữ liệu theo trường Donvi trong DataTable dataXuat
                DataRow[] rowsXuat = originalDataXuat.Select("Donvi = '" + cbloc.Text + "'");
                DataTable filteredDataXuat = originalDataXuat.Clone(); // Tạo một bản sao của schema (cấu trúc) của DataTable originalDataXuat
                foreach (DataRow row in rowsXuat)
                {
                    filteredDataXuat.ImportRow(row); // Thêm các dòng đã lọc vào DataTable mới
                }
                dataNhap = filteredDataNhap;
                dataXuat = filteredDataXuat;
            }
            txtTongsolannhapkho.Text = dataNhap.Rows.Count.ToString();
            txtTongsolanxuatkho.Text = dataXuat.Rows.Count.ToString();
            double totalNhapKg = 0;
            double totalNhapPcs = 0;
            foreach (DataRow row in dataNhap.Rows)
            {
                string donvi = row["Donvi"].ToString();
                double soluongNhap = Convert.ToDouble(row["Soluongnhap"]);
                if (donvi == "Kg")
                {
                    totalNhapKg += soluongNhap;
                }
                if (donvi == "Pcs")
                {
                    totalNhapPcs += soluongNhap;
                }
            }
            txtTongkhoiluongnhapkg.Text = totalNhapKg.ToString() + " Kg";
            txtTongkhoiluongnhappcs.Text = totalNhapPcs.ToString() + " Pcs";

            double totalXuatKg = 0;
            double totalXuatPcs = 0;
            foreach (DataRow row in dataXuat.Rows)
            {
                string donvi = row["Donvi"].ToString();
                double soluongXuat = Convert.ToDouble(row["Soluongxuat"]);
                if (donvi == "Kg")
                {
                    totalXuatKg += soluongXuat;
                }
                if (donvi == "Pcs")
                {
                    totalXuatPcs += soluongXuat;
                }
            }
            txtTongkhoiluongxuatkg.Text = totalXuatKg.ToString() + " Kg";
            txtTongkhoiluongxuatpcs.Text = totalXuatPcs.ToString() + " Pcs";

            return Tuple.Create(dataNhap, dataXuat);
        }

        public void ShowDataOnChartForDay(string date, Chart chart)
        {
            var data = GetDataForDay(date);
            DisplayDataOnChart(data.Item1, data.Item2, chart);
        }

        public void ShowDataOnChartForKhoangthoigian(string tungay, string denngay, Chart chart)
        {
            var data = GetDataForKhoangthoigian(tungay, denngay);
            DisplayDataOnChart(data.Item1, data.Item2, chart);
        }

        private void FormBieudo_Load(object sender, EventArgs e)
        {
            cbloc.SelectedIndexChanged -= cbloc_SelectedIndexChanged;
            cbloc.SelectedItem = "Tất cả";
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            ShowDataOnChartForDay(date, chart);
            groupBoxBieudo.Text = "Biểu đồ dữ liệu nhập xuất trong ngày " + DateTime.Now.ToString("yyyy/MM/dd");

            cbloc.SelectedIndexChanged += cbloc_SelectedIndexChanged;
        }

        private void dtpThang_ValueChanged(object sender, EventArgs e)
        {
            string date = dtpThang.Value.ToString("yyyy/MM");
            ShowDataOnChartForDay(date, chart);
            groupBoxBieudo.Text = "Biểu đồ dữ liệu nhập xuất trong tháng " + date;
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            string date = dtpNgay.Value.ToString("yyyy/MM/dd");
            ShowDataOnChartForDay(date, chart);
            groupBoxBieudo.Text = "Biểu đồ dữ liệu nhập xuất trong ngày " + date;
        }

        private void dtpTungay_ValueChanged(object sender, EventArgs e)
        {
            string tungay = dtpTungay.Value.ToString("yyyy/MM/dd");
            string denngay = dtpDenngay.Value.ToString("yyyy/MM/dd");
            ShowDataOnChartForKhoangthoigian(tungay, denngay, chart);
            groupBoxBieudo.Text = "Biểu đồ dữ liệu nhập xuất từ ngày " + tungay + " đến ngày " + denngay;
        }

        private void dtpDenngay_ValueChanged(object sender, EventArgs e)
        {
            string tungay = dtpTungay.Value.ToString("yyyy/MM/dd");
            string denngay = dtpDenngay.Value.ToString("yyyy/MM/dd");
            ShowDataOnChartForKhoangthoigian(tungay, denngay, chart);
            groupBoxBieudo.Text = "Biểu đồ dữ liệu nhập xuất từ ngày " + tungay + " đến ngày " + denngay;
        }

        private void cbloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbloc.Text != "Tất cả")
            {
                DataRow[] rowsNhap = originalDataNhap.Select("Donvi = '" + cbloc.Text + "'");
                DataTable filteredDataNhap = originalDataNhap.Clone(); // Tạo một bản sao của schema (cấu trúc) của DataTable dataNhap
                foreach (DataRow row in rowsNhap)
                {
                    filteredDataNhap.ImportRow(row); // Thêm các dòng đã lọc vào DataTable mới
                }
                // Lọc dữ liệu theo trường Donvi trong DataTable dataXuat
                DataRow[] rowsXuat = originalDataXuat.Select("Donvi = '" + cbloc.Text + "'");
                DataTable filteredDataXuat = originalDataXuat.Clone(); // Tạo một bản sao của schema (cấu trúc) của DataTable dataXuat
                foreach (DataRow row in rowsXuat)
                {
                    filteredDataXuat.ImportRow(row); // Thêm các dòng đã lọc vào DataTable mới
                }
                DisplayDataOnChart(filteredDataNhap, filteredDataXuat, chart);
            }
            else
            {
                DisplayDataOnChart(originalDataNhap, originalDataXuat, chart);
            }
        }
    }
}
