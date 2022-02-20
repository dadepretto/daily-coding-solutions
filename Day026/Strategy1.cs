namespace Day026;

public class Strategy1 : IStrategy
{
    public void Execute<T>(LinkedList<T> linkedList, int indexFromEnd)
    {
        if (indexFromEnd <= 0)
            throw new ArgumentOutOfRangeException(nameof(indexFromEnd));

        var previous = linkedList.Head;
        var node = linkedList.Head?.Next;

        for (var o = linkedList[indexFromEnd + 1]; o != null; o = o.Next)
        {
            previous = previous?.Next ?? throw new IndexOutOfRangeException();
            node = node?.Next ?? throw new IndexOutOfRangeException();
        }

        previous!.Next = node!.Next;
    }
}