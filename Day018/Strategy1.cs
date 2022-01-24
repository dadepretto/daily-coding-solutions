namespace Day018;

/**
 * This is not in O(n) time and O(k) space, but it's just a first approximation
 * to validate unit tests and understand the general problem
 */
public class Strategy1 : IStrategy
{
    public void Execute(
        IReadOnlyList<int> inputList,
        int subsetLength,
        IList<int> output)
    {
        var inputArray = inputList as int[] ?? inputList.ToArray();

        for (var i = 0; i <= inputArray.Length - subsetLength; i++)
            output.Add(inputArray[i..(i + subsetLength)].Max());
    }
}