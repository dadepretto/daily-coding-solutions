namespace Day003;

public class MalformedStringException : ArgumentException
{
    public MalformedStringException(string? message) : base(message)
    {
    }
}