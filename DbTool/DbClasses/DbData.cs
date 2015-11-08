using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public class DbData:ICreateDataSql
    {
        private TableDataRow _tableDataRow;
        public DbTool.DbClasses.TableDataRow TableDataRow
        {
            get { return _tableDataRow; }
            set { _tableDataRow = value; }
        }
        public DbData() { }
        public DbData(MyDbType dbType, string tableName, string[] tableColumnNames, Type[] tableColumnTypes, object[] tableColumnDbTypes, object[] tableValues=null)
        {
            _tableDataRow = new TableDataRow(dbType, tableName, tableColumnNames, tableColumnTypes, tableColumnDbTypes, tableValues);
        }
        public DbData(TableDataRow tableDataRow)
        {
            _tableDataRow = tableDataRow;
        }
        public void SetValues(object[] tableValues)
        {
            if (_tableDataRow==null)
            {
                return;
            }
            _tableDataRow.SetTableValues(tableValues);
        }
        public CreateDataSqlParams GetCreateOracleSql()
        {
            if (_tableDataRow == null)
            {
                return null;
            }
            
            StringBuilder t1 = new StringBuilder();
            StringBuilder t2 = new StringBuilder();
            OracleParameter[] parms = new OracleParameter[_tableDataRow.tableColumnNames.Length];
            for (int i = 0; i < _tableDataRow.tableColumnNames.Length; i++)
            {
                Type dataType = _tableDataRow.tableColumnTypes[i];
                string culn = OracleTableClass.GetOracleColumnName(_tableDataRow.tableColumnNames[i]);
                t1.Append(culn + ",");
                t2.Append(":" + culn + ",");
                parms[i] = new OracleParameter(":" + culn, _tableDataRow.TableValues[i]);
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + _tableDataRow.tableName + "(");
            strSql.Append(t1.ToString().TrimEnd(','));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(t2.ToString().TrimEnd(',')); 
            strSql.Append(")");
            CreateDataSqlParams sqlp = new CreateDataSqlParams();
            sqlp.sql = strSql.ToString();
            sqlp.sql_params = parms;
            return sqlp;
        }
        public CreateDataSqlParams GetCreateMySqlSql()
        {
            return null;
        }
        public CreateDataSqlParams GetCreateSqlServerSql()
        {
            return null;
        }

        public static DataTable ToDataTable(List<DbData> datas)
        {
            DataTable dt = new DataTable();
            if (datas.Count>0)
            {
                for (int i = 0; i < datas[0].TableDataRow.tableColumnNames.Length; i++)
                {
                    DataColumn dc = new DataColumn(datas[0].TableDataRow.tableColumnNames[i], datas[0].TableDataRow.tableColumnTypes[i]);
                    dt.Columns.Add(dc);
                }
                foreach (DbData item in datas)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = item.TableDataRow.TableValues;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        } 
    }
    public class TableDataRow
    {
        public string tableName;
        public string[] tableColumnNames;
        public MyDbType dbType;
        public object[] tableColumnDbTypes;
        public Type[] tableColumnTypes;
        public object[] base64TableValues;
        private object[] tableValues;
        public object[] TableValues
        {
            get { return tableValues; }
        }
        public TableDataRow() { }
        public TableDataRow(MyDbType dbType, string tableName, string[] tableColumnNames, Type[] tableColumnTypes, object[] tableColumnDbTypes, object[] tableValues = null)
        {
            this.dbType = dbType;
            this.tableName = tableName;
            this.tableColumnNames = tableColumnNames;
            this.tableColumnTypes = tableColumnTypes;
            this.tableColumnDbTypes = tableColumnDbTypes;
            this.tableValues = tableValues;
            DoConvertToBase64();
        }
        public void SetTableValues(object[] tableValues)
        {
            this.tableValues = tableValues;
            DoConvertToBase64();
        }
        internal void DoConvertToBase64()
        {
            if (tableValues==null)
            {
                return;
            }
            if (base64TableValues==null)
            {
                base64TableValues = new object[tableColumnTypes.Length];
            }
            for (int i = 0; i < tableColumnTypes.Length; i++)
            {
                if (tableColumnTypes[i]==typeof(byte[]))
                {
                    if (tableValues[i] == null)
                    {
                        base64TableValues[i] = null;
                    }
                    else if (tableValues[i] == DBNull.Value)
                    {
                        base64TableValues[i] = null;
                    }
                    else
                    {
                        base64TableValues[i] = Convert.ToBase64String((byte[])tableValues[i]);
                    }
                }
                else
                {
                    base64TableValues[i] = tableValues[i];
                }
            }
        }
        public void ConvertValuesFromBase64()
        {
            if (base64TableValues == null)
            {
                return;
            }
            if (tableValues==null)
            {
                tableValues = new object[tableColumnTypes.Length];
            }
            for (int i = 0; i < tableColumnTypes.Length; i++)
            {
                if (tableColumnTypes[i] == typeof(byte[]))
                {
                    if (base64TableValues[i] == null||base64TableValues[i]==DBNull.Value)
                    {
                        tableValues[i] = DBNull.Value;
                    }
                    else base64TableValues[i] = Convert.FromBase64String((string)base64TableValues[i]);
                }
                else
                {
                    tableValues[i] = base64TableValues[i];
                }
            }
        }
    }
    public class CreateDataSqlParams
    {
        public string sql;
        public object[] sql_params;
    }
}
