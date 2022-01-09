namespace Day009;

public interface IStrategy
{
    int? Execute(IEnumerable<int> inputList);
}