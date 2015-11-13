using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public class OracleSourceClass:ISourceClass,IProcedureClass,IJavaSourceClass,IFunctionClass
    {
        public string name;
        public string type;
        public string sql_body;
        private string table_name;
        public string Table_Name
        {
            get { return table_name; }
        }
        public string Name
        {
            get { return name; }
        }
        public OracleSourceClass() { }
        public OracleSourceClass(DataTable dt,int startIndex,int endIndex)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                DataRow dr=dt.Rows[i];
                if (i==startIndex)
                {
                    type = Convert.ToString(dr["TYPE"]);
                    name=Convert.ToString(dr["NAME"]);
                    if (type == "JAVA SOURCE")
                    {
                        sb.AppendLine("create or replace and compile java source named " + name + " as");
                        string t = Convert.ToString(dr["TEXT"]);
                        if (t!=null)
                        {
                           t= t.TrimEnd('\r', '\n');
                        }
                        sb.AppendLine(t);
                    }
                    else if (type == "FUNCTION")
                    {
                        string t = Convert.ToString(dr["TEXT"]);
                        if (t != null)
                        {
                            t = t.TrimEnd('\r', '\n');
                        }
                        sb.AppendLine("create or replace " + t);
                    }
                    else if (type == "PROCEDURE")
                    {
                        string t = Convert.ToString(dr["TEXT"]);
                        if (t != null)
                        {
                            t = t.TrimEnd('\r', '\n');
                        }
                        sb.AppendLine("create or replace " + t);
                    }
                }
                else
                {
                    string t = Convert.ToString(dr["TEXT"]);
                    if (t != null)
                    {
                        t = t.TrimEnd('\r', '\n');
                    }
                    sb.AppendLine(t);
                }
            }
            sql_body = sb.ToString().TrimEnd('\r', '\n');
        }
        public List<CreateSqlObject> GetCreateOracleSql(string tableSpace = null)
        {
            CreateSqlObject obj = new CreateSqlObject(sql_body, "创建资源" + name);
            if (obj.sql.IndexOf("\r\n")<0)
            {
                obj.sql = obj.sql.Replace("\n", "\r\n");
            }
            return new List<CreateSqlObject>() { obj };
        }

        public List<CreateSqlObject> GetCreateMySqlSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public List<CreateSqlObject> GetCreateSqlServerSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public  List<NameAliasValue> GetAttributes()
        {
            List<NameAliasValue> navs = new List<NameAliasValue>();
            navs.Add(new NameAliasValue()
            {
                Name = "name",
                AliasName = "资源名称",
                Value = name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "table_name",
                AliasName = "表名称",
                Value = table_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "type",
                AliasName = "类型",
                Value = type
            });
            return navs;
        }
    }
}
