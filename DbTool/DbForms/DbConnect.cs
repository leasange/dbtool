using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbTool.DbClasses;

namespace DbTool.DbForms
{

    public class DbConnectConfigure
    {
        public string connectName;
        public MyDbType dbType;
        public string userName;
        public string pwd;
        public string server;
        public string database;
        public string connectString;
        public bool useConnectString;

        public new string ToString()
        {
            string temp = "连接名:" + connectName + "\r\n";
            temp += "数据库类型：" + Enum.GetName(typeof(MyDbType), dbType) + "\r\n";
            if (useConnectString)
            {
                temp += "连接字符串:" + connectString;
            }
            else
            {
                temp += "用户名：" + userName + "\r\n";
                temp += "服务器：" + server + "\r\n";
                temp += "数据库/实例:" + database;
            }
            return temp;
        }
        public string GetSimpleText()
        {
            return this.connectName + "-[" + Enum.GetName(typeof(MyDbType), this.dbType) + "]";
        }
        public string GetConnectString()
        {
            if (useConnectString)
            {
                return connectString;
            }
            return "";
        }
        public IDbClass GetDbClass()
        {
            IDbClass dbClass = null;
            string connectString = GetConnectString();
            dbClass = MyDbHelper.GetDbClass(connectString, dbType);
            if (dbClass != null)
            {
                dbClass.Open();
            }
            return dbClass;
        }
    }

    public class ConnectInfo
    {
        private DbConnectConfigure _dbConnectConfigure;
        public DbTool.DbForms.DbConnectConfigure DbConnectConfigure
        {
            get { return _dbConnectConfigure; }
            set 
            { 
                _dbConnectConfigure = value;
                UpdateNodeText();
            }
        }
        private FrmDatabase _frmDataBase;
        public DbTool.FrmDatabase FrmDataBase
        {
            get { return _frmDataBase; }
            set
            {
                RemoveEvent();
                _frmDataBase = value;
                AddEvent();
            }
        }

        private TreeNode _node = null;
        public System.Windows.Forms.TreeNode Node
        {
            get { return _node; }
            set 
            { 
                _node = value;
                UpdateNodeText();
            }
        }
        public ConnectInfo(TreeNode node = null)
        {
            _node = node;
        }

        private void RemoveEvent()
        {
            if (_frmDataBase != null)
            {
                _frmDataBase.NewConnect -= _frmDataBase_NewConnect;
                _frmDataBase.FormClosing -= _frmDataBase_FormClosing;
            }
        }
        private void AddEvent()
        {
            if (_frmDataBase != null)
            {
                _frmDataBase.NewConnect += _frmDataBase_NewConnect;
                _frmDataBase.FormClosing += _frmDataBase_FormClosing;
            }
        }
        private void UpdateNodeText()
        {
            if (_node!=null&&_dbConnectConfigure!=null)
            {
                string text = _dbConnectConfigure.GetSimpleText();
                _node.Text = text;
                _node.ToolTipText = _dbConnectConfigure.ToString();
            }
        }
        void _frmDataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveEvent();
            _frmDataBase.DbConnectConfigure = null;
            _frmDataBase = null;
        }

        void _frmDataBase_NewConnect(object sender, EventArgs e)
        {
            _dbConnectConfigure = _frmDataBase.DbConnectConfigure;
            UpdateNodeText();
            FrmMain.Main.SaveConnectInfos();
        }
    }
}
