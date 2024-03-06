namespace Vietinak_Kho.f_Caidat.Thongtinnguyenvatlieu
{
    partial class FormDanhsachnguyenvatlieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhsachnguyenvatlieu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThemnguyenvatlieu = new System.Windows.Forms.Button();
            this.btnXoanguyenvatlieu = new System.Windows.Forms.Button();
            this.btnSuanguyenvatlieu = new System.Windows.Forms.Button();
            this.btnNhaptuexcel = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 576);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 55);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(947, 481);
            this.panel4.TabIndex = 3;
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(941, 475);
            this.dgv.TabIndex = 0;
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.txtLoc);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(947, 55);
            this.panel3.TabIndex = 2;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(77, 18);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(317, 20);
            this.txtLoc.TabIndex = 1;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lọc dữ liệu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 536);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 40);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnThemnguyenvatlieu, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXoanguyenvatlieu, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSuanguyenvatlieu, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNhaptuexcel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(561, 30);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnThemnguyenvatlieu
            // 
            this.btnThemnguyenvatlieu.BackColor = System.Drawing.Color.LightGreen;
            this.btnThemnguyenvatlieu.FlatAppearance.BorderSize = 0;
            this.btnThemnguyenvatlieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemnguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemnguyenvatlieu.Image")));
            this.btnThemnguyenvatlieu.Location = new System.Drawing.Point(3, 3);
            this.btnThemnguyenvatlieu.Name = "btnThemnguyenvatlieu";
            this.btnThemnguyenvatlieu.Size = new System.Drawing.Size(134, 24);
            this.btnThemnguyenvatlieu.TabIndex = 0;
            this.btnThemnguyenvatlieu.Text = "Thêm nguyên vật liệu";
            this.btnThemnguyenvatlieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemnguyenvatlieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemnguyenvatlieu.UseVisualStyleBackColor = false;
            this.btnThemnguyenvatlieu.Click += new System.EventHandler(this.btnThemnguyenvatlieu_Click);
            // 
            // btnXoanguyenvatlieu
            // 
            this.btnXoanguyenvatlieu.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoanguyenvatlieu.FlatAppearance.BorderSize = 0;
            this.btnXoanguyenvatlieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoanguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoanguyenvatlieu.Image")));
            this.btnXoanguyenvatlieu.Location = new System.Drawing.Point(423, 3);
            this.btnXoanguyenvatlieu.Name = "btnXoanguyenvatlieu";
            this.btnXoanguyenvatlieu.Size = new System.Drawing.Size(135, 24);
            this.btnXoanguyenvatlieu.TabIndex = 0;
            this.btnXoanguyenvatlieu.Text = "Xóa nguyên vật liệu";
            this.btnXoanguyenvatlieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoanguyenvatlieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoanguyenvatlieu.UseVisualStyleBackColor = false;
            this.btnXoanguyenvatlieu.Click += new System.EventHandler(this.btnXoanguyenvatlieu_Click);
            // 
            // btnSuanguyenvatlieu
            // 
            this.btnSuanguyenvatlieu.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuanguyenvatlieu.FlatAppearance.BorderSize = 0;
            this.btnSuanguyenvatlieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuanguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnSuanguyenvatlieu.Image")));
            this.btnSuanguyenvatlieu.Location = new System.Drawing.Point(283, 3);
            this.btnSuanguyenvatlieu.Name = "btnSuanguyenvatlieu";
            this.btnSuanguyenvatlieu.Size = new System.Drawing.Size(134, 24);
            this.btnSuanguyenvatlieu.TabIndex = 0;
            this.btnSuanguyenvatlieu.Text = "Sửa nguyên vật liệu";
            this.btnSuanguyenvatlieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuanguyenvatlieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuanguyenvatlieu.UseVisualStyleBackColor = false;
            this.btnSuanguyenvatlieu.Click += new System.EventHandler(this.btnSuanguyenvatlieu_Click);
            // 
            // btnNhaptuexcel
            // 
            this.btnNhaptuexcel.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNhaptuexcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNhaptuexcel.Enabled = false;
            this.btnNhaptuexcel.FlatAppearance.BorderSize = 0;
            this.btnNhaptuexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaptuexcel.ForeColor = System.Drawing.Color.Black;
            this.btnNhaptuexcel.Image = ((System.Drawing.Image)(resources.GetObject("btnNhaptuexcel.Image")));
            this.btnNhaptuexcel.Location = new System.Drawing.Point(143, 3);
            this.btnNhaptuexcel.Name = "btnNhaptuexcel";
            this.btnNhaptuexcel.Size = new System.Drawing.Size(134, 24);
            this.btnNhaptuexcel.TabIndex = 0;
            this.btnNhaptuexcel.Text = "Nhập từ file Excel";
            this.btnNhaptuexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhaptuexcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhaptuexcel.UseVisualStyleBackColor = false;
            this.btnNhaptuexcel.Click += new System.EventHandler(this.btnNhaptuexcel_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Info;
            this.panel5.Controls.Add(this.txtCount);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(757, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(187, 42);
            this.panel5.TabIndex = 4;
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
            // FormDanhsachnguyenvatlieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 576);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDanhsachnguyenvatlieu";
            this.Text = "FormDanhsachnguyenvatlieu";
            this.Load += new System.EventHandler(this.FormDanhsachnguyenvatlieu_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnThemnguyenvatlieu;
        private System.Windows.Forms.Button btnSuanguyenvatlieu;
        private System.Windows.Forms.Button btnXoanguyenvatlieu;
        private System.Windows.Forms.Button btnNhaptuexcel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.Label label3;
    }
}