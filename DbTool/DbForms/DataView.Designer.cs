namespace DbTool.DbForms
{
    partial class DataView
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
            this.dgvData = new DbTool.MyControls.DataGridViewEx();
            this.lbLoading = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(433, 298);
            this.dgvData.TabIndex = 8;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.ForeColor = System.Drawing.Color.Red;
            this.lbLoading.Location = new System.Drawing.Point(266, 9);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(59, 12);
            this.lbLoading.TabIndex = 5;
            this.lbLoading.Text = "加载中...";
            this.lbLoading.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(160, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 26);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "终止加载";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMore.Location = new System.Drawing.Point(4, 2);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(72, 26);
            this.btnMore.TabIndex = 3;
            this.btnMore.Text = "更多";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(82, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(72, 26);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "所有";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbLoading);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnMore);
            this.panel1.Controls.Add(this.btnAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 29);
            this.panel1.TabIndex = 7;
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Name = "DataView";
            this.Size = new System.Drawing.Size(433, 327);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyControls.DataGridViewEx dgvData;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Panel panel1;
    }
}
