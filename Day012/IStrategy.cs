namespace Day012;

public interface IStrategy
{
    int Execute(int numberOfSteps, int[]? stepSizes = null);
}