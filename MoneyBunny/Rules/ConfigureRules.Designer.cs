namespace MoneyBunny.Rules
{
    partial class ConfigureRules
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
            this.DgvRules = new System.Windows.Forms.DataGridView();
            this.DgcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcComparator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgcValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnRemoveRule = new System.Windows.Forms.Button();
            this.BtnOkay = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAddRule = new ImbaControls.DropDownButton.ImbaDropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRules)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvRules
            // 
            this.DgvRules.AllowUserToAddRows = false;
            this.DgvRules.AllowUserToDeleteRows = false;
            this.DgvRules.AllowUserToResizeColumns = false;
            this.DgvRules.AllowUserToResizeRows = false;
            this.DgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcType,
            this.DgcComparator,
            this.DgcValues});
            this.DgvRules.Location = new System.Drawing.Point(13, 41);
            this.DgvRules.Name = "DgvRules";
            this.DgvRules.RowHeadersVisible = false;
            this.DgvRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRules.Size = new System.Drawing.Size(419, 223);
            this.DgvRules.TabIndex = 9;
            // 
            // DgcType
            // 
            this.DgcType.HeaderText = "Type";
            this.DgcType.Name = "DgcType";
            this.DgcType.ReadOnly = true;
            // 
            // DgcComparator
            // 
            this.DgcComparator.HeaderText = "Comparator";
            this.DgcComparator.Name = "DgcComparator";
            // 
            // DgcValues
            // 
            this.DgcValues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgcValues.HeaderText = "Values";
            this.DgcValues.Name = "DgcValues";
            // 
            // BtnRemoveRule
            // 
            this.BtnRemoveRule.Location = new System.Drawing.Point(340, 12);
            this.BtnRemoveRule.Name = "BtnRemoveRule";
            this.BtnRemoveRule.Size = new System.Drawing.Size(92, 23);
            this.BtnRemoveRule.TabIndex = 8;
            this.BtnRemoveRule.Text = "Remove Rule";
            this.BtnRemoveRule.UseVisualStyleBackColor = true;
            this.BtnRemoveRule.Click += new System.EventHandler(this.BtnRemoveRule_Click);
            // 
            // BtnOkay
            // 
            this.BtnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOkay.Location = new System.Drawing.Point(276, 270);
            this.BtnOkay.Name = "BtnOkay";
            this.BtnOkay.Size = new System.Drawing.Size(75, 23);
            this.BtnOkay.TabIndex = 11;
            this.BtnOkay.Text = "OK";
            this.BtnOkay.UseVisualStyleBackColor = true;
            this.BtnOkay.Click += new System.EventHandler(this.BtnOkay_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(357, 270);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnAddRule
            // 
            this.BtnAddRule.ItemHeight = 21;
            this.BtnAddRule.Location = new System.Drawing.Point(13, 12);
            this.BtnAddRule.Name = "BtnAddRule";
            this.BtnAddRule.ReplaceMain = true;
            this.BtnAddRule.Size = new System.Drawing.Size(118, 21);
            this.BtnAddRule.TabIndex = 12;
            this.BtnAddRule.VisibleItemCount = 10;
            // 
            // ConfigureRules
            // 
            this.AcceptButton = this.BtnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(444, 305);
            this.Controls.Add(this.BtnAddRule);
            this.Controls.Add(this.BtnOkay);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.DgvRules);
            this.Controls.Add(this.BtnRemoveRule);
            this.Name = "ConfigureRules";
            this.Text = "Rules";
            ((System.ComponentModel.ISupportInitialize)(this.DgvRules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvRules;
        private System.Windows.Forms.Button BtnRemoveRule;
        private System.Windows.Forms.Button BtnOkay;
        private System.Windows.Forms.Button BtnCancel;
        private ImbaControls.DropDownButton.ImbaDropDownButton BtnAddRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcType;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgcComparator;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcValues;
    }
}