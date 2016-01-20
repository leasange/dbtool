using DbTool.DbClasses.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbTool.DbClasses
{
    public class OracleIndexClass : IIndexClass
    {
        public object index_name;
        public string Name
        {
            get { return Convert.ToString(index_name); }
        }
        public object index_type;//NORMAL
        public object table_name;
        public object table_type;
        public object uniqueness;//NONUNIQUE,UNIQUE,BITMAP
        public object compression;
        public object prefix_length;
        public object tablespace_name;
        public object ini_trans;
        public object max_trans;
        public object initial_extent;
        public object next_extent;
        public object min_extents;
        public object max_extents;
        public object pct_increase;
        public object pct_threshold;
        public object include_column;
        public object freelists;
        public object freelist_groups;
        public object pct_free;
        public object logging;
        public object blevel;
        public object leaf_blocks;
        public object distinct_keys;
        public object avg_leaf_blocks_per_key;
        public object avg_data_blocks_per_key;
        public object clustering_factor;
        public object status;
        public object num_rows;
        public object sample_size;
        public object last_analyzed;
        public object degree;
        public object instances;
        public object partitioned;
        public object temporary;
        public object generated;
        public object secondary;
        public object buffer_pool;
        public object user_stats;
        public object duration;
        public object pct_direct_access;
        public object ityp_owner;
        public object ityp_name;
        public object parameters;
        public object global_stats;
        public object domidx_status;
        public object domidx_opstatus;
        public object funcidx_status;
        public object join_index;
        public object iot_redundant_pkey_elim;
        public object dropped;
        private OracleODACHelper _oracleHelper = null;
        private bool _isLoadCols = false;
        private List<string> _column_names = new List<string>();
        public List<string> column_names
        {
            get 
            {
                DoLoadCulumns();
                return _column_names;
            }
        }
        public string Table_Name
        {
            get { return Convert.ToString(table_name); }
        }
        internal void DoLoadCulumns()
        {
            if (_oracleHelper != null && _column_names.Count == 0 && !_isLoadCols)
            {
                string sql = "select column_name from user_ind_columns where table_name='" + table_name + "' and index_name='" + index_name + "'";
                DataTable dt = _oracleHelper.ExecuteDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    _column_names.Add(Convert.ToString(item["COLUMN_NAME"]));
                }
                _isLoadCols = true;
            }
        }
        public OracleIndexClass() { }
        public OracleIndexClass(DataRow dr)
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
        /*
        create index IS_DEL on PT_CAMERA_INFO (IS_DEL)
          tablespace PAHF
          pctfree 10
          initrans 2
          maxtrans 255
          storage
          (
            initial 64K
            minextents 1
            maxextents unlimited
          );*/
        public List<CreateSqlObject> GetCreateOracleSql(string tableSpace = null)
        {
            DoLoadCulumns();
            StringBuilder sb = new StringBuilder();
            string cols = string.Join(",", _column_names);
            //uniqueness;//NONUNIQUE,UNIQUE,BITMAP
            string uniq = Convert.ToString(uniqueness);
            if (uniq == "UNIQUE")
            {
                sb.AppendLine("create unique index " + index_name + " on " + table_name + " (" + cols + ")");
            }
            else if (uniq == "BITMAP")
            {
                sb.AppendLine("create bitmap index " + index_name + " on " + table_name + " (" + cols + ")");
            }
            else
                sb.AppendLine("create index " + index_name + " on " + table_name + " (" + cols + ")");
            sb.Append(GetNoTopLineOracleSql(tableSpace));
            CreateSqlObject obj = new CreateSqlObject(sb.ToString(), "创建表" + table_name + "索引" + index_name);
            return new List<CreateSqlObject> { obj };
        }

        public string GetNoTopLineOracleSql(string tableSpace = null)
        {
            string tbsp = string.IsNullOrWhiteSpace(tableSpace) ? Convert.ToString(tablespace_name) : tableSpace;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  tablespace " + tbsp);
            if (!string.IsNullOrWhiteSpace(Convert.ToString(pct_free)))
            {
                sb.AppendLine("  pctfree " + pct_free);
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(ini_trans)))
            {
                sb.AppendLine("  initrans " + ini_trans);
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(max_trans)))
            {
                sb.AppendLine("  maxtrans " + max_trans);
            }
            sb.AppendLine("  storage");
            sb.AppendLine("  (");
            sb.AppendLine("  initial " + initial_extent);
            sb.AppendLine("  minextents " + min_extents);
            string max = Convert.ToString(max_extents);
            int imax = 0;
            int.TryParse(max, out imax);
            if (imax >= 2147483645 || imax == 0)
            {
                sb.AppendLine("  maxextents unlimited");
            }
            else
            {
                sb.AppendLine("  maxextents " + max_extents);
            }
            sb.Append(")");
            return sb.ToString();
        }

        public List<CreateSqlObject> GetCreateMySqlSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public List<CreateSqlObject> GetCreateSqlServerSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public void SetOracleHelper(OracleODACHelper oracleHelper)
        {
            _oracleHelper = oracleHelper;
        }

        public List<NameAliasValue> GetAttributes()
        {
            List<NameAliasValue> navs = new List<NameAliasValue>();
            navs.Add(new NameAliasValue()
            {
                Name = "index_name",
                AliasName = "名称",
                Value = index_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "uniqueness",
                AliasName = "类型",
                Value = uniqueness
            });
            navs.Add(new NameAliasValue()
            {
                Name = "column_names",
                AliasName = "列",
                Value =string.Join(",",column_names)
            });
            navs.Add(new NameAliasValue()
            {
                Name = "procedure",
                AliasName = "存储",
                Value = GetNoTopLineOracleSql().Replace("\r\n","")
            });
            return navs;
        }
    }
}
