namespace Xan.Extensions.Tests.ColorTests;

public class FromRgb
{
    [Theory]
    [AutoData]
    [InlineData(0x00, 0x00, 0x00)]
    [InlineData(0x1, 0x22, 0x33)]
    [InlineData(0xFF, 0xFF, 0xFF)]
    public void ChannelsAreSetAndAlphaIsSetToMax(byte r, byte g, byte b)
    {
        Color sut = Color.FromRgb(r, g, b);
        Assert.Equal(0xFF, sut.A);
        Assert.Equal(r, sut.R);
        Assert.Equal(g, sut.G);
        Assert.Equal(b, sut.B);
    }
}
