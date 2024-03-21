namespace Vietinak_Kho.f_PPC
{
    partial class FormChucnangPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChucnangPO));
            this.btnConfirmPO = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnQuanlyInvoice = new System.Windows.Forms.Button();
            this.btnXoaPO = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirmPO
            // 
            this.btnConfirmPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConfirmPO.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmPO.Image")));
            this.btnConfirmPO.Location = new System.Drawing.Point(145, 90);
            this.btnConfirmPO.Name = "btnConfirmPO";
            this.btnConfirmPO.Size = new System.Drawing.Size(136, 81);
            this.btnConfirmPO.TabIndex = 0;
            this.btnConfirmPO.Text = "Confirm PO";
            this.btnConfirmPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmPO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmPO.UseVisualStyleBackColor = false;
            this.btnConfirmPO.Click += new System.EventHandler(this.btnConfirmPO_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LimeGreen;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(3, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 81);
            this.button2.TabIndex = 0;
            this.button2.Text = "Xuất ra Excel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnQuanlyInvoice
            // 
            this.btnQuanlyInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQuanlyInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanlyInvoice.Image")));
            this.btnQuanlyInvoice.Location = new System.Drawing.Point(3, 3);
            this.btnQuanlyInvoice.Name = "btnQuanlyInvoice";
            this.btnQuanlyInvoice.Size = new System.Drawing.Size(136, 81);
            this.btnQuanlyInvoice.TabIndex = 0;
            this.btnQuanlyInvoice.Text = "Quản lý Invoice";
            this.btnQuanlyInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuanlyInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanlyInvoice.UseVisualStyleBackColor = false;
            this.btnQuanlyInvoice.Click += new System.EventHandler(this.btnQuanlyInvoice_Click);
            // 
            // btnXoaPO
            // 
            this.btnXoaPO.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoaPO.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPO.Image")));
            this.btnXoaPO.Location = new System.Drawing.Point(3, 177);
            this.btnXoaPO.Name = "btnXoaPO";
            this.btnXoaPO.Size = new System.Drawing.Size(136, 81);
            this.btnXoaPO.TabIndex = 0;
            this.btnXoaPO.Text = "Xóa PO";
            this.btnXoaPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaPO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaPO.UseVisualStyleBackColor = false;
            this.btnXoaPO.Click += new System.EventHandler(this.btnXoaPO_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Goldenrod;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(145, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xem chi tiết";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnXoaPO, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirmPO, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnQuanlyInvoice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FormChucnangPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormChucnangPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn chức năng";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormChucnangPO_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmPO;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnQuanlyInvoice;
        private System.Windows.Forms.Button btnXoaPO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}