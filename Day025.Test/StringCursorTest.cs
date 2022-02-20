using Xunit;

namespace Day025.Test;

public class StringCursorTest
{
    [Fact]
    public void Constructor_GivenValue_SaveValue()
    {
        var expected = "Hello, world";
        var cursor = new StringCursor(expected);

        var actual = cursor.Value;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CurrentIndex_OnConstruction_IsSetToZero()
    {
        var cursor = new StringCursor("Hello, world");

        var actual = cursor.CurrentIndex;

        Assert.Equal(0, actual);
    }

    [Fact]
    public void CurrentValue_OnConstruction_IsFirstValue()
    {
        var cursor = new StringCursor("Hello, world");

        var actual = cursor.CurrentValue;

        Assert.Equal('H', actual);
    }

    [Fact]
    public void MoveNext_IncrementCurrentIndex()
    {
        var cursor = new StringCursor("Hello, world");
        cursor.MoveNext();

        var actual = cursor.CurrentIndex;

        Assert.Equal(1, actual);
    }

    [Fact]
    public void MoveNext_SetsCurrentValueToNextCharacter()
    {
        var cursor = new StringCursor("Hello, world");
        cursor.MoveNext();

        var actual = cursor.CurrentValue;

        Assert.Equal('e', actual);
    }

    [Fact]
    public void FastForward_GivenIndex_MovesCurrentIndexOfTheSameAmount()
    {
        var cursor = new StringCursor("Hello, world");
        cursor.FastForward(5);

        var actual = cursor.CurrentIndex;

        Assert.Equal(5, actual);
    }

    [Fact]
    public void ForwardTo_SetsCurrentValueToSecondCharacter()
    {
        var cursor = new StringCursor("Hello, world");
        cursor.FastForward(5);

        var actual = cursor.CurrentValue;

        Assert.Equal(',', actual);
    }

    [Fact]
    public void Remaining_ContainsRemainingCharactersAfterCurrentValue()
    {
        var cursor = new StringCursor("Hello, world");
        cursor.FastForward(6);

        var actual = cursor.Remaining;

        Assert.Equal("world", actual);
    }
}