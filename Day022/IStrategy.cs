namespace Day022;

public interface IStrategy
{
    public IEnumerable<string>? Execute(
        IEnumerable<string> words,
        string sentence);
}