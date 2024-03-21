namespace Vietinak_Kho.f_PPC
{
    partial class FormDanhsachPO
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PO Done");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Po Pending");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("PO Waiting for confirmation");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhsachPO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txttotalpo = new System.Windows.Forms.Button();
            this.txtpodone = new System.Windows.Forms.Button();
            this.txtpopending = new System.Windows.Forms.Button();
            this.txtponoinvoice = new System.Windows.Forms.Button();
            this.txtpowaitconfirm = new System.Windows.Forms.Button();
            this.groupBoxDulieu = new System.Windows.Forms.GroupBox();
            this.treeViewPO = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTaoPo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxDulieu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxDulieu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.50394F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.49606F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 576);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "`";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.82353F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.17647F));
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(935, 69);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtpTo);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpFrom);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 63);
            this.panel4.TabIndex = 3;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(59, 35);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(106, 20);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tới tháng";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(59, 9);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(106, 20);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ tháng";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.txttotalpo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtpodone, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtpopending, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtponoinvoice, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtpowaitconfirm, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(179, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(753, 63);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // txttotalpo
            // 
            this.txttotalpo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txttotalpo.FlatAppearance.BorderSize = 0;
            this.txttotalpo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txttotalpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txttotalpo.ForeColor = System.Drawing.Color.White;
            this.txttotalpo.Location = new System.Drawing.Point(3, 3);
            this.txttotalpo.Name = "txttotalpo";
            this.txttotalpo.Size = new System.Drawing.Size(144, 57);
            this.txttotalpo.TabIndex = 0;
            this.txttotalpo.Text = "Total PO : 0";
            this.txttotalpo.UseVisualStyleBackColor = false;
            // 
            // txtpodone
            // 
            this.txtpodone.BackColor = System.Drawing.Color.Green;
            this.txtpodone.FlatAppearance.BorderSize = 0;
            this.txtpodone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtpodone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtpodone.ForeColor = System.Drawing.Color.White;
            this.txtpodone.Location = new System.Drawing.Point(153, 3);
            this.txtpodone.Name = "txtpodone";
            this.txtpodone.Size = new System.Drawing.Size(144, 57);
            this.txtpodone.TabIndex = 0;
            this.txtpodone.Text = "Done: 0";
            this.txtpodone.UseVisualStyleBackColor = false;
            // 
            // txtpopending
            // 
            this.txtpopending.BackColor = System.Drawing.Color.Orange;
            this.txtpopending.FlatAppearance.BorderSize = 0;
            this.txtpopending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtpopending.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtpopending.ForeColor = System.Drawing.Color.Black;
            this.txtpopending.Location = new System.Drawing.Point(303, 3);
            this.txtpopending.Name = "txtpopending";
            this.txtpopending.Size = new System.Drawing.Size(144, 57);
            this.txtpopending.TabIndex = 0;
            this.txtpopending.Text = "Pending : 0";
            this.txtpopending.UseVisualStyleBackColor = false;
            // 
            // txtponoinvoice
            // 
            this.txtponoinvoice.BackColor = System.Drawing.Color.IndianRed;
            this.txtponoinvoice.FlatAppearance.BorderSize = 0;
            this.txtponoinvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtponoinvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtponoinvoice.ForeColor = System.Drawing.Color.White;
            this.txtponoinvoice.Location = new System.Drawing.Point(453, 3);
            this.txtponoinvoice.Name = "txtponoinvoice";
            this.txtponoinvoice.Size = new System.Drawing.Size(144, 57);
            this.txtponoinvoice.TabIndex = 0;
            this.txtponoinvoice.Text = "No Invoice : 0";
            this.txtponoinvoice.UseVisualStyleBackColor = false;
            // 
            // txtpowaitconfirm
            // 
            this.txtpowaitconfirm.BackColor = System.Drawing.Color.Red;
            this.txtpowaitconfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpowaitconfirm.FlatAppearance.BorderSize = 0;
            this.txtpowaitconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtpowaitconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtpowaitconfirm.ForeColor = System.Drawing.Color.White;
            this.txtpowaitconfirm.Location = new System.Drawing.Point(603, 3);
            this.txtpowaitconfirm.Name = "txtpowaitconfirm";
            this.txtpowaitconfirm.Size = new System.Drawing.Size(147, 57);
            this.txtpowaitconfirm.TabIndex = 0;
            this.txtpowaitconfirm.Text = "Waiting for confirmation : 0";
            this.txtpowaitconfirm.UseVisualStyleBackColor = false;
            // 
            // groupBoxDulieu
            // 
            this.groupBoxDulieu.Controls.Add(this.treeViewPO);
            this.groupBoxDulieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDulieu.Location = new System.Drawing.Point(3, 97);
            this.groupBoxDulieu.Name = "groupBoxDulieu";
            this.groupBoxDulieu.Size = new System.Drawing.Size(941, 408);
            this.groupBoxDulieu.TabIndex = 0;
            this.groupBoxDulieu.TabStop = false;
            this.groupBoxDulieu.Text = "Danh sách PO";
            // 
            // treeViewPO
            // 
            this.treeViewPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPO.Location = new System.Drawing.Point(3, 16);
            this.treeViewPO.Name = "treeViewPO";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode1.ForeColor = System.Drawing.Color.White;
            treeNode1.Name = "Nodepodone";
            treeNode1.Text = "PO Done";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            treeNode2.ForeColor = System.Drawing.Color.Black;
            treeNode2.Name = "Nodepopending";
            treeNode2.Text = "Po Pending";
            treeNode3.BackColor = System.Drawing.Color.Red;
            treeNode3.ForeColor = System.Drawing.Color.White;
            treeNode3.Name = "Nodepowaitingconfirm";
            treeNode3.Text = "PO Waiting for confirmation";
            this.treeViewPO.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeViewPO.Size = new System.Drawing.Size(935, 389);
            this.treeViewPO.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 511);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(941, 62);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(935, 43);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTaoPo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(935, 43);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLoc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(625, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 37);
            this.panel2.TabIndex = 2;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(92, 9);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(212, 20);
            this.txtLoc.TabIndex = 2;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm dữ liệu";
            // 
            // btnTaoPo
            // 
            this.btnTaoPo.BackColor = System.Drawing.Color.LightGreen;
            this.btnTaoPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaoPo.FlatAppearance.BorderSize = 0;
            this.btnTaoPo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPo.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoPo.Image")));
            this.btnTaoPo.Location = new System.Drawing.Point(3, 3);
            this.btnTaoPo.Name = "btnTaoPo";
            this.btnTaoPo.Size = new System.Drawing.Size(305, 37);
            this.btnTaoPo.TabIndex = 0;
            this.btnTaoPo.Text = "Tạo PO";
            this.btnTaoPo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoPo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoPo.UseVisualStyleBackColor = false;
            this.btnTaoPo.Click += new System.EventHandler(this.btnTaoPo_Click);
            // 
            // FormDanhsachPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 576);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDanhsachPO";
            this.Text = "FormDanhsachPO";
            this.Load += new System.EventHandler(this.FormDanhsachPO_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBoxDulieu.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxDulieu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnTaoPo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button txttotalpo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button txtpodone;
        private System.Windows.Forms.Button txtpopending;
        private System.Windows.Forms.Button txtponoinvoice;
        private System.Windows.Forms.Button txtpowaitconfirm;
        private System.Windows.Forms.TreeView treeViewPO;
    }
}