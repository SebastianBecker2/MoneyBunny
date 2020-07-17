using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MoneyBunny
{
    public partial class Statistics : Form
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public Statistics()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            DisplayStatistics();

            base.OnLoad(e);
        }

        private void DisplayStatistics()
        {
            foreach (var category in Categories)
            {
                var row = new DataGridViewRow()
                {
                    Tag = category,
                };

                var name = new DataGridViewTextBoxCell()
                {
                    Value = category.Name,
                };
                row.Cells.Add(name);

                var monthly_avarage = new DataGridViewTextBoxCell()
                {
                    Value = CalculateMonthlyAvarage(category.Id).ToValueString(),
                };
                row.Cells.Add(monthly_avarage);

                var last_month = new DataGridViewTextBoxCell()
                {
                    Value = CalculateLastMonth(category.Id).ToValueString(),
                };
                row.Cells.Add(last_month);

                DgvStatistic.Rows.Add(row);
            }
        }

        private int CalculateMonthlyAvarage(string category_id)
        {
            return (int)Transactions
                .Where(t => t.CategoryId == category_id)
                .GroupBy(t => new { month = t.Date.Month, year = t.Date.Year })
                .Select(g => g.Sum(t => t.Value))
                .DefaultIfEmpty(0)
                .Average();
        }

        private int CalculateLastMonth(string category_id)
        {
            var start_last_month = DateTime.Now.AddMonths(-1).FirstDayOfMonth();
            var end_last_month = DateTime.Now.AddMonths(-1).LastDayOfMonth();
            return (int)Transactions
                .Where(t => t.Date.IsBetween(start_last_month, end_last_month))
                .Where(t => t.CategoryId == category_id)
                .Sum(t => t.Value);
        }

        private void UpdateChart(string category_id)
        {
            foreach (var series in ChtGraph.Series)
            {
                series.Points.Clear();
            }

            var monthly_sums = Transactions
                .Where(t => t.CategoryId == category_id)
                .GroupBy(t => t.Date.FirstDayOfMonth())
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key.ToString("yyyy-MM"),
                              g => (double)g.Sum(t => t.Value) / 100);

            var monthly_avarage = (double)CalculateMonthlyAvarage(category_id) / 100;

            foreach (var kvp in monthly_sums)
            {
                ChtGraph.Series["MonthlySums"].Points.AddXY(kvp.Key, kvp.Value);
                ChtGraph.Series["MonthlyAvarage"].Points.AddXY(kvp.Key, monthly_avarage);
            }
        }

        private void DgvStatistic_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvStatistic.SelectedRows.Count != 1)
            {
                return;
            }

            var category = DgvStatistic.SelectedRows[0].Tag as Category;

            UpdateChart(category.Id);
        }
    }
}
