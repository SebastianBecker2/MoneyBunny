namespace MoneyBunny
{
    partial class ManageCategories
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOkay = new System.Windows.Forms.Button();
            this.DgvCategories = new System.Windows.Forms.DataGridView();
            this.DgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnRemoveCategory = new System.Windows.Forms.Button();
            this.BtnAddCategory = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(266, 392);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOkay
            // 
            this.BtnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOkay.Location = new System.Drawing.Point(185, 392);
            this.BtnOkay.Name = "BtnOkay";
            this.BtnOkay.Size = new System.Drawing.Size(75, 23);
            this.BtnOkay.TabIndex = 1;
            this.BtnOkay.Text = "OK";
            this.BtnOkay.UseVisualStyleBackColor = true;
            this.BtnOkay.Click += new System.EventHandler(this.BtnOkay_Click);
            // 
            // DgvCategories
            // 
            this.DgvCategories.AllowDrop = true;
            this.DgvCategories.AllowUserToAddRows = false;
            this.DgvCategories.AllowUserToDeleteRows = false;
            this.DgvCategories.AllowUserToResizeColumns = false;
            this.DgvCategories.AllowUserToResizeRows = false;
            this.DgvCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcName});
            this.DgvCategories.Location = new System.Drawing.Point(12, 41);
            this.DgvCategories.MultiSelect = false;
            this.DgvCategories.Name = "DgvCategories";
            this.DgvCategories.RowHeadersVisible = false;
            this.DgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCategories.Size = new System.Drawing.Size(329, 345);
            this.DgvCategories.TabIndex = 2;
            this.DgvCategories.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvCategories_DragDrop);
            this.DgvCategories.DragOver += new System.Windows.Forms.DragEventHandler(this.DgvCategories_DragOver);
            this.DgvCategories.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvCategories_MouseDown);
            this.DgvCategories.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DgvCategories_MouseMove);
            // 
            // DgcName
            // 
            this.DgcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgcName.HeaderText = "Name";
            this.DgcName.Name = "DgcName";
            // 
            // BtnRemoveCategory
            // 
            this.BtnRemoveCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveCategory.Location = new System.Drawing.Point(240, 12);
            this.BtnRemoveCategory.Name = "BtnRemoveCategory";
            this.BtnRemoveCategory.Size = new System.Drawing.Size(101, 23);
            this.BtnRemoveCategory.TabIndex = 8;
            this.BtnRemoveCategory.Text = "Remove Category";
            this.BtnRemoveCategory.UseVisualStyleBackColor = true;
            this.BtnRemoveCategory.Click += new System.EventHandler(this.BtnRemoveCategory_Click);
            // 
            // BtnAddCategory
            // 
            this.BtnAddCategory.Location = new System.Drawing.Point(12, 12);
            this.BtnAddCategory.Name = "BtnAddCategory";
            this.BtnAddCategory.Size = new System.Drawing.Size(101, 23);
            this.BtnAddCategory.TabIndex = 7;
            this.BtnAddCategory.Text = "Add Category";
            this.BtnAddCategory.UseVisualStyleBackColor = true;
            this.BtnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click);
            // 
            // btnRules
            // 
            this.btnRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRules.Location = new System.Drawing.Point(12, 392);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(101, 23);
            this.btnRules.TabIndex = 9;
            this.btnRules.Text = "Rules...";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // ManageCategories
            // 
            this.AcceptButton = this.BtnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(353, 427);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.BtnRemoveCategory);
            this.Controls.Add(this.BtnAddCategory);
            this.Controls.Add(this.DgvCategories);
            this.Controls.Add(this.BtnOkay);
            this.Controls.Add(this.BtnCancel);
            this.Name = "ManageCategories";
            this.Text = "Manage Categories";
            ((System.ComponentModel.ISupportInitialize)(this.DgvCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOkay;
        private System.Windows.Forms.DataGridView DgvCategories;
        private System.Windows.Forms.Button BtnRemoveCategory;
        private System.Windows.Forms.Button BtnAddCategory;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcName;
    }
}