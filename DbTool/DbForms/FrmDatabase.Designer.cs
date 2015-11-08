namespace DbTool
{
    partial class FrmDatabase
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSqlWin = new System.Windows.Forms.ToolStripMenuItem();
            this.导入导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceTree = new DbTool.DbForms.SourceTree();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem,
            this.新建ToolStripMenuItem,
            this.导入导出ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(875, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Visible = false;
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect});
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.数据库ToolStripMenuItem.Text = "数据库连接";
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(138, 22);
            this.tsmiConnect.Text = "连接/重连...";
            this.tsmiConnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSqlWin});
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // tsmiSqlWin
            // 
            this.tsmiSqlWin.Name = "tsmiSqlWin";
            this.tsmiSqlWin.Size = new System.Drawing.Size(152, 22);
            this.tsmiSqlWin.Text = "SQL窗口";
            this.tsmiSqlWin.Click += new System.EventHandler(this.tsmiSqlWin_Click);
            // 
            // 导入导出ToolStripMenuItem
            // 
            this.导入导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiExport});
            this.导入导出ToolStripMenuItem.Name = "导入导出ToolStripMenuItem";
            this.导入导出ToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.导入导出ToolStripMenuItem.Text = "导入/导出";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(109, 22);
            this.tsmiImport.Text = "导入...";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(109, 22);
            this.tsmiExport.Text = "导出...";
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceTree);
            this.splitContainer1.Size = new System.Drawing.Size(875, 408);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 2;
            // 
            // sourceTree
            // 
            this.sourceTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTree.Location = new System.Drawing.Point(0, 0);
            this.sourceTree.Name = "sourceTree";
            this.sourceTree.Size = new System.Drawing.Size(267, 408);
            this.sourceTree.TabIndex = 1;
            this.sourceTree.EventSource += new System.EventHandler<DbTool.DbForms.EventSourceTreeArgs>(this.sourceTree_EventSource);
            // 
            // FrmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 433);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmDatabase";
            this.Text = "当前连接数据库";
            this.Load += new System.EventHandler(this.FrmDatabase_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem 导入导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSqlWin;
        private DbForms.SourceTree sourceTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}