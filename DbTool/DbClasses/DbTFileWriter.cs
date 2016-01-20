using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DbTool.DbClasses
{
    public class DbTFileWriter : DbtFile, IDisposable
    {
        private StreamWriter _fileWriter = null;
        public DbTFileWriter(string fileNamePath)
        {
            FileStream fs = File.Open(fileNamePath, FileMode.OpenOrCreate, FileAccess.Write);
            _fileWriter = new StreamWriter(fs);
        }
        public void CloseFile()
        {
            if (_fileWriter != null)
            {
                _fileWriter.Flush();
                _fileWriter.Close();
                _fileWriter.Dispose();
                _fileWriter = null;
            }
        }
        internal void BeforeWriteCheck()
        {
            if (_fileWriter == null)
            {
                throw new Exception("文件未打开");
            }
        }
        internal void WriteTagStart(DbtFileTags tag)
        {
            string str = GetTagStart(tag);
            _fileWriter.WriteLine(str);
        }
        internal void WriteTagEnd(DbtFileTags tag)
        {
            string str = GetTagEnd(tag);
            _fileWriter.WriteLine(str);
        }

        public void BeginWrite(DbtFileTags tagsState)
        {
            BeforeWriteCheck();
            WriteTagStart(tagsState);
        }
        public void Write(object obj)
        {
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            _fileWriter.WriteLine(str);
        }
        public void EndWrite(DbtFileTags tagsState)
        {
            WriteTagEnd(tagsState);
        }
        #region IDisposable 成员

        public void Dispose()
        {
            CloseFile();
        }

        #endregion

        #region 导出DB事件

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
        internal void SetPro(int pro, string msg)
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
        public void WriteDb(IDbClass dbClass,DbClassSelected selected)
        {
            SetPro(0, "开始导出数据库类型...");
            BeginWrite(DbtFileTags.DbTFile);
            //写入类型
            BeginWrite(DbtFileTags.DbType);
            Write(dbClass.GetClassDbType());
            EndWrite(DbtFileTags.DbType);

            BeginWrite(DbtFileTags.Version);
            Write(dbClass.GetDbVersionString());
            EndWrite(DbtFileTags.Version);
            SetPro(2, "导出数据库类型结束！");
            if (selected.isTablesChecked)
            {
                SetPro(2, "开始获取表...");
                //写入表
                List<ITableClass> tables = dbClass.GetTables();
                SetPro(10, "获取表个数：" + tables.Count);
                if (tables.Count > 0)
                {
                    SetPro(10, "开始导出表...");
                    BeginWrite(DbtFileTags.Tables);
                    foreach (ITableClass item in tables)
                    {
                        SetPro(15, "开始导出表:" + item.TableName);
                        BeginWrite(DbtFileTags.Table);
                        Write(item);
                        EndWrite(DbtFileTags.Table);
                    }
                    EndWrite(DbtFileTags.Tables);
                    SetPro(25, "导出表结束！");
                }
            }
            SetPro(25, "");
            if (selected.isConstraintsChecked)
            {
                SetPro(25, "开始获取约束...");
                //写入约束
                List<IConstraintClass> conss = dbClass.GetConstraints();
                SetPro(28, "获取约束个数：" + conss.Count);
                if (conss.Count > 0)
                {
                    SetPro(28, "开始导出约束...");
                    BeginWrite(DbtFileTags.Constraints);
                    foreach (IConstraintClass item in conss)
                    {
                        SetPro(30, "导出约束:" + item.Name);
                        BeginWrite(DbtFileTags.Constraint);
                        Write(item);
                        EndWrite(DbtFileTags.Constraint);
                    }
                    EndWrite(DbtFileTags.Constraints);
                    SetPro(35, "导出约束结束！");
                }
            }
            SetPro(35, "");
            if (selected.isSequencesChecked)
            {
                SetPro(35, "开始获取序列...");
                //写入序列
                List<ISequenceClass> seqs = dbClass.GetSequences();
                SetPro(37, "获取序列个数：" + seqs.Count);
                if (seqs.Count > 0)
                {
                    SetPro(37, "开始导出序列...");
                    BeginWrite(DbtFileTags.Sequences);
                    foreach (ISequenceClass item in seqs)
                    {
                        SetPro(39, "导出序列:" + item.SequenceName);
                        BeginWrite(DbtFileTags.Sequence);
                        Write(item);
                        EndWrite(DbtFileTags.Sequence);
                    }
                    EndWrite(DbtFileTags.Sequences);
                    SetPro(40, "结束导出序列.");
                }
            }
            SetPro(40, "");
            if (selected.isTriggersChecked)
            {
                SetPro(40, "开始获取触发器...");
                //写入触发器
                List<ITriggerClass> tris = dbClass.GetTriggers();
                SetPro(41, "获取触发器个数：" + tris.Count);
                if (tris.Count > 0)
                {
                    SetPro(41, "开始导出触发器...");
                    BeginWrite(DbtFileTags.Triggers);
                    foreach (ITriggerClass item in tris)
                    {
                        SetPro(43, "开始导出触发器...");
                        BeginWrite(DbtFileTags.Trigger);
                        Write(item);
                        EndWrite(DbtFileTags.Trigger);
                    }
                    EndWrite(DbtFileTags.Triggers);
                    SetPro(44, "结束导出触发器.");
                }
            }
            SetPro(44, "");
            if (selected.isIndexesChecked)
            {
                SetPro(44, "开始获取索引...");
                //写入索引
                List<IIndexClass> inds = dbClass.GetIndexs();
                SetPro(45, "获取索引个数：" + inds.Count);
                if (inds.Count > 0)
                {
                    SetPro(45, "开始导出索引...");
                    BeginWrite(DbtFileTags.Indexes);
                    foreach (IIndexClass item in inds)
                    {
                        SetPro(46, "导出索引:" + item.Name);
                        BeginWrite(DbtFileTags.Index);
                        Write(item);
                        EndWrite(DbtFileTags.Index);
                    }
                    EndWrite(DbtFileTags.Indexes);
                    SetPro(47, "导出索引结束.");
                }
            }
            SetPro(47, "");
            if (selected.isFunctionsChecked)
            {
                SetPro(47, "开始获取函数...");
                //写入函数
                List<IFunctionClass> funs = dbClass.GetFunctions();
                SetPro(48, "获取函数个数：" + funs.Count);
                if (funs.Count > 0)
                {
                    SetPro(48, "开始导出函数...");
                    BeginWrite(DbtFileTags.Functions);
                    foreach (IFunctionClass item in funs)
                    {
                        SetPro(49, "导出函数:" + item.Name);
                        BeginWrite(DbtFileTags.Function);
                        Write(item);
                        EndWrite(DbtFileTags.Function);
                    }
                    EndWrite(DbtFileTags.Functions);
                    SetPro(50, "导出函数结束.");
                }
            }
            SetPro(50, "");
            if (selected.isProceduresChecked)
            {
                SetPro(50, "开始获取过程...");
                //写入过程
                List<IProcedureClass> pros = dbClass.GetProcedures();
                SetPro(51, "获取过程个数：" + pros.Count);
                if (pros.Count > 0)
                {
                    SetPro(51, "开始导出过程...");
                    BeginWrite(DbtFileTags.Procedures);
                    foreach (IProcedureClass item in pros)
                    {
                        SetPro(51, "导出过程:" + item.Name);
                        BeginWrite(DbtFileTags.Procedure);
                        Write(item);
                        EndWrite(DbtFileTags.Procedure);
                    }
                    EndWrite(DbtFileTags.Procedures);
                    SetPro(52, "导出过程结束.");
                }
            }
            SetPro(52, "");
            if (selected.isJavaSourcesChecked)
            {
                SetPro(52, "开始获取java资源...");
                //写入Java资源
                List<IJavaSourceClass> javas = dbClass.GetJavaSources();
                SetPro(53, "获取java资源个数：" + javas.Count);
                if (javas.Count > 0)
                {
                    SetPro(53, "开始导出java资源...");
                    BeginWrite(DbtFileTags.JavaSources);
                    foreach (IJavaSourceClass item in javas)
                    {
                        SetPro(53, "导出java资源:" + item.Name);
                        BeginWrite(DbtFileTags.JavaSource);
                        Write(item);
                        EndWrite(DbtFileTags.JavaSource);
                    }
                    EndWrite(DbtFileTags.JavaSources);
                    SetPro(54, "导出java资源结束.");
                }
            }
            SetPro(54, "");
            int perleft = 100 - 54;

            if (selected.isDatasChecked)
            {
                SetPro(54, "开始导出数据...");
                //写入数据
                List<ITableClass> tables = dbClass.GetTables();
                if (tables.Count > 0)
                {
                    float dper = perleft / (float)tables.Count;
                    int tcount = 0;
                    BeginWrite(DbtFileTags.Datas);
                    foreach (ITableClass item in tables)
                    {
                        tcount++;
                        decimal totalDataCount = dbClass.GetTableDataCount(item.TableName);
                        SetPro(54 + (int)(tcount * dper), "开始导出表:" + item.TableName + " 的数据...，需导出总数:" + totalDataCount);
                        if (totalDataCount==0)
                        {
                            SetPro(-1, "表 " + item.TableName + " 无数据导出！");
                            continue;
                        }
                        List<DbData> list = dbClass.GetTableData(item.TableName, 0, 50);
                        if (list.Count > 0)
                        {
                            BeginWrite(DbtFileTags.Data);

                            BeginWrite(DbtFileTags.DataTableName);
                            Write(list[0].TableDataRow.tableName);
                            EndWrite(DbtFileTags.DataTableName);

                            BeginWrite(DbtFileTags.DataColumnType);
                            Write(list[0].TableDataRow.tableColumnTypes);
                            EndWrite(DbtFileTags.DataColumnType);

                            BeginWrite(DbtFileTags.DataColumnDbType);
                            Write(list[0].TableDataRow.tableColumnDbTypes);
                            EndWrite(DbtFileTags.DataColumnDbType);

                            BeginWrite(DbtFileTags.DataCulumnName);
                            Write(list[0].TableDataRow.tableColumnNames);
                            EndWrite(DbtFileTags.DataCulumnName);

                            BeginWrite(DbtFileTags.DataCount);
                            Write(totalDataCount);
                            EndWrite(DbtFileTags.DataCount);

                            int start = 0;
                            do
                            {
                                foreach (DbData data in list)
                                {
                                    BeginWrite(DbtFileTags.DataValue);
                                    Write(data.TableDataRow.base64TableValues);
                                    EndWrite(DbtFileTags.DataValue);
                                }
                                if (list.Count != 50)
                                {
                                    SetPro(54 + (int)(tcount * dper), "导出表:" + item.TableName + " 的数据个数为：" + (start + list.Count));
                                    break;
                                }
                                else
                                {
                                    start += 50;
                                    list = dbClass.GetTableData(item.TableName, start, 50);
                                }
                            } while (true);
                            EndWrite(DbtFileTags.Data);
                        }
                    }
                    EndWrite(DbtFileTags.Datas);
                }
            }

            EndWrite(DbtFileTags.DbTFile);
            SetPro(100, "导出结束.");
        }
        public int GetWriteProgress(ref string msg)
        {
            return _progress;
        }
    }
    public class ProgressChangedArgs : EventArgs
    {
        private int _progress;
        public int Progress
        {
            get { return _progress; }
        }
        private string _msg;
        public string Msg
        {
            get { return _msg; }
        }
        public ProgressChangedArgs(int pro, string msg)
        {
            this._progress = pro;
            this._msg = msg;
        }
    }
}
