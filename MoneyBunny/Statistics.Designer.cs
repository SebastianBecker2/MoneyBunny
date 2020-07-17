namespace MoneyBunny
{
    partial class Statistics
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.DgvStatistic = new System.Windows.Forms.DataGridView();
            this.DgcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcMonthlyAvarage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcLastMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatistic)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Location = new System.Drawing.Point(713, 415);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // DgvStatistic
            // 
            this.DgvStatistic.AllowUserToAddRows = false;
            this.DgvStatistic.AllowUserToDeleteRows = false;
            this.DgvStatistic.AllowUserToResizeColumns = false;
            this.DgvStatistic.AllowUserToResizeRows = false;
            this.DgvStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStatistic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcCategory,
            this.DgcMonthlyAvarage,
            this.DgcLastMonth});
            this.DgvStatistic.Location = new System.Drawing.Point(12, 12);
            this.DgvStatistic.Name = "DgvStatistic";
            this.DgvStatistic.ReadOnly = true;
            this.DgvStatistic.RowHeadersVisible = false;
            this.DgvStatistic.Size = new System.Drawing.Size(776, 397);
            this.DgvStatistic.TabIndex = 1;
            // 
            // DgcCategory
            // 
            this.DgcCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgcCategory.HeaderText = "Category";
            this.DgcCategory.Name = "DgcCategory";
            this.DgcCategory.ReadOnly = true;
            // 
            // DgcMonthlyAvarage
            // 
            this.DgcMonthlyAvarage.HeaderText = "Monthly Avarage";
            this.DgcMonthlyAvarage.Name = "DgcMonthlyAvarage";
            this.DgcMonthlyAvarage.ReadOnly = true;
            // 
            // DgcLastMonth
            // 
            this.DgcLastMonth.HeaderText = "LastMonth";
            this.DgcLastMonth.Name = "DgcLastMonth";
            this.DgcLastMonth.ReadOnly = true;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DgvStatistic);
            this.Controls.Add(this.BtnClose);
            this.Name = "Statistics";
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatistic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.DataGridView DgvStatistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcMonthlyAvarage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcLastMonth;
    }
}