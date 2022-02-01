namespace Day021;

public class Lecture
{
    public Lecture(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public DateTime Start { get; }
    public DateTime End { get; }
}