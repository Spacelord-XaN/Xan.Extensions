using System.Security.Cryptography;

namespace Xan.Extensions;

public static class RandomNumberGeneratorExtensions
{
    public static bool GetBool()
        => RandomNumberGenerator.GetInt32(2) == 0;

    public static double GetDouble()
    {
        return (((long)GetInt32ByBits(26) << 27) + GetInt32ByBits(27))
            / (double)(1L << 53);
    }

    public static double GetGaussian(double mean, double stdDev)
    {
        //  yehaw random stackoverflow code: https://stackoverflow.com/questions/218060/random-gaussian-variables
        double u1 = 1.0 - GetDouble();
        double u2 = 1.0 - GetDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

        return mean + stdDev * randStdNormal;
    }

    public static int GetInt32ByBits(int bits)
        => RandomNumberGenerator.GetInt32((int)Math.Pow(2, bits));   

    public static int GetPositiveInt32()
        => RandomNumberGenerator.GetInt32(int.MaxValue);

    public static T GetRandomElement<T>(this IReadOnlyList<T> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        return items[RandomNumberGenerator.GetInt32(0, items.Count)];
    }

    public static T GetRandomElement<T>(this IQueryable<T> iq)
    {
        ArgumentNullException.ThrowIfNull(iq);

        return iq.ToArray().GetRandomElement();
    }
}
