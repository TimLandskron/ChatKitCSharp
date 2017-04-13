using System;
using System.Collections.Generic;
using System.Collections;
using Java.Util;
using Java.Text;
//using System.text.SimpleDateFormat;

namespace ChatKitCSharp.Utils
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

        public static string Format(Date date, Template template)
        {
            switch (template)
            {
                case Template.STRING_DAY_MONTH:
                    return Format(date, "d MMMM");
                case Template.STRING_DAY_MONTH_YEAR:
                    return Format(date, "d MMMM yyyy");
                case Template.TIME:
                    return Format(date, "HH:mm");
                case Template.STRING_DAY_MONTH_YEAR_TIME:
                    return Format(date, "d MMMM yyyy - HH:mm");
                default:
                    return Format(date, "");
            }
        }

        public static string Format(Date date, string format)
        {
            if (date == null) return "";
            return new SimpleDateFormat(format, Locale.Default).Format(date);
        }

        public static bool IsSameDay(Date date1, Date date2)
        {
            if (date1 == null || date2 == null)
            {
                throw new Exception("Dates must not be null");
            }
            Calendar cal1 = Calendar.Instance;
            cal1.Time = date1;
            Calendar cal2 = Calendar.Instance;
            cal2.Time = date2;

            return IsSameDay(cal1, cal2);
        }

        public static bool IsSameDay(Calendar cal1, Calendar cal2)
        {
            if (cal1 == null || cal2 == null)
            {
                throw new Exception("Dates must not be null");
            }
            return (cal1.Get(CalendarField.Era) == cal2.Get(CalendarField.Era) &&
                    cal1.Get(CalendarField.Year) == cal2.Get(CalendarField.Year) &&
                    cal1.Get(CalendarField.DayOfYear) == cal2.Get(CalendarField.DayOfYear));
        }

        public static bool IsSameYear(Date date1, Date date2)
        {
            if (date1 == null || date2 == null)
            {
                throw new Exception("Dates must not be null");
            }
            Calendar cal1 = Calendar.Instance;
            cal1.Time = date1;
            Calendar cal2 = Calendar.Instance;
            cal2.Time = date2;
            return IsSameYear(cal1, cal2);
        }

        public static bool IsSameYear(Calendar cal1, Calendar cal2)
        {
            if (cal1 == null || cal2 == null)
            {
                throw new Exception("Dates must not be null");
            }
            return (cal1.Get(CalendarField.Era) == cal2.Get(CalendarField.Era) &&
                   cal1.Get(CalendarField.Year) == cal2.Get(CalendarField.Year));
        }

        public static bool IsToday(Date date)
        {
            return IsSameDay(date, Calendar.Instance.Time);
        }

        public static bool IsToday(Calendar cal)
        {
            return IsSameDay(cal, Calendar.Instance);
        }

        public static bool IsYesterday(Calendar cal)
        {
            Calendar yesterday = Calendar.Instance;
            yesterday.Add(CalendarField.DayOfMonth, -1);
            return IsSameDay(cal, yesterday);
        }

        public static bool IsYesterday(Date date)
        {
            Calendar yesterday = Calendar.Instance;
            yesterday.Add(CalendarField.DayOfMonth, -1);
            return IsSameDay(date, yesterday.Time);
        }

        public static bool IsCurrentYear(Date date)
        {
            return IsSameYear(date, Calendar.Instance.Time);
        }

        public static bool IsCurrentYear(Calendar cal)
        {
            return IsSameYear(cal, Calendar.Instance);
        }

        public interface Formatter
        {
            string Format(Date date);
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