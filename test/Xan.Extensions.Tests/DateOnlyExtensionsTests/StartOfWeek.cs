namespace Xan.Extensions.Tests.DateOnlyExtensionsTests;

public sealed class StartOfWeek
    : IDisposable
{
    private readonly AustrianCultureFixture _austrianCulture = new ();

    public void Dispose()
    {
        _austrianCulture.Dispose();
    }

    [Theory, ClassData(typeof(ReturnsDateTimeWithCorrectTimeTestCases))]
    public void ReturnsDateTimeWithCorrectTime(DateOnly date, DateTime expectedResult)
    {
        //  Arrange

        //  Act
        DateTime result = date.StartOfWeek();

        //  Assert\
        result.Should().Be(expectedResult);
    }

    private class ReturnsDateTimeWithCorrectTimeTestCases :
        TheoryData<DateOnly, DateTime>
    {
        public ReturnsDateTimeWithCorrectTimeTestCases()
        {
            Add(new DateOnly(2023, 04, 05), new DateTime(2023, 04, 03));
            Add(new DateOnly(2023, 10, 15), new DateTime(2023, 10, 09));
        }
    }
}
