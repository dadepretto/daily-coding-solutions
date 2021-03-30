class Node:
    def __init__(self, value, left=None, right=None):
        '''
        >>> n = Node(3)
        >>> print(n.value)
        3
        >>> print(n.left)
        None
        >>> print(n.right)
        None
        '''
        self.value = value
        self.left = left
        self.right = right

    def is_unival(self):
        '''
        >>> Node(3).is_unival()
        True
        >>> Node(3, Node(3), Node(3)).is_unival()
        True
        >>> Node(3, Node(4), Node(4)).is_unival()
        False
        >>> Node(3, Node(4), None).is_unival()
        False
        >>> Node(3, Node(4), Node(3)).is_unival()
        False
        >>> Node(3, Node(3, Node(4), Node(4)), Node(3)).is_unival()
        False
        '''
        if self.left is None and self.right is None:
            return True
        else:
            left = self.value if self.left is None else self.left.value
            right = self.value if self.right is None else self.right.value
            return self.value == left == right \
                and self.left.is_unival() \
                and self.right.is_unival()


def n_unival_trees(node):
    '''
    >>> n = Node(0, Node(1), Node(0, Node(1, Node(1), Node(1)), Node(0)))
    >>> n_unival_trees(n)
    5
    >>> n = Node(0, Node(0), Node(0, Node(1, Node(1), Node(1)), Node(0)))
    >>> n_unival_trees(n)
    5
    '''
    return (1 if node.is_unival() else 0) + \
        (n_unival_trees(node.left) if node.left is not None else 0) + \
        (n_unival_trees(node.right) if node.right is not None else 0)


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
