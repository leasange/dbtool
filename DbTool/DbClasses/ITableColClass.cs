using DbTool.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool
{
    public interface ITableColClass : IGetAttribute
    {
        string Name { get; }
    }
}
