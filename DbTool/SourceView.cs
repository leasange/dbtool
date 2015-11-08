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
    public partial class SourceView : UserControl
    {
        public TextBox TextSql
        {
            get { return this.tbSql; }
        }
        public SourceView()
        {
            InitializeComponent();
        }
    }
}
