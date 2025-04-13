namespace MoneyBunny
{
    using MoneyBunny.ExtensionMethods;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Statistics : Form
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public Statistics() => InitializeComponent();

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
                _ = row.Cells.Add(name);

                var monthly_average = new DataGridViewTextBoxCell()
                {
                    Value = CalculateMonthlyAverage(category.CategoryId.Value).ToValueString(),
                };
                _ = row.Cells.Add(monthly_average);

                var last_month = new DataGridViewTextBoxCell()
                {
                    Value = CalculateLastMonth(category.CategoryId.Value).ToValueString(),
                };
                _ = row.Cells.Add(last_month);

                _ = DgvStatistic.Rows.Add(row);
            }
        }

        private double CalculateMonthlyAverage(long category_id) => ToOrderedMonthlySum(Transactions.Where(t => t.CategoryId == category_id))
                .Average(kvp => kvp.MonthlySum);

        private static IEnumerable<(DateTime Month, double MonthlySum)> ToOrderedMonthlySum(IEnumerable<Transaction> transactions)
        {
            var monthly_sums = transactions
                .OrderBy(t => t.Date)
                .ToLookup(t => t.Date.FirstDayOfMonth(), t => t);

            // Fill in the missing month
            var first_month = monthly_sums.First().Key;
            var last_month = monthly_sums.Last().Key;
            for (var month = first_month;
                month <= last_month;
                month = month.AddMonths(1))
            {
                yield return (month, monthly_sums[month].Sum(t => t.Value) / 100);
            }
        }

        private int CalculateLastMonth(long category_id)
        {
            var start_last_month = DateTime.Now.AddMonths(-1).FirstDayOfMonth();
            var end_last_month = DateTime.Now.AddMonths(-1).LastDayOfMonth();
            return Transactions
                .Where(t => t.Date.IsBetween(start_last_month, end_last_month))
                .Where(t => t.CategoryId == category_id)
                .Sum(t => t.Value);
        }

        private void UpdateChart(long category_id)
        {
            foreach (var series in ChtGraph.Series)
            {
                series.Points.Clear();
            }

            var monthly_average = CalculateMonthlyAverage(category_id);

            foreach (var (month, monthly_sum) in
                ToOrderedMonthlySum(Transactions.Where(t => t.CategoryId == category_id)))
            {
                var time_stamp = $"{month:yyyy-MM}";
                _ = ChtGraph.Series["MonthlySums"].Points.AddXY(time_stamp, monthly_sum);
                _ = ChtGraph.Series["MonthlyAverage"].Points.AddXY(time_stamp, monthly_average);
            }
        }

        private void DgvStatistic_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvStatistic.SelectedRows.Count != 1)
            {
                return;
            }

            var category = DgvStatistic.SelectedRows[0].Tag as Category;

            UpdateChart(category.CategoryId.Value);
        }
    }
}
