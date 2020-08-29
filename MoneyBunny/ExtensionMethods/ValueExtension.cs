namespace MoneyBunny.ExtensionMethods
{
    public static class ValueExtension
    {
        public static string ToValueString(this int value)
        {
            return string.Format("{0:N2}", (double)value / 100);
        }

        public static string ToValueString(this double value)
        {
            return string.Format("{0:N2}", value);
        }
    }
}
