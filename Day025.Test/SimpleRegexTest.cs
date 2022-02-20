using Xunit;

namespace Day025.Test;

public class SimpleRegexTest
{
    [Theory]
    [InlineData("", "")]
    [InlineData("ray", "ra.")]
    [InlineData("raymond", "ray..nd")]
    [InlineData("raymond", "ray.on.")]
    [InlineData("raymond", ".ay.on.")]
    [InlineData("raymond", ".......")]
    [InlineData("", "*")]
    [InlineData("chat", ".*at")]
    [InlineData("helloworld", "he*")]
    [InlineData("helloworld", "he*ld")]
    [InlineData("helloworld", "he**ld")]
    [InlineData("helloworld", "he***ld")]
    [InlineData("helloworld", "he*****o**r*d")]
    public void Match_OnValidInput_ReturnsTrue(string input, string regex)
    {
        var simpleRegex = new SimpleRegex(input, regex);

        var actual = simpleRegex.Match();

        Assert.True(actual);
    }

    [Theory]
    [InlineData("a", "")]
    [InlineData("", ".")]
    [InlineData("raymond", "ra.")]
    [InlineData("raymond", "ray.nd")]
    [InlineData("raymond", "ray...nd")]
    [InlineData("raymond", "ray..on.")]
    [InlineData("raymond", "..ay.on.")]
    [InlineData("raymond", "........")]
    [InlineData("raymond", "......")]
    [InlineData("chats", ".*at")]
    [InlineData("helloworld", "he*****o**r*ld")]
    public void Match_OnInvalidInput_ReturnsFalse(string input, string regex)
    {
        var simpleRegex = new SimpleRegex(input, regex);

        var actual = simpleRegex.Match();

        Assert.False(actual);
    }
}