using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HM.Utils_
{
    /// <summary>时间辅助类
    /// </summary>
    public partial class DateTime_
    {
        /// <summary>取每月的第一/最末一天
        /// </summary>
        /// <param name="time">传入时间</param>
        /// <param name="firstDay">第一天还是最末一天</param>
        /// <returns></returns>
        public static DateTime DayOfMonth(DateTime time, bool firstDay = true)
        {
            DateTime time1 = new DateTime(time.Year, time.Month, 1);
            if (firstDay) return time1;
            else return time1.AddMonths(1).AddDays(-1);
        }
        /// <summary>取每季度的第一/最末一天
        /// </summary>
        /// <param name="time">传入时间</param>
        /// <param name="firstDay">第一天还是最末一天</param>
        /// <returns></returns>
        public static DateTime DayOfQuarter(DateTime time, bool firstDay = true)
        {
            int m = 0;
            switch (time.Month)
            {
                case 1:
                case 2:
                case 3:
                    m = 1; break;
                case 4:
                case 5:
                case 6:
                    m = 4; break;
                case 7:
                case 8:
                case 9:
                    m = 7; break;
                case 10:
                case 11:
                case 12:
                    m = 11; break;
            }

            DateTime time1 = new DateTime(time.Year, m, 1);
            if (firstDay) return time1;
            else return time1.AddMonths(3).AddDays(-1);
        }
        /// <summary>取每年的第一/最末一天
        /// </summary>
        /// <param name="time">传入时间</param>
        /// <param name="firstDay">第一天还是最末一天</param>
        /// <returns></returns>
        public static DateTime DayOfYear(DateTime time, bool firstDay = true)
        {
            if (firstDay) return new DateTime(time.Year, 1, 1);
            else return new DateTime(time.Year, 12, 31);
        }
        /// <summary>返回标准日期格式string(yyyy-MM-dd)
        /// </summary>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        /// <summary>返回标准时间格式string
        /// </summary>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>返回标准时间格式string
        /// </summary>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>月份补满
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string StrMonth(int i)
        {
            string sResult = "-";
            if (i < 10)
            {
                sResult += "0" + i.ToString();
            }
            else
            {
                sResult += i.ToString();
            }
            return sResult;
        }

        /// <summary>
        /// 获取某一天当周的开始时间与结束时间
        /// </summary>
        /// <param name="dt">某一天</param>
        /// <param name="isSundayStart">是否周日为第一天</param>
        /// <param name="increment">周增量</param>
        /// <returns></returns>
        [Obsolete("未单元测试！")]
        public static Tuple<DateTime, DateTime> GetWeekDate(DateTime? dt, bool isSundayStart = false, int? increment = null)
        {
            DateTime thisDt = (dt ?? DateTime.Now).Date.AddDays((increment ?? 0) * 7);

            int iWeekDay = (int)thisDt.DayOfWeek;
            if (isSundayStart)
            {
                iWeekDay += 1;
                if (iWeekDay == 7)
                {
                    iWeekDay = 0;
                }
            }
            return new Tuple<DateTime, DateTime>(
                thisDt.AddDays(-1 * iWeekDay),
                thisDt.AddDays(6 - iWeekDay)
            );
        }
        /// <summary>
        ///  获取某一天上周的开始时间与结束时间
        /// </summary>
        /// <param name="dt">某一天</param>
        /// <param name="isSundayStart">是否周日为第一天</param>
        /// <returns></returns>
        public static Tuple<DateTime, DateTime> GetPreWeekDate(DateTime? dt, bool isSundayStart = false)
        {
            return GetWeekDate(dt, isSundayStart, -1);
        }
        /// <summary>
        ///  获取某一天下周的开始时间与结束时间
        /// </summary>
        /// <param name="dt">某一天</param>
        /// <param name="isSundayStart">是否周日为第一天</param>
        /// <returns></returns>
        public static Tuple<DateTime, DateTime> GetNextWeekDate(DateTime? dt, bool isSundayStart = false)
        {
            return GetWeekDate(dt, isSundayStart, 1);
        }

        public static void GetThisWeekDate(DateTime dt, out DateTime WeekSDay, out DateTime WeekEDay)
        {
            WeekSDay = DateTime.Now;
            WeekEDay = DateTime.Now;
            int iWeekDay = 0;
            switch (dt.DayOfWeek.ToString())
            {
                case "Monday":
                    iWeekDay = 0;
                    break;
                case "Tuesday":
                    iWeekDay = 1;
                    break;
                case "Wednesday":
                    iWeekDay = 2;
                    break;
                case "Thursday":
                    iWeekDay = 3;
                    break;
                case "Friday":
                    iWeekDay = 4;
                    break;
                case "Saturday":
                    iWeekDay = 5;
                    break;
                case "Sunday":
                    iWeekDay = 6;
                    break;
                default:
                    break;
            }
            WeekSDay = dt.AddDays(-1 * iWeekDay);
            WeekEDay = dt.AddDays(6 - iWeekDay);
        }
        public static void GetPreWeekDate(ref DateTime dt, out DateTime WeekSDay, out DateTime WeekEDay)
        {
            dt = dt.AddDays(-7);
            int iWeekDay = 0;
            switch (dt.DayOfWeek.ToString())
            {
                case "Monday":
                    iWeekDay = 0;
                    break;
                case "Tuesday":
                    iWeekDay = 1;
                    break;
                case "Wednesday":
                    iWeekDay = 2;
                    break;
                case "Thursday":
                    iWeekDay = 3;
                    break;
                case "Friday":
                    iWeekDay = 4;
                    break;
                case "Saturday":
                    iWeekDay = 5;
                    break;
                case "Sunday":
                    iWeekDay = 6;
                    break;
                default:
                    break;
            }
            WeekSDay = dt.AddDays(-1 * iWeekDay);
            WeekEDay = dt.AddDays(6 - iWeekDay);
        }

        public static void GetNextWeekDate(ref DateTime dt, out DateTime WeekSDay, out DateTime WeekEDay)
        {
            dt = dt.AddDays(7);
            int iWeekDay = 0;
            switch (dt.DayOfWeek.ToString())
            {
                case "Monday":
                    iWeekDay = 0;
                    break;
                case "Tuesday":
                    iWeekDay = 1;
                    break;
                case "Wednesday":
                    iWeekDay = 2;
                    break;
                case "Thursday":
                    iWeekDay = 3;
                    break;
                case "Friday":
                    iWeekDay = 4;
                    break;
                case "Saturday":
                    iWeekDay = 5;
                    break;
                case "Sunday":
                    iWeekDay = 6;
                    break;
                default:
                    break;
            }
            WeekSDay = dt.AddDays(-1 * iWeekDay);
            WeekEDay = dt.AddDays(6 - iWeekDay);
        }

        public static void GetThisMonthDate(DateTime dt, out DateTime MonthSDay, out DateTime MonthEDay)
        {
            MonthSDay = new DateTime(dt.Year, dt.Month, 1);
            MonthEDay = MonthSDay.AddMonths(1).AddDays(-1);
        }

        public static void GetPreMonthDate(ref DateTime dt, out DateTime MonthSDay, out DateTime MonthEDay)
        {
            MonthSDay = new DateTime(dt.Year, dt.Month, 1);
            MonthEDay = MonthSDay.AddMonths(1).AddDays(-1);
            dt = MonthSDay.AddMonths(-1);
            MonthSDay = new DateTime(dt.Year, dt.Month, 1);
            MonthEDay = MonthSDay.AddMonths(1).AddDays(-1);
        }

        public static void GetNexMonthDate(ref DateTime dt, out DateTime MonthSDay, out DateTime MonthEDay)
        {
            MonthSDay = new DateTime(dt.Year, dt.Month, 1);
            MonthEDay = MonthSDay.AddMonths(1).AddDays(-1);
            dt = MonthSDay.AddMonths(1);
            MonthSDay = new DateTime(dt.Year, dt.Month, 1);
            MonthEDay = MonthSDay.AddMonths(1).AddDays(-1);
        }

        public static void GetThisYearDate(ref DateTime dt, out DateTime YearSDay, out DateTime YearEDay)
        {
            YearSDay = new DateTime(dt.Year, 1, 1);
            YearEDay = YearSDay.AddYears(1).AddDays(-1);
        }

        public static void GetPreYearDate(ref DateTime dt, out DateTime YearSDay, out DateTime YearEDay)
        {
            YearSDay = new DateTime(dt.Year, 1, 1);
            YearEDay = YearSDay.AddYears(1).AddDays(-1);
            dt = YearSDay.AddYears(-1);
            YearSDay = new DateTime(dt.Year, 1, 1);
            YearEDay = YearSDay.AddYears(1).AddDays(-1);
        }

        public static void GetNextYearDate(ref DateTime dt, out DateTime YearSDay, out DateTime YearEDay)
        {
            YearSDay = new DateTime(dt.Year, 1, 1);
            YearEDay = YearSDay.AddYears(1).AddDays(-1);
            dt = YearSDay.AddYears(1);
            YearSDay = new DateTime(dt.Year, 1, 1);
            YearEDay = YearSDay.AddYears(1).AddDays(-1);
        }

    }
}
