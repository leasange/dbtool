using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using DbTool.DbClasses.Oracle;

namespace DbTool.DbClasses
{
    public class OracleTableClass : ITableClass
    {
        public object table_name;
        public object tablespace_name;
        public object pct_free;
        public object pct_used;
        public object pct_increase;
        public object ini_trans;
        public object max_trans;
        public object initial_extent;
        public object next_extent;
        public object min_extents;
        public object max_extents;
        public object buffer_pool;
        public object comments;
        public string Comments
        {
            get { return Convert.ToString(comments); }
        }
        private List<OracleTableColClass> columns = new List<OracleTableColClass>();//列
        public List<OracleTableColClass> Columns
        {
            get {
                DoLoadCols();
                return columns;
            }
        }
        
        public ITableColClass this[string columnName]
        {
            get
            {
                //columnName = columnName.ToUpper();
                return this.Columns.Find(m => m.Name == columnName);
            }
        }
        private bool _isLoadConstraints = false;
        public List<OracleTableConstraintsClass> constraints = new List<OracleTableConstraintsClass>();//约束
        public List<OracleTableConstraintsClass> Constraints
        {
            get 
            {
                DoLoadConstraints();
                return constraints;
            }
        }
        private MyDbType _dbType = MyDbType.Oracle;
        private OracleODACHelper _helper = null;
        public DbTool.DbClasses.MyDbType DbType
        {
            get { return _dbType; }
        }

        public OracleTableClass()
        {

        }

        public OracleTableClass(DataRow table)
        {
            LoadNormal(table);
        }
        public void SetOracleHelper(OracleODACHelper helper)
        {
            _helper = helper;
        }

        public void LoadNormal(DataRow table)
        {
            Type type = this.GetType();
            foreach (FieldInfo fi in type.GetFields())
            {
                try
                {
                    fi.SetValue(this, table[fi.Name.ToUpper()]);
                }
                catch (System.Exception ex) { }
            }
        }

        public void LoadCols(DataTable columns)
        {
            Type type = typeof(OracleTableColClass);
            foreach (DataRow item in columns.Rows)
            {
                OracleTableColClass occ = new OracleTableColClass();
                foreach (FieldInfo fi in type.GetFields())
                {
                    try
                    {
                        fi.SetValue(occ, item[fi.Name.ToUpper()]);
                    }
                    catch (System.Exception ex) { }
                }
                this.columns.Add(occ);
            }
        }

        public OracleTableClass(DataRow table, DataTable columns)
        {
            LoadNormal(table);
            LoadCols(columns);
        }

        private void DoLoadCols()
        {
            if (_helper != null && columns.Count == 0)
            {
                string sql = "select t.COLUMN_NAME,t.DATA_TYPE,t.DATA_LENGTH,t.DATA_PRECISION,t.DATA_SCALE,t.NULLABLE,t.DATA_DEFAULT,t1.comments  from user_tab_columns t left join user_col_comments t1 on t.TABLE_NAME=t1.table_name and t.COLUMN_NAME=t1.column_name where t.table_name = '" + table_name + "' order by t.COLUMN_ID";
                DataTable dt = _helper.ExecuteDataTable(sql);
                LoadCols(dt);
               
            }
        }
        private void DoLoadConstraints()
        {
            if (_helper != null && constraints.Count == 0 && !_isLoadConstraints)
            {
                string sql = "select a.constraint_name,a.table_name,a.column_name,b.constraint_type,b.status,b.index_name from user_cons_columns a,user_constraints b where a.table_name=b.table_name and a.constraint_name=b.constraint_name and a.position=1 and a.table_name='" + table_name + "'";
                DataTable dt = _helper.ExecuteDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    OracleTableConstraintsClass otcc = new OracleTableConstraintsClass(item);
                    constraints.Add(otcc);
                }
                _isLoadConstraints = true;
            }
        }
        internal string GetObjectString(object obj)
        {
            return Convert.ToString(obj);
        }
        /*
            -- Create table
            create table KK_ALARM_SCALE
            (
              PK              NUMBER(20) not null,
              RELATED_MONITOR NUMBER(20),
              ENTITY          NUMBER(20)
            )
            tablespace PAHF
              pctfree 10
              initrans 1
              maxtrans 255
              storage
              (
                initial 64
                minextents 1
                maxextents unlimited
              );
          -- Add comments to the table 
            comment on table KK_ALARM_SCALE
              is '报警通知范围';
            -- Add comments to the columns 
            comment on column KK_ALARM_SCALE.PK
              is '主键';
            comment on column KK_ALARM_SCALE.RELATED_MONITOR
              is '关联布控ID';
            comment on column KK_ALARM_SCALE.ENTITY
              is '报警需要通知的实体的ID，包括单位、警员';
          */
        private static List<string> OracleReserveKeys = new List<string>()
        {
            "SIZE",
            "ROWS",
            "LEVEL"
        };

        public List<ITableColClass> GetColumns()
        {
            List<ITableColClass> cols= new List<ITableColClass>();
            cols.AddRange(this.Columns.ToArray());
            return cols;
        }

