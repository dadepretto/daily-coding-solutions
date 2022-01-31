namespace Day019;

public static class MatrixExtensions
{
    public static IEnumerable<IEnumerable<T>> AsEnumerable<T>(this T[,] matrix)
    {
        return Enumerable.Range(0, matrix.GetLength(0)).Select(i =>
            Enumerable.Range(0, matrix.GetLength(1)).Select(j =>
                matrix[i, j]
            )
        );
    }
}