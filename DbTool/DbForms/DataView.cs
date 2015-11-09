using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbTool.DbClasses;

namespace DbTool.DbForms
{
    public partial class DataView : UserControl
    {
        private IDbClass _dbClass;
        //分页
        private string _sqlFormat = "select * from (select t.*, rownum {0} from ({1}) t where rownum <= {2}) where {0} > {3}";
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

        }

        public void ClearData()
        {
            this.dgvData.Rows.Clear();
            this.dgvData.Columns.Clear();
        }

        public void AddDataTable(DataTable dt)
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
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.dgvData.ResumeLayout();
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {

        }

        private void btnAll_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
