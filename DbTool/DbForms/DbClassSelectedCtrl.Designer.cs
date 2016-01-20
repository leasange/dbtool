namespace DbTool.DbForms
{
    partial class DbClassSelectedCtrl
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
            this.cbIndex = new System.Windows.Forms.CheckBox();
            this.cbData = new System.Windows.Forms.CheckBox();
            this.cbJavaSource = new System.Windows.Forms.CheckBox();
            this.cbFunction = new System.Windows.Forms.CheckBox();
            this.cbProcedure = new System.Windows.Forms.CheckBox();
            this.cbContras = new System.Windows.Forms.CheckBox();
            this.cbSequence = new System.Windows.Forms.CheckBox();
            this.cbTrigger = new System.Windows.Forms.CheckBox();
            this.cbTable = new System.Windows.Forms.CheckBox();
            this.cbView = new System.Windows.Forms.CheckBox();
            this.cbJob = new System.Windows.Forms.CheckBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectEx = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbIndex
            // 
            this.cbIndex.AutoSize = true;
            this.cbIndex.Location = new System.Drawing.Point(105, 27);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(48, 16);
            this.cbIndex.TabIndex = 22;
            this.cbIndex.Text = "索引";
            this.cbIndex.UseVisualStyleBackColor = true;
            // 
            // cbData
            // 
            this.cbData.AutoSize = true;
            this.cbData.Location = new System.Drawing.Point(181, 5);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(48, 16);
            this.cbData.TabIndex = 23;
            this.cbData.Text = "数据";
            this.cbData.UseVisualStyleBackColor = true;
            // 
            // cbJavaSource
            // 
            this.cbJavaSource.AutoSize = true;
            this.cbJavaSource.Location = new System.Drawing.Point(382, 5);
            this.cbJavaSource.Name = "cbJavaSource";
            this.cbJavaSource.Size = new System.Drawing.Size(72, 16);
            this.cbJavaSource.TabIndex = 24;
            this.cbJavaSource.Text = "Java资源";
            this.cbJavaSource.UseVisualStyleBackColor = true;
            // 
            // cbFunction
            // 
            this.cbFunction.AutoSize = true;
            this.cbFunction.Location = new System.Drawing.Point(249, 27);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(48, 16);
            this.cbFunction.TabIndex = 25;
            this.cbFunction.Text = "函数";
            this.cbFunction.UseVisualStyleBackColor = true;
            // 
            // cbProcedure
            // 
            this.cbProcedure.AutoSize = true;
            this.cbProcedure.Location = new System.Drawing.Point(249, 5);
            this.cbProcedure.Name = "cbProcedure";
            this.cbProcedure.Size = new System.Drawing.Size(48, 16);
            this.cbProcedure.TabIndex = 26;
            this.cbProcedure.Text = "过程";
            this.cbProcedure.UseVisualStyleBackColor = true;
            // 
            // cbContras
            // 
            this.cbContras.AutoSize = true;
            this.cbContras.Location = new System.Drawing.Point(105, 5);
            this.cbContras.Name = "cbContras";
            this.cbContras.Size = new System.Drawing.Size(48, 16);
            this.cbContras.TabIndex = 27;
            this.cbContras.Text = "约束";
            this.cbContras.UseVisualStyleBackColor = true;
            // 
            // cbSequence
            // 
            this.cbSequence.AutoSize = true;
            this.cbSequence.Location = new System.Drawing.Point(181, 27);
            this.cbSequence.Name = "cbSequence";
            this.cbSequence.Size = new System.Drawing.Size(48, 16);
            this.cbSequence.TabIndex = 28;
            this.cbSequence.Text = "序列";
            this.cbSequence.UseVisualStyleBackColor = true;
            // 
            // cbTrigger
            // 
            this.cbTrigger.AutoSize = true;
            this.cbTrigger.Location = new System.Drawing.Point(13, 27);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.Size = new System.Drawing.Size(60, 16);
            this.cbTrigger.TabIndex = 29;
            this.cbTrigger.Text = "触发器";
            this.cbTrigger.UseVisualStyleBackColor = true;
            // 
            // cbTable
            // 
            this.cbTable.AutoSize = true;
            this.cbTable.Location = new System.Drawing.Point(13, 5);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(60, 16);
            this.cbTable.TabIndex = 30;
            this.cbTable.Text = "表定义";
            this.cbTable.UseVisualStyleBackColor = true;
            // 
            // cbView
            // 
            this.cbView.AutoSize = true;
            this.cbView.Location = new System.Drawing.Point(316, 5);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(48, 16);
            this.cbView.TabIndex = 23;
            this.cbView.Text = "视图";
            this.cbView.UseVisualStyleBackColor = true;
            // 
            // cbJob
            // 
            this.cbJob.AutoSize = true;
            this.cbJob.Location = new System.Drawing.Point(316, 27);
            this.cbJob.Name = "cbJob";
            this.cbJob.Size = new System.Drawing.Size(48, 16);
            this.cbJob.TabIndex = 23;
            this.cbJob.Text = "事务";
            this.cbJob.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(13, 54);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 31;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.Location = new System.Drawing.Point(181, 54);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnUnSelectAll.TabIndex = 31;
            this.btnUnSelectAll.Text = "清除选择";
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // btnSelectEx
            // 
            this.btnSelectEx.Location = new System.Drawing.Point(94, 54);
            this.btnSelectEx.Name = "btnSelectEx";
            this.btnSelectEx.Size = new System.Drawing.Size(75, 23);
            this.btnSelectEx.TabIndex = 31;
            this.btnSelectEx.Text = "反选";
            this.btnSelectEx.UseVisualStyleBackColor = true;
            this.btnSelectEx.Click += new System.EventHandler(this.btnSelectEx_Click);
            // 
            // DbClassSelectedCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectEx);
            this.Controls.Add(this.btnUnSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.cbIndex);
            this.Controls.Add(this.cbJob);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.cbData);
            this.Controls.Add(this.cbJavaSource);
            this.Controls.Add(this.cbFunction);
            this.Controls.Add(this.cbProcedure);
            this.Controls.Add(this.cbContras);
            this.Controls.Add(this.cbSequence);
            this.Controls.Add(this.cbTrigger);
            this.Controls.Add(this.cbTable);
            this.Name = "DbClassSelectedCtrl";
            this.Size = new System.Drawing.Size(464, 87);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbIndex;
        private System.Windows.Forms.CheckBox cbData;
        private System.Windows.Forms.CheckBox cbJavaSource;
        private System.Windows.Forms.CheckBox cbFunction;
        private System.Windows.Forms.CheckBox cbProcedure;
        private System.Windows.Forms.CheckBox cbContras;
        private System.Windows.Forms.CheckBox cbSequence;
        private System.Windows.Forms.CheckBox cbTrigger;
        private System.Windows.Forms.CheckBox cbTable;
        private System.Windows.Forms.CheckBox cbView;
        private System.Windows.Forms.CheckBox cbJob;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnSelectAll;
        private System.Windows.Forms.Button btnSelectEx;
    }
}
