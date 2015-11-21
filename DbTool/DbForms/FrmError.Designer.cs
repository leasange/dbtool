namespace DbTool.DbForms
{
    partial class FrmError
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
            this.tbErrorMsg = new AvalonEdit.Winform.AvalonTextBox();
            this.SuspendLayout();
            // 
            // tbErrorMsg
            // 
            this.tbErrorMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbErrorMsg.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbErrorMsg.Location = new System.Drawing.Point(0, 0);
            this.tbErrorMsg.Margin = new System.Windows.Forms.Padding(4);
            this.tbErrorMsg.Name = "tbErrorMsg";
            this.tbErrorMsg.Size = new System.Drawing.Size(653, 324);
            this.tbErrorMsg.SyntaxHighlighting = "C#";
            this.tbErrorMsg.TabIndex = 0;
            // 
            // FrmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 324);
            this.Controls.Add(this.tbErrorMsg);
            this.MinimizeBox = false;
            this.Name = "FrmError";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异常错误";
            this.ResumeLayout(false);

        }

        #endregion

        private AvalonEdit.Winform.AvalonTextBox tbErrorMsg;
    }
}