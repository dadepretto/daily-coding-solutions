namespace Day002;

/**
 * Just for fun :)
 */
public class Strategy3 : IStrategy
{
    public IEnumerable<int> Execute(IEnumerable<int> inputList)
    {
        var inputArray = inputList as int[] ?? inputList.ToArray();
        var result = inputArray.Select((_, i) =>
            inputArray
                .Where((_, j) => i != j)
                .Aggregate(1, (total, n) => total * n));
        return result;
    }
}