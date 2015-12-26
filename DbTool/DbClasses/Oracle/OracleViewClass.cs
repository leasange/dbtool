using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbTool.DbClasses.Oracle
{
    public class OracleViewClass : IViewClass
    {
        public string view_name;
        public decimal text_length;
        public string text;
        public decimal type_text_length;
        public object type_text;
        public object oid_text_length;
        public object oid_text;
        public object view_type_owner;
        public object view_type;
        public string superview_name;

        
        public string Name
        {
            get { return view_name; }
        }
        public OracleViewClass()
        {
        }
        public OracleViewClass(DataRow dr)
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
            StringBuilder sb = new StringBuilder("create or replace view ");
            sb.Append(view_name);
            sb.AppendLine(" as");
            sb.Append(text);
            CreateSqlObject obj = new CreateSqlObject(sb.ToString(), "创建视图" + view_name);
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

        public List<NameAliasValue> GetAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
