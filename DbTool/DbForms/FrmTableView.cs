using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbTool.DbClasses;
using System.Threading;

namespace DbTool.DbForms
{
    public partial class FrmTableView : Form
    {
        private IDbClass _dbClass = null;
        private ITableClass _table = null;
        public FrmTableView(IDbClass dbClass,ITableClass table,string parentTitle=null)
        {
            InitializeComponent();
            _dbClass = dbClass;
            _table = table;
            this.Text += "【" + _table.TableName + "】- " + parentTitle;
        }

        private void FrmTableView_Load(object sender, EventArgs e)
        {
            LoadNormal();
            LoadCols();
            LoadKeys();
            LoadIndexs();
        }
        //加载属性
        private void LoadNormal()
        {
            string user = _dbClass.GetCurrentUser();
            List<NameAliasValue> navs = _table.GetAttributes();
            NameAliasValue nav = new NameAliasValue()
            {
                Name = "user",
                AliasName = "当前用户",
                Value = user
            };
            navs.Insert(0, nav);
            dgvNormal.DataSource = NameAliasValue.ToDataTable(navs);
        }
        //加载列
        private void LoadCols()
        {
            List<ITableColClass> cols = _table.GetColumns();
            if (cols.Count > 0)
            {
                DataTable dt = NameAliasValue.ToDataTableX(cols.ToArray());
                dgvCol.DataSource = dt;
            }

        }
        //加载键
        public void LoadKeys()
        {
            List<IConstraintClass> ccs = _dbClass.GetConstraints(_table.TableName);
            if (ccs.Count>0)
            {
                DataTable dt = NameAliasValue.ToDataTableX(ccs.ToArray());
                dgvKeys.DataSource = dt;
            }
        }
        //加载索引
        private void LoadIndexs()
        {
            List<IIndexClass> ics = _dbClass.GetIndexs(_table.TableName);
            DataTable dt = NameAliasValue.ToDataTableX(ics.ToArray());
            dgvIndexs.DataSource = dt;
        }
        //加载数据
        private void LoadData(int start, int length)
        {
            List<DbData> datas = _dbClass.GetTableData(_table.TableName, start, length);
            DataTable dt = DbData.ToDataTable(datas);
            if (dgvData.Rows.Count == 0&&dgvData.Columns.Count==0)
            {
                foreach (DataColumn item in dt.Columns)
                {
                    dgvData.Columns.Add(item.ColumnName, item.Caption);
                }
            }
            this.Invoke(new Action(() =>
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dgvData, item.ItemArray);
                    dgvData.Rows.Add(dgvr);
                }
            }));
        }
        private void LoadSql()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CreateSqlObject.ToCollectionSqls(MyDbHelper.GetCreateSqlFunction(_table, _dbClass.GetClassDbType())(null)));

            List<IConstraintClass> ccs = _dbClass.GetConstraints(_table.TableName);
            foreach (IConstraintClass item in ccs)
            {
                sb.AppendLine(CreateSqlObject.ToCollectionSqls(
                    MyDbHelper.GetCreateSqlFunction(item, _dbClass.GetClassDbType())(null)
                    ));
            }
            List<IIndexClass> ics = _dbClass.GetIndexs(_table.TableName);
            foreach (IIndexClass item in ics)
            {
                sb.AppendLine(CreateSqlObject.ToCollectionSqls(
                    MyDbHelper.GetCreateSqlFunction(item, _dbClass.GetClassDbType())(null)
                    ));
            }
            tbSql.Text = sb.ToString().TrimEnd('\r', '\n');
        }

        private bool _bloadedData = false;
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageData)
            {
                if (!_bloadedData)
                {
                    _bloadedData = true;
                    if (dgvData.Rows.Count == 0)
                    {
                        LoadData(0, 50);
                    }
                }
            }
            if (tabControl.SelectedTab==tabPageSql)
            {
                LoadSql();
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            LoadData(dgvData.Rows.Count, 50);
        }

        private Thread _thread = null;
        private void btnAll_Click(object sender, EventArgs e)
        {
            if (_thread == null || !_thread.IsAlive)
            {
                btnMore.Enabled = false;
                btnAll.Enabled = false;
                lbLoading.Visible = true;
                _thread = new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            try
                            {
                                while (true)
                                {
                                    int count = dgvData.Rows.Count;
                                    LoadData(dgvData.Rows.Count, 50);
                                    int count1 = dgvData.Rows.Count;
                                    if (count1 - count < 50)
                                    {
                                        break;
                                    }
                                }
                            }
                            finally
                            {
                                this.Invoke(new Action(() =>
                                    {
                                        btnMore.Enabled = true;
                                        btnAll.Enabled = true;
                                        lbLoading.Visible = false;
                                    }));
                            }
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }));
                _thread.IsBackground = true;
                _thread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_thread != null && _thread.IsAlive)
                {
                    _thread.Abort();
                }
                btnMore.Enabled = true;
                btnAll.Enabled = true;
                lbLoading.Visible = false;
            }
            catch (Exception)
            {
            }

        }
    }
}
