using DbTool.DbClasses;
using DbTool.DbForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace DbTool
{
    public partial class FrmMain : Form
    {
        private static FrmMain _frmMain = null;
        public static DbTool.FrmMain Main
        {
            get { return _frmMain; }
        }
        
        public FrmMain()
        {
            InitializeComponent();
            tvConnectList.ShowNodeToolTips = true;
            _frmMain = this;
        }

        public void ShowOrActiveForm(Form form)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (form!=item&&item.WindowState == FormWindowState.Maximized)
                {
                    item.WindowState = FormWindowState.Normal;
                    item.Location = new Point(0, 0);
                    item.Size = new Size(this.ClientSize.Width - tvConnectList.Width - splitter1.Width-30, this.ClientSize.Height-this.menuMain.Height-30);
                }
            }
            if (form.MdiParent==null)
            {
                form.MdiParent = this;
                ToolStripMenuItem item = new ToolStripMenuItem(form.Text);
                item.Tag = form;
                tssbWins.DropDownItems.Add(item);
                form.Show();
                form.FormClosed += form_FormClosed;
                form.TextChanged += form_TextChanged;
            }
            form.BringToFront();
            this.ActivateMdiChild(form);
        }

        void form_TextChanged(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in tssbWins.DropDownItems)
            {
                if (item.Tag == sender)
                {
                    item.Text = ((Form)sender).Text;
                    return;
                }
            }
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (ToolStripMenuItem item in tssbWins.DropDownItems)
            {
                if (item.Tag == sender)
                {
                    tssbWins.DropDownItems.Remove(item);
                    ((Form)sender).FormClosed -= form_FormClosed;
                    ((Form)sender).TextChanged -= form_TextChanged;
                    return;
                }
            }
        }

        public void SaveConnectInfos()
        {
            try
            {
                List<DbConnectConfigure> configures = new List<DbConnectConfigure>();
                foreach (TreeNode item in this.tvConnectList.Nodes[0].Nodes)
                {
                    ConnectInfo info = (ConnectInfo)item.Tag;
                    configures.Add(info.DbConnectConfigure);
                }
                string path = Application.StartupPath + "\\connectconfigures.json";
                FileStream fs = File.Open(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(Newtonsoft.Json.JsonConvert.SerializeObject(configures));
                sw.Flush();
                sw.Close();
                sw.Dispose();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("保存配置异常！");
            }
        }

        private void OpenConnectInfos()
        {
            try
            {
                string path = Application.StartupPath + "\\connectconfigures.json";
                FileStream fs = File.Open(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string str = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                fs.Dispose();
                List<DbConnectConfigure> configures = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DbConnectConfigure>>(str);
                foreach (DbConnectConfigure item in configures)
                {
                    TreeNode node = new TreeNode();
                    ConnectInfo info = new ConnectInfo(node);
                    tvConnectList.Nodes[0].Nodes.Add(node);
                    node.Tag = info;
                    info.DbConnectConfigure = item;
                }
                tvConnectList.ExpandAll();
            }
            catch (Exception)
            {
            }

        }

        private void openOracle_Click(object sender, EventArgs e)
        {
            FrmOracle oracle = new FrmOracle();
            oracle.MdiParent = this;
            oracle.Show();
        }

        private void tsmiNewConnect_Click(object sender, EventArgs e)
        {
            NewConnectDb();
        }

        private void NewConnectDb(DbConnectConfigure configure = null,ConnectInfo info = null, TreeNode node=null)
        {
            FrmOpenDb openDb = new FrmOpenDb();
            DialogResult dr = openDb.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (node == null)
                {
                    node = new TreeNode();
                    tvConnectList.Nodes[0].Nodes.Add(node);
                }
                if (info==null)
                {
                    info = new ConnectInfo(node);
                }
                node.Tag = info;
                info.DbConnectConfigure = openDb.DbConnectConfigure;
                if (dr == DialogResult.OK)
                {
                    FrmDatabase frmdb = new FrmDatabase(openDb.DbClass);
                    frmdb.DbConnectConfigure = info.DbConnectConfigure;
                    info.FrmDataBase = frmdb;
                    ShowOrActiveForm(frmdb);
                }
                info.Node = node;
                tvConnectList.ExpandAll();
                SaveConnectInfos();
            }
        }

        private void tvConnectList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button!= MouseButtons.Left)
            {
                return;
            }
            ConnectInfo info = e.Node.Tag as ConnectInfo;
            DoOpen(info);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.  
                    MdiClient ctlMDI =  ctl as MdiClient;
                    // Set the BackColor of the MdiClient control. 
                    if (ctlMDI!=null)
                    {
                        ctlMDI.BackColor = this.BackColor;
                    }
                   
                }
                catch (Exception ex)
                {
                    // Catch and ignore the error if casting failed.  
                }
            }
            OpenConnectInfos();
        }

        private void tvConnectList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvConnectList.SelectedNode = e.Node;
            ConnectInfo info = e.Node.Tag as ConnectInfo;
            if (info != null)
            {
                if (info.FrmDataBase != null)
                {
                    ShowOrActiveForm(info.FrmDataBase);
                }

                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip.Show(Cursor.Position);
                }

            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            ConnectInfo info = tvConnectList.SelectedNode.Tag as ConnectInfo;
            DoOpen(info);
        }
        private void DoOpen(ConnectInfo info)
        {
            if (info != null)
            {
                if (info.FrmDataBase != null)
                {
                    ShowOrActiveForm(info.FrmDataBase);
                }
                else if (info.DbConnectConfigure != null)
                {
                    FrmDatabase frmdb = new FrmDatabase(null);
                    info.FrmDataBase = frmdb;
                    ShowOrActiveForm(frmdb);
                    frmdb.DbConnectConfigure = info.DbConnectConfigure;
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            ConnectInfo info = tvConnectList.SelectedNode.Tag as ConnectInfo;
            if (info!=null)
            {
                if (MessageBox.Show("确定删除该连接？","提示",MessageBoxButtons.OKCancel)== DialogResult.OK)
                {
                    tvConnectList.Nodes[0].Nodes.Remove(tvConnectList.SelectedNode);
                    if (info.FrmDataBase != null)
                    {
                        info.FrmDataBase.Close();
                    }
                    SaveConnectInfos();
                }
            }
        }

        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            foreach (TreeNode item in tvConnectList.Nodes[0].Nodes)
            {
                ConnectInfo info = (ConnectInfo)item.Tag;
                if (info.FrmDataBase!=null&&info.FrmDataBase == this.ActiveMdiChild)
                {
                    tvConnectList.SelectedNode = item;
                    break;
                }
            }
            foreach (ToolStripMenuItem item in tssbWins.DropDownItems)
            {
                if (item.Tag == this.ActiveMdiChild)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void tssbWins_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form form = (Form)e.ClickedItem.Tag;
            ShowOrActiveForm(form);
        }
    }
}
