namespace Day028;

public class Word : IRowComponent
{
    private readonly string _word;

    public Word(string word)
    {
        _word = word;
    }

    public int Length => _word.Length;

    public override string ToString()
    {
        return _word;
    }
}