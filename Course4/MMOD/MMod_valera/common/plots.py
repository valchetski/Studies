import math


def group_list(l):
    result = {}
    for i in l:
        value = result.get(i)
        if value is None:
            result[i] = 1
        else:
            result[i] += 1
    return sorted(zip(result.keys(), result.values()))


def group_y(y, m, v, len_y):
    result = []
    a = y[0][0]
    n = 0

    for yi in y:
        n += yi[1]
        b = yi[0]

        if n >= v:
            h = b - a
            result.append((a, b, n, h, 1.0 * n / len_y / h, a + (b - a) / 2.0))
            n = 0
            a = b
    return result


def group_probability_density(y, m, v, len_y):
    result = []
    a = y[0][0]
    b = y[-1][0]
    h = 1.0*(b-a)/m

    for i in xrange(0, m):
        start = a + i*h
        end = start + h

        n = 0
        for yi in filter(lambda x: start <= x[0] <= end, y):
            n += yi[1]

        result.append((start, end, n, h, 1.0*n/len_y))

    return result


def draw_probability_density(y, plot):
    y1 = group_list(y)
    n = len(y)

    if n <= 100:
        m = int(math.sqrt(n))
    else:
        m = int(3 * math.log10(n))

    v = n / m
    y_group = group_probability_density(y1, m, v, n)

    for elem in y_group:
        plot.bar(elem[0], elem[4], width=elem[3])


def draw_hist(y, plot):
    y1 = group_list(y)
    n = len(y)

    if n <= 100:
        m = int(math.sqrt(n))
    else:
        m = int(3 * math.log10(n))

    v = n / m
    y_group = group_y(y1, m, v, n)

    for elem in y_group:
        plot.bar(elem[0], elem[4], width=elem[3])
