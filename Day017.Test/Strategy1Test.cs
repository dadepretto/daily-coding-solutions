using Xunit;

namespace Day017.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext", 20)]
    [InlineData(
        "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext",
        32)]
    [InlineData(
        "dir\n\tsubdir10\n\t\tsubdir11\n\t\t\tsubdir12\n\t\t\t\tsubdir13\n\t\t\t\t\tsubdir14\n\t\t\t\t\t\tsubdir15\n\ta\n\t\tb.ext",
        11)]
    public void Execute_GivenRepresentation_ReturnsLengthOfLongestPath(
        string fileSystemRepresentation,
        int expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(fileSystemRepresentation);

        Assert.Equal(expected, actual);
    }
}