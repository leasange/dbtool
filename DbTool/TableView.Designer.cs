namespace DbTool
{
    partial class TableView
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageNormal = new System.Windows.Forms.TabPage();
            this.dgvNormal = new DbTool.MyControls.DataGridViewEx();
            this.tabPageTableCol = new System.Windows.Forms.TabPage();
            this.dgvCol = new DbTool.MyControls.DataGridViewEx();
            this.tabPageKey = new System.Windows.Forms.TabPage();
            this.dgvKeys = new DbTool.MyControls.DataGridViewEx();
            this.tabPageIndex = new System.Windows.Forms.TabPage();
            this.dgvIndexs = new DbTool.MyControls.DataGridViewEx();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.dgvData = new DbTool.MyControls.DataGridViewEx();
            this.tabPageSql = new System.Windows.Forms.TabPage();
            this.tbSql = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).BeginInit();
            this.tabPageTableCol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCol)).BeginInit();
            this.tabPageKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeys)).BeginInit();
            this.tabPageIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexs)).BeginInit();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tabPageSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageNormal);
            this.tabControl.Controls.Add(this.tabPageTableCol);
            this.tabControl.Controls.Add(this.tabPageKey);
            this.tabControl.Controls.Add(this.tabPageIndex);
            this.tabControl.Controls.Add(this.tabPageData);
            this.tabControl.Controls.Add(this.tabPageSql);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(753, 390);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageNormal
            // 
            this.tabPageNormal.Controls.Add(this.dgvNormal);
            this.tabPageNormal.Location = new System.Drawing.Point(4, 22);
            this.tabPageNormal.Name = "tabPageNormal";
            this.tabPageNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormal.Size = new System.Drawing.Size(745, 364);
            this.tabPageNormal.TabIndex = 2;
            this.tabPageNormal.Text = "一般";
            this.tabPageNormal.UseVisualStyleBackColor = true;
            // 
            // dgvNormal
            // 
            this.dgvNormal.AllowUserToAddRows = false;
            this.dgvNormal.AllowUserToDeleteRows = false;
            this.dgvNormal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNormal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNormal.Location = new System.Drawing.Point(3, 3);
            this.dgvNormal.Name = "dgvNormal";
            this.dgvNormal.ReadOnly = true;
            this.dgvNormal.RowTemplate.Height = 23;
            this.dgvNormal.Size = new System.Drawing.Size(739, 358);
            this.dgvNormal.TabIndex = 1;
            // 
            // tabPageTableCol
            // 
            this.tabPageTableCol.Controls.Add(this.dgvCol);
            this.tabPageTableCol.Location = new System.Drawing.Point(4, 22);
            this.tabPageTableCol.Name = "tabPageTableCol";
            this.tabPageTableCol.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTableCol.Size = new System.Drawing.Size(745, 364);
            this.tabPageTableCol.TabIndex = 0;
            this.tabPageTableCol.Text = "列";
            this.tabPageTableCol.UseVisualStyleBackColor = true;
            // 
            // dgvCol
            // 
            this.dgvCol.AllowUserToAddRows = false;
            this.dgvCol.AllowUserToDeleteRows = false;
            this.dgvCol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCol.Location = new System.Drawing.Point(3, 3);
            this.dgvCol.Name = "dgvCol";
            this.dgvCol.ReadOnly = true;
            this.dgvCol.RowTemplate.Height = 23;
            this.dgvCol.Size = new System.Drawing.Size(739, 358);
            this.dgvCol.TabIndex = 0;
            // 
            // tabPageKey
            // 
            this.tabPageKey.Controls.Add(this.dgvKeys);
            this.tabPageKey.Location = new System.Drawing.Point(4, 22);
            this.tabPageKey.Name = "tabPageKey";
            this.tabPageKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKey.Size = new System.Drawing.Size(745, 364);
            this.tabPageKey.TabIndex = 3;
            this.tabPageKey.Text = "键";
            this.tabPageKey.UseVisualStyleBackColor = true;
            // 
            // dgvKeys
            // 
            this.dgvKeys.AllowUserToAddRows = false;
            this.dgvKeys.AllowUserToDeleteRows = false;
            this.dgvKeys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeys.Location = new System.Drawing.Point(3, 3);
            this.dgvKeys.Name = "dgvKeys";
            this.dgvKeys.ReadOnly = true;
            this.dgvKeys.RowTemplate.Height = 23;
            this.dgvKeys.Size = new System.Drawing.Size(739, 358);
            this.dgvKeys.TabIndex = 2;
            // 
            // tabPageIndex
            // 
            this.tabPageIndex.Controls.Add(this.dgvIndexs);
            this.tabPageIndex.Location = new System.Drawing.Point(4, 22);
            this.tabPageIndex.Name = "tabPageIndex";
            this.tabPageIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIndex.Size = new System.Drawing.Size(745, 364);
            this.tabPageIndex.TabIndex = 4;
            this.tabPageIndex.Text = "索引";
            this.tabPageIndex.UseVisualStyleBackColor = true;
            // 
            // dgvIndexs
            // 
            this.dgvIndexs.AllowUserToAddRows = false;
            this.dgvIndexs.AllowUserToDeleteRows = false;
            this.dgvIndexs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvIndexs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndexs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIndexs.Location = new System.Drawing.Point(3, 3);
            this.dgvIndexs.Name = "dgvIndexs";
            this.dgvIndexs.ReadOnly = true;
            this.dgvIndexs.RowTemplate.Height = 23;
            this.dgvIndexs.Size = new System.Drawing.Size(739, 358);
            this.dgvIndexs.TabIndex = 2;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.btnStop);
            this.tabPageData.Controls.Add(this.btnAll);
            this.tabPageData.Controls.Add(this.btnMore);
            this.tabPageData.Controls.Add(this.dgvData);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(745, 364);
            this.tabPageData.TabIndex = 5;
            this.tabPageData.Text = "数据";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(172, 337);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "终止加载";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(89, 337);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(77, 23);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "所有";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMore.Location = new System.Drawing.Point(6, 337);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(77, 23);
            this.btnMore.TabIndex = 3;
            this.btnMore.Text = "更多";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(-1, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(743, 332);
            this.dgvData.TabIndex = 2;
            // 
            // tabPageSql
            // 
            this.tabPageSql.Controls.Add(this.tbSql);
            this.tabPageSql.Location = new System.Drawing.Point(4, 22);
            this.tabPageSql.Name = "tabPageSql";
            this.tabPageSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSql.Size = new System.Drawing.Size(745, 364);
            this.tabPageSql.TabIndex = 1;
            this.tabPageSql.Text = "SQL";
            this.tabPageSql.UseVisualStyleBackColor = true;
            // 
            // tbSql
            // 
            this.tbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSql.Location = new System.Drawing.Point(3, 3);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSql.Size = new System.Drawing.Size(739, 358);
            this.tbSql.TabIndex = 0;
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(753, 390);
            this.tabControl.ResumeLayout(false);
            this.tabPageNormal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).EndInit();
            this.tabPageTableCol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCol)).EndInit();
            this.tabPageKey.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeys)).EndInit();
            this.tabPageIndex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexs)).EndInit();
            this.tabPageData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tabPageSql.ResumeLayout(false);
            this.tabPageSql.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTableCol;
        private System.Windows.Forms.TabPage tabPageSql;
        private DbTool.MyControls.DataGridViewEx dgvCol;
        private System.Windows.Forms.TextBox tbSql;
        private System.Windows.Forms.TabPage tabPageNormal;
        private DbTool.MyControls.DataGridViewEx dgvNormal;
        private System.Windows.Forms.TabPage tabPageKey;
        private System.Windows.Forms.TabPage tabPageIndex;
        private DbTool.MyControls.DataGridViewEx dgvKeys;
        private DbTool.MyControls.DataGridViewEx dgvIndexs;
        private System.Windows.Forms.TabPage tabPageData;
        private DbTool.MyControls.DataGridViewEx dgvData;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnStop;
    }
}
