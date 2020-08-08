using MoneyBunny.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MoneyBunny.Rules
{
    public enum RuleType
    {
        Reference,
        Value,
        Date,
        Type,
    }

    static class RuleTypesExtensions
    {
        public static string ToDisplayString(this RuleType type)
        {
            switch (type)
            {
                case RuleType.Date:
                    return "Date Rule";
                case RuleType.Reference:
                    return "Reference Rule";
                case RuleType.Type:
                    return "Type Rule";
                case RuleType.Value:
                    return "Value Rule";
            }

            throw new InvalidEnumArgumentException(
                nameof(type),
                (int)type,
                typeof(RuleType));
        }

        public static RuleType ToRuleType(this string text)
        {
            if (text == "Date Rule")
            {
                return RuleType.Date;
            }
            if (text == "Reference Rule")
            {
                return RuleType.Reference;
            }
            if (text == "Type Rule")
            {
                return RuleType.Type;
            }
            if (text == "Value Rule")
            {
                return RuleType.Value;
            }

            throw new ArgumentException(
                "The text provided does not translate to a rule type.",
                nameof(text));
        }

        public static IEnumerable<string> GetComparators(this RuleType type)
        {
            if (type == RuleType.Date)
            {
                return EnumExtensions.GetValues<Comparator>()
                    .Select(c => c.ToDisplayString());
            }

            if (type == RuleType.Value)
            {
                return EnumExtensions.GetValues<Comparator>()
                    .Select(c => c.ToDisplayString());
            }

            if (type == RuleType.Reference)
            {
                return new []{ "Contains any" };
            }

            if (type == RuleType.Type)
            {
                return new[] { "Contains any" };
            }

            throw new InvalidEnumArgumentException(
                nameof(type),
                (int)type,
                typeof(RuleType));
        }
    }
}
