using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using DbTool.DbClasses.Oracle;

namespace DbTool.DbClasses
{
    public class OracleConstraintClass:IConstraintClass
    {//owner	constraint_name	constraint_type	table_name	search_condition	r_owner	r_constraint_name	delete_rule	status	deferrable	deferred	validated	generated	bad	rely	last_change	index_owner	index_name	invalid	view_related
        public string constraint_name;
        public string constraint_type;//U:unique,P:primary,R:foreign,C check
        public object table_name;
        public object search_condition;
        public object status;
        public object validated;
        public object index_name;
        public object r_constraint_name;
        public object delete_rule;//NO ACTION,CASCADE,SET NULL
        private bool _isLoadCos = false;
        public int Level
        {
            get
            { 
                if (constraint_type!=null&&constraint_type=="R")
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }
        private OracleConstraintClass oracleConstraintClass = null;
        public OracleConstraintClass ConstraintClass
        {
            get 
            {
                DoLoadCons();
                return oracleConstraintClass; 
            }
            set
            {
                oracleConstraintClass = value;
            }
        }
        private bool _isLoadIndex = false;
        private OracleIndexClass oracleIndexClass = null;
        public OracleIndexClass IndexClass
        {
            get
            {
                DoLoadIndex();
                return oracleIndexClass;
            }
        }
        private OracleODACHelper _oracleHelper = null;
        private bool _isLoadCols = false;
        private List<string> _column_names = new List<string>();
        public List<string> Column_names
        {
            get 
            {
                DoLoadCols();
                return _column_names;
            }
            set
            {
                _column_names = value;
            }
        }

        public string Table_Name
        {
            get { return Convert.ToString(table_name); }
        }
        internal void DoLoadCols()
        {
            if (_oracleHelper != null && _column_names.Count == 0 && !_isLoadCols)
            {
                string sql = "select column_name from user_cons_columns where table_name='" + table_name + "' and constraint_name='" + constraint_name + "'";
                DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    _column_names.Add(Convert.ToString(item["COLUMN_NAME"]));
                }
                _isLoadCols = true;
            }
        }
        public string Name
        {
            get { return constraint_name; }
        }
        public OracleConstraintClass() { }
        public OracleConstraintClass(DataRow dr) 
        {
            Type type = this.GetType();
            foreach (FieldInfo fi in type.GetFields())
            {
                try
                {
                    fi.SetValue(this, dr[fi.Name.ToUpper()]);
                }
                catch (System.Exception ex) { }
            }
//             if(Convert.ToString(constraint_name)=="CKC_ID_PT_FIELD")
//             {
//                 System.Windows.Forms.MessageBox.Show(Convert.ToString(search_condition));
//             }
        }

        public void SetOracleHelper(OracleODACHelper oracleHelper)
        {
            _oracleHelper = oracleHelper;
        }

