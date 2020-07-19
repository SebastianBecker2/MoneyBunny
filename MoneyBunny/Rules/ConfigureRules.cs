using MoneyBunny.ExtensionMethods;
using MoneyBunny.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImbaControls.DropDownButton;

namespace MoneyBunny.Rules
{
    public partial class ConfigureRules : Form
    {
        public IEnumerable<IRule> Rules { get; set; }

        public ConfigureRules()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            foreach (var type in EnumExtensions.GetValues<RuleType>())
            {
                var btn = new Item(
                    type.ToDisplayString(),
                    (s, arg) => DgvRules.Rows.Add(CreateRow(type)));
                BtnAddRule.Items.Add(btn);
            }

            DisplayRules(Rules);

            base.OnLoad(e);
        }

        private static DataGridViewRow CreateRow(RuleType type)
        {
            var row = new DataGridViewRow()
            {
                Tag = type,
            };

            var type_text = new DataGridViewTextBoxCell()
            {
                Value = type.ToDisplayString(),
            };
            row.Cells.Add(type_text);

            var comparator = new DataGridViewComboBoxCell();
            comparator.Items.AddRange(type.GetComparators().ToArray());
            comparator.Value = comparator.Items[0];
            row.Cells.Add(comparator);

            var values = new DataGridViewTextBoxCell();
            row.Cells.Add(values);

            return row;
        }

        private void DisplayRules(IEnumerable<IRule> rules)
        {
            if (rules == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                var row = CreateRow(rule.Type);

                DgvRules.Rows.Add(row);

                row.Cells["DgcComparator"].Value = rule.ComparatorText;
                row.Cells["DgcValues"].Value = rule.ValueText;
            }
        }

        private void BtnRemoveRule_Click(object sender, EventArgs e)
        {
            if (DgvRules.SelectedRows.Count != 1)
            {
                return;
            }

            DgvRules.Rows.Remove(DgvRules.SelectedRows[0]);
        }

        private IEnumerable<IRule> GetRulesFromDisplay()
        {
            return DgvRules.Rows
                .Cast<DataGridViewRow>()
                .Select(r =>
                {
                    var type = r.Cells["DgcType"].Value.ToString();
                    var comparator = r.Cells["DgcComparator"].Value.ToString();
                    var value = r.Cells["DgcValues"].Value.ToString();
                    return RuleExtensions.CreateRule(type, comparator, value);
                });
        }

        private void BtnOkay_Click(object sender, EventArgs e)
        {
            Rules = GetRulesFromDisplay();
            DialogResult = DialogResult.OK;
        }
    }
}
