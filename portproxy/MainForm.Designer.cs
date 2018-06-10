namespace portproxy
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listRules = new System.Windows.Forms.ListView();
            this.colDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colListenaddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colListenport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConnectaddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConnectport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConnectaddress = new System.Windows.Forms.Label();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.lblConnectport = new System.Windows.Forms.Label();
            this.lblListenport = new System.Windows.Forms.Label();
            this.lblListenaddres = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.txtListenaddress = new System.Windows.Forms.TextBox();
            this.txtListenport = new System.Windows.Forms.TextBox();
            this.txtConnectaddress = new System.Windows.Forms.TextBox();
            this.txtConnectport = new System.Windows.Forms.TextBox();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(741, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiExport});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(116, 22);
            this.tsmiImport.Text = "&Import";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(116, 22);
            this.tsmiExport.Text = "&Export";
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(111, 22);
            this.tsmiAbout.Text = "&About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listRules);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 246);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port proxy rules";
            // 
            // listRules
            // 
            this.listRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDirection,
            this.colListenaddress,
            this.colListenport,
            this.colConnectaddress,
            this.colConnectport,
            this.colProtocol});
            this.listRules.FullRowSelect = true;
            this.listRules.Location = new System.Drawing.Point(9, 20);
            this.listRules.Name = "listRules";
            this.listRules.Size = new System.Drawing.Size(694, 175);
            this.listRules.TabIndex = 1;
            this.listRules.UseCompatibleStateImageBehavior = false;
            this.listRules.View = System.Windows.Forms.View.Details;
            this.listRules.SelectedIndexChanged += new System.EventHandler(this.listRules_SelectedIndexChanged);
            // 
            // colDirection
            // 
            this.colDirection.Text = "Direction";
            this.colDirection.Width = 93;
            // 
            // colListenaddress
            // 
            this.colListenaddress.Text = "Listen address";
            this.colListenaddress.Width = 161;
            // 
            // colListenport
            // 
            this.colListenport.Text = "Listen port";
            this.colListenport.Width = 86;
            // 
            // colConnectaddress
            // 
            this.colConnectaddress.Text = "Connect address";
            this.colConnectaddress.Width = 164;
            // 
            // colConnectport
            // 
            this.colConnectport.Text = "Connect port";
            this.colConnectport.Width = 91;
            // 
            // colProtocol
            // 
            this.colProtocol.Text = "Protocol";
            this.colProtocol.Width = 93;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(91, 210);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Refresh";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(9, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblConnectaddress);
            this.groupBox1.Controls.Add(this.lblProtocol);
            this.groupBox1.Controls.Add(this.lblConnectport);
            this.groupBox1.Controls.Add(this.lblListenport);
            this.groupBox1.Controls.Add(this.lblListenaddres);
            this.groupBox1.Controls.Add(this.lblDirection);
            this.groupBox1.Controls.Add(this.cmbDirection);
            this.groupBox1.Controls.Add(this.txtListenaddress);
            this.groupBox1.Controls.Add(this.txtListenport);
            this.groupBox1.Controls.Add(this.txtConnectaddress);
            this.groupBox1.Controls.Add(this.txtConnectport);
            this.groupBox1.Controls.Add(this.cmbProtocol);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(13, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New proxy rule";
            // 
            // lblConnectaddress
            // 
            this.lblConnectaddress.AutoSize = true;
            this.lblConnectaddress.Location = new System.Drawing.Point(301, 20);
            this.lblConnectaddress.Name = "lblConnectaddress";
            this.lblConnectaddress.Size = new System.Drawing.Size(95, 12);
            this.lblConnectaddress.TabIndex = 1;
            this.lblConnectaddress.Text = "Connect address";
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(494, 20);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(53, 12);
            this.lblProtocol.TabIndex = 1;
            this.lblProtocol.Text = "Protocol";
            // 
            // lblConnectport
            // 
            this.lblConnectport.AutoSize = true;
            this.lblConnectport.Location = new System.Drawing.Point(411, 20);
            this.lblConnectport.Name = "lblConnectport";
            this.lblConnectport.Size = new System.Drawing.Size(77, 12);
            this.lblConnectport.TabIndex = 1;
            this.lblConnectport.Text = "Connect port";
            // 
            // lblListenport
            // 
            this.lblListenport.AutoSize = true;
            this.lblListenport.Location = new System.Drawing.Point(216, 20);
            this.lblListenport.Name = "lblListenport";
            this.lblListenport.Size = new System.Drawing.Size(71, 12);
            this.lblListenport.TabIndex = 1;
            this.lblListenport.Text = "Listen port";
            // 
            // lblListenaddres
            // 
            this.lblListenaddres.AutoSize = true;
            this.lblListenaddres.Location = new System.Drawing.Point(106, 20);
            this.lblListenaddres.Name = "lblListenaddres";
            this.lblListenaddres.Size = new System.Drawing.Size(89, 12);
            this.lblListenaddres.TabIndex = 1;
            this.lblListenaddres.Text = "Listen address";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(7, 20);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(59, 12);
            this.lblDirection.TabIndex = 0;
            this.lblDirection.Text = "Direction";
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "v4tov4",
            "v4tov6",
            "v6tov4",
            "v6tov6"});
            this.cmbDirection.Location = new System.Drawing.Point(7, 37);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(70, 20);
            this.cmbDirection.TabIndex = 2;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // txtListenaddress
            // 
            this.txtListenaddress.Location = new System.Drawing.Point(108, 37);
            this.txtListenaddress.Name = "txtListenaddress";
            this.txtListenaddress.Size = new System.Drawing.Size(104, 21);
            this.txtListenaddress.TabIndex = 2;
            this.txtListenaddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtListenaddress_Validating);
            // 
            // txtListenport
            // 
            this.txtListenport.Location = new System.Drawing.Point(218, 37);
            this.txtListenport.Name = "txtListenport";
            this.txtListenport.Size = new System.Drawing.Size(45, 21);
            this.txtListenport.TabIndex = 2;
            this.txtListenport.Validating += new System.ComponentModel.CancelEventHandler(this.txtListenport_Validating);
            // 
            // txtConnectaddress
            // 
            this.txtConnectaddress.Location = new System.Drawing.Point(303, 37);
            this.txtConnectaddress.Name = "txtConnectaddress";
            this.txtConnectaddress.Size = new System.Drawing.Size(104, 21);
            this.txtConnectaddress.TabIndex = 2;
            this.txtConnectaddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtConnectaddress_Validating);
            // 
            // txtConnectport
            // 
            this.txtConnectport.Location = new System.Drawing.Point(413, 37);
            this.txtConnectport.Name = "txtConnectport";
            this.txtConnectport.Size = new System.Drawing.Size(45, 21);
            this.txtConnectport.TabIndex = 2;
            this.txtConnectport.Validating += new System.ComponentModel.CancelEventHandler(this.txtConnectport_Validating);
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Items.AddRange(new object[] {
            "tcp"});
            this.cmbProtocol.Location = new System.Drawing.Point(496, 37);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(70, 20);
            this.cmbProtocol.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(600, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add / Change";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 371);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PortProxy";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listRules;
        private System.Windows.Forms.ColumnHeader colDirection;
        private System.Windows.Forms.ColumnHeader colListenaddress;
        private System.Windows.Forms.ColumnHeader colListenport;
        private System.Windows.Forms.ColumnHeader colConnectaddress;
        private System.Windows.Forms.ColumnHeader colConnectport;
        private System.Windows.Forms.ColumnHeader colProtocol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtConnectport;
        private System.Windows.Forms.TextBox txtListenport;
        private System.Windows.Forms.TextBox txtConnectaddress;
        private System.Windows.Forms.TextBox txtListenaddress;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label lblConnectaddress;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.Label lblConnectport;
        private System.Windows.Forms.Label lblListenport;
        private System.Windows.Forms.Label lblListenaddres;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

