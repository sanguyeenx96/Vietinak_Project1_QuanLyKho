namespace Vietinak_Kho.f_Taikhoan
{
    partial class FormQuanlydanhsachtaikhoan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhsachtaikhoan = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtLoctukhoa = new System.Windows.Forms.TextBox();
            this.cbLocbophan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTotalAcc = new System.Windows.Forms.Button();
            this.btnAdminAcc = new System.Windows.Forms.Button();
            this.btnUserAcc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsachtaikhoan)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 601);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(947, 601);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(947, 540);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhsachtaikhoan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 534);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách tài khoản";
            // 
            // dgvDanhsachtaikhoan
            // 
            this.dgvDanhsachtaikhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhsachtaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhsachtaikhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhsachtaikhoan.Location = new System.Drawing.Point(3, 16);
            this.dgvDanhsachtaikhoan.Name = "dgvDanhsachtaikhoan";
            this.dgvDanhsachtaikhoan.ReadOnly = true;
            this.dgvDanhsachtaikhoan.Size = new System.Drawing.Size(935, 515);
            this.dgvDanhsachtaikhoan.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(947, 57);
            this.panel3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(947, 57);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc dữ liệu";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtLoctukhoa);
            this.panel4.Controls.Add(this.cbLocbophan);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(941, 38);
            this.panel4.TabIndex = 1;
            // 
            // txtLoctukhoa
            // 
            this.txtLoctukhoa.Location = new System.Drawing.Point(738, 8);
            this.txtLoctukhoa.Name = "txtLoctukhoa";
            this.txtLoctukhoa.Size = new System.Drawing.Size(200, 20);
            this.txtLoctukhoa.TabIndex = 3;
            this.txtLoctukhoa.TextChanged += new System.EventHandler(this.txtLoctukhoa_TextChanged);
            // 
            // cbLocbophan
            // 
            this.cbLocbophan.FormattingEnabled = true;
            this.cbLocbophan.Location = new System.Drawing.Point(564, 8);
            this.cbLocbophan.Name = "cbLocbophan";
            this.cbLocbophan.Size = new System.Drawing.Size(79, 21);
            this.cbLocbophan.TabIndex = 2;
            this.cbLocbophan.SelectedIndexChanged += new System.EventHandler(this.cbLocbophan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(668, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lọc từ khóa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lọc bộ phận";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnTotalAcc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdminAcc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUserAcc, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnTotalAcc
            // 
            this.btnTotalAcc.BackColor = System.Drawing.Color.White;
            this.btnTotalAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalAcc.FlatAppearance.BorderSize = 0;
            this.btnTotalAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTotalAcc.Location = new System.Drawing.Point(3, 3);
            this.btnTotalAcc.Name = "btnTotalAcc";
            this.btnTotalAcc.Size = new System.Drawing.Size(149, 24);
            this.btnTotalAcc.TabIndex = 0;
            this.btnTotalAcc.Text = "Tất cả tài khoản: __";
            this.btnTotalAcc.UseVisualStyleBackColor = false;
            this.btnTotalAcc.Click += new System.EventHandler(this.btnTotalAcc_Click);
            // 
            // btnAdminAcc
            // 
            this.btnAdminAcc.BackColor = System.Drawing.Color.White;
            this.btnAdminAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminAcc.FlatAppearance.BorderSize = 0;
            this.btnAdminAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminAcc.Location = new System.Drawing.Point(158, 3);
            this.btnAdminAcc.Name = "btnAdminAcc";
            this.btnAdminAcc.Size = new System.Drawing.Size(149, 24);
            this.btnAdminAcc.TabIndex = 0;
            this.btnAdminAcc.Text = "Tài khoản quản trị: __";
            this.btnAdminAcc.UseVisualStyleBackColor = false;
            this.btnAdminAcc.Click += new System.EventHandler(this.btnAdminAcc_Click);
            // 
            // btnUserAcc
            // 
            this.btnUserAcc.BackColor = System.Drawing.Color.White;
            this.btnUserAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserAcc.FlatAppearance.BorderSize = 0;
            this.btnUserAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAcc.Location = new System.Drawing.Point(313, 3);
            this.btnUserAcc.Name = "btnUserAcc";
            this.btnUserAcc.Size = new System.Drawing.Size(149, 24);
            this.btnUserAcc.TabIndex = 0;
            this.btnUserAcc.Text = "Tài khoản người dùng: __";
            this.btnUserAcc.UseVisualStyleBackColor = false;
            this.btnUserAcc.Click += new System.EventHandler(this.btnUserAcc_Click);
            // 
            // FormQuanlydanhsachtaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 601);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuanlydanhsachtaikhoan";
            this.Text = "FormQuanlydanhsachtaikhoan";
            this.Load += new System.EventHandler(this.FormQuanlydanhsachtaikhoan_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsachtaikhoan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDanhsachtaikhoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTotalAcc;
        private System.Windows.Forms.Button btnAdminAcc;
        private System.Windows.Forms.Button btnUserAcc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtLoctukhoa;
        private System.Windows.Forms.ComboBox cbLocbophan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}