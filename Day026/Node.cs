namespace Day026;

public class Node<T>
{
    public Node(T value, Node<T>? next = null)
    {
        Value = value;
        Next = next;
    }

    public T Value { get; set; }
    public Node<T>? Next { get; set; }
}