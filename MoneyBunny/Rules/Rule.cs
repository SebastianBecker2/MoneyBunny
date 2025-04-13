namespace MoneyBunny.Rules
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;

    public abstract class Rule : IRule
    {
        public long? RuleId { get; set; }
        public long CategoryId { get; set; }

        public abstract string ComparatorText { get; }
        public abstract string ValueText { get; }
        public abstract RuleType Type { get; }

        public abstract bool Apply(Transaction transaction);

        public static IRule CreateRule(string typeText, string comparatorText, string values)
        {
            var type = typeText.ToRuleType();
            if (type == RuleType.Date)
            {
                return new DateRule(
                    comparatorText.ToComparator(),
                    DateTime.Parse(values, CultureInfo.InvariantCulture));
            }

            if (type == RuleType.Value)
            {
                return new ValueRule(
                    comparatorText.ToComparator(),
                    (int)double.Parse(values, CultureInfo.InvariantCulture) * 100);
            }

            if (type == RuleType.Reference)
            {
                return new ReferenceRule(values
                    .Split(',')
                    .Select(k => k.Trim())
                    .Where(k => !string.IsNullOrEmpty(k)));
            }

            if (type == RuleType.Type)
            {
                return new TypeRule(values
                    .Split(',')
                    .Select(k => k.Trim())
                    .Where(k => !string.IsNullOrEmpty(k)));
            }

            throw new InvalidEnumArgumentException(
                nameof(type),
                (int)type,
                typeof(RuleType));
        }
    }
}
