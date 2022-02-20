using System;
using Xunit;

namespace Day026.Test;

public class LinkedListTest
{
    [Fact]
    public void Construct_WithHead_SavesHead()
    {
        var node = new Node<int>(10);
        var linkedList = new LinkedList<int>(node);

        var actual = linkedList.Head;

        Assert.Same(node, actual);
    }

    [Fact]
    public void Construct_WithEnumerable_ConstructsCorrectLinkedList()
    {
        var list = new[] {1, 2, 3};

        var actual = new LinkedList<int>(list);

        Assert.Equal(1, actual.Head!.Value);
        Assert.Equal(2, actual.Head!.Next!.Value);
        Assert.Equal(3, actual.Head!.Next!.Next!.Value);
        Assert.Null(actual.Head!.Next!.Next!.Next);
    }

    [Fact]
    public void Indexer_GivenNegativeIndex_ThrowsIndexOutOfRange()
    {
        var list = new[] {1, 2, 3};
        var linkedList = new LinkedList<int>(list);

        var action = () => Console.WriteLine(linkedList[-1]);

        Assert.Throws<IndexOutOfRangeException>(action);
    }

    [Fact]
    public void Indexer_GivenZeroIndex_ReturnsHead()
    {
        var head = new Node<int>(10);
        var linkedList = new LinkedList<int>(head);

        var actual = linkedList[0];

        Assert.Same(head, actual);
    }

    [Fact]
    public void Indexer_GivenPositiveIndex_ReturnsCorrespondingItem()
    {
        var firstNext = new Node<int>(11);
        var head = new Node<int>(10, firstNext);
        var linkedList = new LinkedList<int>(head);

        var actual = linkedList[1];

        Assert.Same(firstNext, actual);
    }
}