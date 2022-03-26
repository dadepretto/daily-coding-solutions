namespace Day031;

public class Strategy1 : IStrategy
{
    public int Execute(string source, string target)
    {
        if (string.IsNullOrEmpty(source)) return target.Length;
        if (string.IsNullOrEmpty(target)) return source.Length;
        if (source[0] == target[0]) return Execute(source[1..], target[1..]);

        var paths = new[]
        {
            Execute(source[1..], target),
            Execute(source, target[1..]),
            Execute(source[1..], target[1..])
        };

        return 1 + paths.Min();
    }
}