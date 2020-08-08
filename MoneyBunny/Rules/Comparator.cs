using System;
using System.ComponentModel;

namespace MoneyBunny.Rules
{
    public enum Comparator

    {
        Equals,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
    }

    static class ComparatorExtensions
    {
        public static string ToDisplayString(this Comparator comparator)
        {
            switch (comparator)
            {
                case Comparator.Equals:
                    return "==";
                case Comparator.GreaterThan:
                    return ">";
                case Comparator.GreaterThanOrEqual:
                    return ">=";
                case Comparator.LessThan:
                    return "<";
                case Comparator.LessThanOrEqual:
                    return "<=";
            }

            throw new InvalidEnumArgumentException(
                nameof(comparator),
                (int)comparator,
                typeof(Comparator));
        }

        public static Comparator ToComparator(this string text)
        {
            if (text == "==")
            {
                return Comparator.Equals;
            }
            if (text == ">")
            {
                return Comparator.GreaterThan;
            }
            if (text == ">=")
            {
                return Comparator.GreaterThanOrEqual;
            }
            if (text == "<")
            {
                return Comparator.LessThan;
            }
            if (text == "<=")
            {
                return Comparator.LessThanOrEqual;
            }

            throw new ArgumentException(
                "The text provided does not translate to a comparator.",
                nameof(text));
        }

        public static bool Apply<T>(this Comparator comparator, T lhs, T rhs)
            where T : IComparable<T>
        {
            switch (comparator)
            {
                case Comparator.Equals:
                    return lhs.CompareTo(rhs) == 0;
                case Comparator.GreaterThan:
                    return lhs.CompareTo(rhs) > 0;
                case Comparator.GreaterThanOrEqual:
                    return lhs.CompareTo(rhs) >= 0;
                case Comparator.LessThan:
                    return lhs.CompareTo(rhs) < 0;
                case Comparator.LessThanOrEqual:
                    return lhs.CompareTo(rhs) <= 0;
            }

            throw new InvalidEnumArgumentException(
                nameof(comparator),
                (int)comparator,
                typeof(Comparator));
        }
    }
}
