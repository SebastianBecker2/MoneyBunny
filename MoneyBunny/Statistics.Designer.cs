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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BtnClose = new System.Windows.Forms.Button();
            this.DgvStatistic = new System.Windows.Forms.DataGridView();
            this.DgcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcMonthlyAvarage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcLastMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChtGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChtGraph)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Location = new System.Drawing.Point(1098, 528);
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
            this.DgvStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DgvStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStatistic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcCategory,
            this.DgcMonthlyAvarage,
            this.DgcLastMonth});
            this.DgvStatistic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvStatistic.Location = new System.Drawing.Point(12, 12);
            this.DgvStatistic.MultiSelect = false;
            this.DgvStatistic.Name = "DgvStatistic";
            this.DgvStatistic.ReadOnly = true;
            this.DgvStatistic.RowHeadersVisible = false;
            this.DgvStatistic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvStatistic.Size = new System.Drawing.Size(379, 510);
            this.DgvStatistic.TabIndex = 1;
            this.DgvStatistic.SelectionChanged += new System.EventHandler(this.DgvStatistic_SelectionChanged);
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
            // ChtGraph
            // 
            this.ChtGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.ChtGraph.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.ChtGraph.Legends.Add(legend1);
            this.ChtGraph.Location = new System.Drawing.Point(3, 3);
            this.ChtGraph.Name = "ChtGraph";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "F2";
            series1.Legend = "Legend1";
            series1.LegendText = "Monthly sum";
            series1.Name = "MonthlySums";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.LabelFormat = "F2";
            series2.Legend = "Legend1";
            series2.LegendText = "Overall monthly avarage";
            series2.Name = "MonthlyAvarage";
            series2.SmartLabelStyle.Enabled = false;
            this.ChtGraph.Series.Add(series1);
            this.ChtGraph.Series.Add(series2);
            this.ChtGraph.Size = new System.Drawing.Size(770, 504);
            this.ChtGraph.TabIndex = 2;
            this.ChtGraph.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ChtGraph);
            this.panel1.Location = new System.Drawing.Point(397, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 510);
            this.panel1.TabIndex = 3;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1185, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvStatistic);
            this.Controls.Add(this.BtnClose);
            this.Name = "Statistics";
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChtGraph)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.DataGridView DgvStatistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcMonthlyAvarage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcLastMonth;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChtGraph;
        private System.Windows.Forms.Panel panel1;
    }
}