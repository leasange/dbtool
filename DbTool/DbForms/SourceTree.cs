using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbTool.DbClasses;
using System.Threading;

namespace DbTool.DbForms
{
    public partial class SourceTree : UserControl
    {
        private Action _action=null;
        public event EventHandler<EventSourceTreeArgs> EventSource = null;
           
        public enum TreeNodeType
        {
            TABLE,
            TRIGGER,
            SEQUENCE,
            FUNCTION,
            PROCEDURE,
            JAVASOURCE
        }

        private Dictionary<TreeNodeType, string> _dics = new Dictionary<TreeNodeType, string>();

        private IDbClass _dbClass = null;
        public SourceTree()
        {
            InitializeComponent();
            _dics.Add(TreeNodeType.TABLE, "表");
            _dics.Add(TreeNodeType.TRIGGER, "触发器");
            _dics.Add(TreeNodeType.SEQUENCE, "序列");
            _dics.Add(TreeNodeType.FUNCTION, "函数");
            _dics.Add(TreeNodeType.PROCEDURE, "存储过程");
            _dics.Add(TreeNodeType.JAVASOURCE, "Java资源");
            foreach (var item in _dics)
            {
                TreeNode node = new TreeNode(item.Value);
                node.Tag = item.Key;
                node.ToolTipText = "点击后加载";
                this.tvSourceTree.Nodes.Add(node);
                node.Collapse();
            }
            //this.tvSourceTree.ExpandAll();
        }
        public void SetDbClass(IDbClass dbClass)
        {
            _dbClass = dbClass;
            ClearData();
            if (_dbClass==null)
            {
                return;
            }
        }

        private void ClearData()
        {
            foreach (TreeNode item in tvSourceTree.Nodes)
            {
                item.Nodes.Clear();
            }
        }

        private void DoLoadTreeData()
        {
            if (_action == null)
            {
                return;
            }
            UpdateState(true);
            Thread thread = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        try
                        {
                            _action();
                            this.Invoke(new Action(() =>
                                {
                                    this.tvSourceTree.SelectedNode.Expand();
                                }));
                        }
                        catch (System.Exception ex)
                        {
                            this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show("加载异常：" + ex.Message);
                                }));
                        }
                        finally
                        {
                            this.Invoke(new Action(() =>
                            {
                                UpdateState(false);
                            }));
                        }
                    }
                    catch (Exception)
                    {
                    }
                }));
            thread.IsBackground = true;
            thread.Start();
        }
        private void UpdateState(bool loading)
        {
            tbFilter.Text = "";
            lbLoading.Visible = loading;
            tbFilter.Enabled = !loading;
            tvSourceTree.Enabled = !loading;
        }
        //加载用户表
        private void LoadTables()
        {
            List<ITableClass> tableClasses = _dbClass.GetTables();
            this.Invoke(new Action(() =>
            {
                foreach (ITableClass item in tableClasses)
                {
                    TreeNode node = new TreeNode(Convert.ToString(item.TableName));
                    node.Tag = item;
                    node.ToolTipText = item.Comments;
                    tvSourceTree.SelectedNode.Nodes.Add(node);
                }
            }));
        }
        //加载序列
        private void LoadUserSeqs()
        {
            List<ISequenceClass> segs = _dbClass.GetSequences();
            this.Invoke(new Action(() =>
            {
                foreach (ISequenceClass item in segs)
                {
                    TreeNode node = new TreeNode(Convert.ToString(item.SequenceName));
                    node.Tag = item;
                    tvSourceTree.SelectedNode.Nodes.Add(node);
                }
            }));
        }
        //加载触发器
        private void LoadUserTris()
        {
            List<ITriggerClass> triss = _dbClass.GetTriggers();
            this.Invoke(new Action(() =>
           {
               foreach (ITriggerClass item in triss)
               {
                   TreeNode node = new TreeNode(item.Name);
                   node.Tag = item;
                   tvSourceTree.SelectedNode.Nodes.Add(node);
               }
           }));
        }
        //加载函数
        private void LoadUserFunctions()
        {
            List<IFunctionClass> funcs = _dbClass.GetFunctions();
            this.Invoke(new Action(() =>
           {
               foreach (IFunctionClass item in funcs)
               {
                   TreeNode node = new TreeNode(Convert.ToString(item.Name));
                   node.Tag = item;
                   tvSourceTree.SelectedNode.Nodes.Add(node);
               }
           }));
        }
        //加载存储过程
        private void LoadUserProcedures()
        {
            List<IProcedureClass> proces = _dbClass.GetProcedures();
            this.Invoke(new Action(() =>
           {
            foreach (IProcedureClass item in proces)
            {
                TreeNode node = new TreeNode(Convert.ToString(item.Name));
                node.Tag = item;
                tvSourceTree.SelectedNode.Nodes.Add(node);
            }
           }));
        }
        //加载java资源
        private void LoadUserJavaSources()
        {
            List<IJavaSourceClass> javas = _dbClass.GetJavaSources();
            this.Invoke(new Action(() =>
           {
               foreach (IJavaSourceClass item in javas)
               {
                   TreeNode node = new TreeNode(Convert.ToString(item.Name));
                   node.Tag = item;
                   tvSourceTree.SelectedNode.Nodes.Add(node);
               }
           }));
        }

        protected void OnSourceEvent(EventSourceTreeArgs args)
        {
            if (EventSource!=null)
            {
                EventSource(this, args);
            }
        }
        private void tvSourceTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvSourceTree.SelectedNode = e.Node;
            if (e.Node.Level==0&&e.Node.Nodes.Count==0)
            {
                TreeNodeType type = (TreeNodeType)e.Node.Tag;
                _action = null;
                switch (type)
                {
                    case TreeNodeType.TABLE:
                        _action = LoadTables;
                        break;
                    case TreeNodeType.TRIGGER:
                        _action = LoadUserTris;
                        break;
                    case TreeNodeType.SEQUENCE:
                        _action = LoadUserSeqs;
                        break;
                    case TreeNodeType.FUNCTION:
                        _action = LoadUserFunctions;
                        break;
                    case TreeNodeType.PROCEDURE:
                        _action = LoadUserProcedures;
                        break;
                    case TreeNodeType.JAVASOURCE:
                        _action = LoadUserJavaSources;
                        break;
                    default:
                        break;
                }
                DoLoadTreeData();
            }
        }

        private void tvSourceTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level==1)
            {
                EventSourceTreeArgs args = new EventSourceTreeArgs(EventSourceType.Open, e.Node.Tag);
                OnSourceEvent(args);
            }
        }
    }
    public enum EventSourceType
    {
        Open,//打开
        Select,//查询
        Insert,//插入
        Update,//更新
        Delete,//删除
    }
    public class EventSourceTreeArgs : EventArgs
    {
        private EventSourceType _eventSourceType= EventSourceType.Open;
        public DbTool.DbForms.EventSourceType EventSourceType
        {
            get { return _eventSourceType; }
        }
        private object _sourceObject=null;
        public object SourceObject
        {
            get { return _sourceObject; }
        }
        public EventSourceTreeArgs(EventSourceType type = EventSourceType.Open,object obj=null)
        {
            _eventSourceType = type;
            _sourceObject = obj;
        }
    }
}
