using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace DbTool.DbClasses
{
    public delegate List<CreateSqlObject> CreateSqlDelegate(string tableSpace);
    public delegate CreateDataSqlParams CreateDataSqlDelegate();
    #region 数据库选择
    /// <summary>
    /// 数据库选择器
    /// </summary>
    public interface IDbSelector
    {
        IDbClass GetDbClass(string connectstring);
        /// <summary>
        /// 获取创建SQL的方法
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        CreateSqlDelegate GetCreateSqlFunction(ICreateSql obj);
        /// <summary>
        /// 获取创建数据插入的方法
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <returns>创建数据插入的方法</returns>
        CreateDataSqlDelegate GetCreateSqlFunction(ICreateDataSql obj);
        /// <summary>
        /// 获取数据实现类型
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <returns>数据库实现类型</returns>
        Type GetDbObjectType(Type interfaceType);
        object GetDbDataType(string strDataType, MyDbType outType);
        object GetDbDataType(OracleDbType indbType);
    }
    /// <summary>
    /// Oracle 选择器实现
    /// </summary>
    public class OracleDbSelector : IDbSelector
    {
        private static Dictionary<string, OracleDbType> OracleDbTypeDics = new Dictionary<string, OracleDbType>();
        static OracleDbSelector()
        {
            OracleDbTypeDics.Add("BFILE", OracleDbType.BFile);
            OracleDbTypeDics.Add("BINARY ROWID", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("BINARY_DOUBLE", OracleDbType.BinaryDouble);
            OracleDbTypeDics.Add("BINARY_FLOAT", OracleDbType.BinaryFloat);
            OracleDbTypeDics.Add("BLOB", OracleDbType.Blob);
            OracleDbTypeDics.Add("CANONICAL", OracleDbType.Char);
            OracleDbTypeDics.Add("CFILE", OracleDbType.BFile);
            OracleDbTypeDics.Add("CHAR", OracleDbType.Char);
            OracleDbTypeDics.Add("CLOB", OracleDbType.Clob);
            OracleDbTypeDics.Add("NCLOB", OracleDbType.NClob);
            OracleDbTypeDics.Add("CONTIGUOUS ARRAY", OracleDbType.Blob);
            OracleDbTypeDics.Add("DATE", OracleDbType.Date);
            OracleDbTypeDics.Add("DECIMAL", OracleDbType.Decimal);
            OracleDbTypeDics.Add("DOUBLE PRECISION", OracleDbType.Double);
            OracleDbTypeDics.Add("FLOAT", OracleDbType.Decimal);
            OracleDbTypeDics.Add("INTEGER", OracleDbType.Int32);
            OracleDbTypeDics.Add("INTERVAL DAY(2) TO SECOND(6)", OracleDbType.IntervalDS);
            OracleDbTypeDics.Add("INTERVAL DAY TO SECOND", OracleDbType.IntervalDS);
            OracleDbTypeDics.Add("INTERVAL YEAR(2) TO MONTH", OracleDbType.IntervalYM);
            OracleDbTypeDics.Add("INTERVAL YEAR TO MONTH", OracleDbType.IntervalYM);
            OracleDbTypeDics.Add("LOB POINTER", OracleDbType.Object);
            OracleDbTypeDics.Add("NAMED COLLECTION", OracleDbType.Array);
            OracleDbTypeDics.Add("NAMED OBJECT", OracleDbType.Object);
            OracleDbTypeDics.Add("NUMBER", OracleDbType.Decimal);
            OracleDbTypeDics.Add("OCTET", OracleDbType.Byte);
            OracleDbTypeDics.Add("OID", OracleDbType.Char);
            OracleDbTypeDics.Add("BINARY INTEGER", OracleDbType.BinaryFloat);
            OracleDbTypeDics.Add("BOOLEAN", OracleDbType.Decimal);
            OracleDbTypeDics.Add("COLLECTION", OracleDbType.Array);
            OracleDbTypeDics.Add("LONG", OracleDbType.Long);
            OracleDbTypeDics.Add("LONG RAW", OracleDbType.LongRaw);
            OracleDbTypeDics.Add("NATURAL", OracleDbType.Char);
            OracleDbTypeDics.Add("NATURALN", OracleDbType.NChar);
            OracleDbTypeDics.Add("PLS INTEGER", OracleDbType.Int32);
            OracleDbTypeDics.Add("POSITIVE", OracleDbType.Object);
            OracleDbTypeDics.Add("POSITIVEN", OracleDbType.Object);
            OracleDbTypeDics.Add("RECORD", OracleDbType.Object);
            OracleDbTypeDics.Add("REF CURSOR", OracleDbType.RefCursor);
            OracleDbTypeDics.Add("ROWID", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("STRING", OracleDbType.NVarchar2);
            OracleDbTypeDics.Add("POINTER", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("RAW", OracleDbType.Raw);
            OracleDbTypeDics.Add("REAL", OracleDbType.Decimal);
            OracleDbTypeDics.Add("REF", OracleDbType.Ref);
            OracleDbTypeDics.Add("SIGNED BINARY INTEGER(16)", OracleDbType.Blob);
            OracleDbTypeDics.Add("SIGNED BINARY INTEGER(32)", OracleDbType.Blob);
            OracleDbTypeDics.Add("SIGNED BINARY INTEGER(8)", OracleDbType.Blob);
            OracleDbTypeDics.Add("SMALLINT", OracleDbType.Int16);
            OracleDbTypeDics.Add("TABLE", OracleDbType.Char);
            OracleDbTypeDics.Add("TIME", OracleDbType.TimeStamp);
            OracleDbTypeDics.Add("TIME WITH TZ", OracleDbType.TimeStampTZ);
            OracleDbTypeDics.Add("TIMESTAMP", OracleDbType.TimeStamp);
            OracleDbTypeDics.Add("TIMESTAMP(6)", OracleDbType.TimeStamp);
            OracleDbTypeDics.Add("TIMESTAMP WITH LOCAL TZ", OracleDbType.TimeStampLTZ);
            OracleDbTypeDics.Add("TIMESTAMP(6) WITH LOCAL TIME ZONE", OracleDbType.TimeStampLTZ);
            OracleDbTypeDics.Add("TIMESTAMP WITH TZ", OracleDbType.TimeStampTZ);
            OracleDbTypeDics.Add("TIMESTAMP(6) WITH TIME ZONE", OracleDbType.TimeStampTZ);
            OracleDbTypeDics.Add("UNSIGNED BINARY INTEGER(16)", OracleDbType.Blob);
            OracleDbTypeDics.Add("UNSIGNED BINARY INTEGER(32)", OracleDbType.Blob);
            OracleDbTypeDics.Add("UNSIGNED BINARY INTEGER(8)", OracleDbType.Blob);
            OracleDbTypeDics.Add("UROWID", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("VARCHAR", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("VARCHAR2", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("NVARCHAR2", OracleDbType.NVarchar2);
            OracleDbTypeDics.Add("VARYING ARRAY", OracleDbType.Array);
        }
        public IDbClass GetDbClass(string connectstring)
        {
            return new OracleDbClass(connectstring);
        }
        public CreateSqlDelegate GetCreateSqlFunction(ICreateSql obj)
        {
            return obj.GetCreateOracleSql;
        }

        public CreateDataSqlDelegate GetCreateSqlFunction(ICreateDataSql obj)
        {
            return obj.GetCreateOracleSql;
        }

        public Type GetDbObjectType(Type interfaceType)
        {
            Type objtype = null;
            if (interfaceType == typeof(ITableClass))
            {
                objtype = typeof(OracleTableClass);
            }
            else if (interfaceType == typeof(ITableColClass))
            {
                objtype = typeof(OracleTableColClass);
            }
            else if (interfaceType == typeof(IConstraintClass))
            {
                objtype = typeof(OracleConstraintClass);
            }
            else if (interfaceType == typeof(IFunctionClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IIndexClass))
            {
                objtype = typeof(OracleIndexClass);
            }
            else if (interfaceType == typeof(IJavaSourceClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IProcedureClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(ISequenceClass))
            {
                objtype = typeof(OracleSequenceClass);
            }
            else if (interfaceType == typeof(ITriggerClass))
            {
                objtype = typeof(OracleTriggerClass);
            }
            else if (interfaceType == typeof(IDataDbType))
            {
                objtype = typeof(OracleDbType);
            }
            else if (interfaceType == typeof(IDataDbType[]))
            {
                objtype = typeof(OracleDbType[]);
            }
            return objtype;
        }

        public object GetDbDataType(string strDataType, MyDbType outType)
        {
            try
            {
                OracleDbType dbtype = OracleDbTypeDics[strDataType.ToUpper()];
                if (outType == MyDbType.Oracle)
                {
                    return dbtype;
                }
                object obj = null;
                IDbSelector selector = MyDbHelper.GetDbSelector(outType);
                if (selector != null)
                {
                    obj = selector.GetDbDataType(dbtype);
                }
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object GetDbDataType(OracleDbType indbType)
        {
            return indbType;
        }
    }
    public class SqlServerDbSelector : IDbSelector
    {
        public IDbClass GetDbClass(string connectstring)
        {
            return null;
        }

        public CreateSqlDelegate GetCreateSqlFunction(ICreateSql obj)
        {
            return obj.GetCreateSqlServerSql;
        }

        public CreateDataSqlDelegate GetCreateSqlFunction(ICreateDataSql obj)
        {
            return obj.GetCreateSqlServerSql;
        }

        public Type GetDbObjectType(Type interfaceType)
        {
            Type objtype = null;
            if (interfaceType == typeof(ITableClass))
            {
                //objtype = typeof(OracleTableClass);
            }
            else if (interfaceType == typeof(ITableColClass))
            {
                //objtype = typeof(OracleTableColClass);
            }
            else if (interfaceType == typeof(IConstraintClass))
            {
                //objtype = typeof(OracleConstraintClass);
            }
            else if (interfaceType == typeof(IFunctionClass))
            {
                //objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IIndexClass))
            {
                // objtype = typeof(OracleIndexClass);
            }
            else if (interfaceType == typeof(IJavaSourceClass))
            {
                // objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IProcedureClass))
            {
                //objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(ISequenceClass))
            {
                // objtype = typeof(OracleSequenceClass);
            }
            else if (interfaceType == typeof(ITriggerClass))
            {
                // objtype = typeof(OracleTriggerClass);
            }
            else if (interfaceType == typeof(IDataDbType))
            {
                // objtype = typeof(OracleDbType);
            }
            else if (interfaceType == typeof(IDataDbType[]))
            {
                objtype = typeof(OracleDbType[]);
            }
            return objtype;
        }

        public object GetDbDataType(string strDataType, MyDbType outType)
        {
            throw new NotImplementedException();
        }

        public object GetDbDataType(OracleDbType indbType)
        {
            throw new NotImplementedException();
        }
    }
    public class MySqlDbSelector : IDbSelector
    {
        public IDbClass GetDbClass(string connectstring)
        {
            return null;
        }

        public CreateSqlDelegate GetCreateSqlFunction(ICreateSql obj)
        {
            return obj.GetCreateMySqlSql;
        }

        public CreateDataSqlDelegate GetCreateSqlFunction(ICreateDataSql obj)
        {
            return obj.GetCreateMySqlSql;
        }

        public Type GetDbObjectType(Type interfaceType)
        {
            Type objtype = null;
            if (interfaceType == typeof(ITableClass))
            {
                //objtype = typeof(OracleTableClass);
            }
            else if (interfaceType == typeof(ITableColClass))
            {
                //objtype = typeof(OracleTableColClass);
            }
            else if (interfaceType == typeof(IConstraintClass))
            {
                //objtype = typeof(OracleConstraintClass);
            }
            else if (interfaceType == typeof(IFunctionClass))
            {
                //objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IIndexClass))
            {
                // objtype = typeof(OracleIndexClass);
            }
            else if (interfaceType == typeof(IJavaSourceClass))
            {
                // objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IProcedureClass))
            {
                //objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(ISequenceClass))
            {
                // objtype = typeof(OracleSequenceClass);
            }
            else if (interfaceType == typeof(ITriggerClass))
            {
                // objtype = typeof(OracleTriggerClass);
            }
            else if (interfaceType == typeof(IDataDbType))
            {
                // objtype = typeof(OracleDbType);
            }
            else if (interfaceType == typeof(IDataDbType[]))
            {
                objtype = typeof(OracleDbType[]);
            }
            return objtype;
        }

        public object GetDbDataType(string strDataType, MyDbType outType)
        {
            throw new NotImplementedException();
        }

        public object GetDbDataType(OracleDbType indbType)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    public class MyDbHelper
    {
        /// <summary>
        /// 获取DB选择器
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <returns>选择器</returns>
        public static IDbSelector GetDbSelector(MyDbType type)
        {
            IDbSelector selector = null;
            switch (type)
            {
                case MyDbType.None:
                    break;
                case MyDbType.Oracle:
                    selector = new OracleDbSelector();
                    break;
                case MyDbType.MySql:
                    selector = new MySqlDbSelector();
                    break;
                case MyDbType.SqlServer:
                    selector = new SqlServerDbSelector();
                    break;
                default:
                    break;
            }
            return selector;
        }
        public static IDbClass GetDbClass(string connectstring, MyDbType type)
        {
            IDbClass dbClass = null;
            IDbSelector selector = GetDbSelector(type);
            if (selector != null)
            {
                dbClass = selector.GetDbClass(connectstring);
            }
            return dbClass;
        }
        /// <summary>
        /// 获取指定对象指定数据库类型的创建SQL执行方法
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="type">数据库类型</param>
        /// <returns>创建SQL执行方法</returns>
        public static CreateSqlDelegate GetCreateSqlFunction(ICreateSql obj, MyDbType type)
        {
            CreateSqlDelegate del = null;
            IDbSelector selector = GetDbSelector(type);
            if (selector != null)
            {
                del = selector.GetCreateSqlFunction(obj);
            }
            return del;
        }
        public static CreateDataSqlDelegate GetCreateSqlFunction(ICreateDataSql obj, MyDbType type)
        {
            CreateDataSqlDelegate del = null;
            IDbSelector selector = GetDbSelector(type);
            if (selector != null)
            {
                del = selector.GetCreateSqlFunction(obj);
            }
            return del;
        }
        private static Type GetOracleObjectType(Type interfaceType)
        {
            Type objtype = null;
            if (interfaceType == typeof(ITableClass))
            {
                objtype = typeof(OracleTableClass);
            }
            else if (interfaceType == typeof(ITableColClass))
            {
                objtype = typeof(OracleTableColClass);
            }
            else if (interfaceType == typeof(IConstraintClass))
            {
                objtype = typeof(OracleConstraintClass);
            }
            else if (interfaceType == typeof(IFunctionClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IIndexClass))
            {
                objtype = typeof(OracleIndexClass);
            }
            else if (interfaceType == typeof(IJavaSourceClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(IProcedureClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType == typeof(ISequenceClass))
            {
                objtype = typeof(OracleSequenceClass);
            }
            else if (interfaceType == typeof(ITriggerClass))
            {
                objtype = typeof(OracleTriggerClass);
            }
            else if (interfaceType == typeof(IDataDbType))
            {
                objtype = typeof(OracleDbType);
            }
            else if (interfaceType == typeof(IDataDbType[]))
            {
                objtype = typeof(OracleDbType[]);
            }
            return objtype;
        }
        public static Type GetDbObjectType(Type interfaceType, MyDbType type)
        {
            Type objtype = null;
            IDbSelector selector = GetDbSelector(type);
            if (selector != null)
            {
                objtype = selector.GetDbObjectType(interfaceType);
            }
            return objtype;
        }
        public static object GetDbDataType(string strDataType, MyDbType inType, MyDbType outType)
        {
            object dbdataType = null;
            IDbSelector selector = GetDbSelector(inType);
            if (selector != null)
            {
                dbdataType = selector.GetDbDataType(strDataType, outType);
            }
            return dbdataType;
        }
    }
}
