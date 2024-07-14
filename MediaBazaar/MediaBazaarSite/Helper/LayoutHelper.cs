using System;

namespace MediaBazaarSite.Helper
{
    public static class LayoutHelper
    {
        public static List<string> Days { get; set; }
        public static List<string> DaysOfWeek { get; set; }
        public static int MonthNumber {  get; set; }
        public static int YearNumber {  get; set; }
        public static string MonthName { get; set; }
        public static string Year {  get; set; }

        static LayoutHelper()
        {
            Days = new List<string>();
            DaysOfWeek = new List<string>
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };

            CurrentTimeCalc();
        }

        public static void DaysCalc(int year, int month)
        {
            Days.Clear();

            if (year == 0 || month == 0)
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
            }

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int i = 0; i < (int)firstDayOfMonth.DayOfWeek; i++)
            {
                Days.Add("");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                Days.Add($"{day}");
            }

            MonthName = GetMonthName(year, month);
            Year = GetYearName(year);
            MonthNumber = GetMonth(month);
            YearNumber = GetYear(year);
        }

        public static void CurrentTimeCalc()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            
            DaysCalc(year, month);
        }


        static string GetMonthName(int year, int monthNumber)
        {
            return new DateTime(year, monthNumber, 1).ToString("MMMM");
        }

        static int GetMonth(int monthNumber)
        {
            return monthNumber;
        }

        static string GetYearName(int year)
        {
            return year.ToString();
        }
        static int GetYear(int year)
        {
            return year;
        }
    }
}
