using System;
using Xunit;

namespace Day021.Test;

public class Strategy1Test
{
    [Fact]
    public void Execute_GivenSomeLectures_ReturnsMaximumNumberOfOverlaps()
    {
        var lectures = new[]
        {
            new Lecture(GetDateTime(09, 00), GetDateTime(10, 00)),
            new Lecture(GetDateTime(09, 00), GetDateTime(10, 00)),
            new Lecture(GetDateTime(09, 30), GetDateTime(10, 30)),

            new Lecture(GetDateTime(11, 00), GetDateTime(12, 00)),
            new Lecture(GetDateTime(11, 00), GetDateTime(12, 00)),
            new Lecture(GetDateTime(11, 30), GetDateTime(12, 30)),
            new Lecture(GetDateTime(11, 45), GetDateTime(12, 45)),

            new Lecture(GetDateTime(14, 00), GetDateTime(15, 00)),
            new Lecture(GetDateTime(14, 15), GetDateTime(14, 45))
        };
        var strategy = new Strategy1();

        var actual = strategy.Execute(lectures);

        Assert.Equal(4, actual);
    }

    [Fact]
    public void Execute_GivenOneLecture_ReturnsOne()
    {
        var lectures = new[]
        {
            new Lecture(GetDateTime(09, 00), GetDateTime(10, 00))
        };
        var strategy = new Strategy1();

        var actual = strategy.Execute(lectures);

        Assert.Equal(1, actual);
    }

    [Fact]
    public void Execute_GivenTwoNonOverlappingLectures_ReturnsOne()
    {
        var lectures = new[]
        {
            new Lecture(GetDateTime(09, 00), GetDateTime(10, 00)),
            new Lecture(GetDateTime(10, 00), GetDateTime(11, 00))
        };
        var strategy = new Strategy1();

        var actual = strategy.Execute(lectures);

        Assert.Equal(1, actual);
    }

    [Fact]
    public void Execute_GivenNoLecture_ThrowsInvalidOperation()
    {
        var lectures = Array.Empty<Lecture>();
        var strategy = new Strategy1();

        void Operation()
        {
            strategy.Execute(lectures);
        }

        Assert.Throws<InvalidOperationException>(Operation);
    }

    private DateTime GetDateTime(int hours, int minutes)
    {
        return new DateTime(1970, 1, 1, hours, minutes, 0);
    }
}