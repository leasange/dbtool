﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public interface ITriggerClass : ISourceClass
    {
        string Table_Name { get; }
    }
}
