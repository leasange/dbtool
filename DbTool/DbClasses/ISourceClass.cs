using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    /// <summary>
    /// procedure, function, java source
    /// </summary>
    public interface ISourceClass : ICreateSql
    {
        string Name { get; }
    }
}
