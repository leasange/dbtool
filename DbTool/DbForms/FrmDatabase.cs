using DbTool.DbClasses;
using DbTool.DbForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbTool
{
    public partial class FrmDatabase : Form
    {
        private IDbClass _dbClass = null;
        private DbConnectConfigure _dbConnectConfigure = null;
        public DbTool.DbForms.DbConnectConfigure DbConnectConfigure
        {
            get { return _dbConnectConfigure; }
            set 
            {
                CloseDb();
                if (value==null)
                {
                    _dbConnectConfigure = null;
                    return;
                }
                _dbConnectConfigure = value;
                SetTitle();
                try
                {
                    _dbClass = _dbConnectConfigure.GetDbClass();
                    ReInit();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("打开数据库异常：" + ex.Message);
                }
            }
        }
        public event EventHandler NewConnect = null;
        public FrmDatabase(IDbClass dbClass)
        {
            InitializeComponent();
            SetDbClass(dbClass);
        }

        internal void SetTitle()
        {
            if (_dbConnectConfigure!=null)
            {
              this.Text="当前连接数据库："+  _dbConnectConfigure.GetSimpleText();
            }
        }

        public void SetDbClass(IDbClass dbClass)
        {
            CloseDb();
            _dbClass = dbClass;
        }
        private void CloseDb()
        {
            if (_dbClass != null)
            {
                _dbClass.Close();
                _dbClass = null;
            }
        }
        //初始化
        private void ReInit()
        {
            sourceTree.SetDbClass(_dbClass);
        }

        private void FrmDatabase_Load(object sender, EventArgs e)
        {
            ReInit();
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            FrmOpenDb openDb = new FrmOpenDb();
            if (_dbClass!=null)
            {
                openDb.SetDbType(_dbClass.GetClassDbType(), true);
                openDb.DbConnectConfigure = _dbConnectConfigure;
            }
            DialogResult dr = openDb.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }
            else
            {
                CloseDb();
                _dbConnectConfigure = openDb.DbConnectConfigure;
                SetTitle();
                if (dr==DialogResult.OK)
                {
                    SetDbClass(openDb.DbClass);
                    ReInit();
                }
                else
                {
                    this.DbConnectConfigure = _dbConnectConfigure;
                }
                if (NewConnect!=null)
                {
                    NewConnect(this, e);
                }
            }
        }

        private void tsmiSqlWin_Click(object sender, EventArgs e)
        {
            FrmSqlWin sqlWin = new FrmSqlWin(_dbClass);
            FrmMain.Main.ShowOrActiveForm(sqlWin);
        }

        private void sourceTree_EventSource(object sender, EventSourceTreeArgs e)
        {
            switch (e.EventSourceType)
            {
                case EventSourceType.Open:
                    {
                        ITableClass table = e.SourceObject as ITableClass;
                        if (table != null)
                        {
                            FrmTableView tableView = new FrmTableView(_dbClass, table, _dbConnectConfigure.GetSimpleText());
                            FrmMain.Main.ShowOrActiveForm(tableView);
                        }
                        else
                        {
                            string text = "查看";
                            switch (e.TreeNodeType)
                            {
                                case SourceTree.TreeNodeType.TRIGGER:
                                    text += "触发器";
                                    break;
                                case SourceTree.TreeNodeType.SEQUENCE:
                                    text += "序列";
                                    break;
                                case SourceTree.TreeNodeType.FUNCTION:
                                    text += "函数";
                                    break;
                                case SourceTree.TreeNodeType.PROCEDURE:
                                    text += "过程";
                                    break;
                                case SourceTree.TreeNodeType.JAVASOURCE:
                                    text += "JAVA资源";
                                    break;
                                default:
                                    break;
                            }
                            if (e.SourceObject is IGetAttribute)
                            {
                                text += ":" + ((IGetAttribute)e.SourceObject).Name;
                            }
                            FrmNormalView normalView = new FrmNormalView(_dbClass, e.SourceObject, text);
                            FrmMain.Main.ShowOrActiveForm(normalView);
                        }
                    }
                    break;
                case EventSourceType.Select:
                    break;
                case EventSourceType.Insert:
                    break;
                case EventSourceType.Update:
                    break;
                case EventSourceType.Delete:
                    break;
                default:
                    break;
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            if (_dbClass == null)
            {
                MessageBox.Show("请打开数据库！");
                return;
            }
            FrmExportDbt export = new FrmExportDbt(_dbClass);
            export.ShowDialog(this);
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            if (_dbClass == null)
            {
                MessageBox.Show("请打开数据库！");
                return;
            }
            FrmImportDbt import = new FrmImportDbt(_dbClass);
            import.ShowDialog(this);
        }
    }
}
