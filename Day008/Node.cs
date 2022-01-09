namespace Day008;

public class Node<T> where T : notnull
{
    public Node(T value, Node<T>? left = null, Node<T> right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public T Value { get; set; }

    public Node<T>? Left { get; set; }

    public Node<T>? Right { get; set; }

    public bool IsUnival()
    {
        if (Left is null && Right is null) return true;

        var left = Left is null ? Value : Left.Value;
        var right = Right is null ? Value : Right.Value;
        return Value.Equals(left)
            && Value.Equals(right)
            && (Left?.IsUnival() ?? false)
            && (Right?.IsUnival() ?? false);
    }
}