namespace Day027;

public class Strategy1 : IStrategy
{
    public bool Execute(string stringOfBrackets)
    {
        var expectedClosingStack = new Stack<Bracket>();

        foreach (var bracket in stringOfBrackets.Select(c => new Bracket(c)))
            if (bracket.IsOpening)
                expectedClosingStack.Push(bracket.MatchingClosing);
            else if (!expectedClosingStack.TryPop(out var expectedClosing))
                return false;
            else if (expectedClosing != bracket)
                return false;

        return expectedClosingStack.Count == 0;
    }


}