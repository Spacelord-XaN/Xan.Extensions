namespace Xan.Extensions.Tests;

public class RandomExtensionsTests
{
    private const int _iterationCount = 1000 * 1000;

    [Fact]
    public void GetBool()
    {
        List<bool> results = new();

        RunTimes(() =>
        {
            bool result = RandomExtensions.GetBool();
            results.Add(result);
        });

        results.Should().Contain(false);
        results.Should().Contain(true);
    }

    [Fact]
    public void GetDouble()
    {
        RunTimes(() =>
        {
            double result = RandomExtensions.GetDouble();

            result.Should().BeInRange(0.0, 1.0);
        });
    }

    [Theory]
    [InlineData(3, 0, 7)]
    [InlineData(11, 0, 2047)]
    public void GetInt32ByBits(int bits, int expectedMin, int expectedMax)
    {
        List<int> values = new();

        RunTimes(() =>
        {
            int result = RandomExtensions.GetInt32ByBits(bits);

            result.Should().BeInRange(expectedMin, expectedMax);
            values.Add(result);
        });

        values.Should().Contain(expectedMin);
        values.Should().Contain(expectedMax);
    }

    [Fact]
    public void GetPositiveInt32()
    {
        RunTimes(() =>
        {
            int result = RandomExtensions.GetPositiveInt32();

            result.Should().BeInRange(0, int.MaxValue);
        });
    }

    private static void RunTimes(Action what)
    {
        foreach (int _ in Enumerable.Range(0, _iterationCount))
        {
            what();
        }
    }
}
