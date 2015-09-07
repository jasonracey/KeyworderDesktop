using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            if (!textBoxCreateCategory.HasText())
            {
                labelCreateCategoryMessage.Text = @"Please specify a category.";
                labelCreateCategoryMessage.Visible = true;
                return;
            }

            var category = textBoxCreateCategory.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            category = textInfo.ToTitleCase(category);

            KeywordRepository.CreateCategory(category);

            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            RefreshSelectTab(keywords);

            labelCreateCategoryMessage.Text = @"Category created!";
            labelCreateCategoryMessage.Visible = true;
        }

        private void buttonCreateKeyword_Click(object sender, EventArgs e)
        {
            if (!comboBoxCategoryOfKeywordToCreate.HasSelection())
            {
                labelCreateKeywordMessage.Text = @"Please select a category.";
                labelCreateKeywordMessage.Visible = true;
                return;
            }

            if (!textBoxCreateKeyword.HasText())
            {
                labelCreateKeywordMessage.Text = @"Please specify a keyword.";
                labelCreateKeywordMessage.Visible = true;
                return;
            }

            var category = comboBoxCategoryOfKeywordToCreate.SelectedItem.ToString();
            var keyword = textBoxCreateKeyword.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            keyword = textInfo.ToTitleCase(keyword);

            KeywordRepository.CreateKeyword(category, keyword);

            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            RefreshSelectTab(keywords);

            labelCreateKeywordMessage.Text = @"Keyword created!";
            labelCreateKeywordMessage.Visible = true;
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            if (!comboBoxEditCategory.HasSelection())
            {
                labelEditCategoryMessage.Text = @"Please select a category.";
                labelEditCategoryMessage.Visible = true;
                return;
            }

            if (!textBoxEditCategory.HasText())
            {
                labelEditCategoryMessage.Text = @"Please specify an edit.";
                labelEditCategoryMessage.Visible = true;
                return;
            }

            var oldValue = comboBoxEditCategory.SelectedItem.ToString();
            var newValue = textBoxEditCategory.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            newValue = textInfo.ToTitleCase(newValue);

            KeywordRepository.EditCategory(oldValue, newValue);

            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            InitEditTab(keywords);
            RefreshSelectTab(keywords);

            labelEditCategoryMessage.Text = @"Category saved!";
            labelEditCategoryMessage.Visible = true;
        }

        private void buttonEditKeyword_Click(object sender, EventArgs e)
        {
            if (!comboBoxEditKeyword.HasSelection())
            {
                labelEditKeywordMessage.Text = @"Please select a keyword.";
                labelEditKeywordMessage.Visible = true;
                return;
            }

            if (!textBoxEditKeyword.HasText())
            {
                labelEditKeywordMessage.Text = @"Please specify an edit.";
                labelEditKeywordMessage.Visible = true;
                return;
            }

            var oldValue = comboBoxEditKeyword.SelectedItem.ToString();
            var newValue = textBoxEditKeyword.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            newValue = textInfo.ToTitleCase(newValue);

            KeywordRepository.EditKeyword(oldValue, newValue);

            var keywords = KeywordRepository.GetKeywordsGroupedByCategory();
            InitCreateTab(keywords);
            InitEditTab(keywords);
            RefreshSelectTab(keywords);

            labelEditKeywordMessage.Text = @"Keyword saved!";
            labelEditKeywordMessage.Visible = true;
        }

        private void comboBoxCategoryOfKeywordToCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCreateTabButtonState();
        }

        private void comboBoxEditCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEditCategory.Text = comboBoxEditCategory.SelectedItem.ToString();
            SetEditTabButtonState();
        }

        private void comboBoxEditKeyword_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEditKeyword.Text = comboBoxEditKeyword.SelectedItem.ToString();
            SetEditTabButtonState();
        }

        private void textBoxCreateCategory_TextChanged(object sender, EventArgs e)
        {
            labelCreateCategoryMessage.Visible = false;
            SetCreateTabButtonState();
        }

        private void textBoxCreateKeyword_TextChanged(object sender, EventArgs e)
        {
            labelCreateKeywordMessage.Visible = false;
            SetCreateTabButtonState();
        }

        private void textBoxEditCategory_TextChanged(object sender, EventArgs e)
        {
            labelEditCategoryMessage.Visible = false;
            SetEditTabButtonState();
        }

        private void textBoxEditKeyword_TextChanged(object sender, EventArgs e)
        {
            labelEditKeywordMessage.Visible = false;
            SetEditTabButtonState();
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

        private void InitCreateTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            comboBoxCategoryOfKeywordToCreate.Items.Clear();
            foreach (var keyValuePair in keywords)
            {
                comboBoxCategoryOfKeywordToCreate.Items.Add(keyValuePair.Key);
            }
            textBoxCreateKeyword.Clear();
            textBoxCreateCategory.Clear();
            labelCreateCategoryMessage.Visible = false;
            labelCreateKeywordMessage.Visible = false;
            SetCreateTabButtonState();
        }

        private void InitDeleteTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            // todo
        }

        private void InitEditTab(SortedDictionary<string, SortedSet<string>> keywords)
        {
            comboBoxEditKeyword.Items.Clear();
            var distinctKeywords = keywords.Values.SelectMany(k => k).Distinct().ToList();
            distinctKeywords.Sort();
            foreach (var kwd in distinctKeywords)
            {
                comboBoxEditKeyword.Items.Add(kwd);
            }
            comboBoxEditCategory.Items.Clear();
            foreach (var cat in keywords.Keys)
            {
                comboBoxEditCategory.Items.Add(cat);
            }
            textBoxEditKeyword.Clear();
            textBoxEditCategory.Clear();
            labelEditCategoryMessage.Visible = false;
            labelEditKeywordMessage.Visible = false;
            SetEditTabButtonState();
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
            buttonCreateKeyword.Enabled = comboBoxCategoryOfKeywordToCreate.HasSelection() && textBoxCreateKeyword.HasText();
            buttonCreateCategory.Enabled = textBoxCreateCategory.HasText();
        }

        private void SetSelectTabButtonState()
        {
            var shouldEnable = NodeHandler.AtLeastOneNodeIsChecked(treeViewAllKeywords.Nodes);
            buttonClearSelections.Enabled = shouldEnable;
            buttonCopyToClipboard.Enabled = shouldEnable;
        }

        private void SetEditTabButtonState()
        {
            buttonEditKeyword.Enabled = comboBoxEditKeyword.HasSelection() && textBoxEditKeyword.HasText();
            buttonEditCategory.Enabled = comboBoxEditCategory.HasSelection() && textBoxEditCategory.HasText();
        }
    }
}