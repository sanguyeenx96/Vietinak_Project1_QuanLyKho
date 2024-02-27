namespace Vietinak_Kho
{
    partial class FormTaikhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaikhoan));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTaikhoancuaban = new System.Windows.Forms.ToolStripButton();
            this.btnQuanlydanhsachtaikhoan = new System.Windows.Forms.ToolStripButton();
            this.btnSuathongtintaikhoan = new System.Windows.Forms.ToolStripButton();
            this.btnTaotaikhoanmoi = new System.Windows.Forms.ToolStripButton();
            this.panelTaikhoan_Tong = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTaikhoancuaban,
            this.btnQuanlydanhsachtaikhoan,
            this.btnSuathongtintaikhoan,
            this.btnTaotaikhoanmoi});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(817, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTaikhoancuaban
            // 
            this.btnTaikhoancuaban.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaikhoancuaban.Image = ((System.Drawing.Image)(resources.GetObject("btnTaikhoancuaban.Image")));
            this.btnTaikhoancuaban.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaikhoancuaban.Name = "btnTaikhoancuaban";
            this.btnTaikhoancuaban.Size = new System.Drawing.Size(106, 22);
            this.btnTaikhoancuaban.Text = "Tài khoản của bạn";
            this.btnTaikhoancuaban.Click += new System.EventHandler(this.btnTaikhoancuaban_Click);
            // 
            // btnQuanlydanhsachtaikhoan
            // 
            this.btnQuanlydanhsachtaikhoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuanlydanhsachtaikhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanlydanhsachtaikhoan.Image")));
            this.btnQuanlydanhsachtaikhoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuanlydanhsachtaikhoan.Name = "btnQuanlydanhsachtaikhoan";
            this.btnQuanlydanhsachtaikhoan.Size = new System.Drawing.Size(161, 22);
            this.btnQuanlydanhsachtaikhoan.Text = "Quản lý danh sách tài khoản";
            this.btnQuanlydanhsachtaikhoan.Click += new System.EventHandler(this.btnQuanlydanhsachtaikhoan_Click);
            // 
            // btnSuathongtintaikhoan
            // 
            this.btnSuathongtintaikhoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSuathongtintaikhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnSuathongtintaikhoan.Image")));
            this.btnSuathongtintaikhoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuathongtintaikhoan.Name = "btnSuathongtintaikhoan";
            this.btnSuathongtintaikhoan.Size = new System.Drawing.Size(134, 22);
            this.btnSuathongtintaikhoan.Text = "Sửa thông tin tài khoản";
            this.btnSuathongtintaikhoan.Click += new System.EventHandler(this.btnSuathongtintaikhoan_Click);
            // 
            // btnTaotaikhoanmoi
            // 
            this.btnTaotaikhoanmoi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaotaikhoanmoi.Image = ((System.Drawing.Image)(resources.GetObject("btnTaotaikhoanmoi.Image")));
            this.btnTaotaikhoanmoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaotaikhoanmoi.Name = "btnTaotaikhoanmoi";
            this.btnTaotaikhoanmoi.Size = new System.Drawing.Size(106, 22);
            this.btnTaotaikhoanmoi.Text = "Tạo tài khoản mới";
            this.btnTaotaikhoanmoi.Click += new System.EventHandler(this.btnTaotaikhoanmoi_Click);
            // 
            // panelTaikhoan_Tong
            // 
            this.panelTaikhoan_Tong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaikhoan_Tong.Location = new System.Drawing.Point(0, 25);
            this.panelTaikhoan_Tong.Name = "panelTaikhoan_Tong";
            this.panelTaikhoan_Tong.Size = new System.Drawing.Size(817, 425);
            this.panelTaikhoan_Tong.TabIndex = 1;
            // 
            // FormTaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.panelTaikhoan_Tong);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTaikhoan";
            this.Text = "FormTaikhoan";
            this.Load += new System.EventHandler(this.FormTaikhoan_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnQuanlydanhsachtaikhoan;
        private System.Windows.Forms.ToolStripButton btnTaikhoancuaban;
        private System.Windows.Forms.Panel panelTaikhoan_Tong;
        private System.Windows.Forms.ToolStripButton btnSuathongtintaikhoan;
        private System.Windows.Forms.ToolStripButton btnTaotaikhoanmoi;
    }
}