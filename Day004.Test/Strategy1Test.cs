using Xunit;

namespace Day004.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData(new[] {3, 4, -1, 1}, 2)]
    [InlineData(new[] {1, 2, 0}, 3)]
    [InlineData(new[] {-4, 3, 4, -1, 1, -2, 32, 4, -40}, 2)]
    [InlineData(new[] {0, -1, 1, -2, 2, -3, 3}, 4)]
    public void Execute_ListOfIntegers_FindFirstMissingPositive(int[] inputList,
        int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(inputList);

        Assert.Equal(expected, actual);
    }
}