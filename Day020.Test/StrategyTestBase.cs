using System;
using Xunit;

namespace Day020.Test;

public abstract class StrategyTestBase
{
    private readonly IStrategy _strategy;

    protected StrategyTestBase(IStrategy strategy)
    {
        _strategy = strategy;
    }

    [Fact]
    public void Execute_GivenIntersectingLinkedLists_ReturnIntersectingElement()
    {
        var common = new Node(1, new Node(2, new Node(3)));
        var left = new Node(-1, new Node(0, common));
        var right = new Node(-2, new Node(-1, new Node(0, common)));

        var actual = _strategy.Execute(left, right);

        Assert.Equal(1, actual);
    }

    [Fact]
    public void Execute_GivenNonIntersectingLinkedLists_ThrowsInvalidOperation()
    {
        var left = new Node(1, new Node(2, new Node(3)));
        var right = new Node(1, new Node(2, new Node(3)));

        void Operation()
        {
            _strategy.Execute(left, right);
        }

        Assert.Throws<InvalidOperationException>(Operation);
    }

    private class Node : SampleNode<int>
    {
        public Node(int value, Node? next = default) : base(value, next)
        {
        }
    }
}