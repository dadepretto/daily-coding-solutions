namespace Day016;

public class Strategy1<T> : IStrategy<T> where T : struct
{
    private readonly List<T> _storage;

    public Strategy1(List<T> storage)
    {
        _storage = storage;
    }

    public int Count => _storage.Count;

    public void Record(T orderId)
    {
        _storage.Add(orderId);
    }

    public T GetLast(int i)
    {
        return _storage.ElementAt(_storage.Count - 1 - i);
    }
}