namespace Day020;

public class Strategy2 : IStrategy
{
    // This implementation is not thread-safe, and requires changes on the
    // original class; but it's the best I could find.. :/
    public T Execute<T>(SampleNode<T> leftStart, SampleNode<T> rightStart)
    {
        for (var node = leftStart; node is not null; node = node.Next)
            node.Visited = true;

        for (var node = rightStart; node is not null; node = node.Next)
            if (node.Visited)
                return node.Value;

        throw new InvalidOperationException();
    }
}