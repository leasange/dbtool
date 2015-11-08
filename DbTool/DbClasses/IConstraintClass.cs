using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    /// <summary>
    /// 约束，键
    /// </summary>
    public interface IConstraintClass:ICreateSql,IGetAttribute
    {
        string Name { get; }
        string Table_Name { get; }
        int Level { get; }//用于导入的顺序
    }
}
