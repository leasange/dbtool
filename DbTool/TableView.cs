using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbTool
{
    public partial class TableView : UserControl
    {
        public DataGridView TableColGrid
        {
            get { return this.dgvCol; }
        }
        public DataGridView TableNormalGrid
        {
            get { return this.dgvNormal; }
        }
        public DataGridView TableKeysGrid
        {
            get { return this.dgvKeys; }
        }
        public DataGridView TableIndexsGrid
        {
            get { return this.dgvIndexs; }
        }
        public DataGridView TableDataGrid
        {
            get { return this.dgvData; }
        }
        public event EventHandler<LoadDataEventArgs> LoadDataEvent = null;
        public TextBox TextSql
        {
            get { return this.tbSql; }
        }
        private string table_name;
        public string Table_name
        {
            get { 
                return table_name; 
            }
            set { 
                table_name = value; 
                if (tabControl.SelectedIndex==4)
                {
                    tabControl_SelectedIndexChanged(null, null);
                }
            }
        }
        public TableView()
        {
            InitializeComponent();
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvData.DataSource == null)
            {
                btnMore_Click(sender, e);
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(table_name))
            {
                return;
            }
            if (LoadDataEvent!=null)
            {
                LoadDataEventArgs args = new LoadDataEventArgs(dgvData.Rows.Count, 60);
                LoadDataEvent(this, args);
                if (args.RetTable==null||args.RetTable.Rows.Count==0)
                {
                    return;
                }
                if (this.dgvData.DataSource != null)
                {
                    DataTable dt = (DataTable)this.dgvData.DataSource;
                    this.dgvData.SuspendLayout();
                    this.dgvData.DataSource = null;
                    foreach (DataRow item in args.RetTable.Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = item.ItemArray;
                        dt.Rows.Add(dr);
                    }
                    this.dgvData.DataSource = dt;
                    this.dgvData.ResumeLayout();
                }
                else
                {
                    this.dgvData.DataSource = args.RetTable;
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }


    }
    public class LoadDataEventArgs : EventArgs
    {
        private int _start;
        public int Start
        {
            get { return _start; }
        }
        private int _length;
        public int Length
        {
            get { return _length; }
        }
        public DataTable RetTable = null;
        public LoadDataEventArgs(int start,int length)
        {
            _start = start;
            _length = length;
        }
    }
}
