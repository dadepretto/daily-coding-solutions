using System.Collections.Generic;
using Xunit;

namespace Day022.Test;

public class Strategy1Test
{
    [Theory]
    [InlineData(
        new[] {"quick", "brown", "the", "fox"},
        "thequickbrownfox",
        new[] {"the", "quick", "brown", "fox"})
    ]
    [InlineData(
        new[] {"bed", "bath", "bedbath", "and", "beyond"},
        "bedbathandbeyond",
        new[] {"bed", "bath", "and", "beyond"})
    ]
    public void Execute_GivenListOfWordsAndSentence_ReturnsAPossibleSequence(
        IEnumerable<string> words,
        string sentence,
        IEnumerable<string> expected)
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(words, sentence);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Execute_GivenListOfWordsAndUnrelatedSentence_ReturnsNull()
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(new[] {"hello", "world"}, "hifolks");

        Assert.Null(actual);
    }

    [Fact]
    public void Execute_GivenListOfWordsAndWordAsSentence_ReturnsSentence()
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(new[] {"hello", "world"}, "hello");

        Assert.Equal(new[] {"hello"}, actual);
    }

    [Fact]
    public void Execute_GivenListOfOneWordAndWordAsSentence_ReturnsSentence()
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute(new[] {"hello"}, "hello");

        Assert.Equal(new[] {"hello"}, actual);
    }
}