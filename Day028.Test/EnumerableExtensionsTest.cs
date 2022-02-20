using System;
using System.Linq;
using Xunit;

namespace Day028.Test;

public class EnumerableExtensionsTest
{
    [Fact]
    public void ToQueue_OnEnumerableWithoutElements_ReturnsEmptyQueue()
    {
        var list = Array.Empty<int>();

        var actual = list.ToQueue();

        Assert.Empty(actual);
    }

    [Fact]
    public void ToQueue_OnEnumerable_ReturnsQueueWithSameElements()
    {
        var list = new[] {1, 2, 3};
        var queue = list.ToQueue();

        var actual = queue.ToArray();

        Assert.Equal(list, actual);
    }

    [Fact]
    public void AsCyclical_GivenEmptyList_YieldsNothing()
    {
        var list = Array.Empty<int>();
        var cyclicalList = list.AsCyclical();

        var actual = cyclicalList.ToArray();

        Assert.Empty(actual);
    }

    [Fact]
    public void AsCyclical_GivenListOfN_YieldsNElementsFirst()
    {
        var list = new[] {1, 2, 3};
        var cyclicalList = list.AsCyclical();

        var actual = cyclicalList.Take(list.Length).ToList();

        Assert.Equal(list, actual);
    }

    [Fact]
    public void AsCyclical_GivenListOfN_YieldsSameNElementsAfterFirstN()
    {
        var list = new[] {1, 2, 3};
        var cyclicalList = list.AsCyclical();

        var actual = cyclicalList.Skip(list.Length).Take(list.Length).ToList();

        Assert.Equal(list, actual);
    }
}