using Xunit;

namespace Day001.Test;

public abstract class StrategyTestBase
{
    private readonly IStrategy _strategy;

    protected StrategyTestBase(IStrategy strategy)
    {
        _strategy = strategy;
    }

    [Theory]
    [InlineData(new[] {10, 15, 3, 7}, 17)]
    public virtual void Execute_TwoListNumbersAddToTarget_ReturnsTrue(
        int[] inputList,
        int target)
    {
        var actual = _strategy.Execute(inputList, target);

        Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] {10, 15, 3, 7}, 11)]
    public virtual void Execute_AnyTwoNumbersAddToTarget_ReturnsFalse(
        int[] inputList,
        int target)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(inputList, target);

        Assert.False(actual);
    }
}