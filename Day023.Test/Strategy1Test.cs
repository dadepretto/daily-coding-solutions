using Xunit;

namespace Day023.Test;

public class Strategy1Test
{
    private readonly TestCase[] _testCases =
    {
        new(
            new[,]
            {
                {false, false, false, false},
                {true, true, false, true},
                {false, false, false, false},
                {false, false, false, false}
            },
            (3, 0),
            (0, 0),
            7
        ),
        new(
            new[,]
            {
                {false, false, false, false},
                {false, false, false, false},
                {false, false, false, false},
                {false, false, false, false}
            },
            (3, 0),
            (0, 0),
            3
        )
    };

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void Execute_GivenValidBoardStartEnd_ReturnsMinimumDistance(
        int testCaseIndex)
    {
        var (board, start, end, expected) = _testCases[testCaseIndex];
        var strategy = new Strategy1();

        var actual = strategy.Execute(board, start, end);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Execute_GivenInaccessibleStart_ReturnsNull()
    {
        var strategy = new Strategy1();
        var board = new[,]
        {
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false}
        };

        var actual = strategy.Execute(board, (-1, 0), (0, 0));

        Assert.Null(actual);
    }

    [Fact]
    public void Execute_GivenInaccessibleEnd_ReturnsNull()
    {
        var strategy = new Strategy1();
        var board = new[,]
        {
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false}
        };

        var actual = strategy.Execute(board, (0, 0), (-1, 0));

        Assert.Null(actual);
    }

    [Fact]
    public void Execute_GivenImpossiblePath_ReturnsNull()
    {
        var strategy = new Strategy1();
        var board = new[,]
        {
            {false, false, false, false},
            {true, true, true, true},
            {false, false, false, false},
            {false, false, false, false}
        };

        var actual = strategy.Execute(board, (3, 0), (0, 0));

        Assert.Null(actual);
    }
}

internal record TestCase(
    bool[,] Board,
    (int x, int y) Start,
    (int x, int y) End,
    int Expected);