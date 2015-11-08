using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public interface IDbHelper
    {
        string ConnectString { get; set; }
        bool Open();
        void Close();
        int ExecuteSql(string sql);
        int ExecuteSql(string sql, params object[] prms);
        DataSet ExecuteDataSet(string sql);
        DataSet ExecuteDataSet(string sql, params object[] prms);
        DataTable ExecuteDataTable(string sql);
        DataTable ExecuteDataTable(string sql,params object[] prms);

    }
}
