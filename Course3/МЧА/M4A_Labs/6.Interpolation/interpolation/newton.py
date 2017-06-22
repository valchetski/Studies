import math
from numpy import poly1d, polydiv, polymul, polysub, polyadd


class Newton:

    cache = {}

    @staticmethod
    def interpolate(x_values, y_values):
        dx = x_values[1] - x_values[0]
        q = polydiv(poly1d([1, -x_values[0]]), [dx])[0]
        interpolation_poly = poly1d([y_values[0]])
        finite_difference_cache = {}

        for i in range(1, len(x_values)):
            poly_member = q
            for k in range(1, i):
                poly_member = polymul(poly_member, polysub(q, [k]))
            poly_member = polydiv(poly_member, [math.factorial(i)])[0]
            finite_difference = Newton.__finite_difference__(y_values, 0, i, finite_difference_cache)
            poly_member = polymul(poly_member, [finite_difference])
            interpolation_poly = polyadd(interpolation_poly, poly_member)

        Newton.cache = finite_difference_cache
        return interpolation_poly

    @staticmethod
    def __finite_difference__(y_values, i, k, cache):
        cache_key = 'k={0}, i={1}'.format(k, i)
        if cache_key in cache:
            return cache[cache_key]
        if k == 1:
            finite_difference = y_values[i + 1] - y_values[i]
            cache[cache_key] = finite_difference
            return finite_difference
        previous_i1_diff = Newton.__finite_difference__(y_values, i + 1, k - 1, cache)
        previous_i_diff = Newton.__finite_difference__(y_values, i, k - 1, cache)
        finite_difference = previous_i1_diff - previous_i_diff
        cache[cache_key] = finite_difference
        return finite_difference

    @staticmethod
    def to_string(poly, y0, x_values):
        s = '{:0.3f}'.format(y0)
        for i in xrange(0, 6):
            a = Newton.cache.get('k={0}, i={1}'.format(i+1, 0))
            a = float(a)
            s += ' {:+0.3f}'.format(a)
            for j in xrange(0, i+1):
                s += '*(x - {:0.3f})'.format(x_values[j])
            s += '\n'
        return s[:-1]

    @staticmethod
    def __f_sub(indexes, x_values):
        if len(indexes) > 2:
            return (Newton.__f_sub(indexes[1:], x_values) - Newton.__f_sub(indexes[:-1], x_values))/(x_values[-1] - x_values[0])
        cache_key = 'k={0}, i={1}'.format(indexes[1], indexes[0])
        return Newton.cache.get(cache_key, 0)
