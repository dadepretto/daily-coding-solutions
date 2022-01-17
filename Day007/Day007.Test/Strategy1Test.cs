using Xunit;

namespace Day007.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData("111", 3)]
    [InlineData("3972", 1)]
    [InlineData("2626", 4)]
    public void Execute_GivenEncodedString_ReturnsNumberOfPossibleEvaluations(
        string encodedString, int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(encodedString);

        Assert.Equal(expected, actual);
    }
}