        public static string GetOracleColumnName(string orginName) 
        {
            //避免Oracle关键字作为列名
            if (OracleReserveKeys.Contains(orginName.ToUpper()))
            {
                orginName = "\"" + orginName + "\"";
            }
            return orginName;
        }
        public List<CreateSqlObject> GetCreateOracleSql(string tableSpace = null)
        {
            DoLoadCols();
            List<CreateSqlObject> list = new List<CreateSqlObject>();
            if (string.IsNullOrWhiteSpace(GetObjectString(table_name)))
            {
                return list;
            }
            string tbsp = string.IsNullOrWhiteSpace(tableSpace) ? Convert.ToString(tablespace_name) : tableSpace;
            StringBuilder sb = new StringBuilder();
            CreateSqlObject table = new CreateSqlObject();
            table.comment = "创建表" + table_name;
            sb.AppendLine("create table " + table_name);
            sb.AppendLine("(");
            
            for (int i = 0; i < columns.Count; i++)
            {
                OracleTableColClass item = (OracleTableColClass)columns[i];
                string dataType = Convert.ToString(item.data_type);
                string columnName = Convert.ToString(item.column_name);
                //避免Oracle关键字作为列名
                if (OracleReserveKeys.Contains(columnName.ToUpper()))
                {
                    columnName = "\"" +columnName+ "\"";
                }
                string temp = " " + columnName + "    ";

                if (dataType != "DATE" &&
                    dataType != "CLOB" &&
                    dataType != "NCLOB" &&
                    dataType != "BLOB" &&
                    dataType != "BFILE" &&
                    dataType != "ROWID" &&
                    dataType != "BINARY_DOUBLE"&&
                    dataType != "BINARY_FLOAT"&&
                    !dataType.StartsWith("INTERVAL DAY") &&
                    !dataType.StartsWith("INTERVAL YEAR") &&
                    !dataType.StartsWith("TIMESTAMP"))
                {
                    string data_precision = Convert.ToString(item.data_precision);
                    string data_scale = Convert.ToString(item.data_scale);
                    string data_length = Convert.ToString(item.data_length);
                    int precision = -1, scale = -1, length = -1;
                    int.TryParse(data_precision, out precision);
                    int.TryParse(data_scale, out scale);
                    int.TryParse(data_length, out length);

                    string tnum = "";
                    if (precision>0)
                    {
                        tnum += precision;
                        if (scale>0)
                        {
                            tnum += "," + scale;
                        }
                    }
                    else if (length > 0)
                    {
                        if (dataType=="NUMBER")
                        {
                            dataType = "INTEGER";
                        }
                        else if (dataType == "NVARCHAR2")
                        {
                            tnum += (length / 2);
                        }
                        else
                        {
                            tnum += length;
                        }
                    }

                    if (tnum!="")
                    {
                        tnum = "(" + tnum + ")";
                    }
                    temp += dataType + tnum;
                }
                else
                {
                    temp += dataType;
                }

                if (!string.IsNullOrWhiteSpace(GetObjectString(item.data_default)))
                {
                    temp += " default " + item.data_default;
                }
                if (Convert.ToString(item.nullable) == "N")
                {
                    temp += " not null";
                }
                if (i != columns.Count - 1)
                {
                    temp += ",";
                }
                sb.AppendLine(temp);
            }
            sb.AppendLine(")");
            sb.AppendLine("tablespace " + tbsp);
            if (!string.IsNullOrWhiteSpace(GetObjectString(pct_free)))
            {
                sb.AppendLine("  pctfree " + pct_free);
            }
            if (!string.IsNullOrWhiteSpace(GetObjectString(ini_trans)))
            {
                sb.AppendLine("  initrans " + ini_trans);
            }
            if (!string.IsNullOrWhiteSpace(GetObjectString(max_trans)))
            {
                sb.AppendLine("  maxtrans " + max_trans);
            }
            sb.AppendLine("  storage");
            sb.AppendLine("  (");
            if (!string.IsNullOrWhiteSpace(GetObjectString(initial_extent)))
            {
                sb.AppendLine("    initial " + initial_extent);
            }
            if (!string.IsNullOrWhiteSpace(GetObjectString(min_extents)))
            {
                sb.AppendLine("    minextents " + min_extents);
            }
            int maxE = 0;
            int.TryParse(Convert.ToString(max_extents), out maxE);
            if (maxE == 0 || maxE == 2147483645)
            {
                sb.AppendLine("    maxextents unlimited");
            }
            else
            {
                sb.AppendLine("    maxextents " + max_extents);
            }
            sb.AppendLine("  )");

            table.sql = sb.ToString();
            list.Add(table);
            sb.Clear();
            if (!string.IsNullOrWhiteSpace(GetObjectString(comments)))
            {
                CreateSqlObject comontable = new CreateSqlObject(null, "创建表" + table_name + "的描述");
                sb.AppendLine("comment on table " + table_name + " is '" + comments + "'");
                comontable.sql = sb.ToString();
                list.Add(comontable);
            }
            foreach (OracleTableColClass item in columns)
            {
                if (string.IsNullOrWhiteSpace(GetObjectString(item.comments)))
                {
                    continue;
                }
                sb.Clear();
                CreateSqlObject comonclum = new CreateSqlObject(null, "添加表" + table_name + ".列" + item.column_name + "的描述");

                string columnName = Convert.ToString(item.column_name);
                //避免Oracle关键字作为列名
                if (OracleReserveKeys.Contains(columnName.ToUpper()))
                {
                    columnName = "\"" + columnName + "\"";
                }

                sb.AppendLine("comment on column " + table_name + "." + columnName + " is '" + item.comments + "'");
                comonclum.sql = sb.ToString();
                list.Add(comonclum);
            }
            return list;
        }

