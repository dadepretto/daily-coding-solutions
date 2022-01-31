using System.Collections;

namespace Day019;

internal class DataSetAdapter : IEnumerable<IEnumerable<decimal>>
{
    private readonly decimal[,] _matrix;

    public DataSetAdapter(decimal[,] matrix)
    {
        _matrix = matrix;
    }

    private int NumberOfHouses => _matrix.GetLength(0);

    private int NumberOfColors => _matrix.GetLength(1);

    private IEnumerable<decimal> this[int houseIndex] =>
        Enumerable.Range(0, NumberOfColors)
            .Select(j => _matrix[houseIndex, j]);

    public IEnumerator<IEnumerable<decimal>> GetEnumerator()
    {
        for (var i = 0; i < NumberOfHouses; i++)
            yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}