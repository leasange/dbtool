using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbTool.DbClasses
{
    public class OracleSequenceClass : ISequenceClass
    {
        public object sequence_name;
        public object min_value;
        public decimal? max_value;
        public object increment_by;
        public object cycle_flag;
        public object order_flag;
        public object cache_size;
        public object last_number;
        public OracleSequenceClass()
        {
        }
        public OracleSequenceClass(DataRow dr)
        {
            Type type = this.GetType();
            foreach (FieldInfo fi in type.GetFields())
            {
                try
                {
                    fi.SetValue(this, dr[fi.Name.ToUpper()]);
                }
                catch (System.Exception ex) { }
            }
        }
        /*
          -- Create sequence 
        create sequence S_YW_EQUIP_BAS_UNIT
        minvalue 1
        maxvalue 999999999999999999999999999
        start with 421
        increment by 1
        cache 20
        cycle
        order;
        */
        public List<CreateSqlObject> GetCreateOracleSql(string tableSpace = null)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("-- Create sequence");
            sb.AppendLine("create sequence " + sequence_name);
            sb.AppendLine("minvalue " + min_value);
            sb.AppendLine("maxvalue " + max_value);
            sb.AppendLine("start with " + last_number);
            sb.AppendLine("increment by " + increment_by);
            int cache=0;
            int.TryParse(Convert.ToString(cache_size), out cache);
            if (cache>0)
            {
                sb.AppendLine("cache " + cache_size);
            }
            if (Convert.ToString(cycle_flag) == "Y")
            {
                sb.AppendLine("cycle");
            }
            if (Convert.ToString(order_flag) == "Y")
            {
                sb.AppendLine("order");
            }
            string str = sb.ToString().TrimEnd('\r', '\n');
           // str += ";";
            CreateSqlObject obj = new CreateSqlObject(str, "创建序列" + sequence_name);
            return new List<CreateSqlObject>() { obj };
        }

        public List<CreateSqlObject> GetCreateMySqlSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public List<CreateSqlObject> GetCreateSqlServerSql(string tableSpace = null)
        {
            throw new NotImplementedException();
        }

        public string SequenceName
        {
            get { return Convert.ToString(sequence_name); }
        }

        public string Name
        {
            get { return Convert.ToString(sequence_name); }
        }

        public List<NameAliasValue> GetAttributes()
        {
            List<NameAliasValue> navs = new List<NameAliasValue>();
            navs.Add(new NameAliasValue()
            {
                Name = "sequence_name",
                AliasName = "名称",
                Value = sequence_name
            });
            navs.Add(new NameAliasValue()
            {
                Name = "increment_by",
                AliasName = "增量",
                Value = increment_by
            });
            navs.Add(new NameAliasValue()
            {
                Name = "min_value",
                AliasName = "最小值",
                Value = min_value
            });
            navs.Add(new NameAliasValue()
            {
                Name = "max_value",
                AliasName = "最大值",
                Value = max_value
            });
            navs.Add(new NameAliasValue()
            {
                Name = "last_number",
                AliasName = "开始值",
                Value = last_number
            });
            navs.Add(new NameAliasValue()
            {
                Name = "cache_size",
                AliasName = "缓存大小",
                Value = cache_size
            });
            navs.Add(new NameAliasValue()
            {
                Name = "cycle_flag",
                AliasName = "循环",
                Value = cycle_flag
            });
            navs.Add(new NameAliasValue()
            {
                Name = "order_flag",
                AliasName = "排序",
                Value = order_flag
            });
            return navs;
        }
    }
}
