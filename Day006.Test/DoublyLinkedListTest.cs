using System.Linq;
using Xunit;

namespace Day006.Test;

public class DoublyLinkedListTest : LinkedListTestBase
{
    public DoublyLinkedListTest() : base(typeof(DoublyLinkedList<>))
    {
    }

    [Theory]
    [InlineData(new[] {1, 2, 3})]
    [InlineData(new int[0])]
    public void ToArrayReversed_IntegerValues_GetAsArray(int[] values)
    {
        var linkedList = GetNewInstance() as DoublyLinkedList<int>;
        foreach (var value in values) linkedList?.Add(value);

        var actual = linkedList?.ToArrayReversed();

        Assert.Equal(values.Reverse().ToArray(), actual);
    }
}