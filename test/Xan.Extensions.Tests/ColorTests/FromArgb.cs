namespace Xan.Extensions.Tests.ColorTests;

public class FromArgb
{
    [Theory]
    [AutoData]
    [InlineData(0x00, 0x00, 0x00, 0x00)]
    [InlineData(0x11, 0x22, 0x33, 0x44)]
    [InlineData(0xFF, 0xFF, 0xFF, 0xFF)]
    public void ChannelsAreSet(byte a, byte r, byte g, byte b)
    {
        Color sut = Color.FromArgb(a, r, g, b);
        Assert.Equal(a, sut.A);
        Assert.Equal(r, sut.R);
        Assert.Equal(g, sut.G);
        Assert.Equal(b, sut.B);
    }
}
