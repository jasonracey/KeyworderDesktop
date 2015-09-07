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
            this.treeViewAllKeywords = new KeyworderControls.SingleClickTreeView();
            this.labelSelectedKeywords = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSelect = new System.Windows.Forms.TabPage();
            this.labelKeywordsCopiedToClipboard = new System.Windows.Forms.Label();
            this.listBoxSelectedKeywords = new System.Windows.Forms.ListBox();
            this.buttonClearSelections = new System.Windows.Forms.Button();
            this.tabCreate = new System.Windows.Forms.TabPage();
            this.groupBoxCreateCategories = new System.Windows.Forms.GroupBox();
            this.labelCreateCategory = new System.Windows.Forms.Label();
            this.buttonCreateCategory = new System.Windows.Forms.Button();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.groupBoxCreateKeywords = new System.Windows.Forms.GroupBox();
            this.buttonCreateKeyword = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelKeyword = new System.Windows.Forms.Label();
            this.labelCategoryForKeyword = new System.Windows.Forms.Label();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.labelCreateKeyword = new System.Windows.Forms.Label();
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
            // treeViewAllKeywords
            // 
            this.treeViewAllKeywords.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewAllKeywords.CheckBoxes = true;
            this.treeViewAllKeywords.Location = new System.Drawing.Point(6, 19);
            this.treeViewAllKeywords.Name = "treeViewAllKeywords";
            this.treeViewAllKeywords.Size = new System.Drawing.Size(315, 446);
            this.treeViewAllKeywords.TabIndex = 4;
            this.treeViewAllKeywords.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAllKeywords_AfterCheck);
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
            this.tabControl.Controls.Add(this.tabEdit);
            this.tabControl.Controls.Add(this.tabDelete);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(659, 536);
            this.tabControl.TabIndex = 3;
            // 
            // tabSelect
            // 
            this.tabSelect.Controls.Add(this.labelKeywordsCopiedToClipboard);
            this.tabSelect.Controls.Add(this.listBoxSelectedKeywords);
            this.tabSelect.Controls.Add(this.buttonClearSelections);
            this.tabSelect.Controls.Add(this.labelAllKeywords);
            this.tabSelect.Controls.Add(this.buttonCopyToClipboard);
            this.tabSelect.Controls.Add(this.labelSelectedKeywords);
            this.tabSelect.Controls.Add(this.treeViewAllKeywords);
            this.tabSelect.Location = new System.Drawing.Point(4, 22);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelect.Size = new System.Drawing.Size(651, 510);
            this.tabSelect.TabIndex = 0;
            this.tabSelect.Text = "Select";
            this.tabSelect.UseVisualStyleBackColor = true;
            // 
            // labelKeywordsCopiedToClipboard
            // 
            this.labelKeywordsCopiedToClipboard.AutoSize = true;
            this.labelKeywordsCopiedToClipboard.Location = new System.Drawing.Point(264, 486);
            this.labelKeywordsCopiedToClipboard.Name = "labelKeywordsCopiedToClipboard";
            this.labelKeywordsCopiedToClipboard.Size = new System.Drawing.Size(149, 13);
            this.labelKeywordsCopiedToClipboard.TabIndex = 8;
            this.labelKeywordsCopiedToClipboard.Text = "Keywords copied to clipboard!";
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
            this.groupBoxCreateCategories.Controls.Add(this.labelCreateCategory);
            this.groupBoxCreateCategories.Controls.Add(this.buttonCreateCategory);
            this.groupBoxCreateCategories.Controls.Add(this.textBoxCategory);
            this.groupBoxCreateCategories.Controls.Add(this.labelCategory);
            this.groupBoxCreateCategories.Location = new System.Drawing.Point(6, 264);
            this.groupBoxCreateCategories.Name = "groupBoxCreateCategories";
            this.groupBoxCreateCategories.Size = new System.Drawing.Size(639, 240);
            this.groupBoxCreateCategories.TabIndex = 1;
            this.groupBoxCreateCategories.TabStop = false;
            this.groupBoxCreateCategories.Text = "Create Categories";
            // 
            // labelCreateCategory
            // 
            this.labelCreateCategory.AutoSize = true;
            this.labelCreateCategory.Location = new System.Drawing.Point(289, 61);
            this.labelCreateCategory.Name = "labelCreateCategory";
            this.labelCreateCategory.Size = new System.Drawing.Size(91, 13);
            this.labelCreateCategory.TabIndex = 9;
            this.labelCreateCategory.Text = "Category created!";
            // 
            // buttonCreateCategory
            // 
            this.buttonCreateCategory.Location = new System.Drawing.Point(386, 56);
            this.buttonCreateCategory.Name = "buttonCreateCategory";
            this.buttonCreateCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateCategory.TabIndex = 7;
            this.buttonCreateCategory.Text = "Create";
            this.buttonCreateCategory.UseVisualStyleBackColor = true;
            this.buttonCreateCategory.Click += new System.EventHandler(this.buttonCreateCategory_Click);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(61, 30);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(400, 20);
            this.textBoxCategory.TabIndex = 6;
            this.textBoxCategory.TextChanged += new System.EventHandler(this.textBoxCategory_TextChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(6, 30);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 5;
            this.labelCategory.Text = "Category";
            // 
            // groupBoxCreateKeywords
            // 
            this.groupBoxCreateKeywords.Controls.Add(this.labelCreateKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.buttonCreateKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.textBoxKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.comboBoxCategory);
            this.groupBoxCreateKeywords.Controls.Add(this.labelKeyword);
            this.groupBoxCreateKeywords.Controls.Add(this.labelCategoryForKeyword);
            this.groupBoxCreateKeywords.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCreateKeywords.Name = "groupBoxCreateKeywords";
            this.groupBoxCreateKeywords.Size = new System.Drawing.Size(639, 240);
            this.groupBoxCreateKeywords.TabIndex = 0;
            this.groupBoxCreateKeywords.TabStop = false;
            this.groupBoxCreateKeywords.Text = "Create Keywords";
            // 
            // buttonCreateKeyword
            // 
            this.buttonCreateKeyword.Location = new System.Drawing.Point(386, 83);
            this.buttonCreateKeyword.Name = "buttonCreateKeyword";
            this.buttonCreateKeyword.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateKeyword.TabIndex = 4;
            this.buttonCreateKeyword.Text = "Create";
            this.buttonCreateKeyword.UseVisualStyleBackColor = true;
            this.buttonCreateKeyword.Click += new System.EventHandler(this.buttonCreateKeyword_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(61, 57);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(400, 20);
            this.textBoxKeyword.TabIndex = 3;
            this.textBoxKeyword.TextChanged += new System.EventHandler(this.textBoxKeyword_TextChanged);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(61, 30);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(400, 21);
            this.comboBoxCategory.TabIndex = 2;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // labelKeyword
            // 
            this.labelKeyword.AutoSize = true;
            this.labelKeyword.Location = new System.Drawing.Point(7, 57);
            this.labelKeyword.Name = "labelKeyword";
            this.labelKeyword.Size = new System.Drawing.Size(48, 13);
            this.labelKeyword.TabIndex = 1;
            this.labelKeyword.Text = "Keyword";
            // 
            // labelCategoryForKeyword
            // 
            this.labelCategoryForKeyword.AutoSize = true;
            this.labelCategoryForKeyword.Location = new System.Drawing.Point(6, 30);
            this.labelCategoryForKeyword.Name = "labelCategoryForKeyword";
            this.labelCategoryForKeyword.Size = new System.Drawing.Size(49, 13);
            this.labelCategoryForKeyword.TabIndex = 0;
            this.labelCategoryForKeyword.Text = "Category";
            // 
            // tabEdit
            // 
            this.tabEdit.Location = new System.Drawing.Point(4, 22);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Size = new System.Drawing.Size(651, 510);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Edit";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // tabDelete
            // 
            this.tabDelete.Location = new System.Drawing.Point(4, 22);
            this.tabDelete.Name = "tabDelete";
            this.tabDelete.Size = new System.Drawing.Size(651, 510);
            this.tabDelete.TabIndex = 3;
            this.tabDelete.Text = "Delete";
            this.tabDelete.UseVisualStyleBackColor = true;
            // 
            // labelCreateKeyword
            // 
            this.labelCreateKeyword.AutoSize = true;
            this.labelCreateKeyword.Location = new System.Drawing.Point(289, 88);
            this.labelCreateKeyword.Name = "labelCreateKeyword";
            this.labelCreateKeyword.Size = new System.Drawing.Size(90, 13);
            this.labelCreateKeyword.TabIndex = 10;
            this.labelCreateKeyword.Text = "Keyword created!";
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
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.Button buttonClearSelections;
        private System.Windows.Forms.ListBox listBoxSelectedKeywords;
        private SingleClickTreeView treeViewAllKeywords;
        private System.Windows.Forms.GroupBox groupBoxCreateCategories;
        private System.Windows.Forms.GroupBox groupBoxCreateKeywords;
        private System.Windows.Forms.Button buttonCreateCategory;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Button buttonCreateKeyword;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelKeyword;
        private System.Windows.Forms.Label labelCategoryForKeyword;
        private System.Windows.Forms.Label labelKeywordsCopiedToClipboard;
        private System.Windows.Forms.Label labelCreateCategory;
        private System.Windows.Forms.Label labelCreateKeyword;
    }
}

