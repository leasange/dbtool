using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public interface ITableClass : ICreateSql, IGetAttribute
    {
        string TableName { get; }
        string Comments { get; }
        List<ITableColClass> GetColumns();
    }
}
