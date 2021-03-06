﻿using System;
using System.ComponentModel;
using System.Linq;

namespace MoneyBunny.Rules
{
    public abstract class Rule : IRule
    {
        public long? RuleId { get; set; }
        public long CategoryId { get; set; }

        public abstract string ComparatorText { get; }
        public abstract string ValueText { get; }
        public abstract RuleType Type { get; }

        public abstract bool Apply(Transaction transaction);

        public static IRule CreateRule(string type_text, string comparator_text, string values)
        {
            var type = type_text.ToRuleType();
            if (type == RuleType.Date)
            {
                return new DateRule(
                    comparator_text.ToComparator(),
                    DateTime.Parse(values));
            }

            if (type == RuleType.Value)
            {
                return new ValueRule(
                    comparator_text.ToComparator(),
                    (int)double.Parse(values) * 100);
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
