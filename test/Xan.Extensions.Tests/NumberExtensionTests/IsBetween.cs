namespace Xan.Extensions.Tests.NumberExtensionTests;

public class IsBetween
{
    [Theory]
    [InlineData(44, 23, 66, true)]
    [InlineData(4, 4, 6, false)]
    public void Int(int value, int min, int max, bool expectedResult)
    {
        //  Arrange

        //  Act
        bool result = value.IsBetween(min, max);

        //  Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(4.4, 2.3, 6.6, true)]
    [InlineData(4.4, 4.5, 6.6, false)]
    public void Double(double value, double min, double max, bool expectedResult)
    {
        //  Arrange

        //  Act
        bool result = value.IsBetween(min, max);

        //  Assert
        result.Should().Be(expectedResult);
    }
}
