namespace Day024;

public interface INode<T>
{
    bool IsLocked { get; }
    T Value { get; }
    Node<T>? Left { get; }
    Node<T>? Right { get; }
    bool Lock();
    bool Unlock();
}