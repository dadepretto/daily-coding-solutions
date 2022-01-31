using Xunit;

namespace Day019.Test;

public class Strategy1Test
{
    private readonly TestCase[] _testCases =
    {
        new(new decimal[,] {{2, 3, 1}, {2, 3, 1}}, 3), /*0*/
        new(new decimal[,] {{3, 1, 2}, {3, 1, 2}}, 3), /*1*/
        new(new decimal[,] {{3, 2, 1}, {3, 2, 1}}, 3), /*2*/
        new(new decimal[,] {{2, 1, 3}, {2, 1, 3}}, 3), /*3*/
        new(new decimal[,] {{1, 3, 2}, {1, 3, 2}}, 3), /*4*/
        new(new decimal[,] {{1, 2, 3}, {1, 3, 2}}, 3), /*5*/
        new(new decimal[,] {{2, 3, 1}, {1, 2, 3}}, 2), /*6*/
        new(new decimal[,] {{3, 1, 2}, {2, 3, 1}}, 2), /*7*/
        new(new decimal[,] {{3, 2, 1}, {3, 1, 2}}, 2), /*8*/
        new(new decimal[,] {{2, 1, 3}, {3, 2, 1}}, 2), /*9*/
        new(new decimal[,] {{1, 3, 2}, {2, 1, 3}}, 2), /*10*/
        new(new decimal[,] {{1, 2, 3}, {2, 1, 3}}, 2), /*11*/
        new(new decimal[,] {{2, 3, 1}, {1, 3, 2}}, 2), /*12*/
        new(new decimal[,] {{3, 1, 2}, {1, 2, 3}}, 2), /*13*/
        new(new decimal[,] {{3, 2, 1}, {2, 3, 1}}, 3), /*14*/
        new(new decimal[,] {{2, 1, 3}, {3, 1, 2}}, 3), /*15*/
        new(new decimal[,] {{1, 3, 2}, {3, 2, 1}}, 2), /*16*/
        new(new decimal[,] {{1, 2, 3}, {3, 2, 1}}, 2), /*17*/
        new(new decimal[,] {{2, 3, 1}, {2, 1, 3}}, 2), /*18*/
        new(new decimal[,] {{3, 1, 2}, {1, 3, 2}}, 2), /*19*/
        new(new decimal[,] {{3, 2, 1}, {1, 2, 3}}, 2), /*20*/
        new(new decimal[,] {{2, 1, 3}, {2, 3, 1}}, 2), /*21*/
        new(new decimal[,] {{1, 3, 2}, {3, 1, 2}}, 2), /*22*/
        new(new decimal[,] {{1, 2, 3}, {3, 1, 2}}, 2), /*23*/
        new(new decimal[,] {{2, 3, 1}, {3, 2, 1}}, 3), /*24*/
        new(new decimal[,] {{3, 1, 2}, {2, 1, 3}}, 3), /*25*/
        new(new decimal[,] {{3, 2, 1}, {1, 3, 2}}, 2), /*26*/
        new(new decimal[,] {{2, 1, 3}, {1, 2, 3}}, 2), /*27*/
        new(new decimal[,] {{1, 3, 2}, {2, 3, 1}}, 2), /*28*/
        new(new decimal[,] {{1, 2, 3}, {2, 3, 1}}, 2), /*29*/
        new(new decimal[,] {{2, 3, 1}, {3, 1, 2}}, 2), /*30*/
        new(new decimal[,] {{3, 1, 2}, {3, 2, 1}}, 2), /*31*/
        new(new decimal[,] {{3, 2, 1}, {2, 1, 3}}, 2), /*32*/
        new(new decimal[,] {{2, 1, 3}, {1, 3, 2}}, 2), /*33*/
        new(new decimal[,] {{1, 3, 2}, {1, 2, 3}}, 3) /*34*/
    };

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(19)]
    [InlineData(20)]
    [InlineData(21)]
    [InlineData(22)]
    [InlineData(23)]
    [InlineData(24)]
    [InlineData(25)]
    [InlineData(26)]
    [InlineData(27)]
    [InlineData(28)]
    [InlineData(29)]
    [InlineData(30)]
    [InlineData(31)]
    [InlineData(32)]
    [InlineData(33)]
    [InlineData(34)]
    public void Execute_GivenTwoArrayOfCosts_ReturnsMinimumCost(int caseIndex)
    {
        var strategy = new Strategy1();
        var (costsPerHousePerColor, expected) = _testCases[caseIndex];

        var actual = strategy.Execute(costsPerHousePerColor);

        Assert.Equal(expected, actual);
    }

    private record TestCase(decimal[,] CostsPerHousePerColor, decimal Expected);
}