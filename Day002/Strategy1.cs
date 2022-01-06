namespace Day002;

/*
 * Using multiplication and division
 */
public class Strategy1 : IStrategy
{
    public IEnumerable<int> Execute(IEnumerable<int> inputList)
    {
        var inputArray = inputList as int[] ?? inputList.ToArray();
        var totalProduct = inputArray.Aggregate(1, (total, n) => total * n);
        var result = inputArray.Select(n => totalProduct / n);
        return result;
    }
}