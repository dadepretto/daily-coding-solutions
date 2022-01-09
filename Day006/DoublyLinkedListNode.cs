using System.Runtime.InteropServices;

namespace Day006;

public unsafe struct DoublyLinkedListNode<T> where T : unmanaged
{
    public T Value;

    public DoublyLinkedListNode<T>* Next;

    public DoublyLinkedListNode<T>* Prev;

    public static DoublyLinkedListNode<T>* New(T value,
        DoublyLinkedListNode<T>* previous = null,
        DoublyLinkedListNode<T>* next = null)
    {
        var node = (DoublyLinkedListNode<T>*) Marshal.AllocHGlobal(
            sizeof(DoublyLinkedListNode<T>));
        node->Value = value;
        node->Prev = previous;
        node->Next = next;
        return node;
    }
}