using Xunit;

namespace Day027.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData("([])[]({})")]
    public void Execute_GivenBalancedBrackets_ReturnsTrue(string brackets)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(brackets);

        Assert.True(actual);
    }

    [Theory]
    [InlineData("([)]")]
    [InlineData("((()")]
    [InlineData("())")]
    [InlineData("(/")]
    [InlineData("(/)")]
    public void Execute_GivenUnbalancedBrackets_ReturnsFalse(string brackets)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(brackets);

        Assert.False(actual);
    }
}