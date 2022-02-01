namespace Day020;

public interface IStrategy
{
    T Execute<T>(SampleNode<T> leftStart, SampleNode<T> rightStart);
}