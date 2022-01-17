namespace Day012;

public class Strategy1 : IStrategy
{
    public int Execute(int numberOfSteps, int[]? stepSizes = null)
    {
        if (numberOfSteps <= 0)
            throw new ArgumentOutOfRangeException(nameof(numberOfSteps));

        stepSizes ??= new[] {1, 2};

        return GetWays(numberOfSteps + 1, stepSizes);
    }

    private int GetWays(int numberOfSteps, int[] stepSizes)
    {
        return numberOfSteps switch
        {
            < 0 => 0,
            <= 1 => numberOfSteps,
            _ => stepSizes
                .Select(size => GetWays(numberOfSteps - size, stepSizes))
                .Sum()
        };
    }
}