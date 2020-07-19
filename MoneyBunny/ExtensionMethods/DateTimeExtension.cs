using System;

namespace MoneyBunny.ExtensionMethods
{
    public static class DateTimeExtension
    {
		public static DateTime FirstDayOfMonth(this DateTime date)
		{
			return date.AddDays((date.Day - 1) * -1);
		}

		public static DateTime LastDayOfMonth(this DateTime date)
		{
			date = date.AddMonths(1);
			return date.AddDays(date.Day * -1);
		}

		public static bool IsBetween(this DateTime date, DateTime inclusive_start, DateTime inclusive_end)
        {
			if (inclusive_start > inclusive_end)
            {
				var temp = inclusive_start;
				inclusive_start = inclusive_end;
				inclusive_end = temp;
            }

			return date >= inclusive_start && date <= inclusive_end;
        }
	}
}
