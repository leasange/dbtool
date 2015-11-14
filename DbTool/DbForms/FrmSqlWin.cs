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
    public partial class FrmSqlWin : Form
    {
        private IDbClass _dbClass = null;
        public FrmSqlWin(IDbClass dbClass)
        {
            InitializeComponent();
            _dbClass = dbClass;
            dataView.DbClass = _dbClass;
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            string text = this.tbSql.Text;
            if (tbSql.TextEditor.SelectionLength >0)
            {
                text = tbSql.TextEditor.SelectedText;
            }
            text = text.Trim();
            text = text.TrimEnd(';',' ');
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("输入/选择SQL为空！");
                return;
            }
            dataView.SetSql(text);
            bool isLast=false;
            dataView.ExcuteMore(ref isLast);
            tsbMore.Enabled = !isLast;
            tsbAll.Enabled = !isLast;
        }

        private void tspMore_Click(object sender, EventArgs e)
        {
            bool isLast=false;
            dataView.ExcuteMore(ref isLast);
            tsbMore.Enabled = !isLast;
            tsbAll.Enabled = !isLast;
        }
        private void UpdateLoading(bool isloading)
        {
            this.Invoke(new Action(() =>
                {
                    tsbQuery.Enabled = !isloading;
                    tsbMore.Enabled = !isloading;
                    tsbAll.Enabled = !isloading;
                    tsbStop.Enabled = isloading;
                    tslLoading.Visible = isloading;
                }));
        }
        private Thread _threadQuery = null;
        private void tsbAll_Click(object sender, EventArgs e)
        {
            UpdateLoading(true);
            if (_threadQuery==null||!_threadQuery.IsAlive)
            {
                _threadQuery = new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            try
                            {
                                dataView.ExcuteAll();
                            }
                            catch (Exception)
                            { }
                            finally
                            {
                                UpdateLoading(false);
                            }
                        }
                        catch (Exception)
                        {}
                    }));
                _threadQuery.IsBackground = true;
                _threadQuery.Start();
            }
            
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            if (_threadQuery != null &&_threadQuery.IsAlive)
            {
                try
                {
                    _threadQuery.Abort();
                }
                catch (Exception)
                {}
                UpdateLoading(false);
            }
        }
    }
}
