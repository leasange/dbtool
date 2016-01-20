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
    public partial class DbClassSelectedCtrl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DbTool.DbClasses.DbClassSelected DbClassSelected
        {
            get 
            {
                DbTool.DbClasses.DbClassSelected selected = new DbTool.DbClasses.DbClassSelected();
                selected.isConstraintsChecked = cbContras.Checked;
                selected.isDatasChecked = cbData.Checked;
                selected.isFunctionsChecked = cbFunction.Checked;
                selected.isIndexesChecked = cbIndex.Checked;
                selected.isJavaSourcesChecked = cbJavaSource.Checked;
                selected.isJobsChecked = cbJob.Checked;
                selected.isProceduresChecked = cbProcedure.Checked;
                selected.isSequencesChecked = cbSequence.Checked;
                selected.isTablesChecked = cbTable.Checked;
                selected.isTriggersChecked = cbTrigger.Checked;
                selected.isViewsChecked = cbView.Checked;
                return selected;
            }
            set
            {
                cbContras.Checked = value.isConstraintsChecked;
                cbData.Checked = value.isDatasChecked;
                cbFunction.Checked = value.isFunctionsChecked;
                cbIndex.Checked = value.isIndexesChecked;
                cbJavaSource.Checked = value.isJavaSourcesChecked;
                cbJob.Checked = value.isJobsChecked;
                cbProcedure.Checked = value.isProceduresChecked;
                cbSequence.Checked = value.isSequencesChecked;
                cbTable.Checked = value.isTablesChecked;
                cbTrigger.Checked = value.isTriggersChecked;
                cbView.Checked = value.isViewsChecked;
            }
        }

        public DbClassSelectedCtrl()
        {
            InitializeComponent();
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb == null)
                {
                    continue;
                }
                cb.Checked = true;
            }
        }

        private void btnSelectEx_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb == null)
                {
                    continue;
                }
                cb.Checked = !cb.Checked;
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb==null)
                {
                    continue;
                }
                cb.Checked = false;
            }
        }
    }
}
