namespace Day003;

public class Node
{
    public Node(string value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public string Value { get; }
    public Node? Left { get; }
    public Node? Right { get; }

    public override bool Equals(object? obj)
    {
        return obj is Node && GetHashCode() == obj.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Left, Right);
    }
}