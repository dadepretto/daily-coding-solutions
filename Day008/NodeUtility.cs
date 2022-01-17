namespace Day008;

public static class NodeUtility
{
    public static int CountUnivalTrees<T>(Node<T> node) where T : notnull
    {
        return (node.IsUnival() ? 1 : 0)
            + (node.Left is not null ? CountUnivalTrees(node.Left) : 0)
            + (node.Right is not null ? CountUnivalTrees(node.Right) : 0);
    }
}