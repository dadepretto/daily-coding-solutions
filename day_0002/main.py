from functools import reduce


def strategy1(l):
    '''
    Using multiplication and division
    >>> strategy1([1, 2, 3, 4, 5])
    [120, 60, 40, 30, 24]
    >>> strategy1([3, 2, 1])
    [2, 3, 6]
    '''
    mul = reduce(lambda x, y: x * y, l, 1)
    return list(map(lambda x: mul // x, l))


def strategy2(l):
    '''
    Using only multiplication
    >>> strategy2([1, 2, 3, 4, 5])
    [120, 60, 40, 30, 24]
    >>> strategy2([3, 2, 1])
    [2, 3, 6]
    '''
    out = []
    for i in range(len(l)):
        out_value = 1
        for j, value_j in enumerate(l):
            if i != j:
                out_value *= value_j
        out.append(out_value)
    return out


def strategy3(l):
    '''
    Just for fun :)
    >>> strategy3([1, 2, 3, 4, 5])
    [120, 60, 40, 30, 24]
    >>> strategy3([3, 2, 1])
    [2, 3, 6]
    '''
    return [reduce(lambda x, y: x * y, [value_j for j, value_j in enumerate(l) if j != i], 1) for i, value_i in enumerate(l)]


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
