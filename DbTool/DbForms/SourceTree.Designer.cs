namespace DbTool.DbForms
{
    partial class SourceTree
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.lbLoading = new System.Windows.Forms.Label();
            this.tvSourceTree = new DbTool.MyControls.TreeViewEx();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "筛选";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 29);
            this.panel1.TabIndex = 3;
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFilter.Location = new System.Drawing.Point(41, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(255, 23);
            this.tbFilter.TabIndex = 3;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.BackColor = System.Drawing.Color.White;
            this.lbLoading.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLoading.ForeColor = System.Drawing.Color.Blue;
            this.lbLoading.Location = new System.Drawing.Point(56, 97);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(149, 20);
            this.lbLoading.TabIndex = 5;
            this.lbLoading.Text = "正在加载中....";
            this.lbLoading.Visible = false;
            // 
            // tvSourceTree
            // 
            this.tvSourceTree.CheckBoxes = true;
            this.tvSourceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSourceTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvSourceTree.HideSelection = false;
            this.tvSourceTree.Location = new System.Drawing.Point(0, 29);
            this.tvSourceTree.Name = "tvSourceTree";
            this.tvSourceTree.ShowNodeToolTips = true;
            this.tvSourceTree.Size = new System.Drawing.Size(299, 423);
            this.tvSourceTree.TabIndex = 6;
            this.tvSourceTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSourceTree_NodeMouseClick);
            this.tvSourceTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSourceTree_NodeMouseDoubleClick);
            // 
            // SourceTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.tvSourceTree);
            this.Controls.Add(this.panel1);
            this.Name = "SourceTree";
            this.Size = new System.Drawing.Size(299, 452);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label lbLoading;
        private DbTool.MyControls.TreeViewEx tvSourceTree;
    }
}
