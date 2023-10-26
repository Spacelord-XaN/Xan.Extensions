namespace Xan.Extensions;

public static class RandomExtensions
{
    public static bool GetBool(this Random random)
    {
        ArgumentNullException.ThrowIfNull(random);

        return random.Next(2) == 0;
    }

    public static double GetDouble(this Random random)
    {
        ArgumentNullException.ThrowIfNull(random);

        return (((long)random.GetInt32ByBits(26) << 27) + random.GetInt32ByBits(27))
            / (double)(1L << 53);
    }

    public static double GetGaussian(this Random random, double mean, double stdDev)
    {
        ArgumentNullException.ThrowIfNull(random);

        //  yehaw random stackoverflow code: https://stackoverflow.com/questions/218060/random-gaussian-variables
        double u1 = 1.0 - random.GetDouble();
        double u2 = 1.0 - random.GetDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

        return mean + stdDev * randStdNormal;
    }

    public static int GetInt32ByBits(this Random random, int bits)
    {
        ArgumentNullException.ThrowIfNull(random);

        return random.Next((int)Math.Pow(2, bits));
    }

    public static T GetRandomElement<T>(this Random random, IReadOnlyList<T> items)
    {
        ArgumentNullException.ThrowIfNull(random);
        ArgumentNullException.ThrowIfNull(items);

        return items[random.Next(0, items.Count)];
    }

    public static T GetRandomElement<T>(this Random random, IQueryable<T> iq)
    {
        ArgumentNullException.ThrowIfNull(random);
        ArgumentNullException.ThrowIfNull(iq);

        return random.GetRandomElement(iq.ToArray());
    }

    public static void Shuffle<T>(this Random random, IList<T> list)
    {
        ArgumentNullException.ThrowIfNull(random);
        ArgumentNullException.ThrowIfNull(list);

        int count = list.Count;
        for (int index = count - 1; index > 0; index--)
        {
            int newIndex = random.Next(0, index + 1);

            // Swap elements at i and j
            T temp = list[index];
            list[index] = list[newIndex];
            list[newIndex] = temp;
        }
    }
}
