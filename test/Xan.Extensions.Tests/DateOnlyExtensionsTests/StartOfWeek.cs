namespace Xan.Extensions.Tests.DateOnlyExtensionsTests;

public sealed class StartOfWeek
    : IDisposable
{
    private readonly AustrianCultureFixture _austrianCulture = new ();

    public void Dispose()
    {
        _austrianCulture.Dispose();
    }

    [Fact]
    public void ReturnsDateTimeWithCorrectTime()
    {
        //  Arrange
        DateOnly date = new(2023, 04, 05);

        //  Act
        DateTime result = date.StartOfWeek();

        //  Assert
        result.Year.Should().Be(date.Year);
        result.Month.Should().Be(date.Month);
        result.Day.Should().Be(3);
        result.Hour.Should().Be(0);
        result.Minute.Should().Be(0);
        result.Second.Should().Be(0);
        result.Millisecond.Should().Be(0);
    }
}
