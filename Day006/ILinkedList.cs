namespace Day006;

public interface ILinkedList<T>
{
    int Length { get; }

    T this[int index] { get; set; }

    void Add(T item);

    T[] ToArray();
}