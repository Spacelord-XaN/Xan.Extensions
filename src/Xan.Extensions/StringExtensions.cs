using System.Text;

namespace Xan.Extensions;

public static class StringExtensions
{
    public static string ToPrettyIBAN(this string? iban)
    {
        if (string.IsNullOrEmpty(iban))
        {
            return string.Empty;
        }
        StringBuilder sb = new();
        for (int index = 0; index < iban.Length; index++)
        {
            if (index > 0 && index % 4 == 0)
            {
                sb.Append(' ');
            }
            sb.Append(iban[index]);
        }
        return sb.ToString();
    }

    public static string Truncate(this string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        if (input.Length <= maxLength)
        {
            return input;
        }
        return input.Substring(0, maxLength);
    }
}
