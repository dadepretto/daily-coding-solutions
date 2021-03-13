def find_first_missing_positive(l):
    '''
    >>> find_first_missing_positive([3, 4, -1, 1])
    2
    >>> find_first_missing_positive([1, 2, 0])
    3
    >>> find_first_missing_positive([-4, 3, 4, -1, 1, -2, 32, 4, -40])
    2
    >>> find_first_missing_positive([0, -1, 1, -2, 2, -3, 3])
    4
    '''
    # Separate positive and negative numbers
    i = 0
    e = len(l) - 1
    while i < e:
        if l[i] >= 0:
            i += 1
        elif l[e] < 0:
            e -= 1
        elif l[i] < 0:
            s = l[e]
            l[e] = l[i]
            l[i] = s

    # Turn negative all the numbers at index before their value
    # The idea is to use the indexes as the reference for positive integer
    # numbers and the negative sign as the "got" check
    for i in range(0, e):
        a = abs(l[i])
        if a <= e:
            l[a-1] = -l[a-1] if l[a-1] > 0 else l[a-1]

    # The result is the index + 1 of the first non-negative number
    s = len(l)
    for i in range(len(l)):
        if l[i] > 0:
            s = i + 1
            break

    return s


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
