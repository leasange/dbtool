using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace DbTool.DbClasses
{
    public delegate List<CreateSqlObject> CreateSqlDelegate(string tableSpace);
    public delegate CreateDataSqlParams CreateDataSqlDelegate();

    public interface IDataDbType
    {

    }
    public class MyDbHelper
    {
        public static CreateSqlDelegate GetCreateSqlFunction(ICreateSql obj, MyDbType type)
        {
            CreateSqlDelegate del = null;
            switch (type)
            {
                case MyDbType.None:
                    break;
                case MyDbType.Oracle:
                    del = obj.GetCreateOracleSql;
                    break;
                case MyDbType.MySql:
                    del = obj.GetCreateMySqlSql;
                    break;
                case MyDbType.SqlServer:
                    del = obj.GetCreateSqlServerSql;
                    break;
                default:
                    break;
            }
            return del;
        }
        public static CreateDataSqlDelegate GetCreateSqlFunction(ICreateDataSql obj, MyDbType type)
        {
            CreateDataSqlDelegate del = null;
            switch (type)
            {
                case MyDbType.None:
                    break;
                case MyDbType.Oracle:
                    del = obj.GetCreateOracleSql;
                    break;
                case MyDbType.MySql:
                    del = obj.GetCreateMySqlSql;
                    break;
                case MyDbType.SqlServer:
                    del = obj.GetCreateSqlServerSql;
                    break;
                default:
                    break;
            }
            return del;
        }
        private static Type GetOracleObjectType(Type interfaceType)
        {
            Type objtype = null;
            if (interfaceType ==typeof(ITableClass))
            {
                objtype = typeof(OracleTableClass);
            }
            else if (interfaceType  ==typeof(ITableColClass))
            {
                objtype = typeof(OracleTableColClass);
            }
            else if (interfaceType  ==typeof( IConstraintClass))
            {
                objtype = typeof(OracleConstraintClass);
            }
            else if (interfaceType  ==typeof( IFunctionClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType  ==typeof( IIndexClass))
            {
                objtype = typeof(OracleIndexClass);
            }
            else if (interfaceType  ==typeof( IJavaSourceClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType  ==typeof( IProcedureClass))
            {
                objtype = typeof(OracleSourceClass);
            }
            else if (interfaceType  ==typeof(ISequenceClass))
            {
                objtype = typeof(OracleSequenceClass);
            }
            else if (interfaceType  ==typeof( ITriggerClass))
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
            switch (type)
            {
                case MyDbType.None:
                    break;
                case MyDbType.Oracle:
                    objtype = GetOracleObjectType(interfaceType);
                    break;
                case MyDbType.MySql:
                    break;
                case MyDbType.SqlServer:
                    break;
                default:
                    break;
            }
            return objtype;
        }
    }
}
