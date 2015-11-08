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
    public partial class TriggerView : UserControl
    {
        public DataGridView TableNormalGrid
        {
            get { return this.dgvNormal; }
        }
        public TextBox TextSql
        {
            get { return this.tbSql; }
        }
        public TriggerView()
        {
            InitializeComponent();
        }
    }
}
