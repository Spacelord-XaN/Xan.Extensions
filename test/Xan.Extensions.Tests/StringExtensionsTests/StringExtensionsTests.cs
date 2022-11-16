namespace Xan.Extensions.Tests.StringExtensionsTests;

public class Truncate
{
    [Theory]
    [AutoData]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void EmptyInput_ReturnsEmpty(int length)
    {
        Assert.Empty(string.Empty.Truncate(length));
    }

    [Theory]
    [InlineData("ABCD", 4)]
    [InlineData("ABCDFG", 9999)]
    public void InputIsLessOrEqualThanTruncateLength_ReturnsInput(string input, int length)
    {
        Assert.Equal(input, input.Truncate(length));
    }

    [Theory]
    [InlineData("Hello", "Hello World", 5)]
    public void InputIsGreaterThenTruncateLength_ReturnsTrunacted(string expectedOutput, string input, int length)
    {
        Assert.Equal(expectedOutput, input.Truncate(length));
    }
}
