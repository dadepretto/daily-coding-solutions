class Node:
    def __init__(self, val, left=None, right=None):
        '''
        >>> Node('theValue').val
        'theValue'
        >>> Node('theValue', Node('leftValue'), Node('rightValue')).left.val
        'leftValue'
        >>> Node('theValue', Node('leftValue'), Node('rightValue')).right.val
        'rightValue'
        '''
        self.val = val
        self.left = left
        self.right = right


def serialize(n):
    '''
    >>> serialize(Node('theValue', Node('left'), Node('right')))
    'theValue(left()())(right()())'
    '''
    if n is None:
        return ''
    return f'{n.val}({serialize(n.left)})({serialize(n.right)})'

# The output has the following structure recursive sturcture:
# <value>(<the_left_node_substring>)(<the_right_node_substring>)
#        ^                          ^
#        left_start_index           right_start_index


def get_left_start_index(s):
    '''
    >>> get_left_start_index('root()()')
    4
    >>> get_left_start_index('aroot(a()())(b()())')
    5
    '''
    return s.find('(')


def get_right_start_index(s, start=None):
    '''
    >>> get_right_start_index('root()()')
    6
    >>> get_right_start_index('root(a()())(b()())')
    11
    '''
    if start is None:
        start = get_left_start_index(s)

    level = 0
    for i, c in enumerate(s[start:]):
        if c == '(':
            level += 1
        elif c == ')':
            level -= 1

        if level == 0:
            return i + start + 1


def get_value(s, left_start_index=None):
    '''
    >>> get_value('theValue()()', left_start_index = 8)
    'theValue'
    >>> get_value('anotherValue(subleft()())(subright()())')
    'anotherValue'
    '''
    if left_start_index is None:
        left_start_index = get_left_start_index(s)

    return s[:left_start_index]


def get_left_node_substring(s, left_start_index=None, right_start_index=None):
    '''
    >>> get_left_node_substring('theValue()()', left_start_index = 8, right_start_index = 10)
    ''
    >>> get_left_node_substring('anotherValue(subleft()())(subright()())')
    'subleft()()'
    '''
    if left_start_index is None:
        left_start_index = get_left_start_index(s)
    if right_start_index is None:
        right_start_index = get_right_start_index(s)

    return s[left_start_index + 1:right_start_index - 1]


def get_right_node_substring(s, right_start_index=None):
    '''
    >>> get_right_node_substring('theValue()()', right_start_index = 10)
    ''
    >>> get_right_node_substring('anotherValue(subleft()())(subright()())')
    'subright()()'
    '''
    if right_start_index is None:
        right_start_index = get_right_start_index(s)

    return s[right_start_index + 1:-1]


def deserialize(s):
    '''
    >>> node = Node('root', Node('left', Node('left.left')), Node('right'))
    >>> deserialize(serialize(node)).left.left.val
    'left.left'
    '''
    if s == '':
        return None

    left_start_index = get_left_start_index(s)
    right_start_index = get_right_start_index(s, start=left_start_index)

    left_substring = get_left_node_substring(
        s, left_start_index, right_start_index)
    right_substring = get_right_node_substring(s, right_start_index)

    value = get_value(s, left_start_index)
    left_node = deserialize(left_substring)
    right_node = deserialize(right_substring)

    return Node(value, left_node, right_node)


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
