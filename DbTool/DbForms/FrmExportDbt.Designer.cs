namespace DbTool
{
    partial class FrmExportDbt
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
            this.btnView = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIndex = new System.Windows.Forms.CheckBox();
            this.cbData = new System.Windows.Forms.CheckBox();
            this.cbJavaSource = new System.Windows.Forms.CheckBox();
            this.cbFunction = new System.Windows.Forms.CheckBox();
            this.cbProcedure = new System.Windows.Forms.CheckBox();
            this.cbContras = new System.Windows.Forms.CheckBox();
            this.cbSequence = new System.Windows.Forms.CheckBox();
            this.cbTrigger = new System.Windows.Forms.CheckBox();
            this.cbTable = new System.Windows.Forms.CheckBox();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.btnStartExport = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(544, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(63, 23);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "浏览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(77, 8);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(461, 21);
            this.tbPath.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "文件目录：";
            // 
            // cbIndex
            // 
            this.cbIndex.AutoSize = true;
            this.cbIndex.Location = new System.Drawing.Point(373, 271);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(48, 16);
            this.cbIndex.TabIndex = 13;
            this.cbIndex.Text = "索引";
            this.cbIndex.UseVisualStyleBackColor = true;
            // 
            // cbData
            // 
            this.cbData.AutoSize = true;
            this.cbData.Location = new System.Drawing.Point(143, 271);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(48, 16);
            this.cbData.TabIndex = 14;
            this.cbData.Text = "数据";
            this.cbData.UseVisualStyleBackColor = true;
            // 
            // cbJavaSource
            // 
            this.cbJavaSource.AutoSize = true;
            this.cbJavaSource.Location = new System.Drawing.Point(535, 271);
            this.cbJavaSource.Name = "cbJavaSource";
            this.cbJavaSource.Size = new System.Drawing.Size(72, 16);
            this.cbJavaSource.TabIndex = 15;
            this.cbJavaSource.Text = "Java资源";
            this.cbJavaSource.UseVisualStyleBackColor = true;
            // 
            // cbFunction
            // 
            this.cbFunction.AutoSize = true;
            this.cbFunction.Location = new System.Drawing.Point(481, 271);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(48, 16);
            this.cbFunction.TabIndex = 16;
            this.cbFunction.Text = "函数";
            this.cbFunction.UseVisualStyleBackColor = true;
            // 
            // cbProcedure
            // 
            this.cbProcedure.AutoSize = true;
            this.cbProcedure.Location = new System.Drawing.Point(427, 271);
            this.cbProcedure.Name = "cbProcedure";
            this.cbProcedure.Size = new System.Drawing.Size(48, 16);
            this.cbProcedure.TabIndex = 17;
            this.cbProcedure.Text = "过程";
            this.cbProcedure.UseVisualStyleBackColor = true;
            // 
            // cbContras
            // 
            this.cbContras.AutoSize = true;
            this.cbContras.Location = new System.Drawing.Point(324, 271);
            this.cbContras.Name = "cbContras";
            this.cbContras.Size = new System.Drawing.Size(48, 16);
            this.cbContras.TabIndex = 18;
            this.cbContras.Text = "约束";
            this.cbContras.UseVisualStyleBackColor = true;
            // 
            // cbSequence
            // 
            this.cbSequence.AutoSize = true;
            this.cbSequence.Location = new System.Drawing.Point(270, 271);
            this.cbSequence.Name = "cbSequence";
            this.cbSequence.Size = new System.Drawing.Size(48, 16);
            this.cbSequence.TabIndex = 19;
            this.cbSequence.Text = "序列";
            this.cbSequence.UseVisualStyleBackColor = true;
            // 
            // cbTrigger
            // 
            this.cbTrigger.AutoSize = true;
            this.cbTrigger.Location = new System.Drawing.Point(204, 271);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.Size = new System.Drawing.Size(60, 16);
            this.cbTrigger.TabIndex = 20;
            this.cbTrigger.Text = "触发器";
            this.cbTrigger.UseVisualStyleBackColor = true;
            // 
            // cbTable
            // 
            this.cbTable.AutoSize = true;
            this.cbTable.Location = new System.Drawing.Point(77, 271);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(60, 16);
            this.cbTable.TabIndex = 21;
            this.cbTable.Text = "表定义";
            this.cbTable.UseVisualStyleBackColor = true;
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(77, 303);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(461, 23);
            this.proBar.TabIndex = 12;
            // 
            // btnStartExport
            // 
            this.btnStartExport.Location = new System.Drawing.Point(463, 332);
            this.btnStartExport.Name = "btnStartExport";
            this.btnStartExport.Size = new System.Drawing.Size(75, 29);
            this.btnStartExport.TabIndex = 11;
            this.btnStartExport.Text = "开始导出";
            this.btnStartExport.UseVisualStyleBackColor = true;
            this.btnStartExport.Click += new System.EventHandler(this.btnStartExport_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(77, 35);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMsg.Size = new System.Drawing.Size(461, 230);
            this.tbMsg.TabIndex = 10;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "dbt";
            this.saveFileDialog.Filter = "DbTool文件(*.dbt)|*.dbt|所有文件|*.*";
            this.saveFileDialog.Title = "导出数据库文件";
            // 
            // FrmExportDbt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 367);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label1);
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
            this.Controls.Add(this.btnStartExport);
            this.Controls.Add(this.tbMsg);
            this.Name = "FrmExportDbt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导出数据库文件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExportDbt_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbIndex;
        private System.Windows.Forms.CheckBox cbData;
        private System.Windows.Forms.CheckBox cbJavaSource;
        private System.Windows.Forms.CheckBox cbFunction;
        private System.Windows.Forms.CheckBox cbProcedure;
        private System.Windows.Forms.CheckBox cbContras;
        private System.Windows.Forms.CheckBox cbSequence;
        private System.Windows.Forms.CheckBox cbTrigger;
        private System.Windows.Forms.CheckBox cbTable;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.Button btnStartExport;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}