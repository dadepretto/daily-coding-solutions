namespace Day001;

/**
 * This solutions requires only a sort (log(n) ?) and a single scan
 */
public class Strategy2 : IStrategy
{
    public bool Execute(IEnumerable<int> inputList, int target)
    {
        var orderedList = inputList.OrderBy(n => n).ToArray();

        var i = 0;
        var j = orderedList.Length - 1;

        while (i < j)
            if (orderedList[i] + orderedList[j] < target) i++;
            else if (orderedList[i] + orderedList[j] > target) j--;
            else return true;

        return false;
    }
}