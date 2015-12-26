using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using DbTool.DbClasses.Oracle;

namespace DbTool.DbClasses
{
    public class OracleDbClass : IDbClass
    {
        private bool _isLoadTabs = false;
        private List<OracleTableClass> _tables = new List<OracleTableClass>();
        public List<OracleTableClass> Tables
        {
            get 
            {
                GetTables();
                return _tables; 
            }
        }
        private bool _isLoadCons = false;
        private List<OracleConstraintClass> _constraints = new List<OracleConstraintClass>();
        public List<OracleConstraintClass> Constraints
        {
            get 
            {
                GetConstraints();
                return _constraints; 
            }
        }
        private bool _isLoadInds = false;
        private List<OracleIndexClass> _indexs = new List<OracleIndexClass>();
        public List<OracleIndexClass> Indexs
        {
            get
            {
                GetIndexs();
                return _indexs;
            }
        }
        private bool _isLoadSeqs = false;
        private List<OracleSequenceClass> _sequences = new List<OracleSequenceClass>();
        public List<OracleSequenceClass> Sequences
        {
            get 
            {
                GetSequences();
                return _sequences;
            }
        }
        private bool _isLoadTris = false;
        private List<OracleTriggerClass> _triggers = new List<OracleTriggerClass>();
        public List<OracleTriggerClass> Triggers
        {
            get
            {
                GetTriggers();
                return _triggers;
            }
        }
        private bool _isLoadSrcs = false;
        private List<OracleSourceClass> _sources = new List<OracleSourceClass>();
        public List<OracleSourceClass> Sources
        {
            get
            {
                GetSources();
                return _sources;
            }
        }
        private bool _isLoadViews = false;
        private List<OracleViewClass> _views = new List<OracleViewClass>();
        public List<OracleViewClass> Views
        {
            get 
            {
                GetViews();
                return _views;
            }
        }
        private bool _isLoadJobs = false;
        private List<OracleJobClass> _jobs = new List<OracleJobClass>();
        public List<OracleJobClass> Jobs
        {
            get
            {
                GetJobs();
                return _jobs;
            }
        }


