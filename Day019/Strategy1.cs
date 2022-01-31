namespace Day019;

public class Strategy1 : IStrategy
{
    public decimal Execute(decimal[,] costsPerHousePerColor)
    {
        var dataSet = costsPerHousePerColor.AsEnumerable().ToArray();

        var result = dataSet
            .Skip(1)
            .Aggregate(
                dataSet.First().Select(cost => new List<decimal> {cost}),
                (previousCosts, nextCosts) => previousCosts
                    .SelectMany((previousCost, previousIndex) => nextCosts
                        .Where((_, nextIndex) => previousIndex != nextIndex)
                        .Select(nextCost =>
                            new List<decimal>(previousCost) {nextCost}
                        )
                    )
            )
            .Select(combination => combination.Sum())
            .Min();

        return result;
    }
}