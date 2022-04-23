using System;

namespace LeapYear.Lib
{
    public class LeapYearService
    {
        public bool IsLeapYear(int year)
        {
            if (year < 1) throw new ArgumentOutOfRangeException();

            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}
