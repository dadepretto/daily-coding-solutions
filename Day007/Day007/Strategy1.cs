namespace Day007;

public class Strategy1 : IStrategy
{
    public int Execute(string encodedInput)
    {
        return GetWays(encodedInput) + 1;
    }

    private int GetWays(string encodedInput)
    {
        if (encodedInput.Length == 0) return 0;

        var numberOfWays = GetWays(encodedInput[1..]);

        var isParsableWithTwoDigits =
            encodedInput.Length >= 2 &&
            int.TryParse(encodedInput[..2], out var parsed) &&
            parsed is >= 10 and <= 26;

        if (isParsableWithTwoDigits)
            numberOfWays += 1 + GetWays(encodedInput[2..]);

        return numberOfWays;
    }
}