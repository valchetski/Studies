from functools import reduce
from pip._vendor.requests.packages.urllib3.connectionpool import xrange
from pyprimes import get_prime
from operator import mul


class ConditionError(Exception):
    pass


def gen_prime(above=None):
    if above:
        while 1:
            p = get_prime(len(bin(above)))
            if p > above:
                return p
    else:
        return get_prime(64)


class AsmuthBloomScheme(object):
    @classmethod
    def share_secret(cls, secret, number, members):
        while 1:
            p = gen_prime(secret)
            d = cls._gen_d(number, p)
            try:
                cls._raise_error_if_condition_not_performed(number, members, d, p)
            except ConditionError:
                pass
            else:
                break

        m = secret + gen_prime() * p
        return [(p, di, m % di) for di in d]

    @classmethod
    def restore_secret(cls, elements, members):
        y = [b for a, b, c in elements[-members:]]
        m = [c for a, b, c in elements[-members:]]

        x = cls._garner_algorithm(m, y)
        return x % elements[0][0]

    @classmethod
    def _gen_d(cls, number, above):
        d = []
        for i in xrange(0, number):
            d.append(gen_prime(above))
            above = d[-1]
        return d

    @classmethod
    def _raise_error_if_condition_not_performed(cls, number, members, d, p):
        if not all(di > p for di in d):
            raise ConditionError
        if not all(d[i] < d[i + 1] for i in xrange(0, number - 1)):
            raise ConditionError
        if reduce(mul, d[:members]) <= p * reduce(mul, d[number - members + 2:]):
            raise ConditionError

    @classmethod
    def _extended_gcd(cls, a, b):
        u, u1 = 1, 0
        v, v1 = 0, 1
        g, g1 = a, b
        while g1:
            q = g // g1
            u, u1 = u1, u - q * u1
            v, v1 = v1, v - q * v1
            g, g1 = g1, g - q * g1
        return u, v, g  # (a**-1 mod b), (b**-1 mod a), gcd(a,b)

    @classmethod
    def _multiplicative_inverse(cls, a, b):
        m, _, _ = cls._extended_gcd(a, b)
        if m < 0:
            m = m % b
        return m

    @classmethod
    def _garner_algorithm(cls, v, m):
        c = [0] * len(m)
        for i in xrange(1, len(m)):
            c[i] = 1
            for j in xrange(0, i):
                u = cls._multiplicative_inverse(m[j], m[i])
                c[i] = (u * c[i]) % m[i]
        u = v[0]
        x = u
        for i in xrange(1, len(m)):
            u = ((v[i] - x) * c[i]) % m[i]
            s = 1
            for j in xrange(0, i):
                s = s * m[j]
            x += u * s
        return x
