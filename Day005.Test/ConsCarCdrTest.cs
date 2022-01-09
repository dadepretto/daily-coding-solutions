using Xunit;

namespace Day005.Test;

public class ConsCarCdrTest
{
    [Fact]
    public void Car_ValidCons_ReturnsParameterA()
    {
        var cons = ConsCarCdr.Cons(3, 4);

        var actual = ConsCarCdr.Car(cons);

        Assert.Equal(3, actual);
    }

    [Fact]
    public void Cdr_ValidCons_ReturnsParameterB()
    {
        var cons = ConsCarCdr.Cons(3, 4);

        var actual = ConsCarCdr.Cdr(cons);

        Assert.Equal(4, actual);
    }
}