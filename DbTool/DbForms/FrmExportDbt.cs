using DbTool.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DbTool
{
    public partial class FrmExportDbt : Form
    {
        private IDbClass _dbClass = null;
        public FrmExportDbt(IDbClass dbclass)
        {
            InitializeComponent();
            _dbClass = dbclass;
        }
        private Thread _threadExport = null;

        private void AppendText(string msg)
        {
            this.Invoke(new Action(() =>
            {
                this.tbMsg.AppendText(msg + "\r\n");
            }));
        }
        private void MessageBoxEx(string msg)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(msg);
            }));
        }
        private void SetProgress(int val)
        {
            this.Invoke(new Action(() =>
            {
                this.proBar.Value = val;
            }));
        }
        private void EndExport()
        {
            this.Invoke(new Action(() =>
            {
                btnStartExport.Enabled = true;
                btnView.Enabled = true;
            }));
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.tbPath.Text = saveFileDialog.FileName;
                AppendText("数据库文件：" + this.tbPath.Text);
            }
        }

        private void FrmExportDbt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_threadExport != null && _threadExport.IsAlive)
            {
                if (MessageBox.Show(this, "正在导入数据库文件,是否终止导入？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    e.Cancel = true;
                    _threadExport.Abort();
                }
            }
        }

        private void btnStartExport_Click(object sender, EventArgs e)
        {
            proBar.Value = 0;
            btnStartExport.Enabled = false;
            btnView.Enabled = false;
            _threadExport = new Thread(new ThreadStart(() =>
            {
                try
                {
                    using (DbTFileWriter writer=new DbTFileWriter(this.tbPath.Text))
                    {
                        writer.ProgressChanged += writer_ProgressChanged;
                        writer.WriteDb(_dbClass, 
                            cbTable.Checked,
                            cbContras.Checked,
                            cbSequence.Checked,
                            cbTrigger.Checked,
                            cbIndex.Checked,
                            cbFunction.Checked,
                            cbProcedure.Checked,
                            cbJavaSource.Checked,
                            cbData.Checked);
                        writer.ProgressChanged -= writer_ProgressChanged;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBoxEx("导入异常：" + ex.Message);
                    AppendText("导入异常：" + ex.Message + "\r\n" + ex.StackTrace);
                }
                finally
                {
                    EndExport();
                }
            }));
            _threadExport.IsBackground = true;
            _threadExport.Start();
        }

        void writer_ProgressChanged(object sender, ProgressChangedArgs e)
        {
            if (e.Progress >= 0&&e.Progress<=100)
            {
                SetProgress(e.Progress);
            }
            if (!string.IsNullOrWhiteSpace(e.Msg))
            {
                AppendText(e.Msg);
            }
        }
    }
}
