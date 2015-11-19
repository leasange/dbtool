using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace DbTool.DbClasses.Oracle
{
    public class OracleODACHelper:IDbHelper
    {
        private string _connectString = null;
        public string ConnectString
        {
            get
            {
                return _connectString;
            }
            set
            {
                _connectString = value;
            }
        }
        private OracleConnection _connection = null;
        public OracleODACHelper()
        {

        }
        public OracleODACHelper(string connectionString)
        {
            _connectString = connectionString;
        }
        
        public bool Open()
        {
            if (_connection == null)
            {
                _connection = new OracleConnection(_connectString);
            }
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection.State == ConnectionState.Open;
        }
        public void Close()
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }
            }
            catch (Exception)
            { }

        }

        internal bool CheckConnect()
        {
            try
            {
                bool ret = _connection != null && _connection.State == ConnectionState.Open;
                if (!ret && _connection != null)
                {
                    ret = Open();
                }
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal void CheckConnectEx()
        {
            bool ret= _connection != null && _connection.State == ConnectionState.Open;
            if (!ret)
            {
                if (_connection!=null)
                {
                    Open();
                }
                else throw new Exception("连接未打开");
            }
        }

        public int ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null);
        }
        public int ExecuteSql(string sql, params object[] prms)
        {
            CheckConnectEx();
           // Console.WriteLine("ExecuteSql:\r\n" + sql);
            OracleCommand cmd = PrepareCommand(null, CommandType.Text, sql, (OracleParameter[])prms);
            int rows = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return rows;
        }
        public DataSet ExecuteDataSet(string sql)
        {
            CheckConnectEx();
            DataSet ds = new DataSet();
            using (OracleDataAdapter da = new OracleDataAdapter(sql, _connection))
            {
                da.Fill(ds,"ds");
                return ds;
            }
        }
        /// <summary>
        /// 执行数据库命令前的准备工作
        /// </summary>
        /// <param name="command">Command对象</param>
        /// <param name="_connection">数据库连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">Command类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>
        /// <param name="commandParameters">命令参数集合</param>
        private OracleCommand PrepareCommand(OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand(cmdText, _connection);
            command.CommandText = cmdText;
            command.CommandType = cmdType;

            if (trans != null) command.Transaction = trans;

            if (commandParameters != null)
            {
                foreach (OracleParameter parm in commandParameters)
                    command.Parameters.Add(parm);
            }
            return command;
        }
        public DataSet ExecuteDataSet(string sql, params object[] prms)
        {
            CheckConnectEx();
            DataSet ds = new DataSet();
            OracleCommand cmd = PrepareCommand(null, CommandType.Text, sql, (OracleParameter[])prms);
            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
            {
                da.Fill(ds, "ds");
                cmd.Parameters.Clear();
                return ds;
            }
        }

        public DataTable ExecuteDataTable(string sql)
        {
            DataSet ds= ExecuteDataSet(sql);
            return ds.Tables[0];
        }

        public DataTable ExecuteDataTable(string sql, params object[] prms)
        {
            DataSet ds = ExecuteDataSet(sql,prms);
            return ds.Tables[0];
        }

        internal string GetPageSql(string sql, int start, int length)
        {
            string sqlFormat = "select * from (select t.*, rownum {0} from ({1}) t where rownum <= {2}) where {0} > {3}";
            string row = "row" + Guid.NewGuid().ToString("N").Substring(24);
            string newsql = string.Format(sqlFormat, row, sql, start + length, start);
            return newsql;
        }
        internal DataTable GetPageTable(DataTable dt)
        {
            DataTable dtNew = new DataTable();
            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                dtNew.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);
            }
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dtNew.NewRow();
                object[] obj = new object[item.ItemArray.Length - 1];
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i] = item.ItemArray[i];
                }
                dr.ItemArray = obj;
                dtNew.Rows.Add(dr);
            }
            return dtNew;
        }
        public DataTable ExecuteDataTable(string sql, int start, int length)
        {
            string newsql = GetPageSql(sql, start, length);
            DataTable dt = ExecuteDataTable(newsql);
            return GetPageTable(dt);
        }

        public DataTable ExecuteDataTable(string sql, int start, int length, params object[] prms)
        {
            string newsql = GetPageSql(sql, start, length);
            DataTable dt = ExecuteDataTable(newsql, prms);
            return GetPageTable(dt);
        }
    }
}
