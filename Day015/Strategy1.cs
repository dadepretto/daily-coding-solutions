namespace Day015;

public class Strategy1 : IStrategy
{
    public T Execute<T>(IEnumerable<T> stream)
    {
        var random = new Random();
        T? randomElement = default;

        foreach (var (value, i) in stream.Select((value, i) => (value, i)))
            if (i == 0)
                randomElement = value;
            else if (random.NextInt64(0, i + 1) == 1)
                randomElement = value;

        return randomElement!;
    }
}