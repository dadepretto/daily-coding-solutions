namespace Day006;

public unsafe class XorLinkedList<T> : ILinkedList<T> where T : unmanaged
{
    private XorLinkedListNode<T>* Head = null;
    private XorLinkedListNode<T>* Tail = null;

    public int Length
    {
        get
        {
            var length = 0;
            XorLinkedListNode<T>* prev = null;
            for (var node = Head; node is not null; Next(ref prev, ref node))
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
            var node = XorLinkedListNode<T>.New(item);
            Head = node;
        }
        else if (Tail == null)
        {
            var node = XorLinkedListNode<T>.New(item, Head);
            Head->XorPrevNext = XorLinkedListNode<T>.GetXorPrevNext(null, node);
            Tail = node;
        }
        else
        {
            var node = XorLinkedListNode<T>.New(item, Tail);
            var prev = Tail->GetPrev(null);
            Tail->XorPrevNext = XorLinkedListNode<T>.GetXorPrevNext(prev, node);
            Tail = node;
        }
    }

    public T[] ToArray()
    {
        var result = new T[Length];
        var i = 0;
        XorLinkedListNode<T>* prev = null;
        for (var node = Head; node is not null; Next(ref prev, ref node), i++)
            result[i] = node->Value;
        return result;
    }

    public T[] ToArrayReversed()
    {
        var result = new T[Length];
        var i = 0;
        XorLinkedListNode<T>* next = null;
        for (var node = Tail; node is not null; Prev(ref node, ref next), i++)
            result[i] = node->Value;
        return result;
    }

    private XorLinkedListNode<T>* GetNodeAtIndex(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

        var i = 0;
        XorLinkedListNode<T>* prev = null;
        for (var node = Head; node is not null; Next(ref prev, ref node), i++)
            if (i == index)
                return node;

        throw new ArgumentOutOfRangeException(nameof(index));
    }

    private void Next(ref XorLinkedListNode<T>* prev,
        ref XorLinkedListNode<T>* node)
    {
        var temp = node;
        node = node->GetNext(prev);
        prev = temp;
    }

    private void Prev(ref XorLinkedListNode<T>* node,
        ref XorLinkedListNode<T>* next)
    {
        var temp = node;
        node = node->GetPrev(next);
        next = temp;
    }
}