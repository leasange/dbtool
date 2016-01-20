using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public class DbDefinition
    {
        public MyDbType DbType = MyDbType.None;
        public List<ITableClass> Tables = new List<ITableClass>();
        public List<IConstraintClass> Constraints = new List<IConstraintClass>();
        public List<IIndexClass> Indexes = new List<IIndexClass>();
        public List<ISequenceClass> Sequences = new List<ISequenceClass>();
        public List<ITriggerClass> Triggers = new List<ITriggerClass>();
        public List<IFunctionClass> Functions = new List<IFunctionClass>();
        public List<IProcedureClass> Procedures = new List<IProcedureClass>();
        public List<IJavaSourceClass> JavaSources = new List<IJavaSourceClass>();
        public List<IViewClass> Views = new List<IViewClass>();
        public List<IJobClass> Jobs = new List<IJobClass>();
        public new string ToString()
        {
            return "表个数：" + Tables.Count + "\r\n" +
                "索引个数：" + Indexes.Count + "\r\n" +
                "序列个数：" + Sequences.Count + "\r\n" +
                "触发器个数：" + Triggers.Count + "\r\n" +
                "函数个数：" + Functions.Count + "\r\n" +
                "过程个数：" + Procedures.Count + "\r\n" +
                "Java资源个数：" + JavaSources.Count + "\r\n" +
                 "视图个数：" + Views.Count + "\r\n" +
                 "事务个数：" + Jobs.Count;
        }
    }
}
