using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using KeyworderLib;

namespace Keyworder
{
    public partial class Keyworder : Form
    {
        public Keyworder()
        {
            InitializeComponent();
        }

        private void Keyworder_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void allKeywordsTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // return when this event is triggered by code rather than user input
            if (e.Action == TreeViewAction.Unknown)
            {
                return;
            }

            if (e.Node.Nodes.Count > 0)
            {
                UpdateChildNodes(e.Node, e.Node.Checked);
            }

            selectedKeywordsList.Items.Clear();

            foreach (TreeNode categoryNode in allKeywordsTree.Nodes)
            {
                foreach (TreeNode keywordNode in categoryNode.Nodes)
                {
                    if (keywordNode.Checked)
                    {
                        selectedKeywordsList.Items.Add($"\"{keywordNode.Text}\"");
                    }
                }
            }

            SetButtonState();
        }

        private void clearSelectedKeywordsButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void copyToClipboardButton_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < selectedKeywordsList.Items.Count; i++)
            {
                builder.Append(selectedKeywordsList.Items[i]);
                if (i < selectedKeywordsList.Items.Count - 1)
                {
                    builder.Append(",");
                }
            }
            Clipboard.SetText(builder.ToString());
        }

        private static bool AtLeastOneNodeIsChecked(IEnumerable nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    return AtLeastOneNodeIsChecked(node.Nodes);
                }
                if (node.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private void LoadKeywords()
        {
            allKeywordsTree.BeginUpdate();
            allKeywordsTree.Nodes.Clear();
            foreach (var keywordGroup in KeywordRepository.GetKeywordsGroupedByCategory())
            {
                var categoryNode = new TreeNode(keywordGroup.Key);
                foreach (var keyword in keywordGroup.Value)
                {
                    categoryNode.Nodes.Add(keyword);
                }
                allKeywordsTree.Nodes.Add(categoryNode);
            }
            allKeywordsTree.EndUpdate();
        }

        private void ResetForm()
        {
            LoadKeywords();
            selectedKeywordsList.Items.Clear();
            SetButtonState();
        }

        private void SetButtonState()
        {
            var shouldEnable = AtLeastOneNodeIsChecked(allKeywordsTree.Nodes);
            clearSelectedKeywordsButton.Enabled = shouldEnable;
            copyToClipboardButton.Enabled = shouldEnable;
        }

        private static void UpdateChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    UpdateChildNodes(node, nodeChecked);
                }
            }
        }
    }
}
