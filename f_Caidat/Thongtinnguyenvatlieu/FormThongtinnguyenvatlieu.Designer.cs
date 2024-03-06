namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    partial class FormThongtinnguyenvatlieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongtinnguyenvatlieu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhsachnguyenvatlieu = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLocdonvi = new System.Windows.Forms.ComboBox();
            this.cbLocdiengiai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoctukhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThemnguyenvatlieu = new System.Windows.Forms.Button();
            this.btnSuanguyenvatlieu = new System.Windows.Forms.Button();
            this.btnXoanguyenvatlieu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsachnguyenvatlieu)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 576);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.9375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.95139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 576);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhsachnguyenvatlieu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nguyên vật liệu";
            // 
            // dgvDanhsachnguyenvatlieu
            // 
            this.dgvDanhsachnguyenvatlieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhsachnguyenvatlieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhsachnguyenvatlieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhsachnguyenvatlieu.Location = new System.Drawing.Point(3, 16);
            this.dgvDanhsachnguyenvatlieu.Name = "dgvDanhsachnguyenvatlieu";
            this.dgvDanhsachnguyenvatlieu.ReadOnly = true;
            this.dgvDanhsachnguyenvatlieu.Size = new System.Drawing.Size(935, 424);
            this.dgvDanhsachnguyenvatlieu.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.cbLocdonvi);
            this.groupBox2.Controls.Add(this.cbLocdiengiai);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLoctukhoa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(941, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc dữ liệu";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.txtCount);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(751, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 42);
            this.panel3.TabIndex = 3;
            // 
            // txtCount
            // 
            this.txtCount.AutoSize = true;
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(138, 9);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(0, 24);
            this.txtCount.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số lượng nguyên vật liệu";
            // 
            // cbLocdonvi
            // 
            this.cbLocdonvi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocdonvi.FormattingEnabled = true;
            this.cbLocdonvi.Location = new System.Drawing.Point(486, 22);
            this.cbLocdonvi.Name = "cbLocdonvi";
            this.cbLocdonvi.Size = new System.Drawing.Size(121, 21);
            this.cbLocdonvi.TabIndex = 2;
            this.cbLocdonvi.SelectedIndexChanged += new System.EventHandler(this.cbLocdonvi_SelectedIndexChanged);
            // 
            // cbLocdiengiai
            // 
            this.cbLocdiengiai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocdiengiai.FormattingEnabled = true;
            this.cbLocdiengiai.Location = new System.Drawing.Point(284, 21);
            this.cbLocdiengiai.Name = "cbLocdiengiai";
            this.cbLocdiengiai.Size = new System.Drawing.Size(121, 21);
            this.cbLocdiengiai.TabIndex = 2;
            this.cbLocdiengiai.SelectedIndexChanged += new System.EventHandler(this.cbLocdiengiai_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lọc đơn vị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lọc diễn giải";
            // 
            // txtLoctukhoa
            // 
            this.txtLoctukhoa.Location = new System.Drawing.Point(79, 22);
            this.txtLoctukhoa.Name = "txtLoctukhoa";
            this.txtLoctukhoa.Size = new System.Drawing.Size(121, 20);
            this.txtLoctukhoa.TabIndex = 1;
            this.txtLoctukhoa.TextChanged += new System.EventHandler(this.txtLoctukhoa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lọc từ khóa";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 515);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(941, 58);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 39);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnThemnguyenvatlieu, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSuanguyenvatlieu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXoanguyenvatlieu, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(525, 30);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnThemnguyenvatlieu
            // 
            this.btnThemnguyenvatlieu.BackColor = System.Drawing.Color.LightGreen;
            this.btnThemnguyenvatlieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemnguyenvatlieu.FlatAppearance.BorderSize = 0;
            this.btnThemnguyenvatlieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemnguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemnguyenvatlieu.Image")));
            this.btnThemnguyenvatlieu.Location = new System.Drawing.Point(3, 3);
            this.btnThemnguyenvatlieu.Name = "btnThemnguyenvatlieu";
            this.btnThemnguyenvatlieu.Size = new System.Drawing.Size(169, 24);
            this.btnThemnguyenvatlieu.TabIndex = 0;
            this.btnThemnguyenvatlieu.Text = "Thêm nguyên vật liệu";
            this.btnThemnguyenvatlieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemnguyenvatlieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemnguyenvatlieu.UseVisualStyleBackColor = false;
            this.btnThemnguyenvatlieu.Click += new System.EventHandler(this.btnThemnguyenvatlieu_Click);
            // 
            // btnSuanguyenvatlieu
            // 
            this.btnSuanguyenvatlieu.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuanguyenvatlieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuanguyenvatlieu.FlatAppearance.BorderSize = 0;
            this.btnSuanguyenvatlieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuanguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnSuanguyenvatlieu.Image")));
            this.btnSuanguyenvatlieu.Location = new System.Drawing.Point(178, 3);
            this.btnSuanguyenvatlieu.Name = "btnSuanguyenvatlieu";
            this.btnSuanguyenvatlieu.Size = new System.Drawing.Size(169, 24);
            this.btnSuanguyenvatlieu.TabIndex = 0;
            this.btnSuanguyenvatlieu.Text = "Sửa nguyên vật liệu";
            this.btnSuanguyenvatlieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuanguyenvatlieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuanguyenvatlieu.UseVisualStyleBackColor = false;
            this.btnSuanguyenvatlieu.Click += new System.EventHandler(this.btnSuanguyenvatlieu_Click);
            // 
            // btnXoanguyenvatlieu
            // 
            this.btnXoanguyenvatlieu.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoanguyenvatlieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoanguyenvatlieu.FlatAppearance.BorderSize = 0;
            this.btnXoanguyenvatlieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoanguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoanguyenvatlieu.Image")));
            this.btnXoanguyenvatlieu.Location = new System.Drawing.Point(353, 3);
            this.btnXoanguyenvatlieu.Name = "btnXoanguyenvatlieu";
            this.btnXoanguyenvatlieu.Size = new System.Drawing.Size(169, 24);
            this.btnXoanguyenvatlieu.TabIndex = 0;
            this.btnXoanguyenvatlieu.Text = "Xóa nguyên vật liệu";
            this.btnXoanguyenvatlieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoanguyenvatlieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoanguyenvatlieu.UseVisualStyleBackColor = false;
            this.btnXoanguyenvatlieu.Click += new System.EventHandler(this.btnXoanguyenvatlieu_Click);
            // 
            // FormThongtinnguyenvatlieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 576);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongtinnguyenvatlieu";
            this.Text = "FormThongtinnguyenvatlieu";
            this.Load += new System.EventHandler(this.FormThongtinnguyenvatlieu_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsachnguyenvatlieu)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhsachnguyenvatlieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoctukhoa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnThemnguyenvatlieu;
        private System.Windows.Forms.Button btnSuanguyenvatlieu;
        private System.Windows.Forms.Button btnXoanguyenvatlieu;
        private System.Windows.Forms.ComboBox cbLocdiengiai;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLocdonvi;
        private System.Windows.Forms.Label label4;
    }
}