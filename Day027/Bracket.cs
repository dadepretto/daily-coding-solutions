namespace Day027;

public record Bracket(char Character)
{
    public bool IsOpening => Character is '(' or '[' or '{';

    public Bracket MatchingClosing => Character switch
    {
        '(' => new Bracket(')'),
        '[' => new Bracket(']'),
        '{' => new Bracket('}'),
        _ => throw new ArgumentOutOfRangeException()
    };
}