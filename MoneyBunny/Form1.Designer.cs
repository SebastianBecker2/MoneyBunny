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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtFilePath = new System.Windows.Forms.TextBox();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnImportAndProcess = new System.Windows.Forms.Button();
            this.DgvTransaction = new System.Windows.Forms.DataGridView();
            this.BtnManageCategories = new System.Windows.Forms.Button();
            this.CmbCategorySelection = new System.Windows.Forms.ComboBox();
            this.BtnApplyCategory = new System.Windows.Forms.Button();
            this.DgcSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFilePath.Location = new System.Drawing.Point(90, 13);
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.Size = new System.Drawing.Size(823, 20);
            this.TxtFilePath.TabIndex = 6;
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectFile.Location = new System.Drawing.Point(919, 11);
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
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kontoauszug:";
            // 
            // BtnImportAndProcess
            // 
            this.BtnImportAndProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImportAndProcess.Location = new System.Drawing.Point(869, 395);
            this.BtnImportAndProcess.Name = "BtnImportAndProcess";
            this.BtnImportAndProcess.Size = new System.Drawing.Size(75, 23);
            this.BtnImportAndProcess.TabIndex = 0;
            this.BtnImportAndProcess.Text = "Go!";
            this.BtnImportAndProcess.UseVisualStyleBackColor = true;
            this.BtnImportAndProcess.Click += new System.EventHandler(this.BtnImportAndProcess_Click);
            // 
            // DgvTransaction
            // 
            this.DgvTransaction.AllowUserToAddRows = false;
            this.DgvTransaction.AllowUserToDeleteRows = false;
            this.DgvTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvTransaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcSelection,
            this.DgcDate,
            this.DgcType,
            this.DgcReference,
            this.DgcValue,
            this.DgcCategory});
            this.DgvTransaction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvTransaction.Location = new System.Drawing.Point(12, 67);
            this.DgvTransaction.Name = "DgvTransaction";
            this.DgvTransaction.ReadOnly = true;
            this.DgvTransaction.RowHeadersVisible = false;
            this.DgvTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTransaction.Size = new System.Drawing.Size(932, 322);
            this.DgvTransaction.TabIndex = 7;
            this.DgvTransaction.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTransaction_CellClick);
            // 
            // BtnManageCategories
            // 
            this.BtnManageCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnManageCategories.Location = new System.Drawing.Point(736, 395);
            this.BtnManageCategories.Name = "BtnManageCategories";
            this.BtnManageCategories.Size = new System.Drawing.Size(127, 23);
            this.BtnManageCategories.TabIndex = 8;
            this.BtnManageCategories.Text = "Manage Categories";
            this.BtnManageCategories.UseVisualStyleBackColor = true;
            this.BtnManageCategories.Click += new System.EventHandler(this.BtnManageCategories_Click);
            // 
            // CmbCategorySelection
            // 
            this.CmbCategorySelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmbCategorySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorySelection.FormattingEnabled = true;
            this.CmbCategorySelection.Location = new System.Drawing.Point(12, 395);
            this.CmbCategorySelection.Name = "CmbCategorySelection";
            this.CmbCategorySelection.Size = new System.Drawing.Size(219, 21);
            this.CmbCategorySelection.TabIndex = 9;
            // 
            // BtnApplyCategory
            // 
            this.BtnApplyCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyCategory.Location = new System.Drawing.Point(237, 395);
            this.BtnApplyCategory.Name = "BtnApplyCategory";
            this.BtnApplyCategory.Size = new System.Drawing.Size(106, 23);
            this.BtnApplyCategory.TabIndex = 10;
            this.BtnApplyCategory.Text = "Apply to selected";
            this.BtnApplyCategory.UseVisualStyleBackColor = true;
            this.BtnApplyCategory.Click += new System.EventHandler(this.BtnApplyCategory_Click);
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
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgcReference.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgcReference.HeaderText = "Reference";
            this.DgcReference.Name = "DgcReference";
            this.DgcReference.ReadOnly = true;
            // 
            // DgcValue
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgcValue.DefaultCellStyle = dataGridViewCellStyle4;
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
            // CmbCategoryFilter
            // 
            this.CmbCategoryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoryFilter.FormattingEnabled = true;
            this.CmbCategoryFilter.Location = new System.Drawing.Point(725, 40);
            this.CmbCategoryFilter.Name = "CmbCategoryFilter";
            this.CmbCategoryFilter.Size = new System.Drawing.Size(219, 21);
            this.CmbCategoryFilter.TabIndex = 11;
            this.CmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.CmbCategoryFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(687, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filter:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 430);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbCategoryFilter);
            this.Controls.Add(this.BtnApplyCategory);
            this.Controls.Add(this.CmbCategorySelection);
            this.Controls.Add(this.BtnManageCategories);
            this.Controls.Add(this.DgvTransaction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSelectFile);
            this.Controls.Add(this.TxtFilePath);
            this.Controls.Add(this.BtnImportAndProcess);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransaction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtFilePath;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnImportAndProcess;
        private System.Windows.Forms.DataGridView DgvTransaction;
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
    }
}

