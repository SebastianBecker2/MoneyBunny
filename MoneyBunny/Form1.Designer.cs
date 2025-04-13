namespace MoneyBunny
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            BtnImportAndProcess = new System.Windows.Forms.Button();
            DgvTransactions = new System.Windows.Forms.DataGridView();
            DgcSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            DgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DgcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DgcReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DgcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DgcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            BtnManageCategories = new System.Windows.Forms.Button();
            CmbCategorySelection = new System.Windows.Forms.ComboBox();
            BtnApplyCategory = new System.Windows.Forms.Button();
            CmbCategoryFilter = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeCategoriesFromTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            applyRulesToUncategorizedTransactionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            applyRulesToAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            BtnStatistics = new System.Windows.Forms.Button();
            BtnToDoList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)DgvTransactions).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnImportAndProcess
            // 
            BtnImportAndProcess.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BtnImportAndProcess.Location = new System.Drawing.Point(1014, 565);
            BtnImportAndProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnImportAndProcess.Name = "BtnImportAndProcess";
            BtnImportAndProcess.Size = new System.Drawing.Size(88, 27);
            BtnImportAndProcess.TabIndex = 0;
            BtnImportAndProcess.Text = "Go!";
            BtnImportAndProcess.UseVisualStyleBackColor = true;
            BtnImportAndProcess.Click += BtnImportAndProcess_Click;
            // 
            // DgvTransactions
            // 
            DgvTransactions.AllowUserToAddRows = false;
            DgvTransactions.AllowUserToDeleteRows = false;
            DgvTransactions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgvTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            DgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { DgcSelection, DgcDate, DgcType, DgcReference, DgcValue, DgcCategory });
            DgvTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            DgvTransactions.Location = new System.Drawing.Point(14, 63);
            DgvTransactions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvTransactions.Name = "DgvTransactions";
            DgvTransactions.ReadOnly = true;
            DgvTransactions.RowHeadersVisible = false;
            DgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvTransactions.Size = new System.Drawing.Size(1087, 495);
            DgvTransactions.TabIndex = 7;
            DgvTransactions.CellClick += DgvTransaction_CellClick;
            // 
            // DgcSelection
            // 
            DgcSelection.HeaderText = "Selected";
            DgcSelection.Name = "DgcSelection";
            DgcSelection.ReadOnly = true;
            DgcSelection.Width = 60;
            // 
            // DgcDate
            // 
            DgcDate.HeaderText = "Date";
            DgcDate.Name = "DgcDate";
            DgcDate.ReadOnly = true;
            DgcDate.Width = 80;
            // 
            // DgcType
            // 
            DgcType.HeaderText = "Type";
            DgcType.Name = "DgcType";
            DgcType.ReadOnly = true;
            DgcType.Width = 160;
            // 
            // DgcReference
            // 
            DgcReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DgcReference.DefaultCellStyle = dataGridViewCellStyle1;
            DgcReference.HeaderText = "Reference";
            DgcReference.Name = "DgcReference";
            DgcReference.ReadOnly = true;
            // 
            // DgcValue
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            DgcValue.DefaultCellStyle = dataGridViewCellStyle2;
            DgcValue.HeaderText = "Value";
            DgcValue.Name = "DgcValue";
            DgcValue.ReadOnly = true;
            // 
            // DgcCategory
            // 
            DgcCategory.HeaderText = "Category";
            DgcCategory.Name = "DgcCategory";
            DgcCategory.ReadOnly = true;
            DgcCategory.Width = 200;
            // 
            // BtnManageCategories
            // 
            BtnManageCategories.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BtnManageCategories.Location = new System.Drawing.Point(859, 565);
            BtnManageCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnManageCategories.Name = "BtnManageCategories";
            BtnManageCategories.Size = new System.Drawing.Size(148, 27);
            BtnManageCategories.TabIndex = 8;
            BtnManageCategories.Text = "Manage Categories...";
            BtnManageCategories.UseVisualStyleBackColor = true;
            BtnManageCategories.Click += BtnManageCategories_Click;
            // 
            // CmbCategorySelection
            // 
            CmbCategorySelection.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CmbCategorySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCategorySelection.FormattingEnabled = true;
            CmbCategorySelection.Location = new System.Drawing.Point(14, 565);
            CmbCategorySelection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CmbCategorySelection.Name = "CmbCategorySelection";
            CmbCategorySelection.Size = new System.Drawing.Size(255, 23);
            CmbCategorySelection.TabIndex = 9;
            // 
            // BtnApplyCategory
            // 
            BtnApplyCategory.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            BtnApplyCategory.Location = new System.Drawing.Point(276, 565);
            BtnApplyCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnApplyCategory.Name = "BtnApplyCategory";
            BtnApplyCategory.Size = new System.Drawing.Size(124, 27);
            BtnApplyCategory.TabIndex = 10;
            BtnApplyCategory.Text = "Apply to Selected";
            BtnApplyCategory.UseVisualStyleBackColor = true;
            BtnApplyCategory.Click += BtnApplyCategory_Click;
            // 
            // CmbCategoryFilter
            // 
            CmbCategoryFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCategoryFilter.FormattingEnabled = true;
            CmbCategoryFilter.Location = new System.Drawing.Point(846, 31);
            CmbCategoryFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CmbCategoryFilter.Name = "CmbCategoryFilter";
            CmbCategoryFilter.Size = new System.Drawing.Size(255, 23);
            CmbCategoryFilter.TabIndex = 11;
            CmbCategoryFilter.SelectedIndexChanged += CmbCategoryFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(802, 35);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 15);
            label2.TabIndex = 12;
            label2.Text = "Filter:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, transactionsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1115, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // transactionsToolStripMenuItem
            // 
            transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { clearAllTransactionsToolStripMenuItem, removeCategoriesFromTransactionsToolStripMenuItem, applyRulesToUncategorizedTransactionsToolStripMenuItem1, applyRulesToAllTransactionsToolStripMenuItem });
            transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            transactionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // clearAllTransactionsToolStripMenuItem
            // 
            clearAllTransactionsToolStripMenuItem.Name = "clearAllTransactionsToolStripMenuItem";
            clearAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            clearAllTransactionsToolStripMenuItem.Text = "Clear all Transactions";
            clearAllTransactionsToolStripMenuItem.Click += clearAllTransactionsToolStripMenuItem_Click;
            // 
            // removeCategoriesFromTransactionsToolStripMenuItem
            // 
            removeCategoriesFromTransactionsToolStripMenuItem.Name = "removeCategoriesFromTransactionsToolStripMenuItem";
            removeCategoriesFromTransactionsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            removeCategoriesFromTransactionsToolStripMenuItem.Text = "Remove Categories from Transactions";
            removeCategoriesFromTransactionsToolStripMenuItem.Click += removeCategoriesFromTransactionsToolStripMenuItem_Click;
            // 
            // applyRulesToUncategorizedTransactionsToolStripMenuItem1
            // 
            applyRulesToUncategorizedTransactionsToolStripMenuItem1.Name = "applyRulesToUncategorizedTransactionsToolStripMenuItem1";
            applyRulesToUncategorizedTransactionsToolStripMenuItem1.Size = new System.Drawing.Size(296, 22);
            applyRulesToUncategorizedTransactionsToolStripMenuItem1.Text = "Apply Rules to uncategorized Transactions";
            applyRulesToUncategorizedTransactionsToolStripMenuItem1.Click += applyRulesToUncategorizedTransactionsToolStripMenuItem1_Click;
            // 
            // applyRulesToAllTransactionsToolStripMenuItem
            // 
            applyRulesToAllTransactionsToolStripMenuItem.Name = "applyRulesToAllTransactionsToolStripMenuItem";
            applyRulesToAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            applyRulesToAllTransactionsToolStripMenuItem.Text = "Apply Rules to all Transactions";
            applyRulesToAllTransactionsToolStripMenuItem.Click += applyRulesToAllTransactionsToolStripMenuItem_Click;
            // 
            // BtnStatistics
            // 
            BtnStatistics.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BtnStatistics.Location = new System.Drawing.Point(704, 565);
            BtnStatistics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnStatistics.Name = "BtnStatistics";
            BtnStatistics.Size = new System.Drawing.Size(148, 27);
            BtnStatistics.TabIndex = 14;
            BtnStatistics.Text = "Show Statistics...";
            BtnStatistics.UseVisualStyleBackColor = true;
            BtnStatistics.Click += BtnStatistics_Click;
            // 
            // BtnToDoList
            // 
            BtnToDoList.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BtnToDoList.Location = new System.Drawing.Point(548, 565);
            BtnToDoList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnToDoList.Name = "BtnToDoList";
            BtnToDoList.Size = new System.Drawing.Size(148, 27);
            BtnToDoList.TabIndex = 15;
            BtnToDoList.Text = "Show ToDo-List...";
            BtnToDoList.UseVisualStyleBackColor = true;
            BtnToDoList.Click += BtnToDoList_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1115, 606);
            Controls.Add(BtnToDoList);
            Controls.Add(BtnStatistics);
            Controls.Add(label2);
            Controls.Add(CmbCategoryFilter);
            Controls.Add(BtnApplyCategory);
            Controls.Add(CmbCategorySelection);
            Controls.Add(BtnManageCategories);
            Controls.Add(DgvTransactions);
            Controls.Add(BtnImportAndProcess);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Money Bunny";
            ((System.ComponentModel.ISupportInitialize)DgvTransactions).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
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

