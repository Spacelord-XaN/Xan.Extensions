namespace Xan.Extensions.Tests.DateOnlyExtensionsTests;

public class EndOfWeek
{
    [Fact]
    public void ReturnsDateTimeWithCorrectTime()
    {
        //  Arrange
        DateOnly date = new(2023, 04, 05);

        //  Act
        DateTime result = date.EndOfWeek();

        //  Assert
        result.Year.Should().Be(date.Year);
        result.Month.Should().Be(date.Month);
        result.Day.Should().Be(9);
        result.Hour.Should().Be(23);
        result.Minute.Should().Be(59);
        result.Second.Should().Be(59);
        result.Millisecond.Should().Be(999);
    }
}
