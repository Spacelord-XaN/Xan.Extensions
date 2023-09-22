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
}
