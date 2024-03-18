namespace Vietinak_Kho.f_Thongke
{
    partial class FormThongtinsoluong
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxHienthixuathet = new System.Windows.Forms.CheckBox();
            this.dgvlotno = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlotno)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvlotno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 342);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLoc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.checkBoxHienthixuathet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 36);
            this.panel2.TabIndex = 2;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(751, 8);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(215, 20);
            this.txtLoc.TabIndex = 2;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(662, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm dữ liệu";
            // 
            // checkBoxHienthixuathet
            // 
            this.checkBoxHienthixuathet.AutoSize = true;
            this.checkBoxHienthixuathet.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.checkBoxHienthixuathet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.checkBoxHienthixuathet.ForeColor = System.Drawing.Color.White;
            this.checkBoxHienthixuathet.Location = new System.Drawing.Point(12, 8);
            this.checkBoxHienthixuathet.Name = "checkBoxHienthixuathet";
            this.checkBoxHienthixuathet.Size = new System.Drawing.Size(225, 21);
            this.checkBoxHienthixuathet.TabIndex = 0;
            this.checkBoxHienthixuathet.Text = "Hiển thị các Lot No. đã xuất hết";
            this.checkBoxHienthixuathet.UseVisualStyleBackColor = false;
            this.checkBoxHienthixuathet.CheckedChanged += new System.EventHandler(this.checkBoxHienthixuathet_CheckedChanged);
            // 
            // dgvlotno
            // 
            this.dgvlotno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvlotno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlotno.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvlotno.Location = new System.Drawing.Point(0, 0);
            this.dgvlotno.Name = "dgvlotno";
            this.dgvlotno.ReadOnly = true;
            this.dgvlotno.Size = new System.Drawing.Size(978, 300);
            this.dgvlotno.TabIndex = 1;
            // 
            // FormThongtinsoluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 342);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongtinsoluong";
            this.Text = "FormThongtinsoluong";
            this.Load += new System.EventHandler(this.FormThongtinsoluong_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlotno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvlotno;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxHienthixuathet;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label1;
    }
}