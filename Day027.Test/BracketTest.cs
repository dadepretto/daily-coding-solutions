using System;
using Xunit;

namespace Day027.Test;

public class BracketTest
{
    [Theory]
    [InlineData('(')]
    [InlineData('[')]
    [InlineData('{')]
    public void IsOpening_OnOpeningBracket_IsTrue(char character)
    {
        var bracket = new Bracket(character);

        var actual = bracket.IsOpening;

        Assert.True(actual);
    }

    [Fact]
    public void IsOpening_OnNonOpeningBracket_IsFalse()
    {
        var bracket = new Bracket('/');

        var actual = bracket.IsOpening;

        Assert.False(actual);
    }

    [Theory]
    [InlineData('(', ')')]
    [InlineData('[', ']')]
    [InlineData('{', '}')]
    public void MatchingClosing_OnOpeningBracket_IsMatchingClosing(
        char character, char expected)
    {
        var bracket = new Bracket(character);

        var actual = bracket.MatchingClosing;

        Assert.Equal(expected, actual.Character);
    }

    [Fact]
    public void MatchingClosing_OnNonOpeningBracket_ThrowsArgumentOutOfRange()
    {
        var bracket = new Bracket('/');

        var action = () => bracket.MatchingClosing;

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}