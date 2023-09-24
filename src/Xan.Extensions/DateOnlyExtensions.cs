﻿using System.Globalization;

namespace Xan.Extensions;

public static class DateOnlyExtensions
{
    public static DateTime StartOfDay(this DateOnly date)
    {
        return date.ToDateTime(new TimeOnly(0, 0, 0, 0));
    }

    public static DateTime EndOfDay(this DateOnly date)
    {
        return date.StartOfDay().AddDays(1).AddMilliseconds(-1);
    }

    public static DateTime StartOfWeek(this DateOnly date)
    {
        CultureInfo cultureInfo = CultureInfo.CurrentCulture;
        DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

        int offsetDays = (int)date.DayOfWeek - (int)firstDayOfWeek;

        return date.StartOfDay().AddDays(-offsetDays);
    }

    public static DateTime EndOfWeek(this DateOnly date)
    {
        return date.StartOfWeek().AddDays(7).AddMilliseconds(-1);
    }
    
    public static DateTime StartOfMonth(this DateOnly date)
    {
        return new DateTime(date.Year, date.Month, 1, 0, 0, 0, 0);
    }

    public static DateTime EndOfMonth(this DateOnly date)
    {
        return date.StartOfMonth().AddMonths(1).AddMilliseconds(-1);
    }
}
