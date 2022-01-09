namespace Day003;

public static class NodeExtensions
{
    public static string Serialize(this Node? node)
    {
        return node is null
            ? ""
            : $"{node.Value}({Serialize(node.Left)})({Serialize(node.Right)})";
    }

    public static Node Deserialize(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;

        var leftStart = GetLeftStartIndex(input);
        var rightStart = GetRightStartIndex(input, leftStart);

        var leftSubstring = GetLeftNodeSubstring(input, leftStart, rightStart);
        var rightSubstring = GetRightNodeSubstring(input, rightStart);

        var value = GetValue(input, leftStart);
        var leftNode = leftSubstring.Deserialize();
        var rightNode = rightSubstring.Deserialize();

        return new Node(value, leftNode, rightNode);
    }

    private static int GetLeftStartIndex(string input)
    {
        var index = input.IndexOf('(');
        if (index < 0) throw new MalformedStringException(nameof(input));
        return index;
    }

    private static int GetRightStartIndex(string input, int start)
    {
        input = input[start..];

        var level = 0;
        for (var i = 0; i < input.Length; i++)
        {
            level += input[i] switch {'(' => +1, ')' => -1, _ => 0};
            if (level == 0) return i + start + 1;
        }

        throw new MalformedStringException(nameof(input));
    }

    private static string GetValue(string input, int start)
    {
        return input[..start];
    }

    private static string GetLeftNodeSubstring(string input, int start, int end)
    {
        return input[(start + 1) .. (end - 1)];
    }

    private static string GetRightNodeSubstring(string input, int end)
    {
        if (end >= input.Length - 1)
            throw new MalformedStringException(nameof(input));

        return input[(end + 1)..^1];
    }
}