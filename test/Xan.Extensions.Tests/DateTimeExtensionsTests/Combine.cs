namespace Xan.Extensions.DateTimeExtensionsTests;

public class Combine
{
    [Fact]
    public void WithDateOnly()
    {
        //  Arrange
        DateTime dateTime = new (1999, 12, 31, 14, 15, 16, 123);
        DateOnly date = new (2063, 04, 05);

        //  Act
        DateTime result = dateTime.Combine(date);

        //  Assert
        result.Year.Should().Be(date.Year);
        result.Month.Should().Be(date.Month);
        result.Day.Should().Be(date.Day);
        result.Hour.Should().Be(dateTime.Hour);
        result.Minute.Should().Be(dateTime.Minute);
        result.Second.Should().Be(dateTime.Second);
        result.Millisecond.Should().Be(dateTime.Millisecond);
    }

    [Fact]
    public void WithTimeOnly()
    {
        //  Arrange
        DateTime dateTime = new (2063, 04, 05, 14, 15, 16, 123);
        TimeOnly time = new (23, 59, 59, 999);

        //  Act
        DateTime result = dateTime.Combine(time);

        //  Assert
        result.Year.Should().Be(dateTime.Year);
        result.Month.Should().Be(dateTime.Month);
        result.Day.Should().Be(dateTime.Day);
        result.Hour.Should().Be(time.Hour);
        result.Minute.Should().Be(time.Minute);
        result.Second.Should().Be(time.Second);
        result.Millisecond.Should().Be(time.Millisecond);
    }
}
