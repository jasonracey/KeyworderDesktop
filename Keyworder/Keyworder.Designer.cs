using KeyworderControls;

namespace Keyworder
{
    partial class Keyworder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.labelAllKeywords = new System.Windows.Forms.Label();
            this.treeViewSelectKeywords = new KeyworderControls.SingleClickTreeView();
            this.labelSelectedKeywords = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSelect = new System.Windows.Forms.TabPage();
            this.buttonDeleteSelections = new System.Windows.Forms.Button();
            this.labelSelectKeywordsMessage = new System.Windows.Forms.Label();
            this.listBoxSelectedKeywords = new System.Windows.Forms.ListBox();
            this.buttonClearSelections = new System.Windows.Forms.Button();
            this.tabCreate = new System.Windows.Forms.TabPage();
            this.groupBoxCreateCategories = new System.Windows.Forms.GroupBox();
            this.labelCreateCategoryMessage = new System.Windows.Forms.Label();
            this.buttonCreateCategory = new System.Windows.Forms.Button();
            this.textBoxCreateCategory = new System.Windows.Forms.TextBox();
            this.labelNewCategory = new System.Windows.Forms.Label();
            this.groupBoxCreateKeywords = new System.Windows.Forms.GroupBox();
            this.labelCreateKeywordMessage = new System.Windows.Forms.Label();
            this.buttonCreateKeyword = new System.Windows.Forms.Button();
            this.textBoxCreateKeyword = new System.Windows.Forms.TextBox();
            this.comboBoxCategoryOfKeywordToCreate = new System.Windows.Forms.ComboBox();
            this.labelNewKeyword = new System.Windows.Forms.Label();
            this.labelCategoryForNewKeyword = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.tabCreate.SuspendLayout();
            this.groupBoxCreateCategories.SuspendLayout();
            this.groupBoxCreateKeywords.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(535, 481);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(110, 23);
            this.buttonCopyToClipboard.TabIndex = 6;
            this.buttonCopyToClipboard.Text = "Copy To Clipboard";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // labelAllKeywords
            // 
            this.labelAllKeywords.AutoSize = true;
            this.labelAllKeywords.Location = new System.Drawing.Point(6, 3);
            this.labelAllKeywords.Name = "labelAllKeywords";
            this.labelAllKeywords.Size = new System.Drawing.Size(67, 13);
            this.labelAllKeywords.TabIndex = 2;
            this.labelAllKeywords.Text = "All Keywords";
            // 
            // treeViewSelectKeywords
            // 
            this.treeViewSelectKeywords.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewSelectKeywords.CheckBoxes = true;
            this.treeViewSelectKeywords.LabelEdit = true;
            this.treeViewSelectKeywords.Location = new System.Drawing.Point(6, 19);
            this.treeViewSelectKeywords.Name = "treeViewSelectKeywords";
            this.treeViewSelectKeywords.Size = new System.Drawing.Size(315, 446);
            this.treeViewSelectKeywords.TabIndex = 4;
            this.treeViewSelectKeywords.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSelectKeywords_AfterLabelEdit);
            this.treeViewSelectKeywords.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSelectKeywords_AfterCheck);
            // 
            // labelSelectedKeywords
            // 
            this.labelSelectedKeywords.AutoSize = true;
            this.labelSelectedKeywords.Location = new System.Drawing.Point(327, 3);
            this.labelSelectedKeywords.Name = "labelSelectedKeywords";
            this.labelSelectedKeywords.Size = new System.Drawing.Size(98, 13);
            this.labelSelectedKeywords.TabIndex = 5;
            this.labelSelectedKeywords.Text = "Selected Keywords";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSelect);
            this.tabControl.Controls.Add(this.tabCreate);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(659, 536);
            this.tabControl.TabIndex = 3;
            // 
            // tabSelect
            // 
            this.tabSelect.Controls.Add(this.buttonDeleteSelections);
            this.tabSelect.Controls.Add(this.labelSelectKeywordsMessage);
            this.tabSelect.Controls.Add(this.listBoxSelectedKeywords);
            this.tabSelect.Controls.Add(this.buttonClearSelections);
            this.tabSelect.Controls.Add(this.labelAllKeywords);
            this.tabSelect.Controls.Add(this.buttonCopyToClipboard);
            this.tabSelect.Controls.Add(this.labelSelectedKeywords);
            this.tabSelect.Controls.Add(this.treeViewSelectKeywords);
            this.tabSelect.Location = new System.Drawing.Point(4, 22);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelect.Size = new System.Drawing.Size(651, 510);
            this.tabSelect.TabIndex = 0;
            this.tabSelect.Text = "Select";
            this.tabSelect.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteSelections
            // 
            this.buttonDeleteSelections.Location = new System.Drawing.Point(303, 481);
            this.buttonDeleteSelections.Name = "buttonDeleteSelections";
            this.buttonDeleteSelections.Size = new System.Drawing.Size(110, 23);
            this.buttonDeleteSelections.TabIndex = 9;
            this.buttonDeleteSelections.Text = "Delete Selections";
            this.buttonDeleteSelections.UseVisualStyleBackColor = true;
            this.buttonDeleteSelections.Click += new System.EventHandler(this.buttonDeleteSelections_Click);
            // 
            // labelSelectKeywordsMessage
            // 
            this.labelSelectKeywordsMessage.Location = new System.Drawing.Point(152, 486);
            this.labelSelectKeywordsMessage.Name = "labelSelectKeywordsMessage";
            this.labelSelectKeywordsMessage.Size = new System.Drawing.Size(145, 13);
            this.labelSelectKeywordsMessage.TabIndex = 8;
            this.labelSelectKeywordsMessage.Text = "keywords copied to clipboard";
            this.labelSelectKeywordsMessage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listBoxSelectedKeywords
            // 
            this.listBoxSelectedKeywords.FormattingEnabled = true;
            this.listBoxSelectedKeywords.Location = new System.Drawing.Point(330, 20);
            this.listBoxSelectedKeywords.Name = "listBoxSelectedKeywords";
            this.listBoxSelectedKeywords.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxSelectedKeywords.Size = new System.Drawing.Size(315, 446);
            this.listBoxSelectedKeywords.Sorted = true;
            this.listBoxSelectedKeywords.TabIndex = 7;
            this.listBoxSelectedKeywords.TabStop = false;
            // 
            // buttonClearSelections
            // 
            this.buttonClearSelections.Location = new System.Drawing.Point(419, 481);
            this.buttonClearSelections.Name = "buttonClearSelections";
            this.buttonClearSelections.Size = new System.Drawing.Size(110, 23);
            this.buttonClearSelections.TabIndex = 5;
            this.buttonClearSelections.Text = "Clear Selections";
            this.buttonClearSelections.UseVisualStyleBackColor = true;
            this.buttonClearSelections.Click += new System.EventHandler(this.buttonClearSelections_Click);
            // 
            // tabCreate
            // 
            this.tabCreate.Controls.Add(this.groupBoxCreateCategories);
            this.tabCreate.Controls.Add(this.groupBoxCreateKeywords);
            this.tabCreate.Location = new System.Drawing.Point(4, 22);
            this.tabCreate.Name = "tabCreate";
            this.tabCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreate.Size = new System.Drawing.Size(651, 510);
            this.tabCreate.TabIndex = 1;
            this.tabCreate.Text = "Create";
            this.tabCreate.UseVisualStyleBackColor = true;
            // 
            // groupBoxCreateCategories
            // 
            this.groupBoxCreateCategories.Controls.Add(this.labelCreateCategoryMessage);
            this.groupBoxCreateCategories.Controls.Add(this.buttonCreateCategory);
            this.groupBoxCreateCategories.Controls.Add(this.textBoxCreateCategory);
            this.groupBoxCreateCategories.Controls.Add(this.labelNewCategory);
            this.groupBoxCreateCategories.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCreateCategories.Name = "groupBoxCreateCategories";
            this.groupBoxCreateCategories.Size = new System.Drawing.Size(639, 240);
            this.groupBoxCreateCategories.TabIndex = 1;
            this.groupBoxCreateCategories.TabStop = false;
            this.groupBoxCreateCategories.Text = "Create Categories";
            // 
            // labelCreateCategoryMessage
            // 
            this.labelCreateCategoryMessage.AutoSize = true;
            this.labelCreateCategoryMessage.Location = new System.Drawing.Point(289, 61);
            this.labelCreateCategoryMessage.Name = "labelCreateCategoryMessage";
            this.labelCreateCategoryMessage.Size = new System.Drawing.Size(87, 13);
            this.labelCreateCategoryMessage.TabIndex = 9;
            this.labelCreateCategoryMessage.Text = "category created";
            // 
            // buttonCreateCategory
            // 
            this.buttonCreateCategory.Location = new System.Drawing.Point(386, 56);
            this.buttonCreateCategory.Name = "buttonCreateCategory";
            this.buttonCreateCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateCategory.TabIndex = 7;
            this.buttonCreateCategory.Text = "Save";
            this.buttonCreateCategory.UseVisualStyleBackColor = true;
            this.buttonCreateCategory.Click += new System.EventHandler(this.buttonCreateCategory_Click);
            // 
            // textBoxCreateCategory
            // 
            this.textBoxCreateCategory.Location = new System.Drawing.Point(61, 30);
            this.textBoxCreateCategory.Name = "textBoxCreateCategory";
            this.textBoxCreateCategory.Size = new System.Drawing.Size(400, 20);
            this.textBoxCreateCategory.TabIndex = 6;
            this.textBoxCreateCategory.TextChanged += new System.EventHandler(this.textBoxCreateCategory_TextChanged);
            // 
            // labelNewCategory
            // 
            this.labelNewCategory.AutoSize = true;
            this.labelNewCategory.Location = new System.Drawing.Point(8, 30);
            this.labelNewCategory.Name = "labelNewCategory";
            this.labelNewCategory.Size = new System.Drawing.Size(49, 13);
            this.labelNewCategory.TabIndex = 5;
            this.labelNewCategory.Text = "Category";
            // 
            // groupBoxCreateKeywords
            // 
            this.groupBoxCreateKeywords.Controls.Add(this.labelCreateKeywordMessage);
            this.groupBoxCreateKeywords.Controls.Add(this.buttonCreateKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.textBoxCreateKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.comboBoxCategoryOfKeywordToCreate);
            this.groupBoxCreateKeywords.Controls.Add(this.labelNewKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.labelCategoryForNewKeyword);
            this.groupBoxCreateKeywords.Location = new System.Drawing.Point(6, 264);
            this.groupBoxCreateKeywords.Name = "groupBoxCreateKeywords";
            this.groupBoxCreateKeywords.Size = new System.Drawing.Size(639, 240);
            this.groupBoxCreateKeywords.TabIndex = 0;
            this.groupBoxCreateKeywords.TabStop = false;
            this.groupBoxCreateKeywords.Text = "Create Keywords";
            // 
            // labelCreateKeywordMessage
            // 
            this.labelCreateKeywordMessage.AutoSize = true;
            this.labelCreateKeywordMessage.Location = new System.Drawing.Point(289, 88);
            this.labelCreateKeywordMessage.Name = "labelCreateKeywordMessage";
            this.labelCreateKeywordMessage.Size = new System.Drawing.Size(86, 13);
            this.labelCreateKeywordMessage.TabIndex = 10;
            this.labelCreateKeywordMessage.Text = "keyword created";
            // 
            // buttonCreateKeyword
            // 
            this.buttonCreateKeyword.Location = new System.Drawing.Point(386, 83);
            this.buttonCreateKeyword.Name = "buttonCreateKeyword";
            this.buttonCreateKeyword.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateKeyword.TabIndex = 4;
            this.buttonCreateKeyword.Text = "Save";
            this.buttonCreateKeyword.UseVisualStyleBackColor = true;
            this.buttonCreateKeyword.Click += new System.EventHandler(this.buttonCreateKeyword_Click);
            // 
            // textBoxCreateKeyword
            // 
            this.textBoxCreateKeyword.Location = new System.Drawing.Point(61, 57);
            this.textBoxCreateKeyword.Name = "textBoxCreateKeyword";
            this.textBoxCreateKeyword.Size = new System.Drawing.Size(400, 20);
            this.textBoxCreateKeyword.TabIndex = 3;
            this.textBoxCreateKeyword.TextChanged += new System.EventHandler(this.textBoxCreateKeyword_TextChanged);
            // 
            // comboBoxCategoryOfKeywordToCreate
            // 
            this.comboBoxCategoryOfKeywordToCreate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoryOfKeywordToCreate.FormattingEnabled = true;
            this.comboBoxCategoryOfKeywordToCreate.Location = new System.Drawing.Point(61, 30);
            this.comboBoxCategoryOfKeywordToCreate.Name = "comboBoxCategoryOfKeywordToCreate";
            this.comboBoxCategoryOfKeywordToCreate.Size = new System.Drawing.Size(400, 21);
            this.comboBoxCategoryOfKeywordToCreate.Sorted = true;
            this.comboBoxCategoryOfKeywordToCreate.TabIndex = 2;
            this.comboBoxCategoryOfKeywordToCreate.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoryOfKeywordToCreate_SelectedIndexChanged);
            // 
            // labelNewKeyword
            // 
            this.labelNewKeyword.AutoSize = true;
            this.labelNewKeyword.Location = new System.Drawing.Point(8, 57);
            this.labelNewKeyword.Name = "labelNewKeyword";
            this.labelNewKeyword.Size = new System.Drawing.Size(48, 13);
            this.labelNewKeyword.TabIndex = 1;
            this.labelNewKeyword.Text = "Keyword";
            // 
            // labelCategoryForNewKeyword
            // 
            this.labelCategoryForNewKeyword.AutoSize = true;
            this.labelCategoryForNewKeyword.Location = new System.Drawing.Point(8, 30);
            this.labelCategoryForNewKeyword.Name = "labelCategoryForNewKeyword";
            this.labelCategoryForNewKeyword.Size = new System.Drawing.Size(49, 13);
            this.labelCategoryForNewKeyword.TabIndex = 0;
            this.labelCategoryForNewKeyword.Text = "Category";
            // 
            // Keyworder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Keyworder";
            this.Text = "Keyworder";
            this.Load += new System.EventHandler(this.Keyworder_Load);
            this.tabControl.ResumeLayout(false);
            this.tabSelect.ResumeLayout(false);
            this.tabSelect.PerformLayout();
            this.tabCreate.ResumeLayout(false);
            this.groupBoxCreateCategories.ResumeLayout(false);
            this.groupBoxCreateCategories.PerformLayout();
            this.groupBoxCreateKeywords.ResumeLayout(false);
            this.groupBoxCreateKeywords.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.Label labelAllKeywords;
        private System.Windows.Forms.Label labelSelectedKeywords;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSelect;
        private System.Windows.Forms.TabPage tabCreate;
        private System.Windows.Forms.Button buttonClearSelections;
        private System.Windows.Forms.ListBox listBoxSelectedKeywords;
        private SingleClickTreeView treeViewSelectKeywords;
        private System.Windows.Forms.GroupBox groupBoxCreateCategories;
        private System.Windows.Forms.GroupBox groupBoxCreateKeywords;
        private System.Windows.Forms.Button buttonCreateCategory;
        private System.Windows.Forms.TextBox textBoxCreateCategory;
        private System.Windows.Forms.Label labelNewCategory;
        private System.Windows.Forms.Button buttonCreateKeyword;
        private System.Windows.Forms.TextBox textBoxCreateKeyword;
        private System.Windows.Forms.ComboBox comboBoxCategoryOfKeywordToCreate;
        private System.Windows.Forms.Label labelNewKeyword;
        private System.Windows.Forms.Label labelCategoryForNewKeyword;
        private System.Windows.Forms.Label labelSelectKeywordsMessage;
        private System.Windows.Forms.Label labelCreateCategoryMessage;
        private System.Windows.Forms.Label labelCreateKeywordMessage;
        private System.Windows.Forms.Button buttonDeleteSelections;
    }
}

