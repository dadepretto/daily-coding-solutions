using Xunit;

namespace Day029.Test;

public class UnitTest1
{
    [Theory]
    [InlineData("AAAABBBCCDAA", "4A3B2C1D2A")]
    public void Encode_GivenString_ReturnsEncodedVersion(
        string input, string expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Encode(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("4A3B2C1D2A", "AAAABBBCCDAA")]
    public void Decode_GivenString_ReturnsDecodedVersion(
        string input, string expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Decode(input);

        Assert.Equal(expected, actual);
    }
}