namespace Day026;

public interface IStrategy
{
    void Execute<T>(LinkedList<T> linkedList, int indexFromEnd);
}