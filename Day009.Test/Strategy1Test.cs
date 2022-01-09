using Xunit;

namespace Day009.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData(new int[0], null)]
    [InlineData(new[] {100}, 100)]
    [InlineData(new[] {100, 101}, 101)]
    [InlineData(new[] {5, 7, 6}, 11)]
    [InlineData(new[] {5, 1, 1, 5}, 10)]
    [InlineData(new[] {90, 70, 100, 101}, 191)]
    [InlineData(new[] {101, 90, 70, 100}, 201)]
    [InlineData(new[] {90, 101, 70, 100}, 201)]
    [InlineData(new[] {2, 4, 6, 2, 5}, 13)]
    [InlineData(new[] {10, 15, 6, 0, 2, 0, 3, 0, 4}, 25)]
    public void Execute_ArrayOfNumbers_ReturnsTheLargestSumOfNonAdjacentNumbers(
        int[] inputValues, int? expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(inputValues);

        Assert.Equal(expected, actual);
    }
}