namespace Day003;

public class Node
{
    public Node(string value, Node? left = null, Node right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }


    public string Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Node node
            && node.Value.Equals(Value, StringComparison.Ordinal)
            && (node.Left is null && Left is null ||
                (node.Left?.Equals(Left) ?? false))
            && (node.Right is null && Right is null ||
                (node.Right?.Equals(Right) ?? false));
    }
}