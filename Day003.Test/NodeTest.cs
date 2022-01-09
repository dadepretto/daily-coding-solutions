using Xunit;

namespace Day003.Test;

public class NodeTest
{
    [Fact]
    public void Constructor_CallWithOneParameter_LeftIsNull()
    {
        var node = new Node("");

        var actual = node.Left;

        Assert.Null(actual);
    }

    [Fact]
    public void Constructor_CallWithOneParameter_RightIsNull()
    {
        var node = new Node("");

        var actual = node.Right;

        Assert.Null(actual);
    }

    [Fact]
    public void Constructor_CallWithOneParameter_ValueHasParameter()
    {
        var node = new Node("Hello, world!");

        var actual = node.Value;

        Assert.Equal("Hello, world!", actual);
    }

    [Fact]
    public void Equals_TwoNodesWithSameValueAndNoLeftOrRight_ReturnsTrue()
    {
        var nodeA = new Node("Hello, world!");
        var nodeB = new Node("Hello, world!");

        var actual = nodeA.Equals(nodeB);

        Assert.True(actual);
    }

    [Fact]
    public void Equals_TwoNodesWithDifferentValueAndNoLeftOrRight_ReturnsFalse()
    {
        var nodeA = new Node("Hello, world!");
        var nodeB = new Node("Hello, world.");

        var actual = nodeA.Equals(nodeB);

        Assert.False(actual);
    }
}