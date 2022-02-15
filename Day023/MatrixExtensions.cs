namespace Day023;

public static class MatrixExtensions
{
    public static TOut[,] Select<TIn, TOut>(
        this TIn[,] matrix,
        Func<TIn, TOut> mapper)
    {
        var height = matrix.GetLength(0);
        var width = matrix.GetLength(1);
        var result = new TOut[height, width];
        foreach (var i in Enumerable.Range(0, height))
        foreach (var j in Enumerable.Range(0, width))
            result[i, j] = mapper(matrix[i, j]);
        return result;
    }
}