using System;
using Xunit;

namespace Day012.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData(4, 5)]
    public void Execute_GivenNumberOfSteps_ReturnsNumberOfPossibleWays(
        int numberOfSteps, int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(numberOfSteps);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4, 5, new[] {1, 2})]
    [InlineData(5, 5, new[] {1, 3, 5})]
    public void Execute_GivenNumberOfStepsAndSizes_ReturnsNumberOfPossibleWays(
        int numberOfSteps, int expected, int[] stepSizes)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(numberOfSteps, stepSizes);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Execute_GivenNegativeNumberOfSteps_ThrowsArgumentOutOfRange()
    {
        var strategy = new Strategy1();

        var actual = () => strategy.Execute(-1);

        Assert.Throws<ArgumentOutOfRangeException>(() => actual());
    }
}