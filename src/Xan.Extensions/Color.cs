using System.Globalization;

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

    /// <summary>
    /// Parses a hex color string in the form "RRGGBB" or "AARRGGBB", with an optional leading '#'.
    /// </summary>
    public static bool TryParse(string? hex, out Color color)
    {
        color = default;

        if (hex is null)
        {
            return false;
        }

        ReadOnlySpan<char> span = hex.AsSpan().TrimStart('#');

        byte a;
        ReadOnlySpan<char> rgb;
        switch (span.Length)
        {
            case 6:
                a = 0xFF;
                rgb = span;
                break;
            case 8:
                if (!byte.TryParse(span[..2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out a))
                {
                    return false;
                }
                rgb = span[2..];
                break;
            default:
                return false;
        }

        if (!byte.TryParse(rgb[..2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte r) ||
            !byte.TryParse(rgb[2..4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte g) ||
            !byte.TryParse(rgb[4..6], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte b))
        {
            return false;
        }

        color = FromArgb(a, r, g, b);
        return true;
    }
}
