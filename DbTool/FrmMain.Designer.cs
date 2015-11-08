namespace DbTool
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("所有连接");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tvConnectList = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssbWins = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuMain.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(867, 25);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewConnect});
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.数据库ToolStripMenuItem.Text = "数据库";
            // 
            // tsmiNewConnect
            // 
            this.tsmiNewConnect.Name = "tsmiNewConnect";
            this.tsmiNewConnect.Size = new System.Drawing.Size(133, 22);
            this.tsmiNewConnect.Text = "新建连接...";
            this.tsmiNewConnect.Click += new System.EventHandler(this.tsmiNewConnect_Click);
            // 
            // tvConnectList
            // 
            this.tvConnectList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvConnectList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvConnectList.HideSelection = false;
            this.tvConnectList.Location = new System.Drawing.Point(0, 25);
            this.tvConnectList.Name = "tvConnectList";
            treeNode2.Name = "节点0";
            treeNode2.Text = "所有连接";
            this.tvConnectList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvConnectList.Size = new System.Drawing.Size(240, 423);
            this.tvConnectList.TabIndex = 4;
            this.tvConnectList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvConnectList_NodeMouseClick);
            this.tvConnectList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvConnectList_NodeMouseDoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(240, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 423);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(100, 22);
            this.tsmiOpen.Text = "打开";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbWins});
            this.statusStrip.Location = new System.Drawing.Point(243, 25);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(624, 23);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tssbWins
            // 
            this.tssbWins.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbWins.Image = ((System.Drawing.Image)(resources.GetObject("tssbWins.Image")));
            this.tssbWins.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbWins.Name = "tssbWins";
            this.tssbWins.Size = new System.Drawing.Size(69, 21);
            this.tssbWins.Text = "窗口列表";
            this.tssbWins.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tssbWins_DropDownItemClicked);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(867, 448);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvConnectList);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "FrmMain";
            this.Text = "数据库导出/导入工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.FrmMain_MdiChildActivate);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewConnect;
        private System.Windows.Forms.TreeView tvConnectList;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripDropDownButton tssbWins;
    }
}

