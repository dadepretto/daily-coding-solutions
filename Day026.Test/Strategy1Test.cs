using System;
using Xunit;

namespace Day026.Test;

public class Strategy1Test
{
    [Fact]
    public void Execute_GivenNegativeIndex_ThrowsIndexOutOfRange()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3, 4});
        var strategy = new Strategy1();

        var action = () => strategy.Execute(linkedList, -1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void Execute_GivenZero_ThrowsIndexOutOfRange()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3, 4});
        var strategy = new Strategy1();

        var action = () => strategy.Execute(linkedList, 0);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Execute_GivenRegularListAndOne_RemovesLastElement()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3, 4});
        var strategy = new Strategy1();
        strategy.Execute(linkedList, 1);

        var actual = linkedList.ToList();

        Assert.Equal(new[] {1, 2, 3}, actual);
    }

    [Fact]
    public void Execute_GivenRegularListAndTwo_RemovesPenultimateElement()
    {
        var linkedList = new LinkedList<int>(new[] {1, 2, 3, 4});
        var strategy = new Strategy1();
        strategy.Execute(linkedList, 2);

        var actual = linkedList.ToList();

        Assert.Equal(new[] {1, 2, 4}, actual);
    }
}