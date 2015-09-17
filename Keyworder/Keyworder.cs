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
            var categories = KeywordRepository.GetCategories();
            InitCreateTab(categories);
            InitDeleteTab(categories);
            InitEditTab(categories);
            InitSelectTab(categories);
        }

        private void buttonClearSelections_Click(object sender, EventArgs e)
        {
            var categories = KeywordRepository.GetCategories();
            InitSelectTab(categories);
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

            var category = comboBoxCategoryOfKeywordToCreate.SelectedItem.ToString();
            var keyword = textBoxCreateKeyword.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            keyword = textInfo.ToTitleCase(keyword);

            KeywordRepository.CreateKeyword(category, keyword);

            ReloadForm();

            labelCreateKeywordMessage.Text = @"keyword created";
            labelCreateKeywordMessage.Visible = true;
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (!comboBoxDeleteCategory.HasSelection())
            {
                labelDeleteCategoryMessage.Text = @"Please select a category.";
                labelDeleteCategoryMessage.Visible = true;
                return;
            }

            KeywordRepository.DeleteCategory(comboBoxDeleteCategory.SelectedItem.ToString());
            
            ReloadForm();

            labelDeleteCategoryMessage.Text = @"category deleted";
            labelDeleteCategoryMessage.Visible = true;
        }

        private void buttonDeleteKeyword_Click(object sender, EventArgs e)
        {
            if (!comboBoxDeleteKeyword.HasSelection())
            {
                labelDeleteKeywordMessage.Text = @"Please select a category.";
                labelDeleteKeywordMessage.Visible = true;
                return;
            }

            var keyword = (Keyword)((ComboBoxItem)comboBoxDeleteKeyword.SelectedItem).Value;
            KeywordRepository.DeleteKeyword(keyword.CategoryId, keyword.KeywordId);

            ReloadForm();

            labelDeleteKeywordMessage.Text = @"keyword deleted";
            labelDeleteKeywordMessage.Visible = true;
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

            KeywordRepository.UpdateCategory(oldValue, newValue);

            ReloadForm();

            labelEditCategoryMessage.Text = @"category saved";
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

            var oldKeyword = (Keyword)((ComboBoxItem)comboBoxEditKeyword.SelectedItem).Value;
            var newKeywordId = textBoxEditKeyword.CleanText();

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            newKeywordId = textInfo.ToTitleCase(newKeywordId);

            KeywordRepository.UpdateKeyword(oldKeyword.CategoryId, oldKeyword.KeywordId, newKeywordId);

            ReloadForm();

            labelEditKeywordMessage.Text = @"keyword saved";
            labelEditKeywordMessage.Visible = true;
        }

        private void comboBoxCategoryOfKeywordToCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCreateTabButtonState();
        }

        private void comboBoxDeleteCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDeleteTabButtonState();
        }

        private void comboBoxDeleteKeyword_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDeleteTabButtonState();
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

        private void InitDeleteTab(SortedSet<Category> categories)
        {
            comboBoxDeleteKeyword.Items.Clear();
            foreach (var keyword in categories.SelectMany(kc => kc.Keywords))
            {
                var comboboxItem = new ComboBoxItem
                {
                    Text = keyword.KeywordId,
                    Value = keyword
                };
                comboBoxDeleteKeyword.Items.Add(comboboxItem);
            }
            comboBoxDeleteKeyword.SelectedIndex = 0;
            comboBoxDeleteCategory.Items.Clear();
            foreach (var category in categories)
            {
                comboBoxDeleteCategory.Items.Add(category.CategoryId);
            }
            comboBoxDeleteCategory.SelectedIndex = 0;
            labelDeleteCategoryMessage.Visible = false;
            labelDeleteKeywordMessage.Visible = false;
            SetDeleteTabButtonState();
        }

        private void InitEditTab(SortedSet<Category> categories)
        {
            comboBoxEditKeyword.Items.Clear();
            foreach (var keyword in categories.SelectMany(kc => kc.Keywords))
            {
                var comboboxItem = new ComboBoxItem
                {
                    Text = keyword.KeywordId,
                    Value = keyword
                };
                comboBoxEditKeyword.Items.Add(comboboxItem);
            }
            comboBoxEditKeyword.SelectedIndex = 0;
            textBoxEditKeyword.Text = ((ComboBoxItem)comboBoxEditKeyword.SelectedItem).Text;
            comboBoxEditCategory.Items.Clear();
            foreach (var category in categories)
            {
                comboBoxEditCategory.Items.Add(category.CategoryId);
            }
            comboBoxEditCategory.SelectedIndex = 0;
            textBoxEditCategory.Text = comboBoxEditCategory.SelectedItem.ToString();
            labelEditCategoryMessage.Visible = false;
            labelEditKeywordMessage.Visible = false;
            SetEditTabButtonState();
        }

        private void InitSelectTab(IEnumerable<Category> categories)
        {
            PopulateTreeViewAllKeywords(categories);
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

        private void PopulateTreeViewAllKeywords(IEnumerable<Category> categories)
        {
            treeViewAllKeywords.BeginUpdate();
            treeViewAllKeywords.Nodes.Clear();
            foreach (var category in categories)
            {
                // if user created a category but hasn't assigned any keywords to it yet
                if (category.Keywords.Count == 0)
                {
                    continue;
                }
                var categoryNode = new TreeNode(category.CategoryId);
                foreach (var keyword in category.Keywords)
                {
                    categoryNode.Nodes.Add(keyword.KeywordId);
                }
                treeViewAllKeywords.Nodes.Add(categoryNode);
            }
            treeViewAllKeywords.EndUpdate();
        }

        private void RefreshSelectTab(SortedSet<Category> categories)
        {
            var state = NodeHandler.GetState(treeViewAllKeywords.Nodes);
            PopulateTreeViewAllKeywords(categories);
            NodeHandler.SetState(treeViewAllKeywords.Nodes, state);
            PopulateListBoxSelectedItems(treeViewAllKeywords.Nodes);
        }

        private void ReloadForm()
        {
            var categories = KeywordRepository.GetCategories();
            InitCreateTab(categories);
            InitDeleteTab(categories);
            InitEditTab(categories);
            RefreshSelectTab(categories);
        }

        private void SetCreateTabButtonState()
        {
            buttonCreateKeyword.Enabled = comboBoxCategoryOfKeywordToCreate.HasSelection() && textBoxCreateKeyword.HasText();
            buttonCreateCategory.Enabled = textBoxCreateCategory.HasText();
        }

        private void SetDeleteTabButtonState()
        {
            buttonDeleteKeyword.Enabled = comboBoxDeleteCategory.HasSelection();
            buttonDeleteCategory.Enabled = comboBoxDeleteKeyword.HasSelection();
        }

        private void SetEditTabButtonState()
        {
            buttonEditKeyword.Enabled = comboBoxEditKeyword.HasSelection() && textBoxEditKeyword.HasText();
            buttonEditCategory.Enabled = comboBoxEditCategory.HasSelection() && textBoxEditCategory.HasText();
        }

        private void SetSelectTabButtonState()
        {
            var shouldEnable = NodeHandler.AtLeastOneNodeIsChecked(treeViewAllKeywords.Nodes);
            buttonClearSelections.Enabled = shouldEnable;
            buttonCopyToClipboard.Enabled = shouldEnable;
        }
    }
}