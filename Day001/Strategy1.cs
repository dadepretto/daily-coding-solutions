namespace Day001;

/**
 * This solutions is O(n^2)
 */
public class Strategy1 : IStrategy
{
    public bool Execute(IEnumerable<int> inputList, int target)
    {
        var inputAsArray = inputList.ToArray();

        for (var i = 0; i < inputAsArray.Length; i++)
        for (var j = i + 1; j < inputAsArray.Length; j++)
            if (inputAsArray[i] + inputAsArray[j] == target)
                return true;

        return false;
    }
}