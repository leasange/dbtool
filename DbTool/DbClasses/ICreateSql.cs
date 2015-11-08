using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DbTool.DbClasses
{
    
    public interface ICreateSql
    {
        List<CreateSqlObject> GetCreateOracleSql(string tableSpace=null);

        List<CreateSqlObject> GetCreateMySqlSql(string tableSpace = null);

        List<CreateSqlObject> GetCreateSqlServerSql(string tableSpace = null);

    }

    public interface ICreateDataSql
    {
        CreateDataSqlParams GetCreateOracleSql();
        CreateDataSqlParams GetCreateMySqlSql();
        CreateDataSqlParams GetCreateSqlServerSql();
    }

    public interface IGetAttribute
    {
        List<NameAliasValue> GetAttributes();
    }

    public class NameAliasValue
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _aliasName;
        public string AliasName
        {
            get 
            { 
                if (string.IsNullOrWhiteSpace(_aliasName))
                {
                    return _name;
                }
                return _aliasName;
            }
            set { _aliasName = value; }
        }
        private object _value;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public static DataTable ToDataTable(List<NameAliasValue> navs)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("名称"));
            dt.Columns.Add(new DataColumn("值"));
            //dt.Columns.Add(new DataColumn("原始名称"));
            foreach (NameAliasValue item in navs)
            {
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { item.AliasName,item.Value/*,item.Name*/};
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static DataTable ToDataTableX(IGetAttribute[] attris)
        {
            DataTable dt = new DataTable();
            if (attris.Length > 0)
            {
                List<NameAliasValue> navs = attris[0].GetAttributes();
                foreach (NameAliasValue item in navs)
                {
                    dt.Columns.Add(new DataColumn(item.AliasName));
                }
                foreach (IGetAttribute item in attris)
                {
                    DataRow dr = dt.NewRow();
                    navs = item.GetAttributes();
                    List<object> vals = new List<object>();
                    foreach (NameAliasValue nv in navs)
                    {
                        vals.Add(nv.Value);
                    }
                    dr.ItemArray = vals.ToArray();
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }

    public class CreateSqlObject
    {
        public string sql;
        public string comment;
        public CreateSqlObject() { }
        public CreateSqlObject(string sql, string comment)
        {
            this.sql = sql;
            this.comment = comment;
        }
        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(comment))
            {
                sb.AppendLine("--" + comment);
            }
            if (!string.IsNullOrWhiteSpace(sql))
            {
                sb.AppendLine(sql);
            }
            return sb.ToString().TrimEnd('\r', '\n');
        }
        public static string ToCollectionSqls(List<CreateSqlObject> objs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CreateSqlObject item in objs)
            {
                sb.AppendLine(item.ToString()+";");
            }
            return sb.ToString().TrimEnd('\r','\n');
        }
    }
}
