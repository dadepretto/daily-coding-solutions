using System.Collections.Generic;
using Xunit;

namespace Day018.Test;

public abstract class StrategyTestBase
{
    private readonly IStrategy _strategy;

    protected StrategyTestBase(IStrategy strategy)
    {
        _strategy = strategy;
    }

    [Theory]
    [InlineData(new[] {10, 5, 2, 7, 8, 7}, 1, new[] {10, 5, 2, 7, 8, 7})]
    [InlineData(new[] {10, 5, 2, 7, 8, 7}, 2, new[] {10, 5, 7, 8, 8})]
    [InlineData(new[] {10, 5, 2, 7, 8, 7}, 3, new[] {10, 7, 8, 8})]
    [InlineData(new[] {10, 5, 2, 7, 8, 7}, 4, new[] {10, 8, 8})]
    [InlineData(new[] {10, 5, 2, 7, 8, 7}, 6, new[] {10})]
    [InlineData(new[] {1, 1, 1, 1, 1, 1}, 1, new[] {1, 1, 1, 1, 1, 1})]
    [InlineData(new[] {1, 1, 1, 1, 1, 1}, 2, new[] {1, 1, 1, 1, 1})]
    [InlineData(new[] {1, 1, 1, 1, 1, 1}, 3, new[] {1, 1, 1, 1})]
    [InlineData(new[] {1, 1, 1, 1, 1, 1}, 6, new[] {1})]
    [InlineData(new[] {1, 2, 3, 10, 2, 5, -4, -7, -2, 10}, 3,
        new[] {3, 10, 10, 10, 5, 5, -2, 10})]
    public void Execute_GivenIntArrayAndSubsetLength_ReturnsMaxOfRollingSubsets(
        int[] inputList, int subsetLength, int[] expected)
    {
        var actual = new List<int>();

        _strategy.Execute(inputList, subsetLength, actual);

        Assert.Equal(expected, actual);
    }
}