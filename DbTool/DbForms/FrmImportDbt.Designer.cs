namespace DbTool
{
    partial class FrmImportDbt
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.cbTable = new System.Windows.Forms.CheckBox();
            this.cbTrigger = new System.Windows.Forms.CheckBox();
            this.cbSequence = new System.Windows.Forms.CheckBox();
            this.cbContras = new System.Windows.Forms.CheckBox();
            this.cbProcedure = new System.Windows.Forms.CheckBox();
            this.cbIndex = new System.Windows.Forms.CheckBox();
            this.cbFunction = new System.Windows.Forms.CheckBox();
            this.cbJavaSource = new System.Windows.Forms.CheckBox();
            this.cbData = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件目录：";
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(72, 6);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(461, 21);
            this.tbPath.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(539, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(63, 23);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "浏览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "dbt";
            this.openFileDialog.Filter = "DbTool文件(*.dbt)|*.dbt|所有文件|*.*";
            this.openFileDialog.Title = "打开数据库文件";
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(72, 33);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMsg.Size = new System.Drawing.Size(461, 230);
            this.tbMsg.TabIndex = 3;
            // 
            // btnStartImport
            // 
            this.btnStartImport.Location = new System.Drawing.Point(458, 330);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(75, 29);
            this.btnStartImport.TabIndex = 4;
            this.btnStartImport.Text = "开始导入";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(72, 301);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(461, 23);
            this.proBar.TabIndex = 5;
            // 
            // cbTable
            // 
            this.cbTable.AutoSize = true;
            this.cbTable.Location = new System.Drawing.Point(72, 269);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(60, 16);
            this.cbTable.TabIndex = 6;
            this.cbTable.Text = "表定义";
            this.cbTable.UseVisualStyleBackColor = true;
            // 
            // cbTrigger
            // 
            this.cbTrigger.AutoSize = true;
            this.cbTrigger.Location = new System.Drawing.Point(199, 269);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.Size = new System.Drawing.Size(60, 16);
            this.cbTrigger.TabIndex = 6;
            this.cbTrigger.Text = "触发器";
            this.cbTrigger.UseVisualStyleBackColor = true;
            // 
            // cbSequence
            // 
            this.cbSequence.AutoSize = true;
            this.cbSequence.Location = new System.Drawing.Point(265, 269);
            this.cbSequence.Name = "cbSequence";
            this.cbSequence.Size = new System.Drawing.Size(48, 16);
            this.cbSequence.TabIndex = 6;
            this.cbSequence.Text = "序列";
            this.cbSequence.UseVisualStyleBackColor = true;
            // 
            // cbContras
            // 
            this.cbContras.AutoSize = true;
            this.cbContras.Location = new System.Drawing.Point(319, 269);
            this.cbContras.Name = "cbContras";
            this.cbContras.Size = new System.Drawing.Size(48, 16);
            this.cbContras.TabIndex = 6;
            this.cbContras.Text = "约束";
            this.cbContras.UseVisualStyleBackColor = true;
            // 
            // cbProcedure
            // 
            this.cbProcedure.AutoSize = true;
            this.cbProcedure.Location = new System.Drawing.Point(422, 269);
            this.cbProcedure.Name = "cbProcedure";
            this.cbProcedure.Size = new System.Drawing.Size(48, 16);
            this.cbProcedure.TabIndex = 6;
            this.cbProcedure.Text = "过程";
            this.cbProcedure.UseVisualStyleBackColor = true;
            // 
            // cbIndex
            // 
            this.cbIndex.AutoSize = true;
            this.cbIndex.Location = new System.Drawing.Point(368, 269);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(48, 16);
            this.cbIndex.TabIndex = 6;
            this.cbIndex.Text = "索引";
            this.cbIndex.UseVisualStyleBackColor = true;
            // 
            // cbFunction
            // 
            this.cbFunction.AutoSize = true;
            this.cbFunction.Location = new System.Drawing.Point(476, 269);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(48, 16);
            this.cbFunction.TabIndex = 6;
            this.cbFunction.Text = "函数";
            this.cbFunction.UseVisualStyleBackColor = true;
            // 
            // cbJavaSource
            // 
            this.cbJavaSource.AutoSize = true;
            this.cbJavaSource.Location = new System.Drawing.Point(530, 269);
            this.cbJavaSource.Name = "cbJavaSource";
            this.cbJavaSource.Size = new System.Drawing.Size(72, 16);
            this.cbJavaSource.TabIndex = 6;
            this.cbJavaSource.Text = "Java资源";
            this.cbJavaSource.UseVisualStyleBackColor = true;
            // 
            // cbData
            // 
            this.cbData.AutoSize = true;
            this.cbData.Location = new System.Drawing.Point(138, 269);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(48, 16);
            this.cbData.TabIndex = 6;
            this.cbData.Text = "数据";
            this.cbData.UseVisualStyleBackColor = true;
            // 
            // FrmImportDbt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 367);
            this.Controls.Add(this.cbIndex);
            this.Controls.Add(this.cbData);
            this.Controls.Add(this.cbJavaSource);
            this.Controls.Add(this.cbFunction);
            this.Controls.Add(this.cbProcedure);
            this.Controls.Add(this.cbContras);
            this.Controls.Add(this.cbSequence);
            this.Controls.Add(this.cbTrigger);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.proBar);
            this.Controls.Add(this.btnStartImport);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label1);
            this.Name = "FrmImportDbt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入数据库文件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImportDbt_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.CheckBox cbTable;
        private System.Windows.Forms.CheckBox cbTrigger;
        private System.Windows.Forms.CheckBox cbSequence;
        private System.Windows.Forms.CheckBox cbContras;
        private System.Windows.Forms.CheckBox cbProcedure;
        private System.Windows.Forms.CheckBox cbIndex;
        private System.Windows.Forms.CheckBox cbFunction;
        private System.Windows.Forms.CheckBox cbJavaSource;
        private System.Windows.Forms.CheckBox cbData;
    }
}