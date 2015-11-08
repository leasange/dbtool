namespace DbTool
{
    partial class OracleView
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
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.tableView = new DbTool.TableView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sequenceView = new DbTool.SequenceView();
            this.tabPageTrigger = new System.Windows.Forms.TabPage();
            this.triggerView = new DbTool.TriggerView();
            this.tabPageFun = new System.Windows.Forms.TabPage();
            this.functionView = new DbTool.SourceView();
            this.tabPageProcedure = new System.Windows.Forms.TabPage();
            this.procedureView = new DbTool.SourceView();
            this.tabPageJavaSource = new System.Windows.Forms.TabPage();
            this.javaSourceView = new DbTool.SourceView();
            this.tabControl.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPageTrigger.SuspendLayout();
            this.tabPageFun.SuspendLayout();
            this.tabPageProcedure.SuspendLayout();
            this.tabPageJavaSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTable);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPageTrigger);
            this.tabControl.Controls.Add(this.tabPageFun);
            this.tabControl.Controls.Add(this.tabPageProcedure);
            this.tabControl.Controls.Add(this.tabPageJavaSource);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(612, 419);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.tableView);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(604, 393);
            this.tabPageTable.TabIndex = 0;
            this.tabPageTable.Text = "表";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // tableView
            // 
            this.tableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableView.Location = new System.Drawing.Point(3, 3);
            this.tableView.Name = "tableView";
            this.tableView.Size = new System.Drawing.Size(598, 387);
            this.tableView.TabIndex = 0;
            this.tableView.LoadDataEvent += new System.EventHandler<DbTool.LoadDataEventArgs>(this.tableView_LoadDataEvent);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.sequenceView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(604, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "序列";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sequenceView
            // 
            this.sequenceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sequenceView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sequenceView.Location = new System.Drawing.Point(3, 3);
            this.sequenceView.Name = "sequenceView";
            this.sequenceView.Size = new System.Drawing.Size(598, 387);
            this.sequenceView.TabIndex = 0;
            // 
            // tabPageTrigger
            // 
            this.tabPageTrigger.Controls.Add(this.triggerView);
            this.tabPageTrigger.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrigger.Name = "tabPageTrigger";
            this.tabPageTrigger.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrigger.Size = new System.Drawing.Size(604, 393);
            this.tabPageTrigger.TabIndex = 2;
            this.tabPageTrigger.Text = "触发器";
            this.tabPageTrigger.UseVisualStyleBackColor = true;
            // 
            // triggerView
            // 
            this.triggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triggerView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.triggerView.Location = new System.Drawing.Point(3, 3);
            this.triggerView.Name = "triggerView";
            this.triggerView.Size = new System.Drawing.Size(598, 387);
            this.triggerView.TabIndex = 0;
            // 
            // tabPageFun
            // 
            this.tabPageFun.Controls.Add(this.functionView);
            this.tabPageFun.Location = new System.Drawing.Point(4, 22);
            this.tabPageFun.Name = "tabPageFun";
            this.tabPageFun.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFun.Size = new System.Drawing.Size(604, 393);
            this.tabPageFun.TabIndex = 3;
            this.tabPageFun.Text = "函数";
            this.tabPageFun.UseVisualStyleBackColor = true;
            // 
            // functionView
            // 
            this.functionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.functionView.Location = new System.Drawing.Point(3, 3);
            this.functionView.Name = "functionView";
            this.functionView.Size = new System.Drawing.Size(598, 387);
            this.functionView.TabIndex = 0;
            // 
            // tabPageProcedure
            // 
            this.tabPageProcedure.Controls.Add(this.procedureView);
            this.tabPageProcedure.Location = new System.Drawing.Point(4, 22);
            this.tabPageProcedure.Name = "tabPageProcedure";
            this.tabPageProcedure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProcedure.Size = new System.Drawing.Size(604, 393);
            this.tabPageProcedure.TabIndex = 4;
            this.tabPageProcedure.Text = "过程";
            this.tabPageProcedure.UseVisualStyleBackColor = true;
            // 
            // procedureView
            // 
            this.procedureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procedureView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.procedureView.Location = new System.Drawing.Point(3, 3);
            this.procedureView.Name = "procedureView";
            this.procedureView.Size = new System.Drawing.Size(598, 387);
            this.procedureView.TabIndex = 0;
            // 
            // tabPageJavaSource
            // 
            this.tabPageJavaSource.Controls.Add(this.javaSourceView);
            this.tabPageJavaSource.Location = new System.Drawing.Point(4, 22);
            this.tabPageJavaSource.Name = "tabPageJavaSource";
            this.tabPageJavaSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJavaSource.Size = new System.Drawing.Size(604, 393);
            this.tabPageJavaSource.TabIndex = 5;
            this.tabPageJavaSource.Text = "Java资源";
            this.tabPageJavaSource.UseVisualStyleBackColor = true;
            // 
            // javaSourceView
            // 
            this.javaSourceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.javaSourceView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.javaSourceView.Location = new System.Drawing.Point(3, 3);
            this.javaSourceView.Name = "javaSourceView";
            this.javaSourceView.Size = new System.Drawing.Size(598, 387);
            this.javaSourceView.TabIndex = 0;
            // 
            // OracleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "OracleView";
            this.Size = new System.Drawing.Size(612, 419);
            this.tabControl.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPageTrigger.ResumeLayout(false);
            this.tabPageFun.ResumeLayout(false);
            this.tabPageProcedure.ResumeLayout(false);
            this.tabPageJavaSource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.TabPage tabPage2;
        private TableView tableView;
        private SequenceView sequenceView;
        private System.Windows.Forms.TabPage tabPageTrigger;
        private TriggerView triggerView;
        private System.Windows.Forms.TabPage tabPageFun;
        private SourceView functionView;
        private System.Windows.Forms.TabPage tabPageProcedure;
        private SourceView procedureView;
        private System.Windows.Forms.TabPage tabPageJavaSource;
        private SourceView javaSourceView;
    }
}
