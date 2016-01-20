using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DbTool.DbClasses
{
    public class DbTFileReader : DbtFile, IDisposable
    {
        private StreamReader _fileReader = null;
        private DbTFileConfig _dbtFile = null;
        private DbDefinition _dbDefine = null;
        private bool _hasReadDatasStart = false;
        private bool _hasReadDataStart = false;
        private bool _hasReadValueStart = false;
        private bool _hasReadValueContinue = false;
        private string curTableName = null;
        private Type[] curTableColumnType = null;
        private object[] curTableDbColumnType = null;
        private string[] curTableColumnNames = null;
        private decimal curTableDataCount = 0;
        private bool _datasEnd = false;

        public delegate bool ReadToDbExceptionHandle(Exception ex);

        public DbTFileReader()
        { }
        public DbTFileReader(string fileNamePath)
        {
            OpenFile(fileNamePath);
        }
        public DbTFileConfig OpenFile(string fileNamePath)
        {
            CloseFile();
            if (!File.Exists(fileNamePath))
            {
                return null;
            }
            FileStream fs = File.OpenRead(fileNamePath);
            _fileReader = new StreamReader(fs);
            return DoInitReadFile();
        }
        public void CloseFile()
        {
            if (_fileReader != null)
            {
                _fileReader.Close();
                _fileReader.Dispose();
                _fileReader = null;
                _dbtFile = null;
            }
        }

        internal string ReadLine()
        {
            string str = _fileReader.ReadLine();
            //Console.WriteLine(str);
            return str;
        }

        public DbTFileConfig GetDbTFile()
        {
            return _dbtFile;
        }

        internal DbTFileConfig DoInitReadFile()
        {
            if (_fileReader.EndOfStream) return null;
            bool bdbtFile = false;
            while (!_fileReader.EndOfStream)
            {
                string str = ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }
                if (bdbtFile)
                {
                    if (CheckTagStart(DbtFileTags.DbType, str))
                    {
                        str = DoInReadTagContentNoStart(DbtFileTags.DbType);
                        if (string.IsNullOrWhiteSpace(str))
                        {
                            return null;
                        }
                        if (_dbtFile == null)
                        {
                            _dbtFile = new DbTFileConfig();
                        }
                        _dbtFile.DbType = Newtonsoft.Json.JsonConvert.DeserializeObject<MyDbType>(str);
                        str = DoInReadTagContent(DbtFileTags.Version);
                        _dbtFile.Version = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(str);
                    }
                    else if (CheckTagStart(DbtFileTags.Version, str))
                    {
                        str = DoInReadTagContentNoStart(DbtFileTags.Version);
                        if (_dbtFile == null)
                        {
                            _dbtFile = new DbTFileConfig();
                        }
                        _dbtFile.Version = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(str);
                        str = DoInReadTagContent(DbtFileTags.DbType);
                        _dbtFile.DbType = Newtonsoft.Json.JsonConvert.DeserializeObject<MyDbType>(str);
                    }
                    break;
                }
                else
                {
                    bdbtFile = CheckTagStart(DbtFileTags.DbTFile, str);
                }
            }
            return _dbtFile;
        }

        internal string DoInReadTagContent(DbtFileTags tag)
        {
            while (!_fileReader.EndOfStream)
            {
                string str = ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }
                if (CheckTagStart(tag, str))
                {
                    str = DoInReadTagContentNoStart(tag);
                    return str;
                }
            }
            return "";
        }

        internal string DoInReadTagContentNoStart(DbtFileTags tag)
        {
            string temp = "";
            while (!_fileReader.EndOfStream)
            {
                string str = ReadLine();
                if (CheckTagEnd(tag, str))
                {
                    break;
                }
                else
                {
                    if (temp != "")
                    {
                        temp += "\r\n";
                    }
                    temp += str;
                }
            }
            return temp;
        }

        internal List<string> DoReadTags(DbtFileTags top, DbtFileTags second)
        {
            List<string> strs = new List<string>();
            while (!_fileReader.EndOfStream)
            {
                string str = ReadLine();
                if (CheckTagStart(second, str))
                {
                    str = DoInReadTagContentNoStart(second);
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        strs.Add(str);
                    }
                }
                else if (CheckTagEnd(top, str))
                {
                    break;
                }
            }
            return strs;
        }

        internal void DoReadObjects<IDbObject>(Type dbobjType, DbtFileTags top, DbtFileTags second, List<IDbObject> list)
           where IDbObject : class
        {
            List<string> strs = DoReadTags(top, second);
            foreach (string item in strs)
            {
                object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(item, dbobjType);
                IDbObject dbo = obj as IDbObject;
                if (obj != null)
                {
                    list.Add(dbo);
                }
            }
        }

        internal void DoReadNodes<IDbObject>(DbtFileTags top, DbtFileTags second, List<IDbObject> list)
            where IDbObject : class
        {
            Type dbobjtype = MyDbHelper.GetDbObjectType(typeof(IDbObject), _dbDefine.DbType);
            if (dbobjtype != null)
            {
                DoReadObjects<IDbObject>(dbobjtype, top, second, list);
            }
        }

        public DbDefinition ReadDbDefinition()
        {
            if (_dbtFile == null)
            {
                return null;
            }
            if (_dbDefine != null)
            {
                return _dbDefine;
            }
            _dbDefine = new DbDefinition();
            _dbDefine.DbType = _dbtFile.DbType;
            while (!_fileReader.EndOfStream)
            {
                string str = ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }

                if (CheckTagStart(DbtFileTags.Tables, str))
                {
                    DoReadNodes<ITableClass>(DbtFileTags.Tables, DbtFileTags.Table, _dbDefine.Tables);
                }
                else if (CheckTagStart(DbtFileTags.Constraints, str))
                {
                    DoReadNodes<IConstraintClass>(DbtFileTags.Constraints, DbtFileTags.Constraint, _dbDefine.Constraints);
                }
                else if (CheckTagStart(DbtFileTags.Sequences, str))
                {
                    DoReadNodes<ISequenceClass>(DbtFileTags.Sequences, DbtFileTags.Sequence, _dbDefine.Sequences);
                }
                else if (CheckTagStart(DbtFileTags.Triggers, str))
                {
                    DoReadNodes<ITriggerClass>(DbtFileTags.Triggers, DbtFileTags.Trigger, _dbDefine.Triggers);
                }
                else if (CheckTagStart(DbtFileTags.Indexes, str))
                {
                    DoReadNodes<IIndexClass>(DbtFileTags.Indexes, DbtFileTags.Index, _dbDefine.Indexes);
                }
                else if (CheckTagStart(DbtFileTags.Functions, str))
                {
                    DoReadNodes<IFunctionClass>(DbtFileTags.Functions, DbtFileTags.Function, _dbDefine.Functions);
                }
                else if (CheckTagStart(DbtFileTags.Procedures, str))
                {
                    DoReadNodes<IProcedureClass>(DbtFileTags.Procedures, DbtFileTags.Procedure, _dbDefine.Procedures);
                }
                else if (CheckTagStart(DbtFileTags.JavaSources, str))
                {
                    DoReadNodes<IJavaSourceClass>(DbtFileTags.JavaSources, DbtFileTags.JavaSource, _dbDefine.JavaSources);
                }
                else if (CheckTagStart(DbtFileTags.Views, str))
                {
                    DoReadNodes<IViewClass>(DbtFileTags.Views, DbtFileTags.View, _dbDefine.Views);
                }
                else if (CheckTagStart(DbtFileTags.Jobs, str))
                {
                    DoReadNodes<IJobClass>(DbtFileTags.Jobs, DbtFileTags.Job, _dbDefine.Jobs);
                }
                else if (CheckTagStart(DbtFileTags.Datas, str))
                {
                    _hasReadDatasStart = true;
                    break;
                }
            }

            return _dbDefine;
        }

        public DbData GetNextDataRow()
        {
            if (_datasEnd)
            {
                return null;
            }
            string str = "";
            while (!_fileReader.EndOfStream)
            {
                if (_hasReadDatasStart)//Datas
                {
                DATA:
                    while (!_fileReader.EndOfStream)
                    {
                        if (_hasReadDataStart)//Data
                        {
                            while (!_fileReader.EndOfStream)
                            {
                                if (_hasReadValueStart || _hasReadValueContinue)//读数据
                                {
                                    if (!_hasReadValueStart)
                                    {
                                        while (!_fileReader.EndOfStream)
                                        {
                                            str = ReadLine();
                                            if (string.IsNullOrWhiteSpace(str))
                                            {
                                                continue;
                                            }
                                            if (CheckTagStart(DbtFileTags.DataValue, str))
                                            {
                                                _hasReadValueStart = true;
                                                break;
                                            }
                                            else if (CheckTagEnd(DbtFileTags.Data, str))
                                            {
                                                _hasReadDataStart = false;
                                                _hasReadValueContinue = false;
                                                goto DATA;
                                            }
                                        }
                                    }
                                    if (!_hasReadValueStart)
                                    {
                                        return null;
                                    }
                                    str = DoInReadTagContentNoStart(DbtFileTags.DataValue);
                                    //[1.0,1.0,"eeee","dd ","2015-10-29T00:00:00",null,null,"","rew",2222222222222.0,"你哈哈哈 ",null,null,null,null,"分隔 "]
                                    // Console.WriteLine(str);
                                    string[] objs = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(str);
                                    object[] vals = new object[objs.Length];
                                    for (int i = 0; i < objs.Length; i++)
                                    {
                                        if (objs[i] == null)
                                        {
                                            vals[i] = null;
                                            continue;
                                        }
                                        if (curTableColumnType[i] == typeof(sbyte))
                                        {
                                            vals[i] = sbyte.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(short))
                                        {
                                            vals[i] = short.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(ushort))
                                        {
                                            vals[i] = ushort.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(int))
                                        {
                                            vals[i] = int.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(uint))
                                        {
                                            vals[i] = uint.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(long))
                                        {
                                            vals[i] = long.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(ulong))
                                        {
                                            vals[i] = ulong.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(decimal))
                                        {
                                            vals[i] = decimal.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(float))
                                        {
                                            vals[i] = float.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(double))
                                        {
                                            vals[i] = double.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(bool))
                                        {
                                            vals[i] = bool.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(char))
                                        {
                                            vals[i] = char.Parse(objs[i]);
                                        }
                                        else if (curTableColumnType[i] == typeof(DateTime))
                                        {
                                            vals[i] = DateTime.Parse(objs[i]);
                                        }
                                        else
                                        {
                                            vals[i] = objs[i];
                                        }
                                    }
                                    DbData data = new DbData(_dbDefine.DbType, curTableName, curTableColumnNames, curTableColumnType, curTableDbColumnType, null);
                                    data.TableDataRow.base64TableValues = vals;
                                    data.TableDataRow.ConvertValuesFromBase64();
                                    _hasReadValueStart = false;
                                    _hasReadValueContinue = true;
                                    return data;
                                }
                                else//读列定义
                                {
                                    while (!_fileReader.EndOfStream)
                                    {
                                        str = ReadLine();
                                        if (string.IsNullOrWhiteSpace(str))
                                        {
                                            continue;
                                        }
                                        if (CheckTagStart(DbtFileTags.DataTableName, str))
                                        {
                                            curTableName = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(DoInReadTagContentNoStart(DbtFileTags.DataTableName));
                                        }
                                        else if (CheckTagStart(DbtFileTags.DataColumnType, str))
                                        {
                                            curTableColumnType = Newtonsoft.Json.JsonConvert.DeserializeObject<Type[]>(DoInReadTagContentNoStart(DbtFileTags.DataColumnType));
                                        }
                                        else if (CheckTagStart(DbtFileTags.DataColumnDbType, str))
                                        {
                                            Type type = MyDbHelper.GetDbObjectType(typeof(IDataDbType[]), _dbtFile.DbType);
                                            str = DoInReadTagContentNoStart(DbtFileTags.DataColumnDbType);
                                            Array objs = (Array)Newtonsoft.Json.JsonConvert.DeserializeObject(str, type);
                                            curTableDbColumnType = new object[objs.Length];
                                            objs.CopyTo(curTableDbColumnType, 0);
                                            /*
                                            switch (_dbtFile.DbType)
                                            {
                                                case MyDbType.None:
                                                    break;
                                                case MyDbType.Oracle:
                                                    OracleDbType[] dbtypes = Newtonsoft.Json.JsonConvert.DeserializeObject<OracleDbType[]>(DoInReadTagContentNoStart(DbtFileTags.DataColumnDbType));
                                                    curTableDbColumnType = new object[dbtypes.Length];
                                                    for (int i=0;i<dbtypes.Length;i++)
                                                    {
                                                        curTableDbColumnType[i] = dbtypes[i];
                                                    }
                                                    break;
                                                case MyDbType.MySql:
                                                    break;
                                                case MyDbType.SqlServer:
                                                    break;
                                                default:
                                                    break;
                                            }*/
                                        }
                                        else if (CheckTagStart(DbtFileTags.DataCulumnName, str))
                                        {
                                            curTableColumnNames = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(DoInReadTagContentNoStart(DbtFileTags.DataCulumnName));
                                        }
                                        else if (CheckTagStart(DbtFileTags.DataCount, str))
                                        {
                                            curTableDataCount = Newtonsoft.Json.JsonConvert.DeserializeObject<decimal>(str);
                                        }
                                        else if (CheckTagStart(DbtFileTags.DataValue, str))
                                        {
                                            _hasReadValueStart = true;
                                            break;
                                        }
                                        else if (CheckTagEnd(DbtFileTags.Data, str))
                                        {
                                            _hasReadDataStart = false;
                                            goto DATA;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                        else
                        {
                            str = ReadLine();
                            if (string.IsNullOrWhiteSpace(str))
                            {
                                continue;
                            }
                            if (CheckTagStart(DbtFileTags.Data, str))
                            {
                                _hasReadDataStart = CheckTagStart(DbtFileTags.Data, str);
                            }
                            else if (CheckTagEnd(DbtFileTags.Datas, str))
                            {
                                _datasEnd = true;
                                return null;
                            }
                        }
                    }
                    break;
                }
                else
                {
                    str = ReadLine();
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        continue;
                    }
                    _hasReadDatasStart = CheckTagStart(DbtFileTags.Datas, str);
                    if (!_hasReadDatasStart)
                    {
                        if (CheckTagEnd(DbtFileTags.DbTFile, str))
                        {
                            _datasEnd = true;
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        public MyDbType GetDbType()
        {
            if (_dbtFile == null)
            {
                return MyDbType.None;
            }
            return _dbtFile.DbType;
        }


        internal bool DoProToDbException(string prefixMsg, ReadToDbExceptionHandle exceptionHandle, Exception ex,string extraMsg=null)
        {
            SetPro(-1, prefixMsg + ":" + ex.Message);
            if (extraMsg!=null)
            {
                SetPro(-1, extraMsg);
            }
           
            if (exceptionHandle != null)
            {
                if (!exceptionHandle(ex))
                {
                    SetPro(100, prefixMsg + ":" + ex.Message);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw ex;
            }
        }

        #region 导入DB事件

        private int _progress = 0;
        public int Progress
        {
            get { return _progress; }
        }
        private string _promsg = "";
        public string ProMsg
        {
            get { return _promsg; }
        }
        public event EventHandler<ProgressChangedArgs> ProgressChanged = null;
        internal void SetPro(int pro, string msg = "")
        {
            if (pro > 100)
            {
                pro = 100;
            }
            _progress = pro;
            _promsg = msg;
            if (ProgressChanged != null)
            {
                ProgressChangedArgs args = new ProgressChangedArgs(pro, msg);
                ProgressChanged(this, args);
            }
        }
        #endregion

        public void ReadToDb(IDbClass dbClass, ReadToDbExceptionHandle exceptionHandle = null,
            bool isReadTables = true,
            bool isReadConstraints = true,
            bool isReadSequences = true,
            bool isReadTriggers = true,
            bool isReadIndexes = true,
            bool isReadFunctions = true,
            bool isReadProcedures = true,
            bool isReadJavaSources = true,
            bool isReadDatas = true)
        {
            int process_start = 0;
            int process_end = 3;

            #region 配置文件打开预加载
            SetPro(process_start, "开始导入数据库文件...");
            if (_dbtFile == null)
            {
                SetPro(100, "数据库配置不正确！");
                return;
            }
            process_start = 1;
            SetPro(process_start, "数据库配置：" + _dbtFile.ToString());
            if (_dbDefine == null)
            {
                SetPro(process_start, "开始读取数据库文件定义...");
                ReadDbDefinition();
            }
            process_start = 2;
            SetPro(process_start);
            if (_dbDefine == null)
            {
                SetPro(100, "数据库文件定义不正确！");
                return;
            }
            #endregion
            SetPro(process_end, "读取到数据库定义:" + _dbDefine.ToString());

            process_start = process_end;
            process_end = 4;
            #region 获取当前表空间
            SetPro(process_start, "开始获取当前表空间...");
            string tableSpaceName = null;
            try
            {
                tableSpaceName = dbClass.GetCurrentTableSpaceName();
            }
            catch (Exception ex)
            {
                if (!DoProToDbException("读取表空间异常", exceptionHandle, ex))
                {
                    return;
                }
            }
            SetPro(process_end, "获取到当前表空间:" + tableSpaceName);
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 20;
            #region 导入表
            if (isReadTables)
            {
                SetPro(process_start, "待导入表的数目:" + _dbDefine.Tables.Count);
                if (_dbDefine.Tables.Count > 0)
                {
                    SetPro(process_start, "开始导入表定义...");
                    float dd = (process_end - process_start) / (float)_dbDefine.Tables.Count;
                    int dtcount = 0;
                    foreach (ITableClass item in _dbDefine.Tables)
                    {
                        dtcount++;
                        int pro = process_start + (int)(dtcount * dd);
                        SetPro(pro, "开始导入表:" + item.TableName);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入表错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 60;
            #region 导入数据
            if (isReadDatas)
            {
                DbData data = this.GetNextDataRow();
                int tablesCount = _dbDefine.Tables.Count == 0 ? 1 : _dbDefine.Tables.Count;
                float dd = (process_end - process_start) / (float)tablesCount;
                int dtcount = 0;
                if (data != null)
                {
                    SetPro(20, "开始导入数据...");
                    int count = -1;
                    string tablename = null;
                    while (data != null)
                    {
                        if (count == -1)
                        {
                            int add = (int)(dtcount * dd);
                            if (add > process_end)
                            {
                                add = process_end;
                            }
                            dtcount++;
                            tablename = data.TableDataRow.tableName;

                            SetPro(process_start + add, "开始导入表：" + tablename + " 的数据...待导入数目:" + curTableDataCount);
                            count = 0;
                        }
                        else if (data.TableDataRow.tableName != tablename)
                        {
                            int add = (int)(dtcount * dd);
                            if (add > process_end)
                            {
                                add = process_end;
                            }
                            SetPro(process_start + add, "导入表：" + tablename + " 的数据个数为：" + count);
                            tablename = data.TableDataRow.tableName;
                            SetPro(process_start + add, "开始导入表：" + tablename + " 的数据...待导入数目:" + curTableDataCount);
                            count = 0;
                            dtcount++;
                        }
                        CreateDataSqlDelegate action = MyDbHelper.GetCreateSqlFunction(data, dbClass.GetClassDbType());
                        CreateDataSqlParams sqlpram = action();
                        try
                        {
                            dbClass.GetDbHelper().ExecuteSql(sqlpram.sql, sqlpram.sql_params);
                        }
                        catch (Exception ex)
                        {
                            if (!DoProToDbException("导入数据错误", exceptionHandle, ex, "执行的SQL:" + sqlpram.sql + "\r\n数据：" + Newtonsoft.Json.JsonConvert.SerializeObject(data.TableDataRow.base64TableValues)))
                            {
                                return;
                            }
                        }
                        count++;
                        data = this.GetNextDataRow();
                    }
                    SetPro(process_end, "导入表：" + tablename + " 的数据个数为：" + count);
                    SetPro(process_end, "导入数据结束.");
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 70;
            #region 导入索引
            if (isReadIndexes)
            {
                SetPro(process_start, "待导入索引个数：" + _dbDefine.Indexes.Count);
                if (_dbDefine.Indexes.Count > 0)
                {
                    SetPro(process_start, "开始导入索引...");
                    float dd = (process_end - process_start) / (float)_dbDefine.Indexes.Count;
                    int dtcount = 0;
                    foreach (IIndexClass item in _dbDefine.Indexes)
                    {
                        dtcount++;
                        SetPro(process_start + (int)(dtcount * dd), "开始导入表:" + item.Table_Name + " 的索引:" + item.Name);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入索引错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    SetPro(process_end, "导入索引结束.");
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 80;
            #region 导入约束
            if (isReadConstraints)
            {
                SetPro(process_start, "待导入表的约束个数：" + _dbDefine.Constraints.Count);
                if (_dbDefine.Constraints.Count > 0)
                {
                    SetPro(process_start, "开始导入表约束...");
                    float dd = (process_end - process_start) / (float)_dbDefine.Constraints.Count;
                    int dtcount = 0;
                    IOrderedEnumerable<IConstraintClass> ordered = _dbDefine.Constraints.OrderBy(m => m.Level);
                    foreach (IConstraintClass item in ordered)
                    {
                        dtcount++;
                        int pro = process_start + (int)(dtcount * dd);
                        SetPro(pro, "开始导入表:" + item.Table_Name + " 的约束:" + item.Name);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入约束错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    SetPro(process_end, "导入约束结束.");
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 85;
            #region 导入序列
            if (isReadSequences)
            {
                SetPro(process_start, "待导入序列个数：" + _dbDefine.Sequences.Count);
                if (_dbDefine.Sequences.Count > 0)
                {
                    SetPro(process_start, "开始导入序列...");
                    float dd = (process_end - process_start) / (float)_dbDefine.Sequences.Count;
                    int dtcount = 0;
                    foreach (ISequenceClass item in _dbDefine.Sequences)
                    {
                        dtcount++;
                        SetPro(process_start + (int)(dtcount * dd), "开始导入序列:" + item.SequenceName);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (Exception ex)
                            {
                                if (!DoProToDbException("导入序列错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    SetPro(process_end, "导入序列结束.");
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 90;
            #region 导入触发器
            if (isReadTriggers)
            {
                SetPro(process_start, "待导入触发器个数：" + _dbDefine.Triggers.Count);

                if (_dbDefine.Triggers.Count > 0)
                {
                    float dd = (process_end - process_start) / (float)_dbDefine.Triggers.Count;
                    int dtcount = 0;
                    SetPro(80, "开始导入触发器...");
                    foreach (ITriggerClass item in _dbDefine.Triggers)
                    {
                        dtcount++;
                        SetPro(process_start + (int)(dtcount * dd), "开始导入表:" + item.Table_Name + " 的触发器:" + item.Name);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入触发器错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
                SetPro(process_end, "导入触发器结束.");
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 95;
            #region 导入过程
            if (isReadProcedures)
            {
                SetPro(process_start, "待导入存储过程个数：" + _dbDefine.Procedures.Count);

                if (_dbDefine.Procedures.Count > 0)
                {
                    float dd = (process_end - process_start) / (float)_dbDefine.Procedures.Count;
                    int dtcount = 0;
                    SetPro(process_start, "开始导入存储过程...");
                    foreach (IProcedureClass item in _dbDefine.Procedures)
                    {
                        dtcount++;
                        SetPro(process_start + (int)(dtcount * dd), "开始导入存储过程:" + item.Name);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入存储过程错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    SetPro(process_end, "导入过程结束.");
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 97;
            #region 导入函数
            if (isReadFunctions)
            {
                SetPro(process_start, "待导入函数个数：" + _dbDefine.Functions.Count);
                if (_dbDefine.Functions.Count > 0)
                {
                    float dd = (process_end - process_start) / (float)_dbDefine.Functions.Count;
                    int dtcount = 0;
                    SetPro(process_start, "开始导入函数...");
                    foreach (IFunctionClass item in _dbDefine.Functions)
                    {
                        dtcount++;
                        SetPro(process_start + (int)(dtcount * dd), "开始导入函数:" + item.Name);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入函数错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    SetPro(process_end, "导入函数结束.");
                }
            }
            #endregion
            SetPro(process_end);

            process_start = process_end;
            process_end = 100;
            #region 导入java资源
            if (isReadJavaSources)
            {
                SetPro(process_start, "待导入Java资源个数：" + _dbDefine.JavaSources.Count);
                if (_dbDefine.JavaSources.Count > 0)
                {
                    float dd = (process_end - process_start) / (float)_dbDefine.JavaSources.Count;
                    int dtcount = 0;
                    SetPro(95, "开始导入Java资源...");
                    foreach (IJavaSourceClass item in _dbDefine.JavaSources)
                    {
                        dtcount++;
                        SetPro(95 + (int)(dtcount * dd), "开始导入java资源:" + item.Name);
                        CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(item, dbClass.GetClassDbType());
                        List<CreateSqlObject> sqlObjs = action(tableSpaceName);
                        foreach (CreateSqlObject sql in sqlObjs)
                        {
                            try
                            {
                                dbClass.GetDbHelper().ExecuteSql(sql.sql);
                            }
                            catch (System.Exception ex)
                            {
                                if (!DoProToDbException("导入Java资源错误", exceptionHandle, ex, "执行的SQL:" + sql.sql))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    SetPro(process_end, "导入Java资源结束.");
                }
            }
            #endregion
            SetPro(process_end, "导入结束.");
        }

        public void Dispose()
        {
            CloseFile();
        }
    }
}
