using System;
using System.Collections.Generic;
using Xunit;

namespace Day026.Test;

public class LinkedListExtensionsTest
{
    [Fact]
    public void Count_OnEmptyList_ReturnsZero()
    {
        var linkedList = new LinkedList<int>((Node<int>) null!);

        var actual = linkedList.Count();

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Count_OnNonEmptyList_ReturnsCountOfNodes()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3});

        var actual = linkedList.Count();

        Assert.Equal(3, actual);
    }

    [Fact]
    public void ToList_OnEmptyList_ReturnsEmptyList()
    {
        var linkedList = new LinkedList<int>((Node<int>) null!);

        var actual = linkedList.ToList();

        Assert.Equal(new List<int>(), actual);
    }

    [Fact]
    public void ToList_OnNonEmptyList_ReturnsEmptyList()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3});

        var actual = linkedList.ToList();

        Assert.Equal(new List<int> {1, 2, 3}, actual);
    }

    [Fact]
    public void ToArray_OnEmptyList_ReturnsEmptyList()
    {
        var linkedList = new LinkedList<int>((Node<int>) null!);

        var actual = linkedList.ToArray();

        Assert.Equal(Array.Empty<int>(), actual);
    }

    [Fact]
    public void ToArray_OnNonEmptyList_ReturnsEmptyList()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3});

        var actual = linkedList.ToArray();

        Assert.Equal(new[] {1, 2, 3}, actual);
    }
}