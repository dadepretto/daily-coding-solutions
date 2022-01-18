using Xunit;

namespace Day013.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData("abcba", 2, 3)]
    [InlineData("aaaaa", 2, -1)]
    [InlineData("abcde", 5, 5)]
    [InlineData("abcdd", 5, -1)]
    public void
        Execute_GivenAStringAndK_ReturnsLengthOfLongestSubstringWithKDistinctChars(
            string inputString, int numberOfDistinctCharacters, int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(inputString, numberOfDistinctCharacters);

        Assert.Equal(expected, actual);
    }
}