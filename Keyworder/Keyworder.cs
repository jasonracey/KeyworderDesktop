using System;
using System.Collections.Generic;
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
            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            InitDeleteTab(keywords);
            InitEditTab(keywords);
            InitSelectTab(keywords);
        }

        private void buttonClearSelections_Click(object sender, EventArgs e)
        {
            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitSelectTab(keywords);
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < listBoxSelectedKeywords.Items.Count; i++)
            {
                builder.Append(listBoxSelectedKeywords.Items[i]);
                if (i < listBoxSelectedKeywords.Items.Count - 1)
                {
                    builder.Append(",");
                }
            }
            Clipboard.SetText(builder.ToString());
            labelKeywordsCopiedToClipboard.Visible = true;
        }

        private void buttonCreateCategory_Click(object sender, EventArgs e)
        {
            // todo
            // data should be stored as xml not csv - there's a 1-to-many relationship
            // to title case?
            // don't add category if it already exists
        }

        private void buttonCreateKeyword_Click(object sender, EventArgs e)
        {
            // todo
            // category must be selected
            // keyword must be specified
            // to title case?
            // trim, replace double spaces
            // don't add keyword if it already exists
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // todo
            // if category is selected and textbox has text then enable button else disable
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {
            // todo
            // if has text then enable button else disable
        }

        private void textBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            // todo
            // if has text and category is selected then enable button else disable
        }

        private void treeViewAllKeywords_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // return when this event is triggered by code rather than user input
            if (e.Action == TreeViewAction.Unknown)
            {
                return;
            }

            if (e.Node.Nodes.Count > 0)
            {
                NodeHandler.UpdateChildNodes(e.Node, e.Node.Checked);
            }

            listBoxSelectedKeywords.Items.Clear();

            foreach (TreeNode categoryNode in treeViewAllKeywords.Nodes)
            {
                foreach (TreeNode keywordNode in categoryNode.Nodes)
                {
                    if (keywordNode.Checked)
                    {
                        listBoxSelectedKeywords.Items.Add($"\"{keywordNode.Text}\"");
                    }
                }
            }

            SetSelectTabButtonState();
            labelKeywordsCopiedToClipboard.Visible = false;
        }

        private void InitCreateTab(SortedDictionary<string, SortedSet<string>> keywordsByCategory)
        {
            comboBoxCategory.Items.Clear();
            foreach (var keyValuePair in keywordsByCategory)
            {
                comboBoxCategory.Items.Add(keyValuePair.Key);
            }
            textBoxKeyword.Clear();
            textBoxCategory.Clear();
            SetCreateTabButtonState();
        }

        private void InitDeleteTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            // todo
        }

        private void InitEditTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            // todo
        }

        private void InitSelectTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            PopulateTreeViewAllKeywords(keywords);
            listBoxSelectedKeywords.Items.Clear();
            SetSelectTabButtonState();
            labelKeywordsCopiedToClipboard.Visible = false;
        }

        private void PopulateTreeViewAllKeywords(SortedDictionary<string, SortedSet<string>> keywords)
        {
            treeViewAllKeywords.BeginUpdate();
            treeViewAllKeywords.Nodes.Clear();
            foreach (var keywordGroup in keywords)
            {
                var categoryNode = new TreeNode(keywordGroup.Key);
                foreach (var keyword in keywordGroup.Value)
                {
                    categoryNode.Nodes.Add(keyword);
                }
                treeViewAllKeywords.Nodes.Add(categoryNode);
            }
            treeViewAllKeywords.EndUpdate();
        }

        private void SetCreateTabButtonState()
        {
            buttonCreateKeyword.Enabled = textBoxKeyword.Text.Trim() != string.Empty;
            buttonCreateCategory.Enabled = textBoxCategory.Text.Trim() != string.Empty;
        }

        private void SetSelectTabButtonState()
        {
            var shouldEnable = NodeHandler.AtLeastOneNodeIsChecked(treeViewAllKeywords.Nodes);
            buttonClearSelections.Enabled = shouldEnable;
            buttonCopyToClipboard.Enabled = shouldEnable;
        }
    }
}