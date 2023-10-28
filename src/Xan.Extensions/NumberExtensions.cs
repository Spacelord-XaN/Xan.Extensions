using System.Numerics;

namespace Xan.Extensions;

public static class NumberExtensions
{
    public static bool IsBetween<T>(this T number, T minExclusive, T maxExclusive)
        where T : INumber<T>
    {
        return number > minExclusive && number < maxExclusive;
    }

    public static bool IsInRange<T>(this T number, T minInclusive, T maxInclusive)
        where T : INumber<T>
    {
        return number >= minInclusive && number <= maxInclusive;
    }
}
