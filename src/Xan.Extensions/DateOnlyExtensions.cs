using System.Globalization;

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

    private static readonly Dictionary<DayOfWeek, Dictionary<DayOfWeek, int>> _startOfWeekOffsets = new()
    {
        { DayOfWeek.Monday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, 0 },
                { DayOfWeek.Tuesday, -1 },
                { DayOfWeek.Wednesday, -2 },
                { DayOfWeek.Thursday, -3 },
                { DayOfWeek.Friday, -4 },
                { DayOfWeek.Saturday, -5 },
                { DayOfWeek.Sunday, -6 },
            }
        },
        { DayOfWeek.Tuesday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, -6 },
                { DayOfWeek.Tuesday, 0 },
                { DayOfWeek.Wednesday, -1 },
                { DayOfWeek.Thursday, -2 },
                { DayOfWeek.Friday, -3 },
                { DayOfWeek.Saturday, -4 },
                { DayOfWeek.Sunday, -5 },
            }
        },
        { DayOfWeek.Wednesday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, -5 },
                { DayOfWeek.Tuesday, -6 },
                { DayOfWeek.Wednesday, 0 },
                { DayOfWeek.Thursday, -1 },
                { DayOfWeek.Friday, -2 },
                { DayOfWeek.Saturday, -3 },
                { DayOfWeek.Sunday, -4 },
            }
        },
        { DayOfWeek.Thursday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, -4 },
                { DayOfWeek.Tuesday, -5 },
                { DayOfWeek.Wednesday, -6 },
                { DayOfWeek.Thursday, 0 },
                { DayOfWeek.Friday, -1 },
                { DayOfWeek.Saturday, -2 },
                { DayOfWeek.Sunday, -3 },
            }
        },
        { DayOfWeek.Friday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, -3 },
                { DayOfWeek.Tuesday, -4 },
                { DayOfWeek.Wednesday, -5 },
                { DayOfWeek.Thursday, -6 },
                { DayOfWeek.Friday, 0 },
                { DayOfWeek.Saturday, -1 },
                { DayOfWeek.Sunday, -2 },
            }
        },
        { DayOfWeek.Saturday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, -2 },
                { DayOfWeek.Tuesday, -3 },
                { DayOfWeek.Wednesday, -4 },
                { DayOfWeek.Thursday, -5 },
                { DayOfWeek.Friday, -6 },
                { DayOfWeek.Saturday, 0 },
                { DayOfWeek.Sunday, -1 },
            }
        },
        { DayOfWeek.Sunday, new Dictionary<DayOfWeek, int>
            {
                { DayOfWeek.Monday, -1 },
                { DayOfWeek.Tuesday, -2 },
                { DayOfWeek.Wednesday, -3 },
                { DayOfWeek.Thursday, -4 },
                { DayOfWeek.Friday, -5 },
                { DayOfWeek.Saturday, -6 },
                { DayOfWeek.Sunday, 0 },
            }
        }
    };

    public static DateTime StartOfWeek(this DateOnly date)
    {
        CultureInfo cultureInfo = CultureInfo.CurrentCulture;
        DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
        int offsetDays = _startOfWeekOffsets[firstDayOfWeek][date.DayOfWeek];

        return date.StartOfDay().AddDays(offsetDays);
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
