namespace Day013;

public class Strategy1 : IStrategy
{
    public int Execute(string inputString, int targetDistinctCharactersCount)
    {
        if (inputString.Length == 0) return -1;

        var currentDistinctCharactersCount = inputString.Distinct().Count();

        var candidate =
            currentDistinctCharactersCount == targetDistinctCharactersCount
                ? inputString.Length
                : -1;

        var bestFromSubstrings = Math.Max(
            Execute(inputString[1..], targetDistinctCharactersCount),
            Execute(inputString[..^1], targetDistinctCharactersCount)
        );

        return Math.Max(candidate, bestFromSubstrings);
    }
}