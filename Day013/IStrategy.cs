namespace Day013;

public interface IStrategy
{
    int Execute(string inputString, int targetDistinctCharactersCount);
}