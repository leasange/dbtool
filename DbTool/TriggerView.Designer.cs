namespace DbTool
{
    partial class TriggerView
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
            this.dgvNormal = new DbTool.MyControls.DataGridViewEx();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageNormal = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbSql = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageNormal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvNormal.Size = new System.Drawing.Size(461, 338);
            this.dgvNormal.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageNormal);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(475, 370);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageNormal
            // 
            this.tabPageNormal.Controls.Add(this.dgvNormal);
            this.tabPageNormal.Location = new System.Drawing.Point(4, 22);
            this.tabPageNormal.Name = "tabPageNormal";
            this.tabPageNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormal.Size = new System.Drawing.Size(467, 344);
            this.tabPageNormal.TabIndex = 2;
            this.tabPageNormal.Text = "一般";
            this.tabPageNormal.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbSql);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(631, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbSql
            // 
            this.tbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSql.Location = new System.Drawing.Point(3, 3);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSql.Size = new System.Drawing.Size(625, 354);
            this.tbSql.TabIndex = 0;
            // 
            // TriggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "TriggerView";
            this.Size = new System.Drawing.Size(475, 370);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageNormal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DbTool.MyControls.DataGridViewEx dgvNormal;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageNormal;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbSql;
    }
}
