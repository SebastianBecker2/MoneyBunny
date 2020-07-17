namespace MoneyBunny
{
    public static class ValueExtension
    {
        public static string ToValueString(this int value)
        {
            return string.Format("{0:N2}", (double)value / 100);
        }
    }
}
