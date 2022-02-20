namespace Day028;

public interface IStrategy
{
    public IEnumerable<string> Execute(string[] words, int rowLength);
}