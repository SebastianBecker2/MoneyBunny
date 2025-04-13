namespace MoneyBunny.ExtensionMethods
{
    public static class ValueExtension
    {
        public static string ToValueString(this int value) => $"{(double)value / 100:N2}";

        public static string ToValueString(this double value) => $"{value:N2}";
    }
}