        public List<CreateSqlObject> GetCreateMySqlSql(string tableSpace = null)
        {
            DoLoadCols();
            throw new NotImplementedException();
        }

        public List<CreateSqlObject> GetCreateSqlServerSql(string tableSpace = null)
        {
            DoLoadCols();
            throw new NotImplementedException();
        }

        public string TableName
        {
            get { return Convert.ToString(table_name); }
        }

        #region IGetAttribute 成员

        public List<NameAliasValue> GetAttributes()
        {
            List<NameAliasValue> navs = new List<NameAliasValue>();
            // dr = dt.NewRow(); dr.ItemArray = new object[] { "所有者", user }; dt.Rows.Add(dr);
            navs.Add(new NameAliasValue()
            {
                Name = "table_name",
                AliasName = "表名称",
                Value = table_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "tablespace_name",
                AliasName = "表空间",
                Value = tablespace_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "pct_free",
                AliasName = "空闲(%)",
                Value = pct_free
            });

            int initialex = 65536;

            int.TryParse(Convert.ToString(this.initial_extent), out initialex);
            initialex = initialex / 1024;
            navs.Add(new NameAliasValue()
            {
                Name = "initial_extent",
                AliasName = "初始大小(kb)",
                Value = initialex
            });
            navs.Add(new NameAliasValue()
            {
                Name = "next_extent",
                AliasName = "下一个(byte)",
                Value = next_extent
            });
            navs.Add(new NameAliasValue()
            {
                Name = "pct_used",
                AliasName = "已用(%)",
                Value = pct_used
            });
            navs.Add(new NameAliasValue()
            {
                Name = "added",
                AliasName = "增加(%)",
                Value = ""
            });
            navs.Add(new NameAliasValue()
            {
                Name = "ini_trans",
                AliasName = "初始事务数",
                Value = ini_trans
            });
            navs.Add(new NameAliasValue()
            {
                Name = "min_extents",
                AliasName = "最小数量",
                Value = min_extents
            });
            navs.Add(new NameAliasValue()
            {
                Name = "max_trans",
                AliasName = "最大事务数",
                Value = max_trans
            });
            navs.Add(new NameAliasValue()
            {
                Name = "max_extents",
                AliasName = "最大数量",
                Value = max_extents
            });
            navs.Add(new NameAliasValue()
            {
                Name = "comments",
                AliasName = "描述",
                Value = comments
            });
            return navs;
        }

        #endregion

    }
    public class OracleTableColClass : ITableColClass
    {
        public string column_name;
        public object data_type;
        public object data_length;
        public object data_precision;
        public object data_scale;
        public object nullable;
        public object data_default;
        public object comments;
        public string Name
        {
            get { return column_name; }
        }
        public List<NameAliasValue> GetAttributes()
        {
            List<NameAliasValue> navs = new List<NameAliasValue>();
            navs.Add(new NameAliasValue()
            {
                Name = "column_name",
                AliasName="列名",
                Value = column_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "data_type",
                AliasName = "类型",
                Value = data_type
            });
            navs.Add(new NameAliasValue()
            {
                Name = "data_length",
                AliasName = "大小",
                Value = data_length
            });
            navs.Add(new NameAliasValue()
            {
                Name = "data_precision",
                AliasName = "位数",
                Value = data_precision
            });
            navs.Add(new NameAliasValue()
            {
                Name = "data_scale",
                AliasName = "有效位",
                Value = data_scale
            });
            navs.Add(new NameAliasValue()
            {
                Name = "nullable",
                AliasName = "是否可为空",
                Value = nullable
            });
            navs.Add(new NameAliasValue()
            {
                Name = "data_default",
                AliasName = "默认值",
                Value = data_default
            });
            navs.Add(new NameAliasValue()
            {
                Name = "comments",
                AliasName = "描述",
                Value = comments
            });
            return navs;
        }
    }
    //约束
    public class OracleTableConstraintsClass
    {
        //select a.constraint_name,a.table_name,a.column_name,b.constraint_type,b.status,b.index_name from user_cons_columns a,user_constraints b where a.table_name=b.table_name and a.constraint_name=b.constraint_name and a.position=1 and a.table_name='PT_CAMERA_INFO'
        public object constraint_name;
        public string table_name;
        public object column_name;
        public object constraint_type;
        public object status;
        public object index_name;
        public OracleTableConstraintsClass() { }
        public OracleTableConstraintsClass(DataRow dr)
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
        }
    }
}
