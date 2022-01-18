namespace Day014;

public class Strategy1 : IStrategy
{
    public double Execute()
    {
        var totalRandomPoints = 100_000_000;
        var pointsInsideCircle = RandomNormalizedPoints()
            .Take(totalRandomPoints)
            .Select(p => Math.Pow(p.x, 2) + Math.Pow(p.y, 2))
            .Count(s => s < 1);

        var pi = pointsInsideCircle / (double) totalRandomPoints * 4.0;

        return pi;
    }

    private IEnumerable<(double x, double y)> RandomNormalizedPoints()
    {
        var random = new Random();
        while (true) yield return (random.NextDouble(), random.NextDouble());
        // ReSharper disable once IteratorNeverReturns
    }
}