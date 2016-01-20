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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExportDbt));
            this.btnView = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.btnStartExport = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dbClassSelected = new DbTool.DbForms.DbClassSelectedCtrl();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(567, 6);
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
            this.tbPath.Size = new System.Drawing.Size(484, 21);
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
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(77, 352);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(484, 23);
            this.proBar.TabIndex = 12;
            // 
            // btnStartExport
            // 
            this.btnStartExport.Location = new System.Drawing.Point(486, 381);
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
            this.tbMsg.Size = new System.Drawing.Size(484, 202);
            this.tbMsg.TabIndex = 10;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "dbt";
            this.saveFileDialog.Filter = "DbTool文件(*.dbt)|*.dbt|所有文件|*.*";
            this.saveFileDialog.Title = "导出数据库文件";
            // 
            // dbClassSelected
            // 
            this.dbClassSelected.Location = new System.Drawing.Point(77, 243);
            this.dbClassSelected.Name = "dbClassSelected";
            this.dbClassSelected.Size = new System.Drawing.Size(484, 89);
            this.dbClassSelected.TabIndex = 13;
            // 
            // FrmExportDbt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 422);
            this.Controls.Add(this.dbClassSelected);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.Button btnStartExport;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DbForms.DbClassSelectedCtrl dbClassSelected;
    }
}