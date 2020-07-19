using DCSoft.RTF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny.Rules
{
    public interface IRule
    {
        string ComparatorText { get; }
        string ValueText { get; }
        RuleType Type { get; }

        bool Apply(Transaction transaction);
    }

    public static class RuleExtensions
    {
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
