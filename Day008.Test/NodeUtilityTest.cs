using Xunit;

namespace Day008.Test;

public class NodeUtilityTest
{
    [Fact]
    public void CountUnivalTrees_VariousNodes_ReturnsRightCountOfUnivalTrees()
    {
        var node = new Node<int>(0,
            new Node<int>(1),
            new Node<int>(0,
                new Node<int>(1, new Node<int>(1), new Node<int>(1)),
                new Node<int>(0)));

        var actual = NodeUtility.CountUnivalTrees(node);

        Assert.Equal(5, actual);
    }
}