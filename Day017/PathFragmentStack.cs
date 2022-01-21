namespace Day017;

public class PathFragmentStack
{
    private readonly Stack<PathFragment> _stack = new();
    public int TotalLength { get; private set; }

    public int Depth => _stack.Count;

    public void Push(PathFragment pathFragment)
    {
        _stack.Push(pathFragment);
        TotalLength += pathFragment.Length;
    }

    public void Pop()
    {
        var removedElement = _stack.Pop();
        TotalLength -= removedElement.Length;
    }

    public void Pop(int numberOfItems)
    {
        for (var i = 0; i < numberOfItems; i++) Pop();
    }
}