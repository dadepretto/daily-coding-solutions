using Xunit;

namespace Day025.Test;

public class StringCursorExtensionsTest
{
    [Fact]
    public void PeekNext_WhenCursorHasNextCharacter_ReturnsNextCharacter()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(6);

        var actual = stringCursor.PeekNext();

        Assert.Equal('w', actual);
    }

    [Fact]
    public void PeekNext_WhenCursorIsAtEnd_ReturnsNull()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(12);

        var actual = stringCursor.PeekNext();

        Assert.Null(actual);
    }

    [Fact]
    public void PeekUntilEndOr_GivenUnrealizablePredicate_ReturnsRemaining()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(6);

        var actual = stringCursor.PeekUntilEndOr(c => c == 'H');

        Assert.Equal("world", actual);
    }

    [Fact]
    public void PeekUntilEndOr_GivenValidPredicate_ReturnsMatchingSubstring()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(6);

        var actual = stringCursor.PeekUntilEndOr(c => c == 'r');

        Assert.Equal("wo", actual);
    }

    [Fact]
    public void PeekUntilEndOr_WhenCursorIsEnded_ReturnsNull()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(12);

        var actual = stringCursor.PeekUntilEndOr(c => c == 'r');

        Assert.Null(actual);
    }

    [Fact]
    public void GetOffsetUntil_GivenValidOccurrence_ReturnsOffsetToStart()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(6);

        var actual = stringCursor.GetOffsetUntil("or");

        Assert.Equal(1, actual);
    }

    [Fact]
    public void GetOffsetUntil_GivenInValidOccurrence_ReturnsNull()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(6);

        var actual = stringCursor.GetOffsetUntil("od");

        Assert.Null(actual);
    }

    [Fact]
    public void GetOffsetUntil_WhenCursorIsEnded_ReturnsNull()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(12);

        var actual = stringCursor.GetOffsetUntil("or");

        Assert.Null(actual);
    }

    [Fact]
    public void IsEnd_WhenCursorIsNotEnded_ReturnsFalse()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(6);

        var actual = stringCursor.IsEnd();

        Assert.False(actual);
    }

    [Fact]
    public void IsEnd_WhenCursorIsEnded_ReturnsTrue()
    {
        var stringCursor = new StringCursor("Hello, world");
        stringCursor.FastForward(12);

        var actual = stringCursor.IsEnd();

        Assert.True(actual);
    }
}