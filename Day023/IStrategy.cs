namespace Day023;

public interface IStrategy
{
    int? Execute(bool[,] board, (int x, int y) start, (int x, int y) target);
}