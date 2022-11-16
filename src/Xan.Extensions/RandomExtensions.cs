namespace Xan.Extensions;

public static class RandomExtensions
{
    public static bool NextBool(this Random rand)
    {
        ArgumentNullException.ThrowIfNull(rand);

        return rand.NextDouble() > 0.5;
    }

    public static double NextGaussian(this Random rand, double mean, double stdDev)
    {
        ArgumentNullException.ThrowIfNull(rand);

        //  yehaw random stackoverflow code: https://stackoverflow.com/questions/218060/random-gaussian-variables
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

        return mean + stdDev * randStdNormal;
    }

    public static T TakeRandom<T>(this Random rand, IReadOnlyList<T> items)
    {
        ArgumentNullException.ThrowIfNull(rand);
        ArgumentNullException.ThrowIfNull(items);

        return items[rand.Next(0, items.Count - 1)];
    }

    public static T TakeRandom<T>(this Random rand, IQueryable<T> iq)
    {
        ArgumentNullException.ThrowIfNull(rand);
        ArgumentNullException.ThrowIfNull(iq);
        
        return rand.TakeRandom(iq.ToArray());
    }
}
