using DbTool.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DbTool
{
    public partial class FrmImportDbt : Form
    {
        private IDbClass _dbClass=null;
        private Thread _threadImport = null;
        private DbTool.DbClasses.DbTFileReader.ReadToDbExceptionHandle ReadToDbAction = null; 
        public FrmImportDbt(IDbClass dbClass)
        {
            InitializeComponent();
            _dbClass = dbClass;
            ReadToDbAction = new DbTFileReader.ReadToDbExceptionHandle(DoReadToDbException);
        }

        private void AppendText(string msg)
        {
            this.Invoke(new Action(() =>
                {
                    this.tbMsg.AppendText(msg + "\r\n");
                }));
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.tbPath.Text = openFileDialog.FileName;
                AppendText("数据库文件：" + this.tbPath.Text);
            }
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
        private void EndImport()
        {
            this.Invoke(new Action(() =>
            {
                btnStartImport.Enabled = true;
                btnView.Enabled = true;
            }));
        }

        private bool DoReadToDbException(Exception ex)
        {
            bool ret =
                ex.Message.Contains("ORA-00955") ||//表已存在
                ex.Message.Contains("ORA-02260") ||
                ex.Message.Contains("ORA-02261") ||
                ex.Message.Contains("ORA-02264") ||  //已存在,两个主键
                ex.Message.Contains("ORA-00001")    //数据已存在
                ;

            return ret;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            proBar.Value = 0;
            btnStartImport.Enabled = false;
            btnView.Enabled = false;
            _threadImport = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        using (DbTFileReader reader = new DbTFileReader(this.tbPath.Text))
                        {
                            reader.ProgressChanged += reader_ProgressChanged;
                            reader.ReadToDb(_dbClass,ReadToDbAction,
                                   cbTable.Checked,
                                   cbContras.Checked,
                                   cbSequence.Checked,
                                   cbTrigger.Checked,
                                   cbIndex.Checked,
                                   cbFunction.Checked,
                                   cbProcedure.Checked,
                                   cbJavaSource.Checked,
                                   cbData.Checked);
                            reader.ProgressChanged -= reader_ProgressChanged;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBoxEx("导入异常：" + ex.Message);
                        AppendText("导入异常：" + ex.Message + "\r\n" + ex.StackTrace);
                    }
                    finally
                    {
                        EndImport();
                    }
                }));
            _threadImport.IsBackground = true;
            _threadImport.Start();
        }

        void reader_ProgressChanged(object sender, ProgressChangedArgs e)
        {
            if (e.Progress >= 0 && e.Progress <= 100)
            {
                SetProgress(e.Progress);
            }
            
            if (!string.IsNullOrWhiteSpace(e.Msg))
            {
                AppendText(e.Msg);
            }
        }

        private void FrmImportDbt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_threadImport != null && _threadImport.IsAlive)
            {
               if(MessageBox.Show(this,"正在导入数据库文件,是否终止导入？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
               {
                   e.Cancel = true;
                   _threadImport.Abort();
               }
            }
        }
    }
}