        private OracleODACHelper _oracleHelper = null;
        private string _userName;
        public OracleDbClass(string connect)
        {
            _oracleHelper = new OracleODACHelper(connect);
        }
        public bool Open()
        {
            return _oracleHelper.Open();
        }
        public void Close()
        {
            _oracleHelper.Close();
        }
        //获取当前用户
        public string GetCurrentUser()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_userName))
                {
                    DataTable dt = _oracleHelper.ExecuteDataTable("select user from dual");
                    _userName = dt.Rows[0][0].ToString();
                }
            }
            catch (System.Exception ex)
            {

            }
            return _userName;
        }
        #region 接口
        public MyDbType GetClassDbType()
        {
            return MyDbType.Oracle;
        }
        public List<ITableClass> GetTables()
        {
            if (_tables.Count == 0 && !_isLoadTabs)
            {
                string sql = "select a.table_name,a.tablespace_name,a.pct_free,a.pct_used,a.pct_increase,a.ini_trans,a.max_trans,a.initial_extent,a.next_extent,a.min_extents,a.max_extents,a.buffer_pool,b.comments from user_tables a left join user_tab_comments b on a.table_name=b.table_name order by a.table_name";
                DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    OracleTableClass otc = new OracleTableClass(item);
                    otc.SetOracleHelper(_oracleHelper);
                    _tables.Add(otc);
                }
                _isLoadTabs = true;
            }
            List<ITableClass> t = new List<ITableClass>();
            t.AddRange(_tables);
            return t;
        }
        public ITableClass GetTable(string tableName)
        {
            List<ITableClass> tables = GetTables();
            return tables.Find(m => m.TableName == tableName);
        }

        public ulong GetTableDataCount(string tableName)
        {
            string sql = "select count(1) from " + tableName;
            DataTable dt = _oracleHelper.ExecuteDataTable(sql);
            return ulong.Parse(Convert.ToString(dt.Rows[0][0]));
        }
        public List<DbData> GetTableData(string tableName, int start = 0, int length = -1)
        {//select * from(select t.*,ROWNUM r from pt_oper_log t )where r>50 and r<=100

            string row="row"+Guid.NewGuid().ToString("N").Substring(24);
            //private string _sqlFormat = "select * from (select t.*, rownum {0} from ({1}) t where rownum <= {2}) where {0} > {3}";
            string sql = "select * from(select t.*,ROWNUM " + row + " from " + tableName + " t) where " + row + ">" + start;
            if (length>0)
            {
                sql += " and " + row + "<=" + (start + length);
            }
            DataTable dt = _oracleHelper.ExecuteDataTable(sql);
            List<DbData> datas = new List<DbData>();
            OracleTableClass otc = GetTable(tableName) as OracleTableClass;
            string[] tableColumnNames = new string[dt.Columns.Count-1];
            object[] tableColumnDbTypes = new object[dt.Columns.Count-1];
            Type[] tableColumnTypes = new Type[dt.Columns.Count-1];
            for (int i = 0; i < dt.Columns.Count-1; i++)
            {
                tableColumnNames[i] = dt.Columns[i].ColumnName;
                tableColumnTypes[i] = dt.Columns[i].DataType;
                if (otc != null)
                {
                    tableColumnDbTypes[i] = MyDbHelper.GetDbDataType(Convert.ToString(((OracleTableColClass)(otc[dt.Columns[i].ColumnName])).data_type), MyDbType.Oracle, MyDbType.Oracle);
                }
                else
                {
                    tableColumnDbTypes[i] = dt.Columns[i].DataType;
                }
            }
            foreach (DataRow item in dt.Rows)
            {
                TableDataRow tdr = new TableDataRow();
                tdr.dbType = MyDbType.Oracle;
                object[] tableValues = new object[dt.Columns.Count - 1];
                for (int i = 0; i <  dt.Columns.Count - 1; i++)
                {
                    tableValues[i] = item.ItemArray[i];
                }
                DbData dbData = new DbData(MyDbType.Oracle, tableName, tableColumnNames, tableColumnTypes, tableColumnDbTypes, tableValues);
                datas.Add(dbData);
            }
            return datas;
        }

        public List<IConstraintClass> GetConstraints()
        {
            if (_constraints.Count == 0 && !_isLoadCons)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" create or replace function user_cons_long_2_varchar(p_table_name in user_constraints.constraint_name%type)");
                sb.Append("  return varchar2 as");
                sb.Append("  l_search_condition LONG;");
                sb.Append(" begin");
                sb.Append("  select search_condition");
                sb.Append("    into l_search_condition");
                sb.Append("  from user_constraints");
                sb.Append("  where constraint_name = p_table_name;");
                sb.Append(" return substr(l_search_condition, 1, 40000);");
                sb.Append(" end;");
                _oracleHelper.ExecuteSql(sb.ToString());//添加函数
                string sql = "select t.constraint_name,t.constraint_type,t.table_name,user_cons_long_2_varchar(t.constraint_name) as search_condition,t.r_constraint_name,t.delete_rule,t.status,t.validated,t.index_name from user_constraints t,user_tables t1 where t.table_name=t1.table_name and generated='USER NAME'  order by t.constraint_name";
                DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                _oracleHelper.ExecuteSql("drop function user_cons_long_2_varchar");

                foreach (DataRow item in dt.Rows)
                {
                    OracleConstraintClass occ = new OracleConstraintClass(item);
                    occ.SetOracleHelper(_oracleHelper);
                    _constraints.Add(occ);
                }
                _isLoadCons = true;
            }
            List<IConstraintClass> t = new List<IConstraintClass>();
            t.AddRange(_constraints);
            return t;
        }
        public List<IConstraintClass> GetConstraints(string tableName)
        {
            List<IConstraintClass> ccs = GetConstraints();
            return ccs.FindAll(m => m.Table_Name == tableName);
        }
        public List<IIndexClass> GetIndexs()
        {
            if (_indexs.Count == 0 && !_isLoadInds)
            {
                string sql = "select * from user_indexes where index_type='NORMAL' and dropped='NO'";
                DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    OracleIndexClass oic = new OracleIndexClass(item);
                    oic.SetOracleHelper(_oracleHelper);
                    _indexs.Add(oic);
                }
                _isLoadInds = true;
            }
            List<IIndexClass> t = new List<IIndexClass>();
            t.AddRange(_indexs);
            return t;
        }
        public List<IIndexClass> GetIndexs(string tableName)
        {
            List<IIndexClass> ic = GetIndexs();
            return ic.FindAll(m => m.Table_Name == tableName);
        }
        public List<ISequenceClass> GetSequences()
        {
            if (_sequences.Count == 0 && !_isLoadSeqs)
            {
                DataTable dt = _oracleHelper.ExecuteDataTable("select * from user_sequences order by sequence_name");
                foreach (DataRow item in dt.Rows)
                {
                    OracleSequenceClass osc = new OracleSequenceClass(item);
                    _sequences.Add(osc);
                }
                _isLoadSeqs = true;
            }
            List<ISequenceClass> t = new List<ISequenceClass>();
            t.AddRange(_sequences);
            return t;
        }
        public List<ITriggerClass> GetTriggers()
        {
            if (_triggers.Count == 0 && !_isLoadTris)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" create or replace function user_tris_long_2_varchar(p_trigger_name in user_triggers.trigger_name%type)");
                sb.Append("  return varchar2 as");
                sb.Append("  l_trigger_body LONG;");
                sb.Append("  begin");
                sb.Append("   select trigger_body");
                sb.Append("     into l_trigger_body");
                sb.Append("    from user_triggers");
                sb.Append("   where trigger_name = p_trigger_name;");
                sb.Append("   return substr(l_trigger_body, 1, 40000);");
                sb.Append("   end;");

                _oracleHelper.ExecuteSql(sb.ToString());
                DataTable dt = _oracleHelper.ExecuteDataTable("select t1.trigger_name,t1.trigger_type,t1.triggering_event,t1.table_owner,t1.base_object_type,t1.table_name,t1.column_name,t1.referencing_names,t1.when_clause,t1.status,t1.description,t1.action_type,user_tris_long_2_varchar(t1.trigger_name) as trigger_body from user_triggers t1,user_tables t2 where t1.table_name=t2.table_name");
                _oracleHelper.ExecuteSql("drop function user_tris_long_2_varchar");
                foreach (DataRow item in dt.Rows)
                {
                    OracleTriggerClass otc = new OracleTriggerClass(item);
                    _triggers.Add(otc);
                }
                _isLoadTris = true;
            }
            List<ITriggerClass> t = new List<ITriggerClass>();
            t.AddRange(_triggers);
            return t;
        }
        public List<ISourceClass> GetSources()
        {
            if (_sources.Count==0&&!_isLoadSrcs)
            {
                DataTable dt = _oracleHelper.ExecuteDataTable("select * from user_source order by name,type,line");
                int start = -1;
                int end = -1;
                string temp = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow item = dt.Rows[i];
                    if (temp == null)
                    {
                        temp = Convert.ToString(item["NAME"]);
                        start = i;
                    }
                    else if (temp != Convert.ToString(item["NAME"]))
                    {
                        end = i - 1;

                        OracleSourceClass osc = new OracleSourceClass(dt, start, end);
                        _sources.Add(osc);

                        temp = Convert.ToString(item["NAME"]);
                        start = i;
                    }
                    if (i==dt.Rows.Count-1)
                    {
                        end = dt.Rows.Count - 1;
                        OracleSourceClass osc = new OracleSourceClass(dt, start, end);
                        _sources.Add(osc);
                    }
                }
                _isLoadSrcs = true;
            }
            List<ISourceClass> t = new List<ISourceClass>();
            t.AddRange(_sources);
            return t;
        }
        public List<IJavaSourceClass> GetJavaSources()
        {
            GetSources();
            List<IJavaSourceClass> javas = new List<IJavaSourceClass>();
            javas.AddRange(_sources.FindAll(m => m.type == "JAVA SOURCE"));
            return javas;
        }
        public List<IFunctionClass> GetFunctions()
        {
            GetSources();
            List<IFunctionClass> fucs=new List<IFunctionClass>();
            fucs.AddRange(_sources.FindAll(m => m.type == "FUNCTION"));
            return fucs;
        }
        public List<IProcedureClass> GetProcedures()
        {
            GetSources();
            List<IProcedureClass> pros = new List<IProcedureClass>();
            pros.AddRange(_sources.FindAll(m => m.type == "PROCEDURE"));
            return pros;
        }
        public string GetDbVersionString()
        {
            string sql = "select banner from v$version";
            DataTable dt = _oracleHelper.ExecuteDataTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                string str = item[0].ToString();
                return str;
            }
            return "Oracle Database";
        }
        public string GetCurrentTableSpaceName()
        {
            string sql = "select default_tablespace from user_users";
            DataTable dt = _oracleHelper.ExecuteDataTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                string str = item[0].ToString();
                return str;
            }
            return "";
        }
        public List<IViewClass> GetViews()
        {
            if (_views.Count == 0 && !_isLoadViews)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("create or replace function user_viwes_long_2_varchar(p_view_name in user_views.view_name%type) ");
                sb.Append("return varchar2 as ");
                sb.Append("l_text LONG; ");
                sb.Append("begin ");
                sb.Append("select text ");
                sb.Append("into l_text ");
                sb.Append("from user_views ");
                sb.Append("where view_name = p_view_name; ");
                sb.Append("return substr(l_text, 1, 40000); ");
                sb.Append("end; ");
                _oracleHelper.ExecuteSql(sb.ToString());
                DataTable dt = _oracleHelper.ExecuteDataTable("select view_name,text_length,user_viwes_long_2_varchar(view_name) as text,type_text_length,type_text,oid_text_length,oid_text,view_type_owner,view_type,superview_name from user_views");
                _oracleHelper.ExecuteSql("drop function user_viwes_long_2_varchar");
                foreach (DataRow item in dt.Rows)
                {
                    OracleViewClass ovc = new OracleViewClass(item);
                    _views.Add(ovc);
                }
                _isLoadViews = true;
            }
            List<IViewClass> t = new List<IViewClass>();
            t.AddRange(_views);
            return t;
        }

        public List<IJobClass> GetJobs()
        {
            if (_jobs.Count == 0 && !_isLoadJobs)
            {
                DataTable dt = _oracleHelper.ExecuteDataTable("select * from user_jobs");
                foreach (DataRow item in dt.Rows)
                {
                    OracleJobClass ojc = new OracleJobClass(item);
                    _jobs.Add(ojc);
                }
                _isLoadJobs = true;
            }
            List<IJobClass> t = new List<IJobClass>();
            t.AddRange(_jobs);
            return t;
        }

        public IDbHelper GetDbHelper()
        {
            return _oracleHelper;
        }
        #endregion
        public new string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
