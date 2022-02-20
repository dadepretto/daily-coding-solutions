namespace Day028;

public class Row
{
    private readonly List<IRowComponent> _components = new();

    private readonly int _targetLength;

    public Row(int targetLength)
    {
        _targetLength = targetLength;
    }

    public Row(int targetLength, Word initialWord)
    {
        _targetLength = targetLength;
        if (!TryAdd(initialWord))
            throw new ArgumentOutOfRangeException(nameof(initialWord));
    }

    private int Length => _components.Select(c => c.Length).Sum();

    public bool TryAdd(IRowComponent word)
    {
        if (word.Length + Length > _targetLength) return false;

        if (_components.Any()) _components.Add(new Space());

        _components.Add(word);

        return true;
    }

    public override string ToString()
    {
        AdjustSpaces();
        return string.Concat(_components);
    }

    private void AdjustSpaces()
    {
        var spaces = _components.OfType<Space>().ToArray();

        if (!spaces.Any())
            _components.Add(new Space(_targetLength - Length));

        using var spaceEnumerator = spaces.AsCyclical().GetEnumerator();
        while (Length < _targetLength)
            if (spaceEnumerator.MoveNext())
                spaceEnumerator.Current.Length++;
    }
}