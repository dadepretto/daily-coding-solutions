using Xunit;

namespace Day026.Test;

public class NodeTest
{
    [Fact]
    public void Constructor_GivenValue_SetsValue()
    {
        var node = new Node<int>(10);

        var actual = node.Value;

        Assert.Equal(10, actual);
    }

    [Fact]
    public void Constructor_GivenNext_SetsNext()
    {
        var node = new Node<int>(11);
        var previous = new Node<int>(10, node);

        var actual = previous.Next;

        Assert.Same(node, actual);
    }
}