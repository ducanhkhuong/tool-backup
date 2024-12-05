

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace tool_backup
{
    public class treeview
    {
        private TreeView treeView;
        private TextBox displayTextBox;
        private Action<string> updateFormVariable;
        private string var_download_log;
        private string var_download_db;

        public treeview(TreeView treeView, TextBox displayTextBox, Action<string> updateFormVariable)
        {
            this.treeView = treeView;
            this.displayTextBox = displayTextBox;
            this.updateFormVariable = updateFormVariable;
            InitializeTreeView();
        }

        public void UpdatePaths(string pathLog, string pathDB)
        {
            this.var_download_log = pathLog;
            this.var_download_db = pathDB;
            ResetTreeView();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            TreeNode nodeA = new TreeNode("1.Upload");
            TreeNode nodeA1 = new TreeNode("DataBase");

            TreeNode nodeB = new TreeNode("2.Download");
            TreeNode nodeB1 = new TreeNode("LogFile");
            nodeB1.Nodes.Add(new TreeNode("hcg1.log") { Tag = var_download_log + "hcg1.log" });
            nodeB1.Nodes.Add(new TreeNode("PM.log") { Tag = var_download_log + "PM.log" });
            nodeB1.Nodes.Add(new TreeNode("bluetooth.log") { Tag = var_download_log + "bluetooth.log" });
            nodeB1.Nodes.Add(new TreeNode("io-service.log") { Tag = var_download_log + "io-service.log" });
            nodeB1.Nodes.Add(new TreeNode("ip.log") { Tag = var_download_log + "ip.log" });
            nodeB1.Nodes.Add(new TreeNode("network-service.log") { Tag = var_download_log + "network-service.log" });
            nodeB1.Nodes.Add(new TreeNode("ota.log") { Tag = var_download_log + "ota.log" });
            nodeB1.Nodes.Add(new TreeNode("zigbee.log") { Tag = var_download_log + "zigbee.log" });
            nodeB1.Nodes.Add(new TreeNode("activator-client.log(V2-V3)") { Tag = var_download_log + "activator-client.log" });
            nodeB1.Nodes.Add(new TreeNode("aibox.log(V2-V3)") { Tag = var_download_log + "aibox.log" });
            nodeB1.Nodes.Add(new TreeNode("bluesea-edge.log (V2-V3)") { Tag = var_download_log + "bluesea-edge.log" });
            nodeB1.Nodes.Add(new TreeNode("dnet.log (V2-V3)") { Tag = var_download_log + "dnet.log" });
            nodeB1.Nodes.Add(new TreeNode("hc-module.log (V2-V3)") { Tag = var_download_log + "hc-module.log" });
            nodeB1.Nodes.Add(new TreeNode("io-manager.log (V2-V3)") { Tag = var_download_log + "io-manager.log" });
            nodeB1.Nodes.Add(new TreeNode("process-manager.log (V2-V3)") { Tag = var_download_log + "process-manager.log" });
            nodeB1.Nodes.Add(new TreeNode("relay-agent.log (V2-V3)") { Tag = var_download_log + "relay-agent.log" });
            nodeB1.Nodes.Add(new TreeNode("streaming-module.log (V2-V3)") { Tag = var_download_log + "streaming-module.log" });
            nodeB1.Nodes.Add(new TreeNode("updater.log (V2-V3)") { Tag = var_download_log + "updater.log" });

            TreeNode nodeB2 = new TreeNode("DataBase");
            nodeB2.Nodes.Add(new TreeNode("DataBase") { Tag = var_download_db });

            nodeA.Nodes.Add(nodeA1);
            nodeB.Nodes.Add(nodeB1);
            nodeB.Nodes.Add(nodeB2);

            treeView.Nodes.Add(nodeA);
            treeView.Nodes.Add(nodeB);

            treeView.AfterSelect += TreeView_AfterSelect;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            string path = BuildFullPath(selectedNode);
            displayTextBox.Text = path;
            updateFormVariable(path);
        }

        private string BuildFullPath(TreeNode node)
        {
            string fullPath = node.Tag != null ? node.Tag.ToString() : string.Empty;
            while (node.Parent != null)
            {
                node = node.Parent;
                fullPath = node.Tag != null ? node.Tag.ToString() + fullPath : fullPath;
            }

            return fullPath;
        }

        public void ResetTreeView()
        {
            treeView.Nodes.Clear();
        }
        public string[] GetAllPaths()
        {
            var paths = new List<string>();
            foreach (TreeNode node in treeView.Nodes)
            {
                GetPathsFromNode(node, paths);
            }
            return paths.ToArray();
        }

        private void GetPathsFromNode(TreeNode node, List<string> paths)
        {

            if (node.Tag != null)
            {
                paths.Add(node.Tag.ToString());
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                GetPathsFromNode(childNode, paths);
            }
        }
    }
}
