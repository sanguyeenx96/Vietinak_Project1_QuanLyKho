namespace Vietinak_Kho
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelDate = new System.Windows.Forms.Panel();
            this.txtBophan = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtClock = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTong = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnTrangchinh = new System.Windows.Forms.Button();
            this.btnTaikhoan = new System.Windows.Forms.Button();
            this.btnDonhang = new System.Windows.Forms.Button();
            this.btnDanhsach = new System.Windows.Forms.Button();
            this.btnCaidat = new System.Windows.Forms.Button();
            this.btnThongke = new System.Windows.Forms.Button();
            this.btnThongbao = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.panelDate);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(905, 30);
            this.panelHeader.TabIndex = 0;
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.txtRole);
            this.panelDate.Controls.Add(this.txtCode);
            this.panelDate.Controls.Add(this.txtBophan);
            this.panelDate.Controls.Add(this.txtHoten);
            this.panelDate.Controls.Add(this.label3);
            this.panelDate.Controls.Add(this.label4);
            this.panelDate.Controls.Add(this.label2);
            this.panelDate.Controls.Add(this.label1);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDate.Location = new System.Drawing.Point(419, 0);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(486, 30);
            this.panelDate.TabIndex = 3;
            // 
            // txtBophan
            // 
            this.txtBophan.AutoSize = true;
            this.txtBophan.Location = new System.Drawing.Point(250, 9);
            this.txtBophan.Name = "txtBophan";
            this.txtBophan.Size = new System.Drawing.Size(31, 13);
            this.txtBophan.TabIndex = 3;
            this.txtBophan.Text = "____";
            // 
            // txtHoten
            // 
            this.txtHoten.AutoSize = true;
            this.txtHoten.Location = new System.Drawing.Point(75, 9);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(85, 13);
            this.txtHoten.TabIndex = 3;
            this.txtHoten.Text = "____ ____ ____";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(211, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dept.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(31, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(400, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Role.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.BackColor = System.Drawing.Color.Transparent;
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Location = new System.Drawing.Point(58, 8);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(67, 13);
            this.txtDate.TabIndex = 1;
            this.txtDate.Text = "dd/MM/yyyy";
            // 
            // txtRole
            // 
            this.txtRole.AutoSize = true;
            this.txtRole.Location = new System.Drawing.Point(438, 9);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(31, 13);
            this.txtRole.TabIndex = 3;
            this.txtRole.Text = "____";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 30);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(302, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Code.";
            // 
            // txtCode
            // 
            this.txtCode.AutoSize = true;
            this.txtCode.Location = new System.Drawing.Point(343, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(31, 13);
            this.txtCode.TabIndex = 3;
            this.txtCode.Text = "____";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtClock);
            this.panel3.Controls.Add(this.txtDate);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(633, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 30);
            this.panel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(19, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Date.";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(152, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Clock.";
            // 
            // txtClock
            // 
            this.txtClock.AutoSize = true;
            this.txtClock.BackColor = System.Drawing.Color.Transparent;
            this.txtClock.ForeColor = System.Drawing.Color.Black;
            this.txtClock.Location = new System.Drawing.Point(195, 8);
            this.txtClock.Name = "txtClock";
            this.txtClock.Size = new System.Drawing.Size(51, 13);
            this.txtClock.TabIndex = 1;
            this.txtClock.Text = "hh:mm:ss";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 450);
            this.panel2.TabIndex = 2;
            // 
            // panelTong
            // 
            this.panelTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTong.Location = new System.Drawing.Point(88, 30);
            this.panelTong.Name = "panelTong";
            this.panelTong.Size = new System.Drawing.Size(817, 450);
            this.panelTong.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnThongbao);
            this.panel5.Controls.Add(this.btnThongke);
            this.panel5.Controls.Add(this.btnCaidat);
            this.panel5.Controls.Add(this.btnDanhsach);
            this.panel5.Controls.Add(this.btnDonhang);
            this.panel5.Controls.Add(this.btnTaikhoan);
            this.panel5.Controls.Add(this.btnTrangchinh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(88, 450);
            this.panel5.TabIndex = 0;
            // 
            // btnTrangchinh
            // 
            this.btnTrangchinh.BackColor = System.Drawing.Color.Transparent;
            this.btnTrangchinh.FlatAppearance.BorderSize = 0;
            this.btnTrangchinh.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTrangchinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangchinh.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangchinh.Image")));
            this.btnTrangchinh.Location = new System.Drawing.Point(3, 6);
            this.btnTrangchinh.Name = "btnTrangchinh";
            this.btnTrangchinh.Size = new System.Drawing.Size(82, 51);
            this.btnTrangchinh.TabIndex = 0;
            this.btnTrangchinh.Text = "Trang chính";
            this.btnTrangchinh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTrangchinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTrangchinh.UseVisualStyleBackColor = false;
            this.btnTrangchinh.Click += new System.EventHandler(this.btnTrangchinh_Click);
            // 
            // btnTaikhoan
            // 
            this.btnTaikhoan.BackColor = System.Drawing.Color.Transparent;
            this.btnTaikhoan.FlatAppearance.BorderSize = 0;
            this.btnTaikhoan.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTaikhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaikhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaikhoan.Image")));
            this.btnTaikhoan.Location = new System.Drawing.Point(3, 63);
            this.btnTaikhoan.Name = "btnTaikhoan";
            this.btnTaikhoan.Size = new System.Drawing.Size(82, 51);
            this.btnTaikhoan.TabIndex = 0;
            this.btnTaikhoan.Text = "Tài khoản";
            this.btnTaikhoan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTaikhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTaikhoan.UseVisualStyleBackColor = false;
            this.btnTaikhoan.Click += new System.EventHandler(this.btnTaikhoan_Click);
            // 
            // btnDonhang
            // 
            this.btnDonhang.BackColor = System.Drawing.Color.Transparent;
            this.btnDonhang.FlatAppearance.BorderSize = 0;
            this.btnDonhang.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDonhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonhang.Image = ((System.Drawing.Image)(resources.GetObject("btnDonhang.Image")));
            this.btnDonhang.Location = new System.Drawing.Point(3, 120);
            this.btnDonhang.Name = "btnDonhang";
            this.btnDonhang.Size = new System.Drawing.Size(82, 51);
            this.btnDonhang.TabIndex = 0;
            this.btnDonhang.Text = "Đơn hàng";
            this.btnDonhang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDonhang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDonhang.UseVisualStyleBackColor = false;
            this.btnDonhang.Click += new System.EventHandler(this.btnDonhang_Click);
            // 
            // btnDanhsach
            // 
            this.btnDanhsach.BackColor = System.Drawing.Color.Transparent;
            this.btnDanhsach.FlatAppearance.BorderSize = 0;
            this.btnDanhsach.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDanhsach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhsach.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhsach.Image")));
            this.btnDanhsach.Location = new System.Drawing.Point(3, 177);
            this.btnDanhsach.Name = "btnDanhsach";
            this.btnDanhsach.Size = new System.Drawing.Size(82, 51);
            this.btnDanhsach.TabIndex = 0;
            this.btnDanhsach.Text = "Danh sách";
            this.btnDanhsach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDanhsach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDanhsach.UseVisualStyleBackColor = false;
            this.btnDanhsach.Click += new System.EventHandler(this.btnDanhsach_Click);
            // 
            // btnCaidat
            // 
            this.btnCaidat.BackColor = System.Drawing.Color.Transparent;
            this.btnCaidat.FlatAppearance.BorderSize = 0;
            this.btnCaidat.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCaidat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaidat.Image = ((System.Drawing.Image)(resources.GetObject("btnCaidat.Image")));
            this.btnCaidat.Location = new System.Drawing.Point(3, 234);
            this.btnCaidat.Name = "btnCaidat";
            this.btnCaidat.Size = new System.Drawing.Size(82, 51);
            this.btnCaidat.TabIndex = 0;
            this.btnCaidat.Text = "Cài đặt";
            this.btnCaidat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCaidat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaidat.UseVisualStyleBackColor = false;
            this.btnCaidat.Click += new System.EventHandler(this.btnCaidat_Click);
            // 
            // btnThongke
            // 
            this.btnThongke.BackColor = System.Drawing.Color.Transparent;
            this.btnThongke.FlatAppearance.BorderSize = 0;
            this.btnThongke.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThongke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongke.Image = ((System.Drawing.Image)(resources.GetObject("btnThongke.Image")));
            this.btnThongke.Location = new System.Drawing.Point(3, 291);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(82, 51);
            this.btnThongke.TabIndex = 0;
            this.btnThongke.Text = "Thống kê";
            this.btnThongke.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThongke.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThongke.UseVisualStyleBackColor = false;
            // 
            // btnThongbao
            // 
            this.btnThongbao.BackColor = System.Drawing.Color.Transparent;
            this.btnThongbao.FlatAppearance.BorderSize = 0;
            this.btnThongbao.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThongbao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongbao.Image = ((System.Drawing.Image)(resources.GetObject("btnThongbao.Image")));
            this.btnThongbao.Location = new System.Drawing.Point(3, 348);
            this.btnThongbao.Name = "btnThongbao";
            this.btnThongbao.Size = new System.Drawing.Size(82, 51);
            this.btnThongbao.TabIndex = 0;
            this.btnThongbao.Text = "Thông báo";
            this.btnThongbao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThongbao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThongbao.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelTong);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý kho";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label txtHoten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtBophan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtClock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTong;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnTrangchinh;
        private System.Windows.Forms.Button btnTaikhoan;
        private System.Windows.Forms.Button btnDonhang;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.Button btnCaidat;
        private System.Windows.Forms.Button btnDanhsach;
        private System.Windows.Forms.Button btnThongbao;
    }
}

