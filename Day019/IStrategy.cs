namespace Day019;

public interface IStrategy
{
    decimal Execute(decimal[,] costsPerHousePerColor);
}