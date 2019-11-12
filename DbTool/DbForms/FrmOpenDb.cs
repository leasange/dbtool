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
    public partial class FrmOpenDb : Form
    {
        private IDbClass _dbClass = null;
        public IDbClass DbClass
        {
            get { return _dbClass; }
        }
        private static DbConnectConfigure lastConfigure = null;
        public DbConnectConfigure DbConnectConfigure
        {
            get
            {
                DbConnectConfigure dbconnect = new DbConnectConfigure();
                dbconnect.connectName = this.tbConnectName.Text.Trim();
                dbconnect.dbType = (MyDbType)Enum.Parse(typeof(MyDbType), cbDbType.Text);
                dbconnect.connectString = this.tbConnectString.Text.Trim();
                dbconnect.server = this.cbServer.Text.Trim();
                dbconnect.database = this.cbDbName.Text.Trim();
                dbconnect.pwd = this.tbPwd.Text;
                dbconnect.useConnectString = cbUseConnectStr.Checked;
                dbconnect.userName = this.cbUserName.Text;
                lastConfigure = dbconnect;
                return dbconnect;
            }
            set
            {
                if (value==null)
                {
                    tbConnectName.Text = "";
                    cbUserName.Text = "";
                    cbServer.Text = "";
                    cbDbName.Text = "";
                    tbPwd.Text = "";
                    cbDbType.SelectedIndex = 0;
                    tbConnectString.Text = "";
                }
                else
                {
                    tbConnectName.Text = value.connectName;
                    cbUserName.Text = value.userName;
                    cbServer.Text = value.server;
                    cbDbName.Text = value.database;
                    tbPwd.Text = value.pwd;
                    cbDbType.Text = Enum.GetName(typeof(MyDbType),value.dbType);
                    tbConnectString.Text = value.connectString;
                    cbUseConnectStr.Checked = value.useConnectString;
                }
            }
        }

        public FrmOpenDb()
        {
            InitializeComponent();
            LoadDbType();
        }

        private void FrmOpenDb_Load(object sender, EventArgs e)
        {
            tbConnectName.Focus();
            tbConnectName.Select();
        }

        private void LoadDbType()
        {
            string[] dbTypes = Enum.GetNames(typeof(DbTool.DbClasses.MyDbType));
            List<string> strs = new List<string>();
            for (int i = 1; i < dbTypes.Length; i++)//None 排除
            {
                strs.Add(dbTypes[i]);
            }
            cbDbType.DataSource = strs;
            cbDbType.SelectedIndex = 0;
        }
        public void SetDbType(MyDbType type, bool readOnly)
        {
            cbDbType.Text = Enum.GetName(typeof(DbTool.DbClasses.MyDbType), type);
            cbDbType.Refresh();
            cbDbType.Enabled = readOnly;
        }

        private bool CheckInput()
        {
            if (tbConnectName.Text.Trim()=="")
            {
                MessageBox.Show("请输入连接名称！");
                tbConnectName.Focus();
                return false;
            }
            if (cbUseConnectStr.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbConnectString.Text))
                {
                    MessageBox.Show("连接字符串为空！");
                    tbConnectString.Focus();
                    return false;
                }
            }
            return true;
        }

        public string GetConnectString(out MyDbType dbtype)
        {
            dbtype = (MyDbType)Enum.Parse(typeof(MyDbType), cbDbType.Text);
            string temp = "";
            if (cbUseConnectStr.Checked)
            {
                temp = tbConnectString.Text.Trim();
            }
            else
            {

            }
            return temp;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            try
            {
                _dbClass = this.DbConnectConfigure.GetDbClass();            
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("打开数据库失败！"+ex.Message);
            }
        }

        private void FrmOpenDb_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
