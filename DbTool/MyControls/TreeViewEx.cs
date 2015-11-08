using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DbTool.MyControls
{
    public partial class TreeViewEx : TreeView
    {
        public TreeViewEx()
        {
            InitializeComponent();
        }

        private void TreeViewEx_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.SelectedNode = e.Node;
        }

        private void TreeViewEx_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
//             if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
//             {
//                 if (timerCanCheck.Enabled)
//                 {
//                     e.Cancel = true;
//                 }
//             }
        }
        private void TreeViewEx_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                SetChildChecked(e.Node, e.Node.Checked);
                SetParentChecked(e.Node, e.Node.Checked);
                //this.Enabled = false;
                //timerCanCheck.Start();
                
            }
        }

        private void SetParentChecked(TreeNode node, bool check)
        {
            if (node.Parent!=null)
            {
                bool find = false;
                foreach (TreeNode item in node.Parent.Nodes)
                {
                    if (item.Checked!=check)
                    {
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    node.Parent.Checked = false;
                }
                else
                {
                    node.Parent.Checked = check;
                }
                SetParentChecked(node.Parent, check);
            }
        }
        private void SetChildChecked(TreeNode node,bool check)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = check;
                SetChildChecked(item, check);
            }
        }

        private void timerCanCheck_Tick(object sender, EventArgs e)
        {
            timerCanCheck.Stop();
            //this.Enabled = true;
        }

        private void TreeViewEx_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

    }
}
