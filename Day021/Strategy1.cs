namespace Day021;

public class Strategy1 : IStrategy
{
    public int Execute(IEnumerable<Lecture> lectures)
    {
        var lecturesArray = lectures as Lecture[] ?? lectures.ToArray();

        if (lecturesArray.Length == 0)
            throw new InvalidOperationException("Not enough data");

        var overlappingRanges =
            from l1 in lecturesArray
            from l2 in lecturesArray
            where l1 != l2 && l1.Start < l2.End && l1.End > l2.Start
            group l1 by new
            {
                Start = DateTimeUtility.Max(l1.Start, l2.Start),
                End = DateTimeUtility.Min(l1.End, l2.End)
            };

        var mostConcurrentRange = overlappingRanges.MaxBy(x => x.Count());

        return mostConcurrentRange?.Count() ?? 1;
    }
}