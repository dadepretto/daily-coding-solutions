using System.Runtime.InteropServices;

namespace Day006;

public unsafe struct SimpleLinkedListNode<T> where T : unmanaged
{
    public T Value;

    public SimpleLinkedListNode<T>* Next;

    public static SimpleLinkedListNode<T>* New(T value,
        SimpleLinkedListNode<T>* next = null)
    {
        var node = (SimpleLinkedListNode<T>*) Marshal.AllocHGlobal(
            sizeof(SimpleLinkedListNode<T>));
        node->Value = value;
        node->Next = next;
        return node;
    }
}