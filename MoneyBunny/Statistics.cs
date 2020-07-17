using com.sun.tools.corba.se.idl.constExpr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Ogg.Codecs;

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
                var row = new DataGridViewRow();

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
    }
}
