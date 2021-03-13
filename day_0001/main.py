def strategy1(l, k):
    '''
    This solutions is O(n^2)
    >>> strategy1([10, 15, 3, 7], 17)
    True
    >>> strategy1([10, 15, 3, 7], 11)
    False
    '''
    for i, value_i in enumerate(l):
        for j, value_j in enumerate(l):
            if i != j and value_i + value_j == k:
                return True
    return False


def strategy2(l, k):
    '''
    This solutions requires only a sort (log(n) ?) and a single scan
    >>> strategy2([10, 15, 3, 7], 17)
    True
    >>> strategy2([10, 15, 3, 7], 11)
    False
    '''
    l.sort()
    i, j = 0, len(l) - 1
    while i < j:
        if l[i] + l[j] < k:
            i += 1
        elif l[i] + l[j] > k:
            j -= 1
        else:
            return True
    return False


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
