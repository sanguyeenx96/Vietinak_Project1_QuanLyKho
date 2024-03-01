namespace Vietinak_Kho
{
    partial class FormCaidat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCaidat));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThongtinnguyenvatlieu = new System.Windows.Forms.ToolStripButton();
            this.btnBophanchucvu = new System.Windows.Forms.ToolStripButton();
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
            this.panel1.Size = new System.Drawing.Size(817, 450);
            this.panel1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(817, 425);
            this.panelMain.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThongtinnguyenvatlieu,
            this.btnBophanchucvu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(817, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThongtinnguyenvatlieu
            // 
            this.btnThongtinnguyenvatlieu.Image = ((System.Drawing.Image)(resources.GetObject("btnThongtinnguyenvatlieu.Image")));
            this.btnThongtinnguyenvatlieu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThongtinnguyenvatlieu.Name = "btnThongtinnguyenvatlieu";
            this.btnThongtinnguyenvatlieu.Size = new System.Drawing.Size(162, 22);
            this.btnThongtinnguyenvatlieu.Text = "Thông tin nguyên vật liệu";
            this.btnThongtinnguyenvatlieu.Click += new System.EventHandler(this.btnThongtinnguyenvatlieu_Click);
            // 
            // btnBophanchucvu
            // 
            this.btnBophanchucvu.Image = ((System.Drawing.Image)(resources.GetObject("btnBophanchucvu.Image")));
            this.btnBophanchucvu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBophanchucvu.Name = "btnBophanchucvu";
            this.btnBophanchucvu.Size = new System.Drawing.Size(131, 22);
            this.btnBophanchucvu.Text = "Bộ phận và chức vụ";
            this.btnBophanchucvu.Click += new System.EventHandler(this.btnBophanchucvu_Click);
            // 
            // FormCaidat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCaidat";
            this.Text = "FormCaidat";
            this.Load += new System.EventHandler(this.FormCaidat_Load);
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
        private System.Windows.Forms.ToolStripButton btnBophanchucvu;
        private System.Windows.Forms.ToolStripButton btnThongtinnguyenvatlieu;
    }
}