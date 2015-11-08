namespace DbTool
{
    partial class FrmOracle
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
            this.oracleManager1 = new DbTool.OracleManager();
            this.SuspendLayout();
            // 
            // oracleManager1
            // 
            this.oracleManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oracleManager1.Location = new System.Drawing.Point(0, 0);
            this.oracleManager1.Name = "oracleManager1";
            this.oracleManager1.Size = new System.Drawing.Size(928, 413);
            this.oracleManager1.TabIndex = 0;
            // 
            // FrmOracle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 413);
            this.Controls.Add(this.oracleManager1);
            this.DoubleBuffered = true;
            this.Name = "FrmOracle";
            this.Text = "Oracle数据库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private OracleManager oracleManager1;
    }
}