namespace DbTool.DbForms
{
    partial class FrmOpenDb
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbUseConnectStr = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNormal = new System.Windows.Forms.TabPage();
            this.tbConnectString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbDbName = new System.Windows.Forms.ComboBox();
            this.tbConnectName = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageMore = new System.Windows.Forms.TabPage();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageNormal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 404);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 36);
            this.panel1.TabIndex = 4;
            // 
            // cbUseConnectStr
            // 
            this.cbUseConnectStr.AutoSize = true;
            this.cbUseConnectStr.Location = new System.Drawing.Point(121, 345);
            this.cbUseConnectStr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUseConnectStr.Name = "cbUseConnectStr";
            this.cbUseConnectStr.Size = new System.Drawing.Size(111, 21);
            this.cbUseConnectStr.TabIndex = 0;
            this.cbUseConnectStr.Text = "使用连接字符串";
            this.toolTip.SetToolTip(this.cbUseConnectStr, "使用连接字符串连接数据库");
            this.cbUseConnectStr.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(235, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(323, 4);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 26);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.toolTip.SetToolTip(this.btnConnect, "连接数据库");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageNormal);
            this.tabControl1.Controls.Add(this.tabPageMore);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 404);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPageNormal
            // 
            this.tabPageNormal.Controls.Add(this.cbUseConnectStr);
            this.tabPageNormal.Controls.Add(this.tbConnectString);
            this.tabPageNormal.Controls.Add(this.label6);
            this.tabPageNormal.Controls.Add(this.btnSelect);
            this.tabPageNormal.Controls.Add(this.cbDbName);
            this.tabPageNormal.Controls.Add(this.tbConnectName);
            this.tabPageNormal.Controls.Add(this.tbPwd);
            this.tabPageNormal.Controls.Add(this.label1);
            this.tabPageNormal.Controls.Add(this.cbUserName);
            this.tabPageNormal.Controls.Add(this.label7);
            this.tabPageNormal.Controls.Add(this.label2);
            this.tabPageNormal.Controls.Add(this.label3);
            this.tabPageNormal.Controls.Add(this.cbServer);
            this.tabPageNormal.Controls.Add(this.label4);
            this.tabPageNormal.Controls.Add(this.cbDbType);
            this.tabPageNormal.Controls.Add(this.label5);
            this.tabPageNormal.Location = new System.Drawing.Point(4, 26);
            this.tabPageNormal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageNormal.Name = "tabPageNormal";
            this.tabPageNormal.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageNormal.Size = new System.Drawing.Size(409, 374);
            this.tabPageNormal.TabIndex = 0;
            this.tabPageNormal.Text = "一般";
            this.tabPageNormal.UseVisualStyleBackColor = true;
            // 
            // tbConnectString
            // 
            this.tbConnectString.Location = new System.Drawing.Point(121, 211);
            this.tbConnectString.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbConnectString.Multiline = true;
            this.tbConnectString.Name = "tbConnectString";
            this.tbConnectString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbConnectString.Size = new System.Drawing.Size(263, 128);
            this.tbConnectString.TabIndex = 6;
            this.tbConnectString.Text = "Data Source=192.168.96.80/ORCL;Persist Security Info=True;User ID=safecity;Passwo" +
    "rd=safecity";
            this.toolTip.SetToolTip(this.tbConnectString, "需要勾选使用连接字符串才有效");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "连接字符串：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(386, 40);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(17, 28);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "↓";
            this.toolTip.SetToolTip(this.btnSelect, "选择历史连接记录");
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // cbDbName
            // 
            this.cbDbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDbName.FormattingEnabled = true;
            this.cbDbName.Location = new System.Drawing.Point(121, 175);
            this.cbDbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDbName.Name = "cbDbName";
            this.cbDbName.Size = new System.Drawing.Size(263, 25);
            this.cbDbName.TabIndex = 5;
            this.toolTip.SetToolTip(this.cbDbName, "数据库名称或者实例名称");
            // 
            // tbConnectName
            // 
            this.tbConnectName.Location = new System.Drawing.Point(121, 8);
            this.tbConnectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbConnectName.Name = "tbConnectName";
            this.tbConnectName.Size = new System.Drawing.Size(263, 23);
            this.tbConnectName.TabIndex = 0;
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(121, 110);
            this.tbPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(263, 23);
            this.tbPwd.TabIndex = 3;
            this.toolTip.SetToolTip(this.tbPwd, "密码");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型：";
            // 
            // cbUserName
            // 
            this.cbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(121, 75);
            this.cbUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(263, 25);
            this.cbUserName.TabIndex = 2;
            this.toolTip.SetToolTip(this.cbUserName, "用户名");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "连接名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码：";
            // 
            // cbServer
            // 
            this.cbServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(121, 141);
            this.cbServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(263, 25);
            this.cbServer.TabIndex = 4;
            this.toolTip.SetToolTip(this.cbServer, "服务器名称或IP");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据库/实例：";
            // 
            // cbDbType
            // 
            this.cbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDbType.FormattingEnabled = true;
            this.cbDbType.Location = new System.Drawing.Point(121, 41);
            this.cbDbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDbType.Name = "cbDbType";
            this.cbDbType.Size = new System.Drawing.Size(263, 25);
            this.cbDbType.TabIndex = 1;
            this.toolTip.SetToolTip(this.cbDbType, "需连接的数据库类型");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "服务器：";
            // 
            // tabPageMore
            // 
            this.tabPageMore.Location = new System.Drawing.Point(4, 26);
            this.tabPageMore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMore.Name = "tabPageMore";
            this.tabPageMore.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMore.Size = new System.Drawing.Size(409, 374);
            this.tabPageMore.TabIndex = 1;
            this.tabPageMore.Text = "高级参数";
            this.tabPageMore.UseVisualStyleBackColor = true;
            // 
            // FrmOpenDb
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 440);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpenDb";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接数据库";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmOpenDb_FormClosed);
            this.Load += new System.EventHandler(this.FrmOpenDb_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageNormal.ResumeLayout(false);
            this.tabPageNormal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageNormal;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbDbName;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPageMore;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbConnectString;
        private System.Windows.Forms.CheckBox cbUseConnectStr;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbConnectName;
        private System.Windows.Forms.Label label7;
    }
}