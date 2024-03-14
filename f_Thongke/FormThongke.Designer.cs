namespace Vietinak_Kho.f_Khohang
{
    partial class FormThongke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongke));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLichsunhap = new System.Windows.Forms.ToolStripButton();
            this.btnLichsuxuat = new System.Windows.Forms.ToolStripButton();
            this.btnDanhsachvattu = new System.Windows.Forms.ToolStripButton();
            this.panelChinh = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanhsachvattu,
            this.btnLichsunhap,
            this.btnLichsuxuat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(947, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLichsunhap
            // 
            this.btnLichsunhap.Image = ((System.Drawing.Image)(resources.GetObject("btnLichsunhap.Image")));
            this.btnLichsunhap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLichsunhap.Name = "btnLichsunhap";
            this.btnLichsunhap.Size = new System.Drawing.Size(97, 22);
            this.btnLichsunhap.Text = "Lịch sử nhập ";
            this.btnLichsunhap.Click += new System.EventHandler(this.btnLichsunhap_Click);
            // 
            // btnLichsuxuat
            // 
            this.btnLichsuxuat.Image = ((System.Drawing.Image)(resources.GetObject("btnLichsuxuat.Image")));
            this.btnLichsuxuat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLichsuxuat.Name = "btnLichsuxuat";
            this.btnLichsuxuat.Size = new System.Drawing.Size(93, 22);
            this.btnLichsuxuat.Text = "Lịch sử xuất ";
            this.btnLichsuxuat.Click += new System.EventHandler(this.btnLichsuxuat_Click);
            // 
            // btnDanhsachvattu
            // 
            this.btnDanhsachvattu.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhsachvattu.Image")));
            this.btnDanhsachvattu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDanhsachvattu.Name = "btnDanhsachvattu";
            this.btnDanhsachvattu.Size = new System.Drawing.Size(115, 22);
            this.btnDanhsachvattu.Text = "Danh sách vật tư";
            this.btnDanhsachvattu.Click += new System.EventHandler(this.btnDanhsachvattu_Click);
            // 
            // panelChinh
            // 
            this.panelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChinh.Location = new System.Drawing.Point(0, 25);
            this.panelChinh.Name = "panelChinh";
            this.panelChinh.Size = new System.Drawing.Size(947, 576);
            this.panelChinh.TabIndex = 1;
            // 
            // FormThongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 601);
            this.Controls.Add(this.panelChinh);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongke";
            this.Text = "FormKhohang";
            this.Load += new System.EventHandler(this.FormThongke_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDanhsachvattu;
        private System.Windows.Forms.ToolStripButton btnLichsunhap;
        private System.Windows.Forms.ToolStripButton btnLichsuxuat;
        private System.Windows.Forms.Panel panelChinh;
    }
}