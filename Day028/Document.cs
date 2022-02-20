namespace Day028;

public class Document
{
    private readonly List<Word> _words;

    public Document(IEnumerable<string> words)
    {
        _words = words.Select(w => new Word(w)).ToList();
    }

    public IEnumerable<string> GetJustifiedContent(int length)
    {
        var rows = new List<Row> {new(length)};

        foreach (var word in _words)
        {
            var hasBeenAdded = rows.Last().TryAdd(word);
            if (!hasBeenAdded) rows.Add(new Row(length, word));
        }

        return rows.Select(word => word.ToString());
    }
}