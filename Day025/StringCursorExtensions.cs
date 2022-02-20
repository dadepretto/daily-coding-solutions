namespace Day025;

public static class StringCursorExtensions
{
    public static char? PeekNext(this StringCursor stringCursor)
    {
        return stringCursor.Remaining?.FirstOrDefault();
    }

    public static string? PeekUntilEndOr(this StringCursor stringCursor,
        Func<char?, bool> predicate)
    {
        var chars = stringCursor.Remaining?.TakeWhile(c => !predicate(c));
        return chars is null ? null : string.Concat(chars);
    }

    public static int? GetOffsetUntil(this StringCursor stringCursor,
        string input)
    {
        var foundAt =
            stringCursor.Remaining?.IndexOf(input, StringComparison.Ordinal);
        return foundAt is null or -1 ? null : foundAt;
    }

    public static bool IsEnd(this StringCursor stringCursor)
    {
        return !stringCursor.HasValues;
    }
}