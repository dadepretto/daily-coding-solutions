using Xunit;

namespace Day014.Test;

public class Strategy1Test
{
    [Fact]
    public void Execute_NoParameters_ReturnsPiApproximatedToThirdDecimal()
    {
        var strategy = new Strategy1();

        var actual = strategy.Execute();

        Assert.InRange(actual, 3.1410, 3.1419);
    }
}