        internal void DoLoadIndex()
        {
            if (!_isLoadIndex)
            {
                string type = Convert.ToString(constraint_type);
                if (type != "R")//不是外键
                {
                    string indexName = Convert.ToString(index_name);
                    if (_oracleHelper != null && !string.IsNullOrWhiteSpace(indexName) && oracleIndexClass == null)
                    {
                        string sql = "select * from user_indexes where index_type='NORMAL' and dropped='NO' and index_name='" + index_name + "'";
                        DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            oracleIndexClass = new OracleIndexClass(dt.Rows[0]);
                        }
                    }
                }
                _isLoadIndex = true;
            }
        }
        internal void DoLoadCons()
        {
            if (!_isLoadCos)
            {
                string type = Convert.ToString(constraint_type);
                if (_oracleHelper != null && oracleConstraintClass == null && type == "R")
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
                    sb.Append(" return substr(l_search_condition, 1, 4000);");
                    sb.Append(" end;");
                    _oracleHelper.ExecuteSql(sb.ToString());//添加函数
                    string sql = "select t.constraint_name,t.constraint_type,t.table_name,user_cons_long_2_varchar(t.constraint_name) as search_condition,t.r_constraint_name,t.delete_rule,t.status,t.validated,t.index_name from user_constraints t,user_tables t1 where t.table_name=t1.table_name and generated='USER NAME' and constraint_name='" + r_constraint_name + "'";
                    DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                    _oracleHelper.ExecuteSql("drop function user_cons_long_2_varchar");
                    if (dt.Rows.Count > 0)
                    {
                        oracleConstraintClass = new OracleConstraintClass(dt.Rows[0]);
                        oracleConstraintClass.SetOracleHelper(_oracleHelper);
                    }
                }
                _isLoadCos = true;
            }
        }
        /*
        alter table PT_CAMERA_INFO
          add constraint PT_CAMERA_INFO_KEY primary key (ID);
        alter table PT_CAMERA_INFO
          add constraint CAMERA_NO_UNIQUE unique (CAMERA_NO);
        alter table PT_CAMERA_INFO
          add constraint PT_CAMERA_INFO_FOR foreign key (ORG_ID)
          references PT_ORG_INFO (ID) on delete set null;
         * */
        public List<CreateSqlObject> GetCreateOracleSql(string tableSpace = null)
        {
            DoLoadCols();
            DoLoadIndex();
            List<CreateSqlObject> list = new List<CreateSqlObject>();
            if (_column_names.Count==0)
            {
                return list;
            }
            string type = Convert.ToString(constraint_type);
            string indexName = Convert.ToString(index_name);
            if (type == "R")//不是外键
            {
                if (oracleConstraintClass == null)
                {
                    return list;
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("alter table " + table_name);
            string temp = " primary key ";
            if (type == "P")
            {
                temp = " primary key ";
            } 
            else if (type=="U")
            {
                temp = " unique ";
            }
            else if (type=="R")
            {
                temp = " foreign key ";
            }
            else if (type=="C")
            {
                temp = " check ";
            }
            if (type == "C")
            {
                sb.Append("  add constraint " + constraint_name + temp + "(" + search_condition + ")");
            }
            else
            {
                sb.Append("  add constraint " + constraint_name + temp + "(" + string.Join(",", _column_names) + ")");
            }
            if (type=="R")
            {
                sb.AppendLine();
                sb.Append("  references " + oracleConstraintClass.table_name + " (" + string.Join(",", oracleConstraintClass.Column_names) + ") on delete " + delete_rule);
            }
            else if (type == "P" && !string.IsNullOrWhiteSpace(indexName) && oracleIndexClass != null)
            {
                sb.AppendLine();
                sb.AppendLine("  using index ");
                sb.Append(oracleIndexClass.GetNoTopLineOracleSql(tableSpace));
            }
            CreateSqlObject obj = new CreateSqlObject(sb.ToString(), "创建表" + table_name + "约束" + constraint_name);
            list.Add(obj);
            return list;
        }

        public List<CreateSqlObject> GetCreateMySqlSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public List<CreateSqlObject> GetCreateSqlServerSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public List<NameAliasValue> GetAttributes()
        {
            List<NameAliasValue> navs = new List<NameAliasValue>();
            navs.Add(new NameAliasValue()
            {
                Name = "constraint_name",
                AliasName = "名称",
                Value = constraint_name
            });
            //U:unique,P:primary,R:foreign,C check
            string type = "";
            switch (constraint_type)
            {
                case "U": type = "unique"; break;
                case "P": type = "primary"; break;
                case "R": type = "foreign"; break;
                case "C": type = "check"; break;
                default:
                    break;
            }
            navs.Add(new NameAliasValue()
            {
                Name = "constraint_type",
                AliasName = "类型",
                Value = type
            });
            navs.Add(new NameAliasValue()
            {
                Name = "constraint_type",
                AliasName = "列",
                Value = string.Join(",",Column_names)
            });
            navs.Add(new NameAliasValue()
            {
                Name = "search_condition",
                AliasName = "检查",
                Value = search_condition
            }); 
            navs.Add(new NameAliasValue()
            {
                Name = "status",
                AliasName = "状态",
                Value = status
            });
            navs.Add(new NameAliasValue()
            {
                Name = "r_constraint_name",
                AliasName = "参照约束",
                Value = r_constraint_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "r_table_name",
                AliasName = "参照表",
                Value =ConstraintClass==null?"": ConstraintClass.Table_Name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "r_table_cols",
                AliasName = "参照列",
                Value = ConstraintClass==null?"":string.Join(",",ConstraintClass.Column_names)
            });
            navs.Add(new NameAliasValue()
            {
                Name = "delete_rule",
                AliasName = "级联删除",
                Value = delete_rule
            });
            return navs;
        }

    }
}
