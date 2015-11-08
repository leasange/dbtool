using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbTool.DbClasses;

namespace DbTool
{
    public partial class OracleManager : UserControl
    {
        private OracleDbClass _oracleDbClass = null;
        public OracleManager()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbConnectStr.Text))
            {
                MessageBox.Show("连接字符串不能为空！");
                return;
            }
            try
            {
                if (_oracleDbClass == null)
                {
                    _oracleDbClass = new OracleDbClass(this.tbConnectStr.Text.Trim());
                }

                if (btnConnect.Text == "断开")
                {
                    _oracleDbClass.Close();
                    _oracleDbClass = null;
                    btnConnect.Text = "连接";
                }
                else
                {
                    if (_oracleDbClass.Open())
                    {
                        btnConnect.Text = "断开";
                        LoadDataTree();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_oracleDbClass != null)
                {
                    _oracleDbClass.Close();
                    _oracleDbClass = null;
                }
            }
            
        }
        //加载树
        private void LoadDataTree()
        {
            tvDataTree.Nodes.Clear();
            LoadUserTables();
            LoadUserSeqs();
            LoadUserTris();
            LoadUserFunctions();
            LoadUserProcedures();
            LoadUserJavaSources();
            //             string t=_oracleDbClass.ToString();
            //             Newtonsoft.Json.JsonSerializerSettings s=new Newtonsoft.Json.JsonSerializerSettings();
            //             OracleDbClass dbc=Newtonsoft.Json.JsonConvert.DeserializeObject<OracleDbClass>(t);
        }

        //加载用户表
        private void LoadUserTables()
        {
            List<ITableClass> tableClasses = _oracleDbClass.GetTables();
            TreeNode tables = new TreeNode("所有表");
            tables.Tag = "TABLE";
            foreach (ITableClass item in tableClasses)
            {
                OracleTableClass oitem = (OracleTableClass)item;
                TreeNode table = new TreeNode(Convert.ToString(oitem.table_name));
                table.Tag = oitem;
                table.ToolTipText = Convert.ToString(oitem.comments);
                tables.Nodes.Add(table);
            }
            tvDataTree.Nodes.Add(tables);
        }
        private void LoadUserSeqs()
        {
            List<ISequenceClass> segs = _oracleDbClass.GetSequences();
            TreeNode tables = new TreeNode("所有序列");
            tables.Tag = "SEQUENCE";
            foreach (ISequenceClass item in segs)
            {
                OracleSequenceClass oitem = (OracleSequenceClass)item;
                TreeNode table = new TreeNode(Convert.ToString(oitem.sequence_name));
                table.Tag = oitem;
                tables.Nodes.Add(table);
            }
            tvDataTree.Nodes.Add(tables);
        }
        private void LoadUserTris()
        {
            List<ITriggerClass> triss = _oracleDbClass.GetTriggers();
            TreeNode tables = new TreeNode("所有触发器");
            tables.Tag = "TRIGGER";
            foreach (ITriggerClass item in triss)
            {
                OracleTriggerClass oitem = (OracleTriggerClass)item;
                TreeNode table = new TreeNode(Convert.ToString(oitem.trigger_name));
                table.Tag = oitem;
                tables.Nodes.Add(table);
            }
            tvDataTree.Nodes.Add(tables);
        }

        private void LoadUserFunctions()
        {
            List<IFunctionClass> triss = _oracleDbClass.GetFunctions();
            TreeNode tables = new TreeNode("所有函数");
            tables.Tag = "FUNCTION";
            foreach (IFunctionClass item in triss)
            {
                TreeNode table = new TreeNode(Convert.ToString(item.Name));
                table.Tag = item;
                tables.Nodes.Add(table);
            }
            tvDataTree.Nodes.Add(tables);
        }
        private void LoadUserProcedures()
        {
            List<IProcedureClass> triss = _oracleDbClass.GetProcedures();
            TreeNode tables = new TreeNode("所有过程");
            tables.Tag = "PROCEDURE";
            foreach (IProcedureClass item in triss)
            {
                TreeNode table = new TreeNode(Convert.ToString(item.Name));
                table.Tag = item;
                tables.Nodes.Add(table);
            }
            tvDataTree.Nodes.Add(tables);
        }
        private void LoadUserJavaSources()
        {
            List<IJavaSourceClass> triss = _oracleDbClass.GetJavaSources();
            TreeNode tables = new TreeNode("所有Java资源");
            tables.Tag = "JAVA SOURCE";
            foreach (IJavaSourceClass item in triss)
            {
                TreeNode table = new TreeNode(Convert.ToString(item.Name));
                table.Tag = item;
                tables.Nodes.Add(table);
            }
            tvDataTree.Nodes.Add(tables);
        }
        //加载表列
        internal void LoadTableCol(OracleTableClass otc)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("列名");
                dt.Columns.Add("类型");
                dt.Columns.Add("大小");
                dt.Columns.Add("精度");
                dt.Columns.Add("是否可为空");
                dt.Columns.Add("描述");

                foreach (OracleTableColClass item in otc.Columns)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = new object[] { item.column_name, item.data_type, item.data_length, item.data_precision, item.nullable, item.comments };
                    dt.Rows.Add(dr);
                }
                oracleView.TableView.TableColGrid.DataSource = dt;
                oracleView.TabControl.SelectedIndex = 0;
                oracleView.TabControl.TabPages[0].Text = "表【" + otc.TableName + "】";

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("加载表列异常：" + ex.Message);
            }

        }
        //加载普通属性
        internal void LoadTableNormal(OracleTableClass otc)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("名称"));
            dt.Columns.Add(new DataColumn("值"));
            string user = _oracleDbClass.GetCurrentUser();
            DataRow dr = null;
            int initialex = 65536;

            int.TryParse(Convert.ToString(otc.initial_extent), out initialex);
            initialex = initialex / 1024;

            dr = dt.NewRow(); dr.ItemArray = new object[] { "所有者", user }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "表名称", otc.table_name }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "表空间", otc.tablespace_name }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "空闲(%)", otc.pct_free }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "初始大小(kb)", initialex }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "下一个(byte)", otc.next_extent }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "已用(%)", otc.pct_used }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "增加(%)", "" }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "初始事务数", otc.ini_trans }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "最小数量", otc.min_extents }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "最大事务数", otc.max_trans }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "最大数量", otc.max_extents }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "描述", otc.comments }; dt.Rows.Add(dr);
            oracleView.TableView.TableNormalGrid.DataSource = dt;
        }
        //加载表SQL
        internal void LoadTableSql(OracleTableClass otc)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CreateSqlObject.ToCollectionSqls(otc.GetCreateOracleSql()));
            List<IConstraintClass> ccs = _oracleDbClass.GetConstraints(Convert.ToString(otc.table_name));
            foreach (IConstraintClass item in ccs)
            {
                sb.AppendLine(CreateSqlObject.ToCollectionSqls(item.GetCreateOracleSql()));
            }
            List<IIndexClass> ics = _oracleDbClass.GetIndexs(Convert.ToString(otc.table_name));
            foreach (IIndexClass item in ics)
            {
                sb.AppendLine(CreateSqlObject.ToCollectionSqls(item.GetCreateOracleSql()));
            }
            oracleView.TableView.TextSql.Text = sb.ToString().TrimEnd('\r', '\n');
        }
        //显示表详情
        private void ShowTableDetail(OracleTableClass otc)
        {
            oracleView.TableView.TableDataGrid.DataSource = null;
            oracleView.TableView.Table_name = otc.TableName;
            LoadTableNormal(otc);
            LoadTableCol(otc);
            LoadTableKeys(Convert.ToString(otc.table_name));
            LoadTableIndexs(Convert.ToString(otc.table_name));
            LoadTableSql(otc);
        }

        private void LoadTableKeys(string tableName)
        {
            List<IConstraintClass> ccs = _oracleDbClass.GetConstraints(tableName);
            DataTable dt = new DataTable();
            dt.Columns.Add("名称");
            dt.Columns.Add("类型");
            dt.Columns.Add("列");
            dt.Columns.Add("状态");
            dt.Columns.Add("参照表");
            dt.Columns.Add("参照列");
            dt.Columns.Add("级联删除");
            foreach (IConstraintClass item in ccs)
            {
                OracleConstraintClass oitem = (OracleConstraintClass)item;
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[]{
                    oitem.constraint_name,
                    oitem.constraint_type,
                    string.Join(",",oitem.Column_names),
                    oitem.status,
                    oitem.ConstraintClass==null?"":oitem.ConstraintClass.table_name,
                    oitem.ConstraintClass==null?"":string.Join(",",oitem.Column_names),
                    oitem.delete_rule
                };
                dt.Rows.Add(dr);
            }
            oracleView.TableView.TableKeysGrid.DataSource = dt;
        }
        private void LoadTableIndexs(string tableName)
        {
            List<IIndexClass> ics = _oracleDbClass.GetIndexs(tableName);
            DataTable dt = new DataTable();
            dt.Columns.Add("名称");
            dt.Columns.Add("类型");
            dt.Columns.Add("列");
            foreach (IIndexClass item in ics)
            {
                OracleIndexClass oitem = (OracleIndexClass)item;
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[]{
                    oitem.index_name,
                    oitem.uniqueness,
                    string.Join(",",oitem.column_names)
                };
                dt.Rows.Add(dr);
            }
            oracleView.TableView.TableIndexsGrid.DataSource = dt;
        }


        //显示序列
        private void ShowSequenceDetail(OracleSequenceClass osc)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("所有者");
            dt.Columns.Add("名称");
            dt.Columns.Add("增量");
            dt.Columns.Add("最小值");
            dt.Columns.Add("最大值");
            dt.Columns.Add("开始值");
            dt.Columns.Add("缓存大小");
            dt.Columns.Add("循环");
            dt.Columns.Add("排序");
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] {
                _oracleDbClass.GetCurrentUser(),
                osc.sequence_name,
                osc.increment_by,
                osc.min_value,
                osc.max_value,
                osc.last_number,
                osc.cache_size,
                osc.cycle_flag,
                osc.cache_size
            };
            dt.Rows.Add(dr);
            oracleView.SequenceView.TableNormalGrid.DataSource = dt;
            oracleView.TabControl.SelectedIndex = 1;
            oracleView.TabControl.SelectedTab.Text = "序列【" + osc.sequence_name + "】";
            oracleView.SequenceView.TextSql.Text = CreateSqlObject.ToCollectionSqls(osc.GetCreateOracleSql());
        }

        //显示触发器
        private void ShowTriggerDetail(OracleTriggerClass otc)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("所有者");
            dt.Columns.Add("名称");
            dt.Columns.Add("类型");
            dt.Columns.Add("事件");
            dt.Columns.Add("所属表名称");
            dt.Columns.Add("启动状态");
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] {
                _oracleDbClass.GetCurrentUser(),
                otc.trigger_name,
                otc.trigger_type,
                otc.triggering_event,
                otc.table_name,
                otc.status
            };
            dt.Rows.Add(dr);
            oracleView.TriggerView.TableNormalGrid.DataSource = dt;
            oracleView.TabControl.SelectedIndex = 2;
            oracleView.TabControl.SelectedTab.Text = "触发器【" + otc.trigger_name + "】";
            oracleView.TriggerView.TextSql.Text = CreateSqlObject.ToCollectionSqls(otc.GetCreateOracleSql());
        }

        //显示函数
        private void ShowFunctionDetail(int tabIndex, string tabName, SourceView sv, OracleSourceClass osc)
        {
            oracleView.TabControl.SelectedIndex = tabIndex;
            oracleView.TabControl.SelectedTab.Text = tabName + "【" + osc.name + "】";
            sv.TextSql.Text = CreateSqlObject.ToCollectionSqls(osc.GetCreateOracleSql());
        }

        private void tvDataTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.IsSelected)
            {
                tvDataTree.SelectedNode = e.Node;
            }
        }

        private void tvDataTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                TreeNode t = e.Node.Parent;
                if (t.Tag.ToString() == "TABLE")//表
                {
                    TreeNode table = e.Node;
                    OracleTableClass otc = (OracleTableClass)table.Tag;
                    ShowTableDetail(otc);
                }
                else if (t.Tag.ToString() == "SEQUENCE")//序列
                {
                    TreeNode seq = e.Node;
                    OracleSequenceClass osc = (OracleSequenceClass)seq.Tag;
                    ShowSequenceDetail(osc);
                }
                else if (t.Tag.ToString() == "TRIGGER")//触发器
                {
                    TreeNode tri = e.Node;
                    OracleTriggerClass otc = (OracleTriggerClass)tri.Tag;
                    ShowTriggerDetail(otc);
                }
                else if (t.Tag.ToString() == "FUNCTION")//函数
                {
                    TreeNode tri = e.Node;
                    OracleSourceClass osc = (OracleSourceClass)tri.Tag;
                    ShowFunctionDetail(3, "函数", oracleView.FunctionView, osc);
                }
                else if (t.Tag.ToString() == "PROCEDURE")//过程
                {
                    TreeNode tri = e.Node;
                    OracleSourceClass osc = (OracleSourceClass)tri.Tag;
                    ShowFunctionDetail(4, "过程", oracleView.ProcedureView, osc);
                }
                else if (t.Tag.ToString() == "JAVA SOURCE")//Java资源
                {
                    TreeNode tri = e.Node;
                    OracleSourceClass osc = (OracleSourceClass)tri.Tag;
                    ShowFunctionDetail(5, "Java资源", oracleView.JavaSourceView, osc);
                }
            }
        }

        private void oracleView_LoadDataEvent(object sender, LoadDataEventArgs e)
        {
            List<DbData> dbDatas = _oracleDbClass.GetTableData(oracleView.TableView.Table_name, e.Start, e.Length);
            if (dbDatas.Count > 0)
            {
                DataTable dt = new DataTable();
                foreach (string item in dbDatas[0].TableDataRow.tableColumnNames)
                {
                    DataColumn dc = new DataColumn(item);
                    dt.Columns.Add(dc);
                }

                foreach (DbData item in dbDatas)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = item.TableDataRow.TableValues;
                    dt.Rows.Add(dr);
                }
                e.RetTable = dt;
            }
        }

        private void tsmiExportDb_Click(object sender, EventArgs e)
        {
            if (_oracleDbClass == null)
            {
                MessageBox.Show("请打开数据库！");
                return;
            }
            FrmExportDbt export = new FrmExportDbt(_oracleDbClass);
            export.ShowDialog(this);
        }

        private void tsmiImportDb_Click(object sender, EventArgs e)
        {
            if (_oracleDbClass == null)
            {
                MessageBox.Show("请打开数据库！");
                return;
            }
            FrmImportDbt import = new FrmImportDbt(_oracleDbClass);
            import.ShowDialog(this);
        }

        private void tsmiCreateSqlWin_Click(object sender, EventArgs e)
        {
            if (_oracleDbClass == null)
            {
                MessageBox.Show("请打开数据库！");
                return;
            }
            FrmSqlWin win = new FrmSqlWin(_oracleDbClass);
            win.MdiParent = this.ParentForm.MdiParent;
            win.Show();
        }
    }
}
