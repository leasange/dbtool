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
            return null;
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
            throw new NotImplementedException();
        }
    }
}
