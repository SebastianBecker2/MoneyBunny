namespace MoneyBunny.ExtensionMethods
{
    using System;

    public static class DateTimeExtension
    {
        public static DateTime FirstDayOfMonth(this DateTime date) => date.AddDays((date.Day - 1) * -1);

        public static DateTime LastDayOfMonth(this DateTime date)
		{
			date = date.AddMonths(1);
			return date.AddDays(date.Day * -1);
		}

		public static bool IsBetween(this DateTime date, DateTime inclusiveStart, DateTime inclusiveEnd)
        {
			if (inclusiveStart > inclusiveEnd)
            {
				var temp = inclusiveStart;
				inclusiveStart = inclusiveEnd;
				inclusiveEnd = temp;
            }

			return date >= inclusiveStart && date <= inclusiveEnd;
        }
	}
}
