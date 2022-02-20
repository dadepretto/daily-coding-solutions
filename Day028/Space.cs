namespace Day028;

public class Space : IRowComponent
{
    public Space(int length = 1)
    {
        Length = length;
    }

    public int Length { get; set; }

    public override string ToString()
    {
        return string.Concat(Enumerable.Repeat(' ', Length));
    }
}