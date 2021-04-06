def buildHints(l):
    hints = {}
    for word in l:
        for i in range(len(word)):
            prefix = word[:i + 1]
            if hints.get(prefix) is None:
                hints[prefix] = [word]
            else:
                hints[prefix].append(word)
    return hints


def autocomplete(h, s):
    r = h.get(s)
    return r if r is not None else []


def test_autocomplete(l, s):
    '''
    >>> test_autocomplete(['dog', 'deer', 'deal'], 'de')
    ['deer', 'deal']
    >>> test_autocomplete(['dog', 'deer', 'deal'], 'ca')
    []
    '''
    h = buildHints(l)
    return autocomplete(h, s)


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
