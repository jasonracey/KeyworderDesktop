using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            if (!textBoxCategory.HasText())
            {
                labelCreateCategory.Text = @"Please specify a category.";
                labelCreateCategory.Visible = true;
                return;
            }

            var category = textBoxCategory.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            category = textInfo.ToTitleCase(category);

            KeywordRepository.CreateCategory(category);

            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            RefreshSelectTab(keywords);

            labelCreateCategory.Text = @"Category created!";
            labelCreateCategory.Visible = true;
        }

        private void buttonCreateKeyword_Click(object sender, EventArgs e)
        {
            if (!comboBoxCategory.HasSelection())
            {
                labelCreateKeyword.Text = @"Please select a category.";
                labelCreateKeyword.Visible = true;
                return;
            }

            if (!textBoxKeyword.HasText())
            {
                labelCreateKeyword.Text = @"Please specify a keyword.";
                labelCreateKeyword.Visible = true;
                return;
            }

            var category = comboBoxCategory.SelectedItem.ToString();
            var keyword = textBoxKeyword.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            keyword = textInfo.ToTitleCase(keyword);

            KeywordRepository.CreateKeyword(category, keyword);

            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            RefreshSelectTab(keywords);

            labelCreateKeyword.Text = @"Keyword created!";
            labelCreateKeyword.Visible = true;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCreateTabButtonState();
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {
            labelCreateCategory.Visible = false;
            SetCreateTabButtonState();
        }

        private void textBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            labelCreateKeyword.Visible = false;
            SetCreateTabButtonState();
        }

        private void treeViewAllKeywords_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // return when this event is triggered by code rather than user input
            if (e.Action == TreeViewAction.Unknown)
            {
                return;
            }
            NodeHandler.UpdateChildNodes(e.Node, e.Node.Checked);
            PopulateListBoxSelectedItems(treeViewAllKeywords.Nodes);
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
            labelCreateCategory.Visible = false;
            labelCreateKeyword.Visible = false;
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

        private void PopulateListBoxSelectedItems(IEnumerable treeNodes)
        {
            listBoxSelectedKeywords.BeginUpdate();
            listBoxSelectedKeywords.Items.Clear();
            foreach (TreeNode categoryNode in treeNodes)
            {
                foreach (TreeNode keywordNode in categoryNode.Nodes)
                {
                    if (keywordNode.Checked)
                    {
                        var text = $"\"{keywordNode.Text}\"";
                        // don't add duplicate keywords even if from different categories
                        if (!listBoxSelectedKeywords.Items.Contains(text))
                        {
                            listBoxSelectedKeywords.Items.Add(text);
                        }
                    }
                }
            }
            listBoxSelectedKeywords.EndUpdate();
        }

        private void PopulateTreeViewAllKeywords(SortedDictionary<string, SortedSet<string>> keywords)
        {
            treeViewAllKeywords.BeginUpdate();
            treeViewAllKeywords.Nodes.Clear();
            foreach (var keywordGroup in keywords)
            {
                // if user created a category but hasn't assigned any keywords to it yet
                if (keywordGroup.Value.Count == 0)
                {
                    continue;
                }
                var categoryNode = new TreeNode(keywordGroup.Key);
                foreach (var keyword in keywordGroup.Value)
                {
                    categoryNode.Nodes.Add(keyword);
                }
                treeViewAllKeywords.Nodes.Add(categoryNode);
            }
            treeViewAllKeywords.EndUpdate();
        }

        private void RefreshSelectTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            var state = NodeHandler.GetState(treeViewAllKeywords.Nodes);
            PopulateTreeViewAllKeywords(keywords);
            NodeHandler.SetState(treeViewAllKeywords.Nodes, state);
            PopulateListBoxSelectedItems(treeViewAllKeywords.Nodes);
        }

        private void SetCreateTabButtonState()
        {
            buttonCreateKeyword.Enabled = comboBoxCategory.HasSelection() && textBoxKeyword.HasText();
            buttonCreateCategory.Enabled = textBoxCategory.HasText();
        }

        private void SetSelectTabButtonState()
        {
            var shouldEnable = NodeHandler.AtLeastOneNodeIsChecked(treeViewAllKeywords.Nodes);
            buttonClearSelections.Enabled = shouldEnable;
            buttonCopyToClipboard.Enabled = shouldEnable;
        }
    }
}