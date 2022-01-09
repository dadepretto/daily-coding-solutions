using System.Runtime.InteropServices;

namespace Day006;

public unsafe struct XorLinkedListNode<T> where T : unmanaged
{
    public T Value;

    public ulong XorPrevNext;

    public static XorLinkedListNode<T>* New(T value,
        XorLinkedListNode<T>* prev = null,
        XorLinkedListNode<T>* next = null)
    {
        var node = (XorLinkedListNode<T>*) Marshal.AllocHGlobal(
            sizeof(XorLinkedListNode<T>));
        node->Value = value;
        node->XorPrevNext = GetXorPrevNext(prev, next);
        return node;
    }

    public static ulong GetXorPrevNext(XorLinkedListNode<T>* prev,
        XorLinkedListNode<T>* next)
    {
        return (ulong) prev ^ (ulong) next;
    }

    public XorLinkedListNode<T>* GetPrev(XorLinkedListNode<T>* next)
    {
        return (XorLinkedListNode<T>*) (XorPrevNext ^ (ulong) next);
    }

    public XorLinkedListNode<T>* GetNext(XorLinkedListNode<T>* Prev)
    {
        return (XorLinkedListNode<T>*) (XorPrevNext ^ (ulong) Prev);
    }
}