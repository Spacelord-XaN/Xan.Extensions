namespace Xan.Extensions.Tests;

public class RandomExtensionsTests
{
    private const int _iterationCount = 1000 * 1000;
    private const int _seed = 666;
    
    private readonly Random _random;

    public RandomExtensionsTests()
    {
        _random = new Random(_seed);
    }

    [Fact]
    public void GetBool()
    {
        List<bool> results = new();

        RunTimes(() =>
        {
            bool result = _random.GetBool();
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
            double result = _random.GetDouble();

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
            int result = _random.GetInt32ByBits(bits);

            result.Should().BeInRange(expectedMin, expectedMax);
            values.Add(result);
        });

        values.Should().Contain(expectedMin);
        values.Should().Contain(expectedMax);
    }

    [Theory]
    [AutoData]
    public void Shuffle(int[] input)
    {
        //  Arrange
        int[] unshuffled = input.Select(x => x).ToArray();

        //  Act
        _random.Shuffle(input);

        //  Assert
        input.Should().BeEquivalentTo(unshuffled);
    }

    private static void RunTimes(Action what)
    {
        foreach (int _ in Enumerable.Range(0, _iterationCount))
        {
            what();
        }
    }
}
