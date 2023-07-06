namespace TestProject.Helper
{
	public static class DateRangeCompareHelper
	{
        public static bool CompareDateRange(this string targetDate, DateTime DateBegin, DateTime DateEnd)
        {
            DateTime vDate = DateTime.Parse(targetDate);

            return vDate.CompareTo(DateBegin) > 0 && vDate.CompareTo(DateEnd) < 0;
        }

        
    }
}

