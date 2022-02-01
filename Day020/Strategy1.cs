namespace Day020;

public class Strategy1 : IStrategy
{
    public T Execute<T>(SampleNode<T> leftStart, SampleNode<T> rightStart)
    {
        for (var left = leftStart; left is not null; left = left.Next)
        for (var right = rightStart; right is not null; right = right.Next)
            if (left == right)
                return left.Value;

        throw new InvalidOperationException();
    }
}