namespace Day028;

public class Strategy1 : IStrategy
{
    public IEnumerable<string> Execute(string[] words, int rowLength)
    {
        var document = new Document(words);
        var justifiedContent = document.GetJustifiedContent(rowLength);
        return justifiedContent;
    }
}