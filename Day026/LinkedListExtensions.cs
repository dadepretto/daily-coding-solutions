namespace Day026;

public static class LinkedListExtensions
{
    public static int Count<T>(this LinkedList<T> linkedList)
    {
        var count = 0;
        for (var node = linkedList.Head; node is not null; node = node.Next)
            count++;
        return count;
    }

    public static List<T> ToList<T>(this LinkedList<T> linkedList)
    {
        var list = new List<T>();
        for (var node = linkedList.Head; node is not null; node = node.Next)
            list.Add(node.Value);
        return list;
    }

    public static T[] ToArray<T>(this LinkedList<T> linkedList)
    {
        var array = new T[linkedList.Count()];
        var i = 0;
        for (var node = linkedList.Head; node is not null; node = node.Next)
            array[i++] = node.Value;
        return array;
    }
}