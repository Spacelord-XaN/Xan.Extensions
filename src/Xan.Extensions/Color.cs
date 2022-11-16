namespace Xan.Extensions;

public struct Color
{
    public byte A { get; set; }
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public static Color FromRgb(byte r, byte g, byte b)
    {
        return new Color
        {
            A = 0xFF,
            R = r,
            G = g,
            B = b
        };
    }

    public static Color FromArgb(byte a, byte r, byte g, byte b)
    {
        return new Color
        {
            A = a,
            R = r,
            G = g,
            B = b
        };
    }
}
