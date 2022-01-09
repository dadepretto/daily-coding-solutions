namespace Day006;

public unsafe class DoublyLinkedList<T> : ILinkedList<T> where T : unmanaged
{
    private DoublyLinkedListNode<T>* Head = null;
    private DoublyLinkedListNode<T>* Tail = null;

    public int Length
    {
        get
        {
            var length = 0;
            for (var curr = Head; curr is not null; curr = curr->Next)
                length++;
            return length;
        }
    }

    public T this[int index]
    {
        get => GetNodeAtIndex(index)->Value;
        set => GetNodeAtIndex(index)->Value = value;
    }

    public void Add(T item)
    {
        if (Head is null)
        {
            var node = DoublyLinkedListNode<T>.New(item);
            Head = node;
        }
        else if (Tail is null)
        {
            var node = DoublyLinkedListNode<T>.New(item, Head);
            Tail = Head->Next = node;
        }
        else
        {
            var Node = DoublyLinkedListNode<T>.New(item, Tail);
            Tail->Next = Tail = Node;
        }
    }

    public T[] ToArray()
    {
        var result = new T[Length];
        var i = 0;
        for (var curr = Head; curr is not null; curr = curr->Next, i++)
            result[i] = curr->Value;
        return result;
    }

    public T[] ToArrayReversed()
    {
        var result = new T[Length];
        var i = 0;
        for (var curr = Tail; curr is not null; curr = curr->Prev, i++)
            result[i] = curr->Value;
        return result;
    }

    private DoublyLinkedListNode<T>* GetNodeAtIndex(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

        var i = 0;
        for (var curr = Head; curr is not null; curr = curr->Next, i++)
            if (i == index)
                return curr;

        throw new ArgumentOutOfRangeException(nameof(index));
    }
}