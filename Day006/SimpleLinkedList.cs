namespace Day006;

public unsafe class SimpleLinkedList<T> : ILinkedList<T> where T : unmanaged
{
    private SimpleLinkedListNode<T>* Head = null;

    public void Add(T value)
    {
        var current = Head;
        var node = SimpleLinkedListNode<T>.New(value);

        if (Head is null)
        {
            Head = node;
        }
        else
        {
            while (current->Next is not null)
                current = current->Next;

            current->Next = node;
        }
    }

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

    public T[] ToArray()
    {
        var result = new T[Length];
        var i = 0;
        for (var curr = Head; curr is not null; curr = curr->Next, i++)
            result[i] = curr->Value;
        return result;
    }

    private SimpleLinkedListNode<T>* GetNodeAtIndex(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

        var i = 0;
        for (var curr = Head; curr is not null; curr = curr->Next, i++)
            if (i == index)
                return curr;

        throw new ArgumentOutOfRangeException(nameof(index));
    }
}