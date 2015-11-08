namespace DbTool
{
    partial class OracleManager
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectStr = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tvDataTree = new System.Windows.Forms.TreeView();
            this.oracleView = new DbTool.OracleView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportDb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportDb = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateSqlWin = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库连接:";
            // 
            // tbConnectStr
            // 
            this.tbConnectStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnectStr.Location = new System.Drawing.Point(85, 13);
            this.tbConnectStr.Name = "tbConnectStr";
            this.tbConnectStr.Size = new System.Drawing.Size(690, 21);
            this.tbConnectStr.TabIndex = 1;
            this.tbConnectStr.Text = "Data Source=192.168.96.80/ORCL;Persist Security Info=True;User ID=safecity;Passwo" +
    "rd=safecity";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(781, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(58, 24);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(10, 46);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvDataTree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.oracleView);
            this.splitContainer.Size = new System.Drawing.Size(856, 354);
            this.splitContainer.SplitterDistance = 293;
            this.splitContainer.TabIndex = 3;
            // 
            // tvDataTree
            // 
            this.tvDataTree.CheckBoxes = true;
            this.tvDataTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDataTree.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvDataTree.HideSelection = false;
            this.tvDataTree.Location = new System.Drawing.Point(0, 0);
            this.tvDataTree.Name = "tvDataTree";
            this.tvDataTree.ShowNodeToolTips = true;
            this.tvDataTree.Size = new System.Drawing.Size(293, 354);
            this.tvDataTree.TabIndex = 0;
            this.tvDataTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDataTree_NodeMouseClick);
            this.tvDataTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDataTree_NodeMouseDoubleClick);
            // 
            // oracleView
            // 
            this.oracleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oracleView.Location = new System.Drawing.Point(0, 0);
            this.oracleView.Name = "oracleView";
            this.oracleView.Size = new System.Drawing.Size(559, 354);
            this.oracleView.TabIndex = 0;
            this.oracleView.LoadDataEvent += new System.EventHandler<DbTool.LoadDataEventArgs>(this.oracleView_LoadDataEvent);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(879, 25);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportDb,
            this.tsmiImportDb,
            this.新建ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // tsmiExportDb
            // 
            this.tsmiExportDb.Name = "tsmiExportDb";
            this.tsmiExportDb.Size = new System.Drawing.Size(145, 22);
            this.tsmiExportDb.Text = "导出数据库...";
            this.tsmiExportDb.Click += new System.EventHandler(this.tsmiExportDb_Click);
            // 
            // tsmiImportDb
            // 
            this.tsmiImportDb.Name = "tsmiImportDb";
            this.tsmiImportDb.Size = new System.Drawing.Size(145, 22);
            this.tsmiImportDb.Text = "导入数据库...";
            this.tsmiImportDb.Click += new System.EventHandler(this.tsmiImportDb_Click);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateSqlWin});
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // tsmiCreateSqlWin
            // 
            this.tsmiCreateSqlWin.Name = "tsmiCreateSqlWin";
            this.tsmiCreateSqlWin.Size = new System.Drawing.Size(123, 22);
            this.tsmiCreateSqlWin.Text = "SQL窗口";
            this.tsmiCreateSqlWin.Click += new System.EventHandler(this.tsmiCreateSqlWin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbConnectStr);
            this.panel1.Controls.Add(this.splitContainer);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 403);
            this.panel1.TabIndex = 5;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "dbt";
            this.saveFileDialog.Title = "导出数据库";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "打开数据库文件";
            // 
            // OracleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Name = "OracleManager";
            this.Size = new System.Drawing.Size(879, 428);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnectStr;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView tvDataTree;
        private OracleView oracleView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportDb;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportDb;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateSqlWin;
    }
}
