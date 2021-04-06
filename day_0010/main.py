import time


def schedule(f, n):
    time_in_seconds = n / 1000
    time.sleep(time_in_seconds)
    f()


def test_schedule():
    '''
    >>> test_schedule()
    Hello world!
    True
    '''
    def f(): return print('Hello world!')
    start = time.time()
    schedule(f, 500)
    end = time.time()

    if end - start >= 0.500:
        return True
    else:
        return False


if __name__ == '__main__':
    import doctest
    doctest.testmod(verbose=True)
