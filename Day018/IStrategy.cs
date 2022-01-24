namespace Day018;

public interface IStrategy
{
    void Execute(
        IReadOnlyList<int> inputList,
        int subsetLength,
        IList<int> output);
}