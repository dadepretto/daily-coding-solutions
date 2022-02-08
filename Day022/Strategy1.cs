namespace Day022;

public class Strategy1 : IStrategy
{
    public IEnumerable<string>? Execute(
        IEnumerable<string> words,
        string sentence)
    {
        var wordSet = words.ToHashSet();
        var result = new List<string>();

        for (int start = 0, end = 0; end < sentence.Length; end++)
        {
            var candidate = sentence[start..(end + 1)];
            if (!wordSet.Contains(candidate)) continue;
            result.Add(candidate);
            start = end + 1;
        }

        return result.Any() ? result : null;
    }
}