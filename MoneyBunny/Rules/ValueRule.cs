﻿using MoneyBunny.ExtensionMethods;

namespace MoneyBunny.Rules
{
    public class ValueRule : Rule
    {
        public Comparator Comparator { get; }
        public int Value { get; }

        //public override string ComparatorText { get { return Comparator.ToDisplayString(); } }
        public override string ComparatorText => Comparator.ToDisplayString();
        public override string ValueText => Value.ToValueString();
        public override RuleType Type => RuleType.Value;

        public ValueRule(Comparator comparator, int value)
        {
            Comparator = comparator;
            Value = value;
        }

        public override bool Apply(Transaction transaction)
        {
            return Comparator.Apply(transaction.Value, Value);
        }
    }
}
