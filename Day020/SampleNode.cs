namespace Day020;

public class SampleNode<T>
{
    internal bool Visited = false;

    public SampleNode(T value, SampleNode<T>? next = default)
    {
        Value = value;
        Next = next;
    }

    public T Value { get; set; }
    public SampleNode<T>? Next { get; set; }
}