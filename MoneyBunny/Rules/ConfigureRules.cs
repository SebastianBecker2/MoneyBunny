namespace MoneyBunny.Rules
{
    using MoneyBunny.ExtensionMethods;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using ImbaControls.DropDownButton;

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
            _ = row.Cells.Add(type_text);

            var comparator = new DataGridViewComboBoxCell();
            comparator.Items.AddRange([.. type.GetComparators()]);
            comparator.Value = comparator.Items[0];
            _ = row.Cells.Add(comparator);

            var values = new DataGridViewTextBoxCell();
            _ = row.Cells.Add(values);

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

                _ = DgvRules.Rows.Add(row);

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

        private IEnumerable<IRule> GetRulesFromDisplay() => DgvRules.Rows
                .Cast<DataGridViewRow>()
                .Select(r =>
                {
                    var type = r.Cells["DgcType"].Value.ToString();
                    var comparator = r.Cells["DgcComparator"].Value.ToString();
                    var value = r.Cells["DgcValues"].Value.ToString();
                    return Rule.CreateRule(type, comparator, value);
                });

        private void BtnOkay_Click(object sender, EventArgs e)
        {
            Rules = GetRulesFromDisplay();
            DialogResult = DialogResult.OK;
        }
    }
}
