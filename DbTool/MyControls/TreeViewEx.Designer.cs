namespace DbTool.MyControls
{
    partial class TreeViewEx
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
            this.components = new System.ComponentModel.Container();
            this.timerCanCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerCanCheck
            // 
            this.timerCanCheck.Interval = 400;
            this.timerCanCheck.Tick += new System.EventHandler(this.timerCanCheck_Tick);
            // 
            // TreeViewEx
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewEx_BeforeCheck);
            this.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewEx_AfterCheck);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewEx_NodeMouseClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewEx_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCanCheck;
    }
}
