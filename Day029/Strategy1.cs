using System.Text;

namespace Day029;

public class Strategy1 : IStrategy
{
    public string Encode(string input)
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < input.Length;)
        {
            var currentCharacter = input[i];
            var firstFoundAt = i;
            while (i < input.Length && input[i] == currentCharacter) i++;
            stringBuilder.Append(i - firstFoundAt);
            stringBuilder.Append(currentCharacter);
        }

        return stringBuilder.ToString();
    }

    public string Decode(string input)
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < input.Length; i += 2)
        {
            var iterations = int.Parse(input[i].ToString());
            var character = input[i + 1];
            var value = string.Concat(Enumerable.Repeat(character, iterations));
            stringBuilder.Append(value);
        }

        return stringBuilder.ToString();
    }
}