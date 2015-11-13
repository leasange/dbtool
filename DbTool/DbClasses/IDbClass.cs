using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public enum MyDbType
    {
        None,
        Oracle,
        MySql,
        SqlServer
    }
    public interface IDbClass
    {
        bool Open();
        void Close();

        MyDbType GetClassDbType();
        string GetDbVersionString();
        string GetCurrentTableSpaceName();
        string GetCurrentUser();
        IDbHelper GetDbHelper();
        List<ITableClass> GetTables();
        ITableClass GetTable(string tableName);
        ulong GetTableDataCount(string tableName);
        List<DbData> GetTableData(string tableName, int start=0, int length=-1);//from 0 to .. if length=-1 unlimited
        List<IConstraintClass> GetConstraints();
        List<IConstraintClass> GetConstraints(string tableName);
        List<IIndexClass> GetIndexs();
        List<IIndexClass> GetIndexs(string tableName);
        List<ISequenceClass> GetSequences();
        List<ITriggerClass> GetTriggers();
        List<IFunctionClass> GetFunctions();
        List<IProcedureClass> GetProcedures();
        List<IJavaSourceClass> GetJavaSources();
        List<IViewClass> GetViews();
        List<IJobClass> GetJobs();
    }
}
