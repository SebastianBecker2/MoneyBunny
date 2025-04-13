namespace MoneyBunny.Rules
{
    using System;

    public class DateRule(Comparator comparator, DateTime value) : Rule
    {
        public Comparator Comparator { get; } = comparator;
        public DateTime Value { get; } = value;

        public override string ComparatorText => Comparator.ToDisplayString();
        public override string ValueText => $"{Value:d}";
        public override RuleType Type => RuleType.Date;

        public override bool Apply(Transaction transaction) => Comparator.Apply(transaction.Date.Date, Value.Date);
    }
}
