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
        private readonly KeywordRepository _keywordRepository = new KeywordRepository(@"Keywords.xml");

        public Keyworder()
        {
            InitializeComponent();
        }

        private void Keyworder_Load(object sender, EventArgs e)
        {
            var categories = _keywordRepository.GetCategories();
            InitCreateTab(categories);
            InitSelectTab(categories);
        }

        private void buttonClearSelections_Click(object sender, EventArgs e)
        {
            InitSelectTab(_keywordRepository.GetCategories());
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
            labelSelectKeywordsMessage.Text = @"keywords copied to clipboard";
            labelSelectKeywordsMessage.Visible = true;
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

            _keywordRepository.CreateCategory(category);

            ReloadForm();

            labelCreateCategoryMessage.Text = @"category created";
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

            var category = comboBoxCategoryOfKeywordToCreate.SelectedItem.ToString() ?? throw new KeyworderException("Category is null");
            var keyword = textBoxCreateKeyword.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            keyword = textInfo.ToTitleCase(keyword);

            _keywordRepository.CreateKeyword(category, keyword);

            // retain selected category and keep focus here
            var selectedIndex = comboBoxCategoryOfKeywordToCreate.SelectedIndex;
            ReloadForm();
            comboBoxCategoryOfKeywordToCreate.SelectedIndex = selectedIndex;
            textBoxCreateKeyword.Focus();

            // put corresponding area of tree in viewport (refresh otherwise scrolls view to the bottom of the tree)
            treeViewSelectKeywords.TopNode = NodeHandler.GetCategoryNode(treeViewSelectKeywords.Nodes, category);
            treeViewSelectKeywords.TopNode.Expand();

            labelCreateKeywordMessage.Text = @"keyword created";
            labelCreateKeywordMessage.Visible = true;
        }

        private void buttonDeleteSelections_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(
                @"Delete selected categories and keywords?", 
                @"Confirm Delete", 
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            var checkedNodes = NodeHandler.GetCheckedNodes(treeViewSelectKeywords.Nodes);
            foreach (var node in checkedNodes)
            {
                if (node.Parent == null)
                {
                    _keywordRepository.DeleteCategory(node.Text);
                }
                else
                {
                    _keywordRepository.DeleteKeyword(node.Parent.Text, node.Text);
                }
            }
            ReloadForm();
            labelSelectKeywordsMessage.Text = @"items deleted";
            labelSelectKeywordsMessage.Visible = true;
        }

        private void comboBoxCategoryOfKeywordToCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCreateTabButtonState();
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

        private void treeViewSelectKeywords_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // return if this event is triggered by code rather than user input
            if (e.Action == TreeViewAction.Unknown)
            {
                return;
            }
            NodeHandler.UpdateChildNodes(e.Node, e.Node.Checked);
            PopulateListBoxSelectedItems(treeViewSelectKeywords.Nodes);
            SetSelectTabButtonState();
            labelSelectKeywordsMessage.Visible = false;
        }

        private void treeViewSelectKeywords_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            var oldText = e.Node.Text;

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            var newText = textInfo.ToTitleCase(e.Label);

            e.Node.Text = newText;

            if (e.Node.Parent == null)
            {
                _keywordRepository.UpdateCategory(oldText, newText);
                var categories = _keywordRepository.GetCategories();
                InitCreateTab(categories);
            }
            else
            {
                _keywordRepository.UpdateKeyword(e.Node.Parent.Text, oldText, newText);
                PopulateListBoxSelectedItems(treeViewSelectKeywords.Nodes);
            }
        }

        private void InitCreateTab(IEnumerable<Category> categories)
        {
            comboBoxCategoryOfKeywordToCreate.Items.Clear();
            foreach (var category in categories)
            {
                comboBoxCategoryOfKeywordToCreate.Items.Add(category.CategoryId);
            }
            comboBoxCategoryOfKeywordToCreate.SelectedIndex = 0;
            textBoxCreateKeyword.Clear();
            textBoxCreateCategory.Clear();
            labelCreateCategoryMessage.Visible = false;
            labelCreateKeywordMessage.Visible = false;
            SetCreateTabButtonState();
        }

        private void InitSelectTab(IEnumerable<Category> categories)
        {
            PopulateTreeViewSelectKeywords(categories);
            listBoxSelectedKeywords.Items.Clear();
            SetSelectTabButtonState();
            labelSelectKeywordsMessage.Visible = false;
        }

        private void PopulateListBoxSelectedItems(IEnumerable treeNodes)
        {
            listBoxSelectedKeywords.BeginUpdate();
            listBoxSelectedKeywords.Items.Clear();
            foreach (var categoryNode in treeNodes.Cast<TreeNode>())
            {
                foreach (var keywordNode in categoryNode.Nodes.Cast<TreeNode>())
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

        private void PopulateTreeViewSelectKeywords(IEnumerable<Category> categories)
        {
            treeViewSelectKeywords.BeginUpdate();
            treeViewSelectKeywords.Nodes.Clear();
            foreach (var category in categories)
            {
                var categoryNode = new TreeNode(category.CategoryId);
                foreach (var keyword in category.Keywords)
                {
                    categoryNode.Nodes.Add(keyword.KeywordId);
                }
                treeViewSelectKeywords.Nodes.Add(categoryNode);
            }
            treeViewSelectKeywords.EndUpdate();
        }

        private void RefreshSelectTab(IEnumerable<Category> categories)
        {
            var state = NodeHandler.GetState(treeViewSelectKeywords.Nodes);
            PopulateTreeViewSelectKeywords(categories);
            NodeHandler.SetState(treeViewSelectKeywords.Nodes, state);
            PopulateListBoxSelectedItems(treeViewSelectKeywords.Nodes);
            SetSelectTabButtonState();
        }

        private void ReloadForm()
        {
            var categories = _keywordRepository.GetCategories();
            InitCreateTab(categories);
            RefreshSelectTab(categories);
        }

        private void SetCreateTabButtonState()
        {
            buttonCreateKeyword.Enabled = comboBoxCategoryOfKeywordToCreate.HasSelection() && textBoxCreateKeyword.HasText();
            buttonCreateCategory.Enabled = textBoxCreateCategory.HasText();
        }

        private void SetSelectTabButtonState()
        {
            var shouldEnable = NodeHandler.AtLeastOneNodeIsChecked(treeViewSelectKeywords.Nodes);
            buttonClearSelections.Enabled = shouldEnable;
            buttonCopyToClipboard.Enabled = shouldEnable;
            buttonDeleteSelections.Enabled = shouldEnable;
        }
    }
}