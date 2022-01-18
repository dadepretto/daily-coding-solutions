namespace Day015;

public interface IStrategy
{
    T? Execute<T>(IEnumerable<T> stream);
}