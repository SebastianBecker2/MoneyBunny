using System;

namespace MoneyBunny.Rules
{
    public class DateRule : Rule
    {
        public Comparator Comparator { get; }
        public DateTime Value { get; }

        public override string ComparatorText => Comparator.ToDisplayString();
        public override string ValueText => Value.ToString("d");
        public override RuleType Type => RuleType.Date;

        public DateRule(Comparator comparator, DateTime value)
        {
            Comparator = comparator;
            Value = value;
        }

        public override bool Apply(Transaction transaction)
        {
            return Comparator.Apply(transaction.Date.Date, Value.Date);
        }
    }
}
