namespace Day024;

public class Node<T> : INode<T>
{
    private int _numberOfLockedChildren;

    public Node(
        T value,
        Node<T>? parent = null,
        Node<T>? left = null,
        Node<T>? right = null)
    {
        Value = value;
        Parent = parent;
        Left = left;
        Right = right;
    }

    public Node<T>? Parent { get; }

    public T Value { get; }

    public Node<T>? Left { get; set; }

    public Node<T>? Right { get; set; }

    public bool IsLocked { get; private set; }

    public bool Lock()
    {
        if (!CanToggleState()) return false;

        for (var node = Parent; node is not null; node = node.Parent)
            node._numberOfLockedChildren++;

        IsLocked = true;
        return true;
    }

    public bool Unlock()
    {
        if (!CanToggleState()) return false;

        for (var node = Parent; node is not null; node = node.Parent)
            node._numberOfLockedChildren--;

        IsLocked = false;
        return true;
    }

    private bool CanToggleState()
    {
        if (_numberOfLockedChildren > 0) return false;

        for (var node = Parent; node is not null; node = node.Parent)
            if (node.IsLocked)
                return false;

        return true;
    }
}