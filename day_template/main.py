def greet(s):
    '''
    >>> greet(None)
    'Hello!'
    >>> greet('')
    'Hello!'
    >>> greet('     ')
    'Hello!'
    >>> greet('Python')
    'Hello, Python!'
    '''

    if s is not None and s.strip() == '':
        s = None

    return f"Hello{f', {s}' if s is not None else ''}!"


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
