namespace Vietinak_Kho.f_PPC
{
    partial class FormSuaPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuaPO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.dgvPoInfo = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnLuulai = new System.Windows.Forms.Button();
            this.cbOderto = new System.Windows.Forms.ComboBox();
            this.cbDeliveryTerm = new System.Windows.Forms.ComboBox();
            this.cbShippingmethod = new System.Windows.Forms.ComboBox();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThemItem = new System.Windows.Forms.Button();
            this.btnXoaItem = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoInfo)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 612);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvPoInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.57143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1062, 612);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.cbCurrency);
            this.panel2.Controls.Add(this.cbShippingmethod);
            this.panel2.Controls.Add(this.cbDeliveryTerm);
            this.panel2.Controls.Add(this.cbOderto);
            this.panel2.Controls.Add(this.txtPageno);
            this.panel2.Controls.Add(this.txtFromdate);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.txtSec);
            this.panel2.Controls.Add(this.txtFax);
            this.panel2.Controls.Add(this.txtAttn);
            this.panel2.Controls.Add(this.txtTel);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.txtNo);
            this.panel2.Controls.Add(this.txtPaymentTerm);
            this.panel2.Controls.Add(this.txtIssuedate);
            this.panel2.Controls.Add(this.txtDept);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 291);
            this.panel2.TabIndex = 1;
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
            // dgvPoInfo
            // 
            this.dgvPoInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoInfo.Location = new System.Drawing.Point(3, 300);
            this.dgvPoInfo.Name = "dgvPoInfo";
            this.dgvPoInfo.ReadOnly = true;
            this.dgvPoInfo.Size = new System.Drawing.Size(1056, 222);
            this.dgvPoInfo.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtRemark);
            this.panel3.Controls.Add(this.txtTotal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 528);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 37);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Remark";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total";
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.SystemColors.Info;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(241, 7);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(810, 22);
            this.txtRemark.TabIndex = 2;
            // 
            // btnLuulai
            // 
            this.btnLuulai.BackColor = System.Drawing.Color.LightGreen;
            this.btnLuulai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLuulai.Image = ((System.Drawing.Image)(resources.GetObject("btnLuulai.Image")));
            this.btnLuulai.Location = new System.Drawing.Point(707, 3);
            this.btnLuulai.Name = "btnLuulai";
            this.btnLuulai.Size = new System.Drawing.Size(346, 32);
            this.btnLuulai.TabIndex = 3;
            this.btnLuulai.Text = "Lưu lại";
            this.btnLuulai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuulai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuulai.UseVisualStyleBackColor = false;
            this.btnLuulai.Click += new System.EventHandler(this.btnLuulai_Click);
            // 
            // cbOderto
            // 
            this.cbOderto.BackColor = System.Drawing.SystemColors.Info;
            this.cbOderto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOderto.FormattingEnabled = true;
            this.cbOderto.Location = new System.Drawing.Point(139, 126);
            this.cbOderto.Name = "cbOderto";
            this.cbOderto.Size = new System.Drawing.Size(591, 24);
            this.cbOderto.TabIndex = 16;
            this.cbOderto.SelectedIndexChanged += new System.EventHandler(this.cbOderto_SelectedIndexChanged);
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
            this.cbDeliveryTerm.Location = new System.Drawing.Point(434, 264);
            this.cbDeliveryTerm.Name = "cbDeliveryTerm";
            this.cbDeliveryTerm.Size = new System.Drawing.Size(146, 24);
            this.cbDeliveryTerm.TabIndex = 17;
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
            this.cbShippingmethod.Location = new System.Drawing.Point(684, 264);
            this.cbShippingmethod.Name = "cbShippingmethod";
            this.cbShippingmethod.Size = new System.Drawing.Size(146, 24);
            this.cbShippingmethod.TabIndex = 18;
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
            this.cbCurrency.Location = new System.Drawing.Point(904, 262);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(146, 24);
            this.cbCurrency.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnLuulai, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnThemItem, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXoaItem, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 571);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1056, 38);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnThemItem
            // 
            this.btnThemItem.BackColor = System.Drawing.Color.Orange;
            this.btnThemItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemItem.Image = ((System.Drawing.Image)(resources.GetObject("btnThemItem.Image")));
            this.btnThemItem.Location = new System.Drawing.Point(355, 3);
            this.btnThemItem.Name = "btnThemItem";
            this.btnThemItem.Size = new System.Drawing.Size(346, 32);
            this.btnThemItem.TabIndex = 3;
            this.btnThemItem.Text = "Thêm Item trong PO";
            this.btnThemItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemItem.UseVisualStyleBackColor = false;
            this.btnThemItem.Click += new System.EventHandler(this.btnThemItem_Click);
            // 
            // btnXoaItem
            // 
            this.btnXoaItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoaItem.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaItem.Image")));
            this.btnXoaItem.Location = new System.Drawing.Point(3, 3);
            this.btnXoaItem.Name = "btnXoaItem";
            this.btnXoaItem.Size = new System.Drawing.Size(346, 32);
            this.btnXoaItem.TabIndex = 3;
            this.btnXoaItem.Text = "Xóa Item trong PO";
            this.btnXoaItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaItem.UseVisualStyleBackColor = false;
            this.btnXoaItem.Click += new System.EventHandler(this.btnXoaItem_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(46, 7);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(107, 22);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormSuaPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1062, 612);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormSuaPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa PO";
            this.Load += new System.EventHandler(this.FormSuaPO_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoInfo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPageno;
        private System.Windows.Forms.TextBox txtFromdate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtAttn;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.TextBox txtPaymentTerm;
        private System.Windows.Forms.TextBox txtIssuedate;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.DataGridView dgvPoInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnLuulai;
        private System.Windows.Forms.ComboBox cbOderto;
        private System.Windows.Forms.ComboBox cbDeliveryTerm;
        private System.Windows.Forms.ComboBox cbShippingmethod;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnThemItem;
        private System.Windows.Forms.Button btnXoaItem;
        private System.Windows.Forms.TextBox txtTotal;
    }
}