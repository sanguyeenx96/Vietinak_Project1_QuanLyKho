﻿namespace Vietinak_Kho.f_Nghiemthu
{
    partial class FormNghiemthu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNghiemthu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDanhsachchonghiemthu = new System.Windows.Forms.ToolStripButton();
            this.panelChinh = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelChinh);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 601);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanhsachchonghiemthu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(947, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDanhsachchonghiemthu
            // 
            this.btnDanhsachchonghiemthu.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhsachchonghiemthu.Image")));
            this.btnDanhsachchonghiemthu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDanhsachchonghiemthu.Name = "btnDanhsachchonghiemthu";
            this.btnDanhsachchonghiemthu.Size = new System.Drawing.Size(170, 22);
            this.btnDanhsachchonghiemthu.Text = "Danh sách chờ nghiệm thu";
            this.btnDanhsachchonghiemthu.Click += new System.EventHandler(this.btnDanhsachchonghiemthu_Click);
            // 
            // panelChinh
            // 
            this.panelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChinh.Location = new System.Drawing.Point(0, 25);
            this.panelChinh.Name = "panelChinh";
            this.panelChinh.Size = new System.Drawing.Size(947, 576);
            this.panelChinh.TabIndex = 1;
            // 
            // FormNghiemthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 601);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNghiemthu";
            this.Text = "FormDanhsachchonghiemthu";
            this.Load += new System.EventHandler(this.FormNghiemthu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDanhsachchonghiemthu;
        private System.Windows.Forms.Panel panelChinh;
    }
}