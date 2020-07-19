using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny.Rules
{
    public class DateRule : IRule
    {
        public Comparator Comparator { get; }
        public DateTime Value { get; }

        public string ComparatorText => Comparator.ToDisplayString();
        public string ValueText => Value.ToString("d");
        public RuleType Type => RuleType.Date;

        public DateRule(Comparator comparator, DateTime value)
        {
            Comparator = comparator;
            Value = value;
        }

        public bool Apply(Transaction transaction)
        {
            return Comparator.Apply(transaction.Date.Date, Value.Date);
        }
    }
}
