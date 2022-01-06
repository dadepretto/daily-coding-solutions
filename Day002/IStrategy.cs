namespace Day002;

public interface IStrategy
{
    IEnumerable<int> Execute(IEnumerable<int> inputList);
}