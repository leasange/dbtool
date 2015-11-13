using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    /// <summary>
    /// 序列
    /// </summary>
    public interface ISequenceClass : ICreateSql,IGetAttribute
    {
        string SequenceName { get; }
    }
}
