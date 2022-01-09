namespace Day004;

public interface IStrategy
{
    int Execute(IEnumerable<int> inputList);
}