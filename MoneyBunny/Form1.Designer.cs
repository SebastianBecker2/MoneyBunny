﻿namespace MoneyBunny
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtFilePath = new System.Windows.Forms.TextBox();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnImportAndProcess = new System.Windows.Forms.Button();
            this.DgvTransactions = new System.Windows.Forms.DataGridView();
            this.DgcSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnManageCategories = new System.Windows.Forms.Button();
            this.CmbCategorySelection = new System.Windows.Forms.ComboBox();
            this.BtnApplyCategory = new System.Windows.Forms.Button();
            this.CmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCategoriesFromTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnStatistics = new System.Windows.Forms.Button();
            this.BtnToDoList = new System.Windows.Forms.Button();
            this.applyRulesToUncategorizedTransactionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applyRulesToAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransactions)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFilePath.Location = new System.Drawing.Point(91, 28);
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.Size = new System.Drawing.Size(498, 20);
            this.TxtFilePath.TabIndex = 6;
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectFile.Location = new System.Drawing.Point(595, 26);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(25, 23);
            this.BtnSelectFile.TabIndex = 2;
            this.BtnSelectFile.Text = "...";
            this.BtnSelectFile.UseVisualStyleBackColor = true;
            this.BtnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kontoauszug:";
            // 
            // BtnImportAndProcess
            // 
            this.BtnImportAndProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImportAndProcess.Location = new System.Drawing.Point(869, 490);
            this.BtnImportAndProcess.Name = "BtnImportAndProcess";
            this.BtnImportAndProcess.Size = new System.Drawing.Size(75, 23);
            this.BtnImportAndProcess.TabIndex = 0;
            this.BtnImportAndProcess.Text = "Go!";
            this.BtnImportAndProcess.UseVisualStyleBackColor = true;
            this.BtnImportAndProcess.Click += new System.EventHandler(this.BtnImportAndProcess_Click);
            // 
            // DgvTransactions
            // 
            this.DgvTransactions.AllowUserToAddRows = false;
            this.DgvTransactions.AllowUserToDeleteRows = false;
            this.DgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcSelection,
            this.DgcDate,
            this.DgcType,
            this.DgcReference,
            this.DgcValue,
            this.DgcCategory});
            this.DgvTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvTransactions.Location = new System.Drawing.Point(12, 55);
            this.DgvTransactions.Name = "DgvTransactions";
            this.DgvTransactions.ReadOnly = true;
            this.DgvTransactions.RowHeadersVisible = false;
            this.DgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTransactions.Size = new System.Drawing.Size(932, 429);
            this.DgvTransactions.TabIndex = 7;
            this.DgvTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTransaction_CellClick);
            // 
            // DgcSelection
            // 
            this.DgcSelection.HeaderText = "Selected";
            this.DgcSelection.Name = "DgcSelection";
            this.DgcSelection.ReadOnly = true;
            this.DgcSelection.Width = 60;
            // 
            // DgcDate
            // 
            this.DgcDate.HeaderText = "Date";
            this.DgcDate.Name = "DgcDate";
            this.DgcDate.ReadOnly = true;
            this.DgcDate.Width = 80;
            // 
            // DgcType
            // 
            this.DgcType.HeaderText = "Type";
            this.DgcType.Name = "DgcType";
            this.DgcType.ReadOnly = true;
            this.DgcType.Width = 160;
            // 
            // DgcReference
            // 
            this.DgcReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgcReference.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgcReference.HeaderText = "Reference";
            this.DgcReference.Name = "DgcReference";
            this.DgcReference.ReadOnly = true;
            // 
            // DgcValue
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgcValue.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgcValue.HeaderText = "Value";
            this.DgcValue.Name = "DgcValue";
            this.DgcValue.ReadOnly = true;
            // 
            // DgcCategory
            // 
            this.DgcCategory.HeaderText = "Category";
            this.DgcCategory.Name = "DgcCategory";
            this.DgcCategory.ReadOnly = true;
            this.DgcCategory.Width = 200;
            // 
            // BtnManageCategories
            // 
            this.BtnManageCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnManageCategories.Location = new System.Drawing.Point(736, 490);
            this.BtnManageCategories.Name = "BtnManageCategories";
            this.BtnManageCategories.Size = new System.Drawing.Size(127, 23);
            this.BtnManageCategories.TabIndex = 8;
            this.BtnManageCategories.Text = "Manage Categories...";
            this.BtnManageCategories.UseVisualStyleBackColor = true;
            this.BtnManageCategories.Click += new System.EventHandler(this.BtnManageCategories_Click);
            // 
            // CmbCategorySelection
            // 
            this.CmbCategorySelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmbCategorySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorySelection.FormattingEnabled = true;
            this.CmbCategorySelection.Location = new System.Drawing.Point(12, 490);
            this.CmbCategorySelection.Name = "CmbCategorySelection";
            this.CmbCategorySelection.Size = new System.Drawing.Size(219, 21);
            this.CmbCategorySelection.TabIndex = 9;
            // 
            // BtnApplyCategory
            // 
            this.BtnApplyCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyCategory.Location = new System.Drawing.Point(237, 490);
            this.BtnApplyCategory.Name = "BtnApplyCategory";
            this.BtnApplyCategory.Size = new System.Drawing.Size(106, 23);
            this.BtnApplyCategory.TabIndex = 10;
            this.BtnApplyCategory.Text = "Apply to Selected";
            this.BtnApplyCategory.UseVisualStyleBackColor = true;
            this.BtnApplyCategory.Click += new System.EventHandler(this.BtnApplyCategory_Click);
            // 
            // CmbCategoryFilter
            // 
            this.CmbCategoryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoryFilter.FormattingEnabled = true;
            this.CmbCategoryFilter.Location = new System.Drawing.Point(725, 27);
            this.CmbCategoryFilter.Name = "CmbCategoryFilter";
            this.CmbCategoryFilter.Size = new System.Drawing.Size(219, 21);
            this.CmbCategoryFilter.TabIndex = 11;
            this.CmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.CmbCategoryFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(687, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filter:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transactionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllTransactionsToolStripMenuItem,
            this.removeCategoriesFromTransactionsToolStripMenuItem,
            this.applyRulesToUncategorizedTransactionsToolStripMenuItem1,
            this.applyRulesToAllTransactionsToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // clearAllTransactionsToolStripMenuItem
            // 
            this.clearAllTransactionsToolStripMenuItem.Name = "clearAllTransactionsToolStripMenuItem";
            this.clearAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.clearAllTransactionsToolStripMenuItem.Text = "Clear all Transactions";
            this.clearAllTransactionsToolStripMenuItem.Click += new System.EventHandler(this.clearAllTransactionsToolStripMenuItem_Click);
            // 
            // removeCategoriesFromTransactionsToolStripMenuItem
            // 
            this.removeCategoriesFromTransactionsToolStripMenuItem.Name = "removeCategoriesFromTransactionsToolStripMenuItem";
            this.removeCategoriesFromTransactionsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.removeCategoriesFromTransactionsToolStripMenuItem.Text = "Remove Categories from Transactions";
            this.removeCategoriesFromTransactionsToolStripMenuItem.Click += new System.EventHandler(this.removeCategoriesFromTransactionsToolStripMenuItem_Click);
            // 
            // BtnStatistics
            // 
            this.BtnStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStatistics.Location = new System.Drawing.Point(603, 490);
            this.BtnStatistics.Name = "BtnStatistics";
            this.BtnStatistics.Size = new System.Drawing.Size(127, 23);
            this.BtnStatistics.TabIndex = 14;
            this.BtnStatistics.Text = "Show Statistics...";
            this.BtnStatistics.UseVisualStyleBackColor = true;
            this.BtnStatistics.Click += new System.EventHandler(this.BtnStatistics_Click);
            // 
            // BtnToDoList
            // 
            this.BtnToDoList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnToDoList.Location = new System.Drawing.Point(470, 490);
            this.BtnToDoList.Name = "BtnToDoList";
            this.BtnToDoList.Size = new System.Drawing.Size(127, 23);
            this.BtnToDoList.TabIndex = 15;
            this.BtnToDoList.Text = "Show ToDo-List...";
            this.BtnToDoList.UseVisualStyleBackColor = true;
            this.BtnToDoList.Click += new System.EventHandler(this.BtnToDoList_Click);
            // 
            // applyRulesToUncategorizedTransactionsToolStripMenuItem1
            // 
            this.applyRulesToUncategorizedTransactionsToolStripMenuItem1.Name = "applyRulesToUncategorizedTransactionsToolStripMenuItem1";
            this.applyRulesToUncategorizedTransactionsToolStripMenuItem1.Size = new System.Drawing.Size(296, 22);
            this.applyRulesToUncategorizedTransactionsToolStripMenuItem1.Text = "Apply Rules to uncategorized Transactions";
            this.applyRulesToUncategorizedTransactionsToolStripMenuItem1.Click += new System.EventHandler(this.applyRulesToUncategorizedTransactionsToolStripMenuItem1_Click);
            // 
            // applyRulesToAllTransactionsToolStripMenuItem
            // 
            this.applyRulesToAllTransactionsToolStripMenuItem.Name = "applyRulesToAllTransactionsToolStripMenuItem";
            this.applyRulesToAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.applyRulesToAllTransactionsToolStripMenuItem.Text = "Apply Rules to all Transactions";
            this.applyRulesToAllTransactionsToolStripMenuItem.Click += new System.EventHandler(this.applyRulesToAllTransactionsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 525);
            this.Controls.Add(this.BtnToDoList);
            this.Controls.Add(this.BtnStatistics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbCategoryFilter);
            this.Controls.Add(this.BtnApplyCategory);
            this.Controls.Add(this.CmbCategorySelection);
            this.Controls.Add(this.BtnManageCategories);
            this.Controls.Add(this.DgvTransactions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSelectFile);
            this.Controls.Add(this.TxtFilePath);
            this.Controls.Add(this.BtnImportAndProcess);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Money Bunny";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransactions)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtFilePath;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnImportAndProcess;
        private System.Windows.Forms.DataGridView DgvTransactions;
        private System.Windows.Forms.Button BtnManageCategories;
        private System.Windows.Forms.ComboBox CmbCategorySelection;
        private System.Windows.Forms.Button BtnApplyCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgcSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcCategory;
        private System.Windows.Forms.ComboBox CmbCategoryFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllTransactionsToolStripMenuItem;
        private System.Windows.Forms.Button BtnStatistics;
        private System.Windows.Forms.Button BtnToDoList;
        private System.Windows.Forms.ToolStripMenuItem removeCategoriesFromTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyRulesToUncategorizedTransactionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem applyRulesToAllTransactionsToolStripMenuItem;
    }
}

