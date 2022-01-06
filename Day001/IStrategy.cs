namespace Day001;

public interface IStrategy
{
    bool Execute(IEnumerable<int> inputList, int target);
}