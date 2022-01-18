namespace Day016;

public interface IStrategy<T> where T : struct
{
    void Record(T orderId);
    T GetLast(int i);
}