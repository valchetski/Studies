import math
import numpy as np
from scipy.integrate import quad


delta_time = 0.01


class UniformDistribution(object):

    def __init__(self, a, b):
        self._a = a
        self._b = b

    @classmethod
    def get_F(cls, a=0, b=1):
        def F(x):
            if a <= x <= b:
                return 1.0*(x-a)/(b-a)
            elif x < a:
                return 0
            return 1
        return F

    @classmethod
    def get_f(cls, a=0, b=1):
        return lambda x: 1.0/(b-a) if a <= x <= b else 0

    @classmethod
    def get_y(cls, a, b, N):
        x = np.random.random((N,))
        return 1.0*x*(b-a)

    @classmethod
    def theoretical_m(cls, a=0, b=1):
        return (a + b)/2.0

    @classmethod
    def theoretical_d(cls, a=0, b=1):
        return math.pow(b - a, 2)/12.0

    def generate(self):
        return delta_time*self.get_y(self._a, self._b, 1)[0]


class GausseDistribution(object):

    def __init__(self, m, sigma):
        self._m = m
        self._sigma = sigma

    @classmethod
    def get_F(cls, sigma=1, u=0):
        return lambda x: 1.0/2.0*(1+math.erf((x-u)/(math.sqrt(2*math.pow(sigma, 2)))))

    @classmethod
    def get_f(cls, sigma=1, u=0):
        return lambda x: 1.0/(sigma*math.sqrt(2*math.pi))*math.exp(-(math.pow(x-u, 2))/(2.0*math.pow(sigma, 2)))

    @classmethod
    def get_y(cls, mx, dx, N):
        n = 6
        x = np.random.random((n, N))
        sigma = math.sqrt(dx)
        return mx + 1.0 * sigma * math.sqrt(12.0 / n) * (sum(x) - n / 2)

    @classmethod
    def theoretical_m(cls, u=0):
        return u

    @classmethod
    def theoretical_d(cls, sigma=1):
        return math.pow(sigma, 2)

    def generate(self):
        return delta_time*self.get_y(self._m, self._sigma, 1)[0]


class SimpsonDistribution(object):

    def __init__(self, a, b):
        self._a = a
        self._b = b

    @classmethod
    def get_F(cls, a=0, b=1):
        return lambda x: quad(cls.get_f(a, b), 0, x)[0]

    @classmethod
    def get_f(cls, a=0, b=1):
        return lambda x: 2.0/(b-a) - 2.0/math.pow((b-a), 2) * abs(a+b-2.0*x)

    @classmethod
    def get_y(cls, a, b, N):
        return np.random.random((N,)) * (b/2.0 - a/2.0) + a/2.0 + np.random.random((N,)) * (b/2.0 - a/2.0) + a/2.0

    @classmethod
    def theoretical_m(cls, a=0, b=1):
        return (a+b)/2.0

    @classmethod
    def theoretical_d(cls, a=0, b=1):
        return math.pow(b - a, 2)/24.0

    def generate(self):
        return delta_time*self.get_y(self._a, self._b, 1)[0]


class TriangularDistribution(object):

    def __init__(self, a, b):
        self._a = a
        self._b = b

    @classmethod
    def get_F(cls, a=0, b=1):
        return lambda x: quad(cls.get_f(a, b), 0, x)[0]

    @classmethod
    def get_f(cls, a=0, b=1):
        return lambda x: 2.0*(x-a)/math.pow(b - a, 2)

    @classmethod
    def get_y(cls, a, b, N):
        x = np.zeros(N)
        for i in xrange(0, N):
            while 1:
                r1 = np.random.random()
                r2 = np.random.random()
                if r2 < r1:
                    x[i] = a + (b-a)*r1
                    break
        return x

    @classmethod
    def theoretical_m(cls, a=0, b=1):
        return (a+b)/2.0

    @classmethod
    def theoretical_d(cls, a=0, b=1):
        return math.pow(b - a, 2)/24.0

    def generate(self):
        return delta_time*self.get_y(self._a, self._b, 1)[0]


class ExponentialDistribution(object):

    def __init__(self, l):
        self._l = l

    @classmethod
    def get_F(cls, l=1.0):
        return lambda x: 1.0 - math.exp(-l*x)

    @classmethod
    def get_f(cls, l=1.0):
        return lambda x: 1.0 * l * math.exp(-l*x)

    @classmethod
    def get_y(cls, l, N):
        x = np.random.random((N,))
        return -1.0 / l * np.log(1 - x)

    @classmethod
    def theoretical_m(cls, l=1.0):
        return math.pow(l, -1)

    @classmethod
    def theoretical_d(cls, l=1.0):
        return math.pow(l, -2)

    def generate(self):
        return delta_time*self.get_y(self._l, 1)[0]
