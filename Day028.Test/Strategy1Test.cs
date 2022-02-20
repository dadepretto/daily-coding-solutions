using System;
using System.Linq;
using Xunit;

namespace Day028.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData(new[] {"Hello", "world"}, 5, new[] {"Hello", "world"})]
    [InlineData(new[] {"Hello", "world"}, 6, new[] {"Hello ", "world "})]
    [InlineData(
        new[]
        {
            "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy",
            "dog"
        },
        16,
        new[] {"the  quick brown", "fox  jumps  over", "the   lazy   dog"}
    )]
    public void Execute_GivenWordsAndRowLength_ReturnsJustifiedRows(
        string[] words, int rowLength, string[] expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(words, rowLength).ToArray();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new[] {"Hello", "world"}, 4)]
    [InlineData(new[] {"Hello", "Dotnet"}, 5)]
    public void Execute_GivenWordsAndTooShortLength_ThrowsParameterOutOfBound(
        string[] words, int rowLength)
    {
        var strategy = new Strategy1();

        var action = () => strategy.Execute(words, rowLength);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}