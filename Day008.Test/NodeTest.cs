using Xunit;

namespace Day008.Test;

public class NodeTest
{
    [Fact]
    public void IsUnival_SimpleUnivalNode_ReturnsTrue()
    {
        var node = new Node<int>(3);

        var actual = node.IsUnival();

        Assert.True(actual);
    }

    [Fact]
    public void IsUnival_ComplexUnivalNode_ReturnsTrue()
    {
        var node = new Node<int>(3, new Node<int>(3), new Node<int>(3));

        var actual = node.IsUnival();

        Assert.True(actual);
    }

    [Fact]
    public void IsUnival_MediumNonUnivalNode_ReturnsFalse()
    {
        var node = new Node<int>(3, new Node<int>(4), new Node<int>(4));

        var actual = node.IsUnival();

        Assert.False(actual);
    }

    [Fact]
    public void IsUnival_ComplexNonUnivalNode_ReturnsFalse()
    {
        var node = new Node<int>(3,
            new Node<int>(3, new Node<int>(4), new Node<int>(4)),
            new Node<int>(3));

        var actual = node.IsUnival();

        Assert.False(actual);
    }
}