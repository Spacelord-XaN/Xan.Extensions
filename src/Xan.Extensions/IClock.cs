namespace Xan.Extensions;

public interface IClock
{
    DateOnly GetCurrentDate();
    
    DateTime GetCurrentDateTime();
    
    DateTimeOffset GetCurrentDateTimeOffset();
    
    TimeOnly GetCurrentTime();
}
