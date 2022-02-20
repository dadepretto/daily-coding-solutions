namespace Day026;

public class LinkedList<T>
{
    public LinkedList(Node<T>? head)
    {
        Head = head;
    }

    public LinkedList(IEnumerable<T> enumerable)
    {
        Head = enumerable.Reverse().Aggregate((Node<T>?) null,
            (current, item) => new Node<T>(item, current))!;
    }

    public Node<T>? Head { get; }

    public Node<T>? this[int index] => index switch
    {
        0 => Head,
        > 0 => Enumerable.Range(0, index).Aggregate(Head,
            (node, _) => node?.Next ?? throw new IndexOutOfRangeException()),
        _ => throw new IndexOutOfRangeException()
    };
}