using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhishDetect.UserControls
{
    public partial class Tree : UserControl
    {
        public Tree()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"D:\Phish Detect\ruleset.txt");
          
            TreeNode node;

            node = treeView1.Nodes.Add("Master node");
            node.Nodes.Add("Child node");
            node.Nodes.Add("Child node 2");

            node = treeView1.Nodes.Add("Master node 2");
            node.Nodes.Add("mychild");
            node.Nodes.Add("mychild");
            treeView1.Nodes.Add("ParentKey", "Parent Text");

        }
    }
}
