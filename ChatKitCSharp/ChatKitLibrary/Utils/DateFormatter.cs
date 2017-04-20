using System;
using System.Collections.Generic;
using System.Collections;
using Java.Util;
using Java.Text;
//using System.text.SimpleDateFormat;

namespace ChatKitLibrary.Utils
{
    public sealed class DateFormatter
    {
        private DateFormatter()
        {
        }

        public static string GetFormatString(Template template)
        {
            switch (template)
            {
                case Template.STRING_DAY_MONTH:
                    return "d MMMM";
                case Template.STRING_DAY_MONTH_YEAR:
                    return "d MMMM yyyy";
                case Template.STRING_DAY_MONTH_YEAR_TIME:
                    return "d MMMM yyyy - HH:mm";
                case Template.TIME:
                    return "HH:mm";
                default:
                    return "";
            }
        }

        public static string Format(DateTime date, Template template)
        {
            switch (template)
            {
                case Template.STRING_DAY_MONTH:
                    return $"{date.Day.ToString("dd")}.{date.Month.ToString("MM")}";
                case Template.STRING_DAY_MONTH_YEAR:
                    return date.ToShortDateString();
                case Template.TIME:
                    return date.ToShortTimeString();
                case Template.STRING_DAY_MONTH_YEAR_TIME:
                    return date.ToShortDateString() + date.ToShortTimeString();
                default:
                    return "";
            }
        }

        public static bool IsSameDay(DateTime date1, DateTime date2)
        {
            if (date1 == null || date2 == null)
            {
                throw new Exception("Dates must not be null");
            }
            return (date1.Day == date2.Day) &&
                (date1.Month == date2.Month) &&
                (date1.Year == date2.Year);
        }

        public static bool IsSameYear(DateTime date1, DateTime date2)
        {
            if (date1 == null || date2 == null)
            {
                throw new Exception("Dates must not be null");
            }
            
            return (date1.Year == date2.Year);
        }

        public static bool IsToday(DateTime date)
        {
            return IsSameDay(date, DateTime.Now);
        }

        public static bool IsYesterday(DateTime date)
        {
            var yesterday = DateTime.Now.AddDays(-1);
            return IsSameDay(date, yesterday);
        }

        public static bool IsCurrentYear(DateTime date)
        {
            return IsSameYear(date, DateTime.Now);
        }

        public interface Formatter
        {
            string Format(DateTime date);
        }

        public enum Template
        {
            STRING_DAY_MONTH_YEAR = 1,
            STRING_DAY_MONTH = 2,
            TIME = 3,
            STRING_DAY_MONTH_YEAR_TIME = 4
        }
    }
}