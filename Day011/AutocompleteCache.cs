namespace Day011;

public class AutocompleteCache
{
    private readonly Dictionary<string, List<string>> _hints = new();

    public AutocompleteCache(IEnumerable<string> wordsToIndex)
    {
        AddRange(wordsToIndex);
    }

    public void AddRange(IEnumerable<string> wordsToIndex)
    {
        foreach (var word in wordsToIndex) Add(word);
    }

    public void Add(string word)
    {
        for (var i = 0; i < word.Length; i++)
        {
            var prefix = word[..(i + 1)];
            if (_hints.ContainsKey(prefix)) _hints[prefix].Add(word);
            else _hints[prefix] = new List<string> {word};
        }
    }

    public string[] GetSuggestionsFor(string input)
    {
        return _hints.TryGetValue(input, out var result)
            ? result.ToArray()
            : Array.Empty<string>();
    }
}