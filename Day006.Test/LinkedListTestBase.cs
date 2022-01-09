using System;
using Xunit;

namespace Day006.Test;

public abstract class LinkedListTestBase
{
    private readonly Type linkedListType;

    protected LinkedListTestBase(Type linkedListType)
    {
        this.linkedListType = linkedListType;
    }

    protected ILinkedList<int> GetNewInstance()
    {
        var type = linkedListType.MakeGenericType(typeof(int));
        return (Activator.CreateInstance(type) as ILinkedList<int>)!;
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void Add_IntegerValue_AddValueToList(int value)
    {
        var _linkedList = GetNewInstance();
        _linkedList.Add(value);

        var actual = _linkedList[0];

        Assert.Equal(value, actual);
    }

    [Theory]
    [InlineData(new[] {1, 2, 3})]
    [InlineData(new int[0])]
    public void ToList_IntegerValues_GetAsArray(int[] values)
    {
        var _linkedList = GetNewInstance();
        foreach (var value in values) _linkedList.Add(value);

        var actual = _linkedList.ToArray();

        Assert.Equal(values, actual);
    }

    [Fact]
    public void Indexer_ValidIndex_GetCorrectValue()
    {
        var _linkedList = GetNewInstance();
        _linkedList.Add(1);
        _linkedList.Add(2);
        _linkedList.Add(3);

        var actual = _linkedList[1];

        Assert.Equal(2, actual);
    }

    [Fact]
    public void Indexer_ValidIndex_SetCorrectValue()
    {
        var _linkedList = GetNewInstance();
        _linkedList.Add(1);
        _linkedList.Add(2);
        _linkedList.Add(3);
        _linkedList[2] = 4;

        var actual = _linkedList[2];

        Assert.Equal(4, actual);
    }

    [Fact]
    public void Indexer_IndexBelowZero_ThrowsArgumentOutOfRangeException()
    {
        var _linkedList = GetNewInstance();

        void actual()
        {
            _ = _linkedList[-1];
        }

        Assert.Throws<ArgumentOutOfRangeException>(actual);
    }

    [Fact]
    public void Indexer_IndexEqualLength_ThrowsArgumentOutOfRangeException()
    {
        var _linkedList = GetNewInstance();
        _linkedList.Add(1);

        void actual()
        {
            _ = _linkedList[1];
        }

        Assert.Throws<ArgumentOutOfRangeException>(actual);
    }

    [Fact]
    public void Indexer_IndexAboveLength_ThrowsArgumentOutOfRangeException()
    {
        var _linkedList = GetNewInstance();
        _linkedList.Add(1);

        void actual()
        {
            _ = _linkedList[5];
        }

        Assert.Throws<ArgumentOutOfRangeException>(actual);
    }
}