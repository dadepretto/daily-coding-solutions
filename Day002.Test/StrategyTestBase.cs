using Xunit;

namespace Day002.Test;

public abstract class StrategyTestBase
{
    private readonly IStrategy _strategy;

    protected StrategyTestBase(IStrategy strategy)
    {
        _strategy = strategy;
    }

    [Theory]
    [InlineData(new[] {1, 2, 3, 4, 5}, new[] { 120, 60, 40, 30, 24 })]
    [InlineData(new[] {3, 2, 1}, new[] { 2, 3, 6 })]
    public virtual void Execute_ListOfNumbers_ReturnsMultiplicationsExceptSelf(
        int[] inputList,
        int[] expected)
    {
        var actual = _strategy.Execute(inputList);

        Assert.Equal(actual, expected);
    }
}