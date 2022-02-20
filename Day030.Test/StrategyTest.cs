using Xunit;

namespace Day030.Test;

public class StrategyTest
{
    [Theory]
    [InlineData(new[] {2, 1, 2}, 1)]
    [InlineData(new[] {3, 0, 1, 3, 0, 5}, 8)]
    public void Execute_GivenHeightMap_ReturnsUnitsOfWaterTrapped(int[] map,
        int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(map);

        Assert.Equal(expected, actual);
    }
}