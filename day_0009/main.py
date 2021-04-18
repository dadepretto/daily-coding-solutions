def get_sum_bigger_non_adjacent(l):
    '''
    >>> get_sum_bigger_non_adjacent([])

    >>> get_sum_bigger_non_adjacent([100])
    100
    >>> get_sum_bigger_non_adjacent([100, 101])
    101
    >>> get_sum_bigger_non_adjacent([5, 7, 6])
    11
    >>> get_sum_bigger_non_adjacent([5, 1, 1, 5])
    10
    >>> get_sum_bigger_non_adjacent([90, 70, 100, 101])
    191
    >>> get_sum_bigger_non_adjacent([101, 90, 70, 100])
    201
    >>> get_sum_bigger_non_adjacent([90, 101, 70, 100])
    201
    >>> get_sum_bigger_non_adjacent([2, 4, 6, 2, 5])
    13
    >>> get_sum_bigger_non_adjacent([10, 15, 6, 0, 2, 0, 3, 0, 4])
    25
    '''

    if not l:
        return None

    i, e = l[0], 0

    for x in l[1:]:
        i, e = e + x, max(i, e)

    return max(i, e)


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
