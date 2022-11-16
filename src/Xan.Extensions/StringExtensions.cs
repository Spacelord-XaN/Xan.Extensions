namespace Xan.Extensions;

public static class StringExtensions
{
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
