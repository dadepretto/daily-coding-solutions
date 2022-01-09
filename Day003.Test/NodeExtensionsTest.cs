using Xunit;

namespace Day003.Test;

public class NodeExtensionsTest
{
    [Fact]
    public void Serialize_NodeWithoutLeftAndRight_ReturnsOnlyValueAsString()
    {
        Node node = new("theValue");

        var actual = node.Serialize();

        Assert.Equal("theValue()()", actual);
    }

    [Fact]
    public void Serialize_NodeWithNullLeftAndRight_ReturnsOnlyValueAsString()
    {
        Node node = new("theValue");

        var actual = node.Serialize();

        Assert.Equal("theValue()()", actual);
    }

    [Fact]
    public void Serialize_NodeWithValueLeftAndNullRight_ReturnsValueAndLeft()
    {
        var node = new Node("theValue", new Node("left"));

        var actual = node.Serialize();

        Assert.Equal("theValue(left()())()", actual);
    }

    [Fact]
    public void Serialize_NodeWithNullLeftAndValueRight_ReturnsValueAndRight()
    {
        var node = new Node("theValue", null, new Node("right"));

        var actual = node.Serialize();

        Assert.Equal("theValue()(right()())", actual);
    }

    [Fact]
    public void Serialize_NodeWithLeftAndRight_ReturnsValueLeftRight()
    {
        var node = new Node("theValue", new Node("left"), new Node("right"));

        var actual = node.Serialize();

        Assert.Equal("theValue(left()())(right()())", actual);
    }

    [Fact]
    public void Deserialize_WellFormedStringNodeWithSingleValue_ReturnsNode()
    {
        const string input = "theValue()()";

        var actual = input.Deserialize();

        Assert.Equal(new Node("theValue"), actual);
    }

    [Fact]
    public void Deserialize_WellFormedStringNodeWithValueAndLeft_ReturnsNode()
    {
        const string input = "theValue(left()())()";

        var actual = input.Deserialize();

        Assert.Equal(new Node("theValue", new Node("left")), actual);
    }

    [Fact]
    public void Deserialize_WellFormedStringNodeWithValueAndRight_ReturnsNode()
    {
        const string input = "theValue()(right()())";

        var actual = input.Deserialize();

        Assert.Equal(new Node("theValue", null, new Node("right")), actual);
    }

    [Fact]
    public void Deserialize_WellFormedStringNodeWithAll_ReturnsNode()
    {
        const string input = "theValue(left()())(right()())";

        var actual = input.Deserialize();

        Assert.Equal(new Node("theValue", new Node("left"), new Node("right")),
            actual);
    }

    [Theory]
    [InlineData("()")]
    [InlineData("theValue")]
    [InlineData("theValue())")]
    [InlineData("theValue((()")]
    [InlineData("theValue(())")]
    [InlineData("theValue())))")]
    [InlineData("theValue(((()")]
    [InlineData("theValue(()())")]
    [InlineData("theValue((()())(()()))")]
    public void Deserialize_UnbalancedString_ThrowsMalformedStringException(
        string input)
    {
        void Actual()
        {
            input.Deserialize();
        }

        Assert.Throws<MalformedStringException>(Actual);
    }
}