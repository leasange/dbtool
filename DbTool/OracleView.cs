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
    public partial class OracleView : UserControl
    {
        public TableView TableView
        {
            get { return this.tableView; }
        }
        public SequenceView SequenceView
        {
            get { return this.sequenceView; }
        }
        public TriggerView TriggerView
        {
            get { return this.triggerView; }
        }
        public SourceView FunctionView
        {
            get { return this.functionView; }
        }
        public SourceView ProcedureView
        {
            get { return this.procedureView; }
        }
        public SourceView JavaSourceView
        {
            get { return this.javaSourceView; }
        }
        public TabControl TabControl
        {
            get { return this.tabControl; }
        }
        public event EventHandler<LoadDataEventArgs> LoadDataEvent = null;
        public OracleView()
        {
            InitializeComponent();
        }

        private void tableView_LoadDataEvent(object sender, LoadDataEventArgs e)
        {
            if (LoadDataEvent!=null)
            {
                LoadDataEvent(sender, e);
            }
        }
    }
}
