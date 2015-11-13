using DbTool.DbClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbTool.DbForms
{
    public partial class FrmNormalView : Form
    {
        private IDbClass _dbClass = null;
        private object _object = null;
        public FrmNormalView(IDbClass dbClass,object obj,string text)
        {
            InitializeComponent();
            _dbClass = dbClass;
            _object = obj;
            this.Text = text;
        }

        private void FrmNormalView_Load(object sender, EventArgs e)
        {
            IGetAttribute attri = _object as IGetAttribute;
            if (attri!=null)
            {
                this.dgvNormal.DataSource = NameAliasValue.ToDataTable(attri.GetAttributes());
            }
            ICreateSql creatsql = _object as ICreateSql;
            if (creatsql!=null)
            {
                CreateSqlDelegate action = MyDbHelper.GetCreateSqlFunction(creatsql, _dbClass.GetClassDbType());
                if (action!=null)
                {
                    List<CreateSqlObject> csos = action(_dbClass.GetCurrentTableSpaceName());
                    tbSql.Text = CreateSqlObject.ToCollectionSqls(csos);
                }
            }
        }
    }
}
