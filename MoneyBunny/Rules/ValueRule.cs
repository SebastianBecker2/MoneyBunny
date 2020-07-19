using MoneyBunny.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny.Rules
{
    public class ValueRule : IRule
    {
        public Comparator Comparator { get; }
        public int Value { get; }

        public string RuleText => RuleType.Value.ToDisplayString();
        public string ComparatorText => Comparator.ToDisplayString();
        public string ValueText => Value.ToValueString();
        public RuleType Type => RuleType.Value;

        public ValueRule(Comparator comparator, int value)
        {
            Comparator = comparator;
            Value = value;
        }

        public bool Apply(Transaction transaction)
        {
            return Comparator.Apply(transaction.Value, Value);
        }
    }
}
