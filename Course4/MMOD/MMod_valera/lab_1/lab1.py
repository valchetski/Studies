import matplotlib.pyplot as plot
from matplotlib import interactive
interactive(True)


def method_1(seed):
    while True:
        seed **= 2
        seed /= 100
        seed -= seed / 10000 * 10000
        yield seed


def method_2(m, k, a0=1):
    ai = a0
    while True:
        ai = (k * ai) % m
        yield ai


def testing_uniformity(method, k=10, n=100, file_name='bar_1.png'):
    plot.close()

    def get_p(method, k, n):
        def append_to_interval(value, ni):
            for interval in ni:
                if interval[0] <= value <= interval[1]:
                    ni[interval] += 1


        gen = method()

        zi = []
        ni = {(i * 1.0/k, (i+1)*1.0/k): 0.0 for i in xrange(0, k)}

        for _ in xrange(0, n):
            value = next(gen)
            zi.append(value)
            append_to_interval(value, ni)

        pi = []

        for i, interval in enumerate(sorted(ni.keys())):
            pi.append(1.0 * ni[interval] / n)

        return pi, ni, zi

    p1, n1, z1 = get_p(method, k, n)
    p2, n2, z2 = get_p(method, k, 10000)

    plot.figure(1)

    plot.subplot(211)
    plot.bar([elem[0] for elem in sorted(n1)],
             [elem for elem in p1],
             width=1.0/k)

    plot.subplot(212)
    plot.bar([elem[0] for elem in sorted(n2)],
             [elem for elem in p2],
             width=1.0/k)

    plot.savefig(file_name)

    M = 1.0/len(z2) * sum(z2)
    D = 1.0/len(z2) * sum([v**2 for v in z2]) - M ** 2

    print('Testing uniformity')
    print('n = {}'.format(len(z2)))
    print('M = {}'.format(M))
    print('D = {}'.format(D))
    print


def testing_independence(method, n=10000, s=3):
    gen = method()
    zi = []

    for _ in xrange(0, n):
        value = next(gen)
        zi.append(value)

    sum_ = 0
    for i in range(0, n - s):
        sum_ += zi[i] * zi[i + s]

    R = 12.0 / (n - s) * sum_ - 3

    print('Testing independence')
    print('R = {}'.format(R))
    print


def testing_repeated(gen):
    zi = []
    prev_i = None

    for i in xrange(0, 100000):
        value = next(gen)

        if prev_i is not None and value in zi:
            return len(zi) - 1
        elif prev_i is None and value in zi:
            prev_i = len(zi)
        elif prev_i is not None:
            prev_i = None

        zi.append(value)
    return None


if __name__ == '__main__':
    def method_1_():
        gen = method_1(2346251)
        while True:
            yield next(gen) / 10000.0

    def method_2_():
        gen = method_2(2345234524352345, 2345235)
        while True:
            value = next(gen) / 10000.0
            while value > 1:
                value /= 10.0
            yield value

    testing_uniformity(method_1_, file_name='method_1_test_1.png')
    testing_uniformity(method_2_, file_name='method_2_test_1.png')

    testing_independence(method_1_)
    testing_independence(method_2_)

    # print('Method 1 = {}'.format(testing_repeated(method_1(1234))))
    # print('Method 2 = {}'.format(testing_repeated(method_2(13, 7))))
