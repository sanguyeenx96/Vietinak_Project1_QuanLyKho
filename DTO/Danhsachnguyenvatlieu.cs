using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.DTO
{
    public class Danhsachnguyenvatlieu
    {
        public Danhsachnguyenvatlieu(int id, string code, int materialno, string suppliername, string materialppc,
          string materialvtn, string maker, string addressiso, string addresscoabox,
          bool diachitrencoacotrenisokhong, string isoiatfcertificate, string expirydate, string note,
          string vtncode, string itemcode, string vietnamesename, string unit, float unitprice, string currency)
        {
            this.Id = id;
            this.Code = code;
            this.Materialno = materialno;
            this.Suppliername = suppliername;
            this.Materialppc = materialppc;
            this.Materialvtn = materialvtn;
            this.Maker = maker;
            this.Addressiso = addressiso;
            this.Addresscoabox = addresscoabox;
            this.Diachitrencoacotrenisokhong = diachitrencoacotrenisokhong;           
            this.Isoiatfcertificate = isoiatfcertificate;
            this.Expirydate = expirydate;
            this.Note = note;
            this.Vtncode = vtncode;
            this.Itemcode = itemcode;
            this.Vietnamesename = vietnamesename;
            this.Unit = unit;
            this.Unitprice = unitprice;
            this.Currency = currency;
        }
       
        public Danhsachnguyenvatlieu(DataRow row)
        {
            this.Id = GetInt32(row, "id");
            this.Code = GetString(row, "code");
            this.Materialno = GetInt32(row, "materialno");
            this.Suppliername = GetString(row, "suppliername");
            this.Materialppc = GetString(row, "materialppc");
            this.Materialvtn = GetString(row, "materialvtn");
            this.Maker = GetString(row, "maker");
            this.Addressiso = GetString(row, "addressiso");
            this.Addresscoabox = GetString(row, "addresscoabox");
            this.Diachitrencoacotrenisokhong = GetBoolean(row, "diachitrencoacotrenisokhong");
            this.Isoiatfcertificate = GetString(row, "isoiatfcertificate");
            this.Expirydate = GetString(row, "expirydate");
            this.Note = GetString(row, "note");
            this.Vtncode = GetString(row, "vtncode");
            this.Itemcode = GetString(row, "itemcode");
            this.Vietnamesename = GetString(row, "vietnamesename");
            this.Unit = GetString(row, "unit");
            this.Unitprice = GetFloat(row, "unitprice");
            this.Currency = GetString(row, "currency");
        }

        private int GetInt32(DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? 0 : Convert.ToInt32(row[columnName]);
        }

        private string GetString(DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? string.Empty : row[columnName].ToString();
        }

        private bool GetBoolean(DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? false : Convert.ToBoolean(row[columnName]);
        }

        private float GetFloat(DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? 0 : Convert.ToSingle(row[columnName]);
        }


        private int id;
        private string code;
        private int materialno;
        private string suppliername;
        private string materialppc;
        private string materialvtn;
        private string maker;
        private string addressiso;
        private string addresscoabox;
        private bool diachitrencoacotrenisokhong;
        private string isoiatfcertificate;
        private string expirydate;
        private string note;
        private string vtncode;
        private string itemcode;
        private string vietnamesename;
        private string unit;
        private float unitprice;
        private string currency;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public int Materialno { get => materialno; set => materialno = value; }
        public string Suppliername { get => suppliername; set => suppliername = value; }
        public string Materialppc { get => materialppc; set => materialppc = value; }
        public string Materialvtn { get => materialvtn; set => materialvtn = value; }
        public string Maker { get => maker; set => maker = value; }
        public string Addressiso { get => addressiso; set => addressiso = value; }
        public string Addresscoabox { get => addresscoabox; set => addresscoabox = value; }
        public bool Diachitrencoacotrenisokhong { get => diachitrencoacotrenisokhong; set => diachitrencoacotrenisokhong = value; }
        public string Isoiatfcertificate { get => isoiatfcertificate; set => isoiatfcertificate = value; }
        public string Expirydate { get => expirydate; set => expirydate = value; }
        public string Note { get => note; set => note = value; }
        public string Vtncode { get => vtncode; set => vtncode = value; }
        public string Itemcode { get => itemcode; set => itemcode = value; }
        public string Vietnamesename { get => vietnamesename; set => vietnamesename = value; }
        public string Unit { get => unit; set => unit = value; }
        public float Unitprice { get => unitprice; set => unitprice = value; }
        public string Currency { get => currency; set => currency = value; }
    }
}
