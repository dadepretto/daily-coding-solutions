using Xunit;

namespace Day031.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData("", "", 0)]
    [InlineData("a", "", 1)]
    [InlineData("aa", "", 2)]
    [InlineData("", "a", 1)]
    [InlineData("", "aa", 2)]
    [InlineData("a", "aa", 1)]
    [InlineData("aa", "a", 1)]
    [InlineData("kitten", "sitting", 3)]
    [InlineData("book", "back", 2)]
    [InlineData("book", "black", 3)]
    [InlineData("portal", "port", 2)]
    [InlineData("hello", "man", 5)]
    [InlineData("computer", "table", 7)]
    [InlineData("governance", "policy", 8)]
    public void Execute_GivenTwoStrings_ReturnsDistance(
        string a, string b, int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(a, b);
        
        Assert.Equal(expected, actual);
    }
}