using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    /// <summary>
    /// 索引
    /// </summary>
    public interface IIndexClass : ICreateSql,IGetAttribute
    {
        string Name { get; }
        string Table_Name { get; }
    }
}
