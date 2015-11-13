using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbTool.DbClasses
{
    public class OracleTriggerClass : ITriggerClass
    {
        public object trigger_name;
        public object trigger_type;
        public object triggering_event;
        public object table_owner;
        public object base_object_type;
        public object table_name;
        public object column_name;
        public object referencing_names;
        public object when_clause;
        public object status;
        public object description;
        public object action_type;
        public object trigger_body;
        public string Name { get { return Convert.ToString(trigger_name); } }
        public string Table_Name { get { return Convert.ToString(table_name); } }
        public OracleTriggerClass()
        {

        }
        public OracleTriggerClass(DataRow dr)
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
        public List<CreateSqlObject> GetCreateOracleSql(string tableSpace = null)
        {
            CreateSqlObject sqlobj = new CreateSqlObject();
            sqlobj.comment = "创建触发器";
            string sql = "CREATE OR REPLACE TRIGGER " + trigger_name + "\r\n";
            string[] dds = Convert.ToString(description).Split('\n');
            for (int i = 1; i < dds.Length; i++)
            {
                sql += dds[i].TrimEnd('\r', '\n')+"\r\n";
            }
            //\"SAFECITY\".TR_JFJK_TOTALHOUSE_SYNC_AFTER\nAFTER INSERT OR DELETE OR UPDATE on YW_JFJK_TOTALHOUSE\nfor each row\n
            string body = Convert.ToString(trigger_body);
            if (body.IndexOf("\r\n") < 0)
            {
                body = body.Replace("\n", "\r\n");
            }
            sql += body;
            sqlobj.sql = sql;
            return new List<CreateSqlObject>() { sqlobj };
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
                Name = "trigger_name",
                AliasName = "触发器名称",
                Value = trigger_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "triggering_event",
                AliasName = "事件",
                Value = triggering_event
            });
            navs.Add(new NameAliasValue()
            {
                Name = "trigger_type",
                AliasName = "类型",
                Value = trigger_type
            });
            navs.Add(new NameAliasValue()
            {
                Name = "table_name",
                AliasName = "表名称",
                Value = table_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "column_name",
                AliasName = "列名称",
                Value = column_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "status",
                AliasName = "启动状态",
                Value = status
            });
            navs.Add(new NameAliasValue()
            {
                Name = "column_name",
                AliasName = "列名称",
                Value = column_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "referencing_names",
                AliasName = "引用名称",
                Value = referencing_names
            });
            return navs;
        }
    }
}
