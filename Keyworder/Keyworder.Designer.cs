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
            this.copyToClipboardButton = new System.Windows.Forms.Button();
            this.allKeywordsLabel = new System.Windows.Forms.Label();
            this.allKeywordsTree = new SingleClickTreeView();
            this.selectedKeywordsLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.selectKeywordsTab = new System.Windows.Forms.TabPage();
            this.selectedKeywordsList = new System.Windows.Forms.ListBox();
            this.clearSelectedKeywordsButton = new System.Windows.Forms.Button();
            this.createKeywordsTab = new System.Windows.Forms.TabPage();
            this.editKeywordsTab = new System.Windows.Forms.TabPage();
            this.deleteKeywordsTab = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.selectKeywordsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyToClipboardButton
            // 
            this.copyToClipboardButton.Location = new System.Drawing.Point(505, 481);
            this.copyToClipboardButton.Name = "copyToClipboardButton";
            this.copyToClipboardButton.Size = new System.Drawing.Size(140, 23);
            this.copyToClipboardButton.TabIndex = 6;
            this.copyToClipboardButton.Text = "Copy To Clipboard";
            this.copyToClipboardButton.UseVisualStyleBackColor = true;
            this.copyToClipboardButton.Click += new System.EventHandler(this.copyToClipboardButton_Click);
            // 
            // allKeywordsLabel
            // 
            this.allKeywordsLabel.AutoSize = true;
            this.allKeywordsLabel.Location = new System.Drawing.Point(6, 3);
            this.allKeywordsLabel.Name = "allKeywordsLabel";
            this.allKeywordsLabel.Size = new System.Drawing.Size(67, 13);
            this.allKeywordsLabel.TabIndex = 2;
            this.allKeywordsLabel.Text = "All Keywords";
            // 
            // allKeywordsTree
            // 
            this.allKeywordsTree.BackColor = System.Drawing.SystemColors.Window;
            this.allKeywordsTree.CheckBoxes = true;
            this.allKeywordsTree.Location = new System.Drawing.Point(6, 19);
            this.allKeywordsTree.Name = "allKeywordsTree";
            this.allKeywordsTree.Size = new System.Drawing.Size(315, 446);
            this.allKeywordsTree.TabIndex = 4;
            this.allKeywordsTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.allKeywordsTree_AfterCheck);
            // 
            // selectedKeywordsLabel
            // 
            this.selectedKeywordsLabel.AutoSize = true;
            this.selectedKeywordsLabel.Location = new System.Drawing.Point(327, 3);
            this.selectedKeywordsLabel.Name = "selectedKeywordsLabel";
            this.selectedKeywordsLabel.Size = new System.Drawing.Size(98, 13);
            this.selectedKeywordsLabel.TabIndex = 5;
            this.selectedKeywordsLabel.Text = "Selected Keywords";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.selectKeywordsTab);
            this.tabControl.Controls.Add(this.createKeywordsTab);
            this.tabControl.Controls.Add(this.editKeywordsTab);
            this.tabControl.Controls.Add(this.deleteKeywordsTab);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(659, 536);
            this.tabControl.TabIndex = 3;
            // 
            // selectKeywordsTab
            // 
            this.selectKeywordsTab.Controls.Add(this.selectedKeywordsList);
            this.selectKeywordsTab.Controls.Add(this.clearSelectedKeywordsButton);
            this.selectKeywordsTab.Controls.Add(this.allKeywordsLabel);
            this.selectKeywordsTab.Controls.Add(this.copyToClipboardButton);
            this.selectKeywordsTab.Controls.Add(this.selectedKeywordsLabel);
            this.selectKeywordsTab.Controls.Add(this.allKeywordsTree);
            this.selectKeywordsTab.Location = new System.Drawing.Point(4, 22);
            this.selectKeywordsTab.Name = "selectKeywordsTab";
            this.selectKeywordsTab.Padding = new System.Windows.Forms.Padding(3);
            this.selectKeywordsTab.Size = new System.Drawing.Size(651, 510);
            this.selectKeywordsTab.TabIndex = 0;
            this.selectKeywordsTab.Text = "Select Keywords";
            this.selectKeywordsTab.UseVisualStyleBackColor = true;
            // 
            // selectedKeywordsList
            // 
            this.selectedKeywordsList.FormattingEnabled = true;
            this.selectedKeywordsList.Location = new System.Drawing.Point(330, 20);
            this.selectedKeywordsList.Name = "selectedKeywordsList";
            this.selectedKeywordsList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.selectedKeywordsList.Size = new System.Drawing.Size(315, 446);
            this.selectedKeywordsList.Sorted = true;
            this.selectedKeywordsList.TabIndex = 7;
            this.selectedKeywordsList.TabStop = false;
            // 
            // clearSelectedKeywordsButton
            // 
            this.clearSelectedKeywordsButton.Location = new System.Drawing.Point(359, 481);
            this.clearSelectedKeywordsButton.Name = "clearSelectedKeywordsButton";
            this.clearSelectedKeywordsButton.Size = new System.Drawing.Size(140, 23);
            this.clearSelectedKeywordsButton.TabIndex = 5;
            this.clearSelectedKeywordsButton.Text = "Clear Selected Keywords";
            this.clearSelectedKeywordsButton.UseVisualStyleBackColor = true;
            this.clearSelectedKeywordsButton.Click += new System.EventHandler(this.clearSelectedKeywordsButton_Click);
            // 
            // createKeywordsTab
            // 
            this.createKeywordsTab.Location = new System.Drawing.Point(4, 22);
            this.createKeywordsTab.Name = "createKeywordsTab";
            this.createKeywordsTab.Padding = new System.Windows.Forms.Padding(3);
            this.createKeywordsTab.Size = new System.Drawing.Size(651, 510);
            this.createKeywordsTab.TabIndex = 1;
            this.createKeywordsTab.Text = "Create Keywords";
            this.createKeywordsTab.UseVisualStyleBackColor = true;
            // 
            // editKeywordsTab
            // 
            this.editKeywordsTab.Location = new System.Drawing.Point(4, 22);
            this.editKeywordsTab.Name = "editKeywordsTab";
            this.editKeywordsTab.Size = new System.Drawing.Size(651, 510);
            this.editKeywordsTab.TabIndex = 2;
            this.editKeywordsTab.Text = "Edit Keywords";
            this.editKeywordsTab.UseVisualStyleBackColor = true;
            // 
            // deleteKeywordsTab
            // 
            this.deleteKeywordsTab.Location = new System.Drawing.Point(4, 22);
            this.deleteKeywordsTab.Name = "deleteKeywordsTab";
            this.deleteKeywordsTab.Size = new System.Drawing.Size(651, 510);
            this.deleteKeywordsTab.TabIndex = 3;
            this.deleteKeywordsTab.Text = "Delete Keywords";
            this.deleteKeywordsTab.UseVisualStyleBackColor = true;
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
            this.selectKeywordsTab.ResumeLayout(false);
            this.selectKeywordsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button copyToClipboardButton;
        private System.Windows.Forms.Label allKeywordsLabel;
        private System.Windows.Forms.Label selectedKeywordsLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage selectKeywordsTab;
        private System.Windows.Forms.TabPage createKeywordsTab;
        private System.Windows.Forms.TabPage editKeywordsTab;
        private System.Windows.Forms.TabPage deleteKeywordsTab;
        private System.Windows.Forms.Button clearSelectedKeywordsButton;
        private System.Windows.Forms.ListBox selectedKeywordsList;
        private SingleClickTreeView allKeywordsTree;
    }
}

