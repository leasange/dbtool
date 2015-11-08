using DbTool.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbTool
{
    public partial class FrmSqlWin : Form
    {
        private IDbClass _dbClass = null;
        public FrmSqlWin(IDbClass dbClass)
        {
            InitializeComponent();
            _dbClass = dbClass;
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            string text = this.tbSql.Text;
            if (tbSql.SelectionLength >0)
            {
                text=tbSql.SelectedText;
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("输入SQL为空！");
                return;
            }
            this.dgvResult.DataSource = _dbClass.GetDbHelper().ExecuteDataTable(text);
        }
    }
}
