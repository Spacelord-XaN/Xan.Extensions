namespace Xan.Extensions.Tests.ColorTests;

public class TryParse
{
    [Theory]
    [InlineData("#112233", 0xFF, 0x11, 0x22, 0x33)]
    [InlineData("112233", 0xFF, 0x11, 0x22, 0x33)]
    [InlineData("#44112233", 0x44, 0x11, 0x22, 0x33)]
    [InlineData("44112233", 0x44, 0x11, 0x22, 0x33)]
    [InlineData("#FFFFFF", 0xFF, 0xFF, 0xFF, 0xFF)]
    [InlineData("#000000", 0xFF, 0x00, 0x00, 0x00)]
    public void ValidHexStringIsParsed(string hex, byte a, byte r, byte g, byte b)
    {
        bool result = Color.TryParse(hex, out Color sut);

        Assert.True(result);
        Assert.Equal(a, sut.A);
        Assert.Equal(r, sut.R);
        Assert.Equal(g, sut.G);
        Assert.Equal(b, sut.B);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#12345")]
    [InlineData("#1234567")]
    [InlineData("#123456789")]
    [InlineData("#GGGGGG")]
    [InlineData("not a color")]
    public void InvalidHexStringReturnsFalse(string? hex)
    {
        bool result = Color.TryParse(hex, out Color sut);

        Assert.False(result);
        Assert.Equal(default, sut);
    }
}
