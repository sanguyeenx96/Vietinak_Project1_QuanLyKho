namespace Vietinak_Kho.f_PPC
{
    partial class FormTaoPo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaoPo));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.cbShippingmethod = new System.Windows.Forms.ComboBox();
            this.cbDeliveryTerm = new System.Windows.Forms.ComboBox();
            this.cbOderto = new System.Windows.Forms.ComboBox();
            this.txtPageno = new System.Windows.Forms.TextBox();
            this.txtFromdate = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtSec = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtAttn = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.txtPaymentTerm = new System.Windows.Forms.TextBox();
            this.txtIssuedate = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.67567F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.32432F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1070, 370);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnHuybo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnXacNhan, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 320);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1064, 47);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnHuybo
            // 
            this.btnHuybo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnHuybo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuybo.FlatAppearance.BorderSize = 0;
            this.btnHuybo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuybo.Image = ((System.Drawing.Image)(resources.GetObject("btnHuybo.Image")));
            this.btnHuybo.Location = new System.Drawing.Point(3, 3);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(526, 41);
            this.btnHuybo.TabIndex = 1;
            this.btnHuybo.Text = "Hủy bỏ";
            this.btnHuybo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuybo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuybo.UseVisualStyleBackColor = false;
            this.btnHuybo.Click += new System.EventHandler(this.btnHuybo_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.LightGreen;
            this.btnXacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(535, 3);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(526, 41);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1064, 311);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin PO";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.cbCurrency);
            this.panel1.Controls.Add(this.cbShippingmethod);
            this.panel1.Controls.Add(this.cbDeliveryTerm);
            this.panel1.Controls.Add(this.cbOderto);
            this.panel1.Controls.Add(this.txtPageno);
            this.panel1.Controls.Add(this.txtFromdate);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.txtSec);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.txtAttn);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtNo);
            this.panel1.Controls.Add(this.txtPaymentTerm);
            this.panel1.Controls.Add(this.txtIssuedate);
            this.panel1.Controls.Add(this.txtDept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 292);
            this.panel1.TabIndex = 0;
            // 
            // cbCurrency
            // 
            this.cbCurrency.AutoCompleteCustomSource.AddRange(new string[] {
            "USD",
            "JPY",
            "VNĐ"});
            this.cbCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbCurrency.BackColor = System.Drawing.SystemColors.Info;
            this.cbCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Items.AddRange(new object[] {
            "USD",
            "JPY",
            "VNĐ"});
            this.cbCurrency.Location = new System.Drawing.Point(905, 263);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(146, 24);
            this.cbCurrency.TabIndex = 1;
            this.cbCurrency.SelectedIndexChanged += new System.EventHandler(this.cbOderto_SelectedIndexChanged);
            // 
            // cbShippingmethod
            // 
            this.cbShippingmethod.AutoCompleteCustomSource.AddRange(new string[] {
            "Sea Freight",
            "Air Freight",
            "Truck"});
            this.cbShippingmethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbShippingmethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbShippingmethod.BackColor = System.Drawing.SystemColors.Info;
            this.cbShippingmethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShippingmethod.FormattingEnabled = true;
            this.cbShippingmethod.Items.AddRange(new object[] {
            "Sea Freight",
            "Air Freight",
            "Truck"});
            this.cbShippingmethod.Location = new System.Drawing.Point(685, 263);
            this.cbShippingmethod.Name = "cbShippingmethod";
            this.cbShippingmethod.Size = new System.Drawing.Size(146, 24);
            this.cbShippingmethod.TabIndex = 1;
            this.cbShippingmethod.SelectedIndexChanged += new System.EventHandler(this.cbOderto_SelectedIndexChanged);
            // 
            // cbDeliveryTerm
            // 
            this.cbDeliveryTerm.AutoCompleteCustomSource.AddRange(new string[] {
            "CIF Hai Phong",
            "CIF Noi Bai",
            "FCA Nagoya",
            "Ex-work",
            "DDU Vietinak",
            "FOB JKT"});
            this.cbDeliveryTerm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDeliveryTerm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDeliveryTerm.BackColor = System.Drawing.SystemColors.Info;
            this.cbDeliveryTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDeliveryTerm.FormattingEnabled = true;
            this.cbDeliveryTerm.Items.AddRange(new object[] {
            "CIF Hai Phong",
            "CIF Noi Bai",
            "FCA Nagoya",
            "Ex-work",
            "DDU Vietinak",
            "FOB JKT"});
            this.cbDeliveryTerm.Location = new System.Drawing.Point(432, 263);
            this.cbDeliveryTerm.Name = "cbDeliveryTerm";
            this.cbDeliveryTerm.Size = new System.Drawing.Size(146, 24);
            this.cbDeliveryTerm.TabIndex = 1;
            this.cbDeliveryTerm.SelectedIndexChanged += new System.EventHandler(this.cbOderto_SelectedIndexChanged);
            // 
            // cbOderto
            // 
            this.cbOderto.BackColor = System.Drawing.SystemColors.Info;
            this.cbOderto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOderto.FormattingEnabled = true;
            this.cbOderto.Location = new System.Drawing.Point(139, 126);
            this.cbOderto.Name = "cbOderto";
            this.cbOderto.Size = new System.Drawing.Size(591, 24);
            this.cbOderto.TabIndex = 1;
            this.cbOderto.SelectedIndexChanged += new System.EventHandler(this.cbOderto_SelectedIndexChanged);
            // 
            // txtPageno
            // 
            this.txtPageno.BackColor = System.Drawing.SystemColors.Info;
            this.txtPageno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageno.Location = new System.Drawing.Point(857, 82);
            this.txtPageno.Name = "txtPageno";
            this.txtPageno.Size = new System.Drawing.Size(194, 22);
            this.txtPageno.TabIndex = 15;
            this.txtPageno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromdate
            // 
            this.txtFromdate.BackColor = System.Drawing.SystemColors.Info;
            this.txtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromdate.Location = new System.Drawing.Point(857, 45);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Size = new System.Drawing.Size(194, 22);
            this.txtFromdate.TabIndex = 14;
            this.txtFromdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(857, 7);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(194, 22);
            this.txtCode.TabIndex = 13;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSec
            // 
            this.txtSec.BackColor = System.Drawing.SystemColors.Info;
            this.txtSec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSec.Location = new System.Drawing.Point(580, 7);
            this.txtSec.Name = "txtSec";
            this.txtSec.Size = new System.Drawing.Size(150, 22);
            this.txtSec.TabIndex = 12;
            this.txtSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.SystemColors.Info;
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(422, 185);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(308, 22);
            this.txtFax.TabIndex = 4;
            // 
            // txtAttn
            // 
            this.txtAttn.BackColor = System.Drawing.SystemColors.Info;
            this.txtAttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttn.Location = new System.Drawing.Point(139, 214);
            this.txtAttn.Name = "txtAttn";
            this.txtAttn.Size = new System.Drawing.Size(214, 22);
            this.txtAttn.TabIndex = 5;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.SystemColors.Info;
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(139, 185);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(214, 22);
            this.txtTel.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(139, 156);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(591, 22);
            this.txtAddress.TabIndex = 2;
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNo.Location = new System.Drawing.Point(486, 82);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(244, 22);
            this.txtNo.TabIndex = 0;
            // 
            // txtPaymentTerm
            // 
            this.txtPaymentTerm.BackColor = System.Drawing.SystemColors.Info;
            this.txtPaymentTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentTerm.Location = new System.Drawing.Point(230, 264);
            this.txtPaymentTerm.Name = "txtPaymentTerm";
            this.txtPaymentTerm.Size = new System.Drawing.Size(146, 22);
            this.txtPaymentTerm.TabIndex = 7;
            this.txtPaymentTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIssuedate
            // 
            this.txtIssuedate.BackColor = System.Drawing.SystemColors.Info;
            this.txtIssuedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssuedate.Location = new System.Drawing.Point(41, 264);
            this.txtIssuedate.Name = "txtIssuedate";
            this.txtIssuedate.Size = new System.Drawing.Size(146, 22);
            this.txtIssuedate.TabIndex = 6;
            this.txtIssuedate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDept
            // 
            this.txtDept.BackColor = System.Drawing.SystemColors.Info;
            this.txtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Location = new System.Drawing.Point(371, 7);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(105, 22);
            this.txtDept.TabIndex = 11;
            this.txtDept.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormTaoPo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1070, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormTaoPo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo PO";
            this.Load += new System.EventHandler(this.FormTaoPo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPageno;
        private System.Windows.Forms.TextBox txtFromdate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtAttn;
        private System.Windows.Forms.TextBox txtPaymentTerm;
        private System.Windows.Forms.TextBox txtIssuedate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ComboBox cbOderto;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.ComboBox cbShippingmethod;
        private System.Windows.Forms.ComboBox cbDeliveryTerm;
    }
}