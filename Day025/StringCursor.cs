namespace Day025;

public class StringCursor
{
    public StringCursor(string value)
    {
        Value = value;
        CurrentIndex = 0;
    }

    public string Value { get; }

    public int CurrentIndex { get; private set; }

    public bool HasValues => CurrentIndex < Value.Length;

    public char? CurrentValue => HasValues ? Value[CurrentIndex] : null;

    public string? Remaining => HasValues ? Value[(CurrentIndex + 1)..] : null;

    public void MoveNext()
    {
        CurrentIndex++;
    }

    public void FastForward(int offset)
    {
        CurrentIndex += offset;
    }
}