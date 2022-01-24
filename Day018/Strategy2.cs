namespace Day018;

/**
 * This is shoudl be in O(n) time and O(k) space, but I'm not sure TBH because
 * of those nested while loops.. 🧐
 */
public class Strategy2 : IStrategy
{
    public void Execute(
        IReadOnlyList<int> inputList,
        int subsetLength,
        IList<int> output)
    {
        var indexes = new LinkedList<int>();

        for (var i = 0; i < subsetLength; ++i)
        {
            while (indexes.Count > 0 &&
                   inputList[i] >= inputList[indexes.Last!.Value])
                indexes.RemoveLast();

            indexes.AddLast(i);
        }

        output.Add(inputList[indexes.First!.Value]);

        for (var i = subsetLength; i < inputList.Count; ++i)
        {
            while (indexes.Count > 0 &&
                   indexes.First.Value <= i - subsetLength)
                indexes.RemoveFirst();

            while (indexes.Count > 0 &&
                   inputList[i] >= inputList[indexes.Last!.Value])
                indexes.RemoveLast();

            indexes.AddLast(i);

            output.Add(inputList[indexes.First.Value]);
        }
    }
}