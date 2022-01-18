using System.Linq;
using Xunit;

namespace Day015.Test;

public class Strategy1Test
{
    [Fact]
    public void Execute_GivenStream_ReturnsRandomElementWithUniformProbability()
    {
        var items = new[] {'a', 'b', 'c'};
        var strategy = new Strategy1();
        var iterations = 1_000_000;

        var averageAverageSelection = Enumerable
            .Repeat(items, iterations)
            .AsParallel()
            .Select(strategy.Execute)
            .GroupBy(x => x)
            .Select(g => g.Count() / (double) iterations)
            .Average();

        Assert.InRange(averageAverageSelection, 0.33330, 0.33339);
    }
}