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
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.groupBoxEditCategories = new System.Windows.Forms.GroupBox();
            this.labelEditCategoryMessage = new System.Windows.Forms.Label();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.textBoxEditCategory = new System.Windows.Forms.TextBox();
            this.comboBoxEditCategory = new System.Windows.Forms.ComboBox();
            this.labelCategoryEdit = new System.Windows.Forms.Label();
            this.labelCategoryToEdit = new System.Windows.Forms.Label();
            this.groupBoxEditKeywords = new System.Windows.Forms.GroupBox();
            this.labelEditKeywordMessage = new System.Windows.Forms.Label();
            this.buttonEditKeyword = new System.Windows.Forms.Button();
            this.textBoxEditKeyword = new System.Windows.Forms.TextBox();
            this.comboBoxEditKeyword = new System.Windows.Forms.ComboBox();
            this.labelKeywordEdit = new System.Windows.Forms.Label();
            this.labelKeywordToEdit = new System.Windows.Forms.Label();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.tabCreate.SuspendLayout();
            this.groupBoxCreateCategories.SuspendLayout();
            this.groupBoxCreateKeywords.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.groupBoxEditCategories.SuspendLayout();
            this.groupBoxEditKeywords.SuspendLayout();
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
            this.groupBoxCreateCategories.Controls.Add(this.labelCreateCategoryMessage);
            this.groupBoxCreateCategories.Controls.Add(this.buttonCreateCategory);
            this.groupBoxCreateCategories.Controls.Add(this.textBoxCreateCategory);
            this.groupBoxCreateCategories.Controls.Add(this.labelNewCategory);
            this.groupBoxCreateCategories.Location = new System.Drawing.Point(6, 264);
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
            this.labelCreateCategoryMessage.Size = new System.Drawing.Size(91, 13);
            this.labelCreateCategoryMessage.TabIndex = 9;
            this.labelCreateCategoryMessage.Text = "Category created!";
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
            this.groupBoxCreateKeywords.Location = new System.Drawing.Point(6, 6);
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
            this.labelCreateKeywordMessage.Size = new System.Drawing.Size(90, 13);
            this.labelCreateKeywordMessage.TabIndex = 10;
            this.labelCreateKeywordMessage.Text = "Keyword created!";
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
            this.comboBoxCategoryOfKeywordToCreate.FormattingEnabled = true;
            this.comboBoxCategoryOfKeywordToCreate.Location = new System.Drawing.Point(61, 30);
            this.comboBoxCategoryOfKeywordToCreate.Name = "comboBoxCategoryOfKeywordToCreate";
            this.comboBoxCategoryOfKeywordToCreate.Size = new System.Drawing.Size(400, 21);
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
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.groupBoxEditCategories);
            this.tabEdit.Controls.Add(this.groupBoxEditKeywords);
            this.tabEdit.Location = new System.Drawing.Point(4, 22);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Size = new System.Drawing.Size(651, 510);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Edit";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // groupBoxEditCategories
            // 
            this.groupBoxEditCategories.Controls.Add(this.labelEditCategoryMessage);
            this.groupBoxEditCategories.Controls.Add(this.buttonEditCategory);
            this.groupBoxEditCategories.Controls.Add(this.textBoxEditCategory);
            this.groupBoxEditCategories.Controls.Add(this.comboBoxEditCategory);
            this.groupBoxEditCategories.Controls.Add(this.labelCategoryEdit);
            this.groupBoxEditCategories.Controls.Add(this.labelCategoryToEdit);
            this.groupBoxEditCategories.Location = new System.Drawing.Point(6, 264);
            this.groupBoxEditCategories.Name = "groupBoxEditCategories";
            this.groupBoxEditCategories.Size = new System.Drawing.Size(639, 240);
            this.groupBoxEditCategories.TabIndex = 2;
            this.groupBoxEditCategories.TabStop = false;
            this.groupBoxEditCategories.Text = "Edit Categories";
            // 
            // labelEditCategoryMessage
            // 
            this.labelEditCategoryMessage.AutoSize = true;
            this.labelEditCategoryMessage.Location = new System.Drawing.Point(289, 88);
            this.labelEditCategoryMessage.Name = "labelEditCategoryMessage";
            this.labelEditCategoryMessage.Size = new System.Drawing.Size(94, 13);
            this.labelEditCategoryMessage.TabIndex = 10;
            this.labelEditCategoryMessage.Text = "Category updated!";
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.Location = new System.Drawing.Point(386, 83);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonEditCategory.TabIndex = 4;
            this.buttonEditCategory.Text = "Save";
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // textBoxEditCategory
            // 
            this.textBoxEditCategory.Location = new System.Drawing.Point(61, 57);
            this.textBoxEditCategory.Name = "textBoxEditCategory";
            this.textBoxEditCategory.Size = new System.Drawing.Size(400, 20);
            this.textBoxEditCategory.TabIndex = 3;
            this.textBoxEditCategory.TextChanged += new System.EventHandler(this.textBoxEditCategory_TextChanged);
            // 
            // comboBoxEditCategory
            // 
            this.comboBoxEditCategory.FormattingEnabled = true;
            this.comboBoxEditCategory.Location = new System.Drawing.Point(61, 30);
            this.comboBoxEditCategory.Name = "comboBoxEditCategory";
            this.comboBoxEditCategory.Size = new System.Drawing.Size(400, 21);
            this.comboBoxEditCategory.TabIndex = 2;
            this.comboBoxEditCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditCategory_SelectedIndexChanged);
            // 
            // labelCategoryEdit
            // 
            this.labelCategoryEdit.AutoSize = true;
            this.labelCategoryEdit.Location = new System.Drawing.Point(30, 57);
            this.labelCategoryEdit.Name = "labelCategoryEdit";
            this.labelCategoryEdit.Size = new System.Drawing.Size(25, 13);
            this.labelCategoryEdit.TabIndex = 1;
            this.labelCategoryEdit.Text = "Edit";
            // 
            // labelCategoryToEdit
            // 
            this.labelCategoryToEdit.AutoSize = true;
            this.labelCategoryToEdit.Location = new System.Drawing.Point(6, 30);
            this.labelCategoryToEdit.Name = "labelCategoryToEdit";
            this.labelCategoryToEdit.Size = new System.Drawing.Size(49, 13);
            this.labelCategoryToEdit.TabIndex = 0;
            this.labelCategoryToEdit.Text = "Category";
            // 
            // groupBoxEditKeywords
            // 
            this.groupBoxEditKeywords.Controls.Add(this.labelEditKeywordMessage);
            this.groupBoxEditKeywords.Controls.Add(this.buttonEditKeyword);
            this.groupBoxEditKeywords.Controls.Add(this.textBoxEditKeyword);
            this.groupBoxEditKeywords.Controls.Add(this.comboBoxEditKeyword);
            this.groupBoxEditKeywords.Controls.Add(this.labelKeywordEdit);
            this.groupBoxEditKeywords.Controls.Add(this.labelKeywordToEdit);
            this.groupBoxEditKeywords.Location = new System.Drawing.Point(6, 6);
            this.groupBoxEditKeywords.Name = "groupBoxEditKeywords";
            this.groupBoxEditKeywords.Size = new System.Drawing.Size(639, 240);
            this.groupBoxEditKeywords.TabIndex = 1;
            this.groupBoxEditKeywords.TabStop = false;
            this.groupBoxEditKeywords.Text = "Edit Keywords";
            // 
            // labelEditKeywordMessage
            // 
            this.labelEditKeywordMessage.AutoSize = true;
            this.labelEditKeywordMessage.Location = new System.Drawing.Point(289, 88);
            this.labelEditKeywordMessage.Name = "labelEditKeywordMessage";
            this.labelEditKeywordMessage.Size = new System.Drawing.Size(93, 13);
            this.labelEditKeywordMessage.TabIndex = 10;
            this.labelEditKeywordMessage.Text = "Keyword updated!";
            // 
            // buttonEditKeyword
            // 
            this.buttonEditKeyword.Location = new System.Drawing.Point(386, 83);
            this.buttonEditKeyword.Name = "buttonEditKeyword";
            this.buttonEditKeyword.Size = new System.Drawing.Size(75, 23);
            this.buttonEditKeyword.TabIndex = 4;
            this.buttonEditKeyword.Text = "Save";
            this.buttonEditKeyword.UseVisualStyleBackColor = true;
            this.buttonEditKeyword.Click += new System.EventHandler(this.buttonEditKeyword_Click);
            // 
            // textBoxEditKeyword
            // 
            this.textBoxEditKeyword.Location = new System.Drawing.Point(61, 57);
            this.textBoxEditKeyword.Name = "textBoxEditKeyword";
            this.textBoxEditKeyword.Size = new System.Drawing.Size(400, 20);
            this.textBoxEditKeyword.TabIndex = 3;
            this.textBoxEditKeyword.TextChanged += new System.EventHandler(this.textBoxEditKeyword_TextChanged);
            // 
            // comboBoxEditKeyword
            // 
            this.comboBoxEditKeyword.FormattingEnabled = true;
            this.comboBoxEditKeyword.Location = new System.Drawing.Point(61, 30);
            this.comboBoxEditKeyword.Name = "comboBoxEditKeyword";
            this.comboBoxEditKeyword.Size = new System.Drawing.Size(400, 21);
            this.comboBoxEditKeyword.TabIndex = 2;
            this.comboBoxEditKeyword.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditKeyword_SelectedIndexChanged);
            // 
            // labelKeywordEdit
            // 
            this.labelKeywordEdit.AutoSize = true;
            this.labelKeywordEdit.Location = new System.Drawing.Point(30, 57);
            this.labelKeywordEdit.Name = "labelKeywordEdit";
            this.labelKeywordEdit.Size = new System.Drawing.Size(25, 13);
            this.labelKeywordEdit.TabIndex = 1;
            this.labelKeywordEdit.Text = "Edit";
            // 
            // labelKeywordToEdit
            // 
            this.labelKeywordToEdit.AutoSize = true;
            this.labelKeywordToEdit.Location = new System.Drawing.Point(7, 30);
            this.labelKeywordToEdit.Name = "labelKeywordToEdit";
            this.labelKeywordToEdit.Size = new System.Drawing.Size(48, 13);
            this.labelKeywordToEdit.TabIndex = 0;
            this.labelKeywordToEdit.Text = "Keyword";
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
            this.tabEdit.ResumeLayout(false);
            this.groupBoxEditCategories.ResumeLayout(false);
            this.groupBoxEditCategories.PerformLayout();
            this.groupBoxEditKeywords.ResumeLayout(false);
            this.groupBoxEditKeywords.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxCreateCategory;
        private System.Windows.Forms.Label labelNewCategory;
        private System.Windows.Forms.Button buttonCreateKeyword;
        private System.Windows.Forms.TextBox textBoxCreateKeyword;
        private System.Windows.Forms.ComboBox comboBoxCategoryOfKeywordToCreate;
        private System.Windows.Forms.Label labelNewKeyword;
        private System.Windows.Forms.Label labelCategoryForNewKeyword;
        private System.Windows.Forms.Label labelKeywordsCopiedToClipboard;
        private System.Windows.Forms.Label labelCreateCategoryMessage;
        private System.Windows.Forms.Label labelCreateKeywordMessage;
        private System.Windows.Forms.GroupBox groupBoxEditCategories;
        private System.Windows.Forms.Label labelEditCategoryMessage;
        private System.Windows.Forms.Button buttonEditCategory;
        private System.Windows.Forms.TextBox textBoxEditCategory;
        private System.Windows.Forms.ComboBox comboBoxEditCategory;
        private System.Windows.Forms.Label labelCategoryEdit;
        private System.Windows.Forms.Label labelCategoryToEdit;
        private System.Windows.Forms.GroupBox groupBoxEditKeywords;
        private System.Windows.Forms.Label labelEditKeywordMessage;
        private System.Windows.Forms.Button buttonEditKeyword;
        private System.Windows.Forms.TextBox textBoxEditKeyword;
        private System.Windows.Forms.ComboBox comboBoxEditKeyword;
        private System.Windows.Forms.Label labelKeywordEdit;
        private System.Windows.Forms.Label labelKeywordToEdit;
    }
}

