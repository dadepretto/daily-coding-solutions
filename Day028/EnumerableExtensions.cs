namespace Day028;

public static class EnumerableExtensions
{
    public static Queue<T> ToQueue<T>(this IEnumerable<T> enumerable)
    {
        var queue = new Queue<T>();
        foreach (var item in enumerable) queue.Enqueue(item);
        return queue;
    }

    public static IEnumerable<T> AsCyclical<T>(this IEnumerable<T> enumerable)
    {
        var array = enumerable as T[] ?? enumerable.ToArray();
        if (!array.Any()) yield break;
        for (var i = 0;; i++) yield return array[i % array.Length];
        // ReSharper disable once IteratorNeverReturns
    }
}