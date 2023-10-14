namespace Xan.Extensions;

public static class DateTimeExtensions
{
    public static DateTime Combine(this DateTime dateTime, DateOnly date)
    {
        return new DateTime(date.Year, date.Month, date.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }

    public static DateTime Combine(this DateTime dateTime, TimeOnly time)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
    }
}
