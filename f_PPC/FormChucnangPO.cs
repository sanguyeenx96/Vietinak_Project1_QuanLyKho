using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Vietinak_Kho.DAO;
using Vietinak_Kho.f_PPC.Invoice;
using Vietinak_Kho.f_Nghiemthu;
using Vietinak_Kho.f_Nhapxuat;

namespace Vietinak_Kho.f_PPC
{
    public partial class FormChucnangPO : Form
    {
        public event EventHandler<DialogClosedEventArgs> DialogClosed;

        private int id;
        public FormChucnangPO(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormChucnangPO_Load(object sender, EventArgs e)
        {
            var thongtinpo = PoDAO.Instance.LoadTableList_PoById(id);
            if(thongtinpo.Trangthai != "Chờ confirm" )
            {
                btnConfirmPO.Enabled = false;
                btnConfirmPO.BackColor = Color.Gray;
            }
            if (thongtinpo.Trangthai == "Chờ confirm" || thongtinpo.Trangthai == "Done")
            {
                btnConfirmPODone.Enabled = false;
                btnConfirmPODone.BackColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormXemchitietPO f = new FormXemchitietPO(id);
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                var thongtinPO = PoDAO.Instance.LoadTableList_PoById(id);
                var chitietPO = PoInfoDAO.Instance.LoadTableList_PoInfoFromPo(thongtinPO.Id);

                string basepath = Application.StartupPath;
                string POfilepath = basepath + @"/PO-PPC.xlsx";

                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(POfilepath)))
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                    int startRow = 17;
                    int endRow = worksheet.Dimension.End.Row; // Hàng cuối cùng có dữ liệu
                    var data = chitietPO;
                    if (thongtinPO != null || data != null)
                    {
                        int rowCount = data.Count; // Số hàng dữ liệu mới sẽ được chèn vào
                        worksheet.InsertRow(startRow + 1, rowCount);
                        int currentRow = startRow;
                        //Info
                        worksheet.Cells["K" + 1].Value = thongtinPO.Dept;
                        worksheet.Cells["Q" + 1].Value = thongtinPO.Sec;
                        worksheet.Cells["Y" + 1].Value = thongtinPO.Code;
                        worksheet.Cells["Y" + 3].Value = thongtinPO.Fromdate;
                        worksheet.Cells["Y" + 5].Value = thongtinPO.Pageno;
                        worksheet.Cells["I" + 5].Value = thongtinPO.No;
                        worksheet.Cells["E" + 8].Value = thongtinPO.Orderto;
                        worksheet.Cells["E" + 9].Value = thongtinPO.Address;
                        worksheet.Cells["E" + 10].Value = thongtinPO.Tel;
                        worksheet.Cells["E" + 11].Value = thongtinPO.Attn;
                        worksheet.Cells["N" + 10].Value = thongtinPO.Fax;
                        worksheet.Cells["A" + 14].Value = thongtinPO.Issuedate;
                        worksheet.Cells["G" + 14].Value = thongtinPO.Paymentterm;
                        worksheet.Cells["L" + 14].Value = thongtinPO.Deliveryterm;
                        worksheet.Cells["R" + 14].Value = thongtinPO.Shippingmethod;
                        worksheet.Cells["Z" + 14].Value = thongtinPO.Currency;
                        //List
                        int stt = 0;
                        foreach (var item in data)
                        {
                            worksheet.Cells["A" + currentRow].Value = stt++;
                            worksheet.Cells["B" + currentRow + ":E" + currentRow].Merge = true;
                            worksheet.Cells["B" + currentRow].Value = item.Itemcode;

                            worksheet.Cells["F" + currentRow + ":H" + currentRow].Merge = true;
                            worksheet.Cells["F" + currentRow].Value = item.Description;

                            worksheet.Cells["I" + currentRow + ":K" + currentRow].Merge = true;
                            worksheet.Cells["I" + currentRow].Value = item.Partno;

                            worksheet.Cells["L" + currentRow + ":M" + currentRow].Merge = true;
                            worksheet.Cells["L" + currentRow].Value = item.Qty;

                            worksheet.Cells["N" + currentRow + ":O" + currentRow].Merge = true;
                            worksheet.Cells["N" + currentRow].Value = item.Unit;

                            worksheet.Cells["P" + currentRow + ":Q" + currentRow].Merge = true;
                            worksheet.Cells["P" + currentRow].Value = item.Price;

                            worksheet.Cells["R" + currentRow + ":T" + currentRow].Merge = true;
                            worksheet.Cells["R" + currentRow].Value = item.Amount;

                            worksheet.Cells["U" + currentRow + ":W" + currentRow].Merge = true;
                            worksheet.Cells["U" + currentRow].Value = item.Group;

                            worksheet.Cells["X" + currentRow + ":Y" + currentRow].Merge = true;
                            worksheet.Cells["X" + currentRow].Value = item.Requesteddepartment;

                            worksheet.Cells["Z" + currentRow + ":AB" + currentRow].Merge = true;
                            worksheet.Cells["Z" + currentRow].Value = item.Factory;

                            worksheet.Cells["AC" + currentRow].Value = item.Etd;

                            using (var range = worksheet.Cells["A" + currentRow + ":AC" + currentRow])
                            {
                                //range.Style.Font.Bold = true; // Đặt chữ in đậm
                                range.Style.Font.Size = 11; // Đặt kích cỡ chữ
                                range.Style.Font.Name = "Times New Roman"; // Đặt tên font chữ
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Căn giữa ngang cho cả dòng
                                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center; // Căn giữa dọc cho cả dòng
                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }
                            using (var range = worksheet.Cells["P" + currentRow + ":T" + currentRow])
                            {
                                range.Style.Numberformat.Format = "#,##0.00"; // Định dạng các ô trong phạm vi là số có hai chữ số thập phân và dấu phân cách hàng nghìn
                            }

                            currentRow++;
                        }
                        currentRow = currentRow + 1;
                        worksheet.Cells["R" + currentRow].Value = data.FirstOrDefault()?.Total;
                        currentRow = currentRow + 1;
                        worksheet.Cells["C" + currentRow].Value = data.FirstOrDefault()?.Remark;


                        // Lưu file Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            FileInfo file = new FileInfo(saveFileDialog.FileName);
                            excelPackage.SaveAs(file);
                            MessageBox.Show("Dữ liệu đã được xuất ra file Excel.");
                        }
                    }
                }
            }

            catch
            {
                MessageBox.Show("Dữ liệu PO không đầy đủ để xuất ra file Excel!");
            }
        }

        private void btnQuanlyInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDanhsachInvoice f = new FormDanhsachInvoice(id);
            f.ShowDialog();
        }

        private void btnConfirmPO_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cập nhật trạng thái confirm cho PO?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool update = PoDAO.Instance.UpdateTrangthaiPO(id, "Pending");
                if (update)
                {
                    DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }    

        }

        private void btnXoaPO_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận xóa PO và tất cả các thông tin liên quan?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool delete = PoDAO.Instance.Delete(id);
                if (delete)
                {
                    DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }
        }

        private void btnConfirmPODone_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cập nhật trạng thái Done cho PO?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool update = PoDAO.Instance.UpdateTrangthaiPO(id, "Done");
                if (update)
                {
                    DialogClosed?.Invoke(this, new DialogClosedEventArgs("OK"));
                    this.Close();
                    FormThanhcong fthanhcong = new FormThanhcong();
                    fthanhcong.ShowDialog();
                }
            }
        }

        private void btnSuaPO_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSuaPO f = new FormSuaPO(id);
            f.ShowDialog();
        }
    }
}
