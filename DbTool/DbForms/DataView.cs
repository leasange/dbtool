using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbTool.DbClasses;
using System.Threading;

namespace DbTool.DbForms
{
    public partial class DataView : UserControl
    {
        private IDbClass _dbClass;

        private string _sql = "";

        public DbTool.DbClasses.IDbClass DbClass
        {
            get { return _dbClass; }
            set { _dbClass = value; }
        }
        public DataView()
        {
            InitializeComponent();
        }

        public void SetSql(string sql)
        {
            _sql = sql;
            ClearData();
        }

        private DataTable QueryMore(ref bool isLast)
        {
            int start = this.dgvData.Rows.Count;
            int length = this.Height / (this.dgvData.RowTemplate.Height + this.dgvData.ColumnHeadersHeight);
            if (length<50)
            {
                length = 50;
            }
            DataTable dt=null;
            if (_sql.Trim().StartsWith("select", true, null))
            {
                dt = _dbClass.GetDbHelper().ExecuteDataTable(_sql, start, length);
            }
            else
            {
                int ret = _dbClass.GetDbHelper().ExecuteSql(_sql);
                dt = new DataTable();
                dt.Columns.Add("结果", typeof(int));
                DataRow dr = dt.NewRow();
                dr[0] = ret;
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count < length)
            {
                isLast = true;
            }
            else
            {
                isLast = false;
            }
            return dt;
        }

        public void ClearData()
        {
            this.dgvData.Rows.Clear();
            this.dgvData.Columns.Clear();
        }

        public void AddDataTable(DataTable dt)
        {
            Exception exc = null;
            this.Invoke(new Action(() =>
                {
                    this.dgvData.SuspendLayout();
                    try
                    {
                        if (this.dgvData.Columns.Count == 0)
                        {
                            foreach (DataColumn item in dt.Columns)
                            {
                                DataGridViewColumn dgvc = new DataGridViewColumn();
                                dgvc.ValueType = item.DataType;
                                dgvc.CellTemplate = new System.Windows.Forms.DataGridViewTextBoxCell();
                                dgvc.Resizable =  DataGridViewTriState.True;
                                dgvc.SortMode = DataGridViewColumnSortMode.Automatic;
                                dgvc.Name = item.ColumnName;
                                dgvc.HeaderText = item.ColumnName;
                                this.dgvData.Columns.Add(dgvc);
                            }
                        }
                        foreach (DataRow item in dt.Rows)
                        {
                            DataGridViewRow dgvr = new DataGridViewRow();
                            dgvr.CreateCells(dgvData, item.ItemArray);
                            this.dgvData.Rows.Add(dgvr);
                        }
                        //this.dgvData.FirstDisplayedScrollingRowIndex = this.dgvData.Rows.Count - dt.Rows.Count;
                    }
                    catch (Exception ex)
                    {
                        exc = ex;
                    }
                    finally
                    {
                        this.dgvData.ResumeLayout();
                    }
                }));
            if (exc!=null)
            {
                throw exc;
            }
        }

        public void ExcuteMore(ref bool isLast)
        {
            DataTable dt = QueryMore(ref isLast);
            AddDataTable(dt);
        }

        public void ExcuteAll()
        {
            bool ret = false;
            while (!ret)
            {
                ExcuteMore(ref ret);
            }
        }
    }
}
