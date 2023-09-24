namespace Xan.Extensions.Tests.DateOnlyExtensionsTests;

public class EndOfMonth
{
    [Theory]
    [InlineData(2063, 04, 05, 30)]
    [InlineData(2000, 02, 15, 29)]  //  Leap year February
    [InlineData(2200, 02, 22, 28)]  //  Non Leap year February
    public void ReturnsDateTimeWithCorrectTime(int year, int month, int day, int expectedDayOfMonth)
    {
        //  Arrange
        DateOnly date = new (year, month, day);

        //  Act
        DateTime result = date.EndOfMonth();

        //  Assert
        result.Year.Should().Be(date.Year);
        result.Month.Should().Be(date.Month);
        result.Day.Should().Be(expectedDayOfMonth);
        result.Hour.Should().Be(23);
        result.Minute.Should().Be(59);
        result.Second.Should().Be(59);
        result.Millisecond.Should().Be(999);
    }
}
