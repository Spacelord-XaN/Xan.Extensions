namespace Xan.Extensions;

public sealed class SystemClock
    : IClock
{
    public DateOnly GetCurrentDate()
        => DateOnly.FromDateTime(DateTime.Now);

    public DateTime GetCurrentDateTime()
        => DateTime.Now;

    public DateTimeOffset GetCurrentDateTimeOffset()
        => DateTimeOffset.Now;

    public TimeOnly GetCurrentTime()
        => TimeOnly.FromDateTime(DateTime.Now);
}
