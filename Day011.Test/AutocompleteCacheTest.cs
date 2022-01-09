using Xunit;

namespace Day011.Test;

public class AutocompleteCacheTest
{
    [Theory]
    [InlineData(new[] {"dog", "deer", "deal"}, "de", new[] {"deer", "deal"})]
    [InlineData(new[] {"dog", "deer", "deal"}, "ca", new string[0])]
    public void GetSuggestionsFor_SetOfWords_ReturnsRelevantSuggestions(
        string[] inputStrings, string input, string[] expected)
    {
        var autocompleteCache = new AutocompleteCache(inputStrings);

        var actual = autocompleteCache.GetSuggestionsFor(input);

        Assert.Equal(expected, actual);
    }
}