using System.Collections.Generic;
using Xunit;

namespace Day016.Test;

public class Strategy1Test
{
    [Fact]
    public void Record_GivenOrderId_ShouldIncrementLengthByOne()
    {
        var strategy = new Strategy1<int>(new List<int>());
        strategy.Record(123);

        var actual = strategy.Count;

        Assert.Equal(1, actual);
    }

    [Fact]
    public void GetLast_GivenZero_ShouldReturnTheLastElement()
    {
        var strategy = new Strategy1<int>(new List<int>());
        strategy.Record(123);

        var actual = strategy.GetLast(0);

        Assert.Equal(123, actual);
    }

    [Fact]
    public void GetLast_GivenOne_ShouldReturnTheLastButOneElement()
    {
        var strategy = new Strategy1<int>(new List<int>());
        strategy.Record(123);
        strategy.Record(321);

        var actual = strategy.GetLast(1);

        Assert.Equal(123, actual);
    }
}