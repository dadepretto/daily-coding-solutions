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

    if len(l) <= 2:
        return None

    if len(l) == 3:
        return l[0] + l[2]

    max_value_1 = float('-inf')
    max_index_1 = None
    for i, element in enumerate(l):
        if element > max_value_1:
            max_value_1 = element
            max_index_1 = i

    max_value_2 = float('-inf')
    for i, element in enumerate(l):
        if i not in [max_index_1 - 1, max_index_1, max_index_1 + 1]:
            if element > max_value_2:
                max_value_2 = element

    return max_value_1 + max_value_2


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
