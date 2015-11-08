using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public class DbTFileConfig
    {
        private MyDbType _dbType = MyDbType.None;
        public DbTool.DbClasses.MyDbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
        private string _version = "";
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public new string ToString()
        {
            return "数据库类型：" + Enum.GetName(typeof(MyDbType), _dbType) + "\r\n" +
                "数据库版本：" + _version;
        }
    }

    public class DbtFile
    {
        public static string TagStartFormat = "<DBS_{0}>";
        public static string TagEndFormat = "<DBE_{0}>";
        public string GetTagStart(DbtFileTags tag)
        {
            return string.Format(TagStartFormat, Enum.GetName(typeof(DbtFileTags), tag));
        }
        public string GetTagEnd(DbtFileTags tag)
        {
            return string.Format(TagEndFormat, Enum.GetName(typeof(DbtFileTags), tag));
        }
        public bool CheckTagStart(DbtFileTags tag, string checkStr)
        {
            string tagStr = string.Format(TagStartFormat, Enum.GetName(typeof(DbtFileTags), tag));
            return checkStr.Trim() == tagStr;
        }
        public bool CheckTagEnd(DbtFileTags tag, string checkStr)
        {
            string tagStr = string.Format(TagEndFormat, Enum.GetName(typeof(DbtFileTags), tag));
            return checkStr.Trim() == tagStr;
        }
    }

    public enum DbtFileTags
    {
        None,
        DbTFile,
        DbType,
        Version,
        Tables,
        Table,
        Constraints,
        Constraint,
        Sequences,
        Sequence,
        Triggers,
        Trigger,
        Indexes,
        Index,
        Functions,
        Function,
        Procedures,
        Procedure,
        JavaSources,
        JavaSource,
        Datas,
        Data,
        DataTableName,
        DataCulumnName,
        DataColumnDbType,
        DataColumnType,
        DataValue,
    }
}
