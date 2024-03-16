namespace Vietinak_Kho.f_PPC
{
    partial class FormPPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPPC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDanhsachPO = new System.Windows.Forms.ToolStripButton();
            this.btnThongtinNCC = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 601);
            this.panel1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(947, 576);
            this.panelMain.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanhsachPO,
            this.btnThongtinNCC});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(947, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDanhsachPO
            // 
            this.btnDanhsachPO.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhsachPO.Image")));
            this.btnDanhsachPO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDanhsachPO.Name = "btnDanhsachPO";
            this.btnDanhsachPO.Size = new System.Drawing.Size(101, 22);
            this.btnDanhsachPO.Text = "Danh sách PO";
            this.btnDanhsachPO.Click += new System.EventHandler(this.btnDanhsachPO_Click);
            // 
            // btnThongtinNCC
            // 
            this.btnThongtinNCC.Image = ((System.Drawing.Image)(resources.GetObject("btnThongtinNCC.Image")));
            this.btnThongtinNCC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThongtinNCC.Name = "btnThongtinNCC";
            this.btnThongtinNCC.Size = new System.Drawing.Size(162, 22);
            this.btnThongtinNCC.Text = "Danh sách thông tin NCC";
            this.btnThongtinNCC.Click += new System.EventHandler(this.btnThongtinNCC_Click);
            // 
            // FormPPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 601);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPPC";
            this.Text = "FormPPC";
            this.Load += new System.EventHandler(this.FormPPC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDanhsachPO;
        private System.Windows.Forms.ToolStripButton btnThongtinNCC;
    }
}