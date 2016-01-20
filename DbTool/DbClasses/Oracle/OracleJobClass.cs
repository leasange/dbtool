using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbTool.DbClasses.Oracle
{
    public class OracleJobClass : IJobClass
    {
        public object job;
        public object log_user;
        public object priv_user;
        public object schema_user;
        public object last_date;
        public object last_sec;
        public object this_date;
        public object this_sec;
        public object next_date;
        public object next_sec;
        public object total_time;
        public object broken;
        public object interval;
        public object failures;
        public object what;
        public object nls_env;
        public object misc_env;
        public object instance;
        
        public string Name
        {
            get { return Convert.ToString(job); }
        }
        public OracleJobClass()
        {
        }
        public OracleJobClass(DataRow dr)
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
            StringBuilder sb = new StringBuilder("declare job number;\r\n");
           // CreateSqlObject obj1 = new CreateSqlObject(sb.ToString(), "定义事务变量");

            //sb.Clear();
            sb.AppendLine("begin");
            sb.AppendLine(" sys.dbms_job.submit(job => job,");
            sb.AppendLine("          what => '" + what + "',");
            DateTime dt = (DateTime)next_date;
            sb.AppendLine("          next_date => to_date('" + dt.ToString("dd-MM-yyyy ") + next_sec + "', 'dd-mm-yyyy hh24:mi:ss'),");
            sb.AppendLine("          interval => '" + interval + "');");
            sb.AppendLine("  commit;");
            sb.AppendLine("end;");

            CreateSqlObject obj2 = new CreateSqlObject(sb.ToString(), "创建事务" + job);
            return new List<CreateSqlObject>() { obj2 };
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
                Name = "job",
                AliasName = "作业",
                Value = job
            });
            navs.Add(new NameAliasValue()
            {
                Name = "log_user",
                AliasName = "提交者",
                Value = log_user
            });
            navs.Add(new NameAliasValue()
            {
                Name = "priv_user",
                AliasName = "私有用户",
                Value = priv_user
            });
            navs.Add(new NameAliasValue()
            {
                Name = "schema_user",
                AliasName = "方案用户",
                Value = schema_user
            });
            navs.Add(new NameAliasValue()
            {
                Name = "what",
                AliasName = "What值",
                Value = what
            });
            navs.Add(new NameAliasValue()
            {
                Name = "last_date",
                AliasName = "上次日期",
                Value = last_date
            });
            navs.Add(new NameAliasValue()
            {
                Name = "this_date",
                AliasName = "本次日期",
                Value = this_date
            });
            navs.Add(new NameAliasValue()
            {
                Name = "next_date",
                AliasName = "下次日期",
                Value = next_date
            });
            navs.Add(new NameAliasValue()
            {
                Name = "next_date",
                AliasName = "下次日期",
                Value = next_date
            });
            navs.Add(new NameAliasValue()
            {
                Name = "interval",
                AliasName = "间隔时间",
                Value = interval
            });
            navs.Add(new NameAliasValue()
            {
                Name = "failures",
                AliasName = "失败次数",
                Value = failures
            });
            navs.Add(new NameAliasValue()
            {
                Name = "nls_env",
                AliasName = "NLS环境",
                Value = nls_env
            });
            navs.Add(new NameAliasValue()
            {
                Name = "broken",
                AliasName = "断开状态",
                Value = broken
            });
            return navs;
        }
    }
}
