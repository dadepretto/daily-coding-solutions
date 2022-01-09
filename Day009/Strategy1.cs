namespace Day009;

public class Strategy1 : IStrategy
{
    public int? Execute(IEnumerable<int> inputList)
    {
        var inputArray = inputList as int[] ?? inputList.ToArray();

        if (inputArray.Length == 0) return null;

        var i = inputArray[0];
        var j = 0;

        foreach (var number in inputArray[1..])
            (i, j) = (j + number, Math.Max(i, j));

        return Math.Max(i, j);
    }
}