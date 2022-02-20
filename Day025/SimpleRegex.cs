namespace Day025;

public class SimpleRegex
{
    private readonly StringCursor _input;
    private readonly StringCursor _regex;

    public SimpleRegex(string input, string regex)
    {
        _input = new StringCursor(input);
        _regex = new StringCursor(regex);
    }

    public bool Match()
    {
        if (string.IsNullOrEmpty(_input.Value) &&
            string.IsNullOrEmpty(_regex.Value)) return true;

        bool? isMatch = null;

        while (isMatch is null)
            isMatch = _regex.CurrentValue switch
            {
                '*' => SkipRepeated('*').AcceptAny(),
                '.' => AcceptOne(),
                _ => CheckMatch()
            };

        return isMatch.Value;
    }

    private SimpleRegex SkipRepeated(char input)
    {
        while (_regex.PeekNext() == input) _regex.MoveNext();
        return this;
    }

    private bool? AcceptAny()
    {
        var nextRegexSection = _regex.PeekUntilEndOr(c => c is '*' or '.');

        if (string.IsNullOrEmpty(nextRegexSection)) return true;

        var offset = _input.GetOffsetUntil(nextRegexSection);

        if (offset is null) return false;

        _regex.MoveNext();
        _input.FastForward(offset.Value + 1);
        return null;
    }

    private bool? AcceptOne()
    {
        if (_input.IsEnd() || _regex.IsEnd())
            return _input.IsEnd() && _regex.IsEnd();

        _regex.MoveNext();
        _input.MoveNext();
        return null;
    }

    private bool? CheckMatch()
    {
        return _input.CurrentValue != _regex.CurrentValue ? false : AcceptOne();
    }
}