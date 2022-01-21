namespace Day017;

public class PathFragment
{
    public PathFragment(string line)
    {
        Depth = line.TakeWhile(c => c == '\t').Count() + 1;
        Value = Depth == 1 ? line : '/' + line[(Depth - 1)..];
    }

    public int Depth { get; }

    public string Value { get; }

    public int Length => Value.Length;

    public bool IsFile => Value.Contains('.');
}