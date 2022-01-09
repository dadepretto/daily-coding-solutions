namespace Day004;

public class Strategy1 : IStrategy
{
    public int Execute(IEnumerable<int> inputList)
    {
        var l = inputList as int[] ?? inputList.ToArray();

        // Separate positive and negative numbers
        var i = 0;
        var e = l.Length - 1;
        while (i < e)
            if (l[i] >= 0)
                i++;
            else if (l[e] < 0)
                e--;
            else if (l[i] < 0)
                (l[e], l[i]) = (l[i], l[e]);

        // Turn negative all the numbers at index before their value
        // The idea is to use the indexes as the reference for positive integer
        // numbers and the negative sign as the "got" check
        for (var j = 0; j < e; j++)
        {
            var a = Math.Abs(l[j]);
            if (a == 0) continue;
            if (a <= e) l[a - 1] = l[a - 1] > 0 ? -l[a - 1] : l[a - 1];
        }

        // The result is the index + 1 of the first non-negative number
        var s = l.Length;
        for (var j = 0; j < l.Length; j++)
        {
            if (l[j] <= 0) continue;
            s = j + 1;
            break;
        }

        return s;
    }
}