namespace Xan.Extensions.Tests.StringExtensionsTests;

public class ToPrettyIBAN
{
    [Theory]
    [InlineData("", null)]
    [InlineData("", "")]
    [InlineData("ATpp bbbb bkkk kkkk kkkk", "ATppbbbbbkkkkkkkkkkk")]
    [InlineData("EGpp bbbb ssss kkkk kkkk kkkk kkkk k", "EGppbbbbsssskkkkkkkkkkkkkkkkk")]
    public void Input_ReturnsExpected(string expected, string input)
    {
        Assert.Equal(expected, input.ToPrettyIBAN());
    }
}
