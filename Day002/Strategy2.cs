namespace Day002;

/**
 * Using only multiplication
 */
public class Strategy2 : IStrategy
{
    public IEnumerable<int> Execute(IEnumerable<int> inputList)
    {
        var inputArray = inputList as int[] ?? inputList.ToArray();
        var result = new int[inputArray.Length];

        for (var i = 0; i < inputArray.Length; i++)
            result[i] = inputArray
                .Where((_, j) => i != j)
                .Aggregate(1, (total, n) => total * n);

        return result;
    }
}