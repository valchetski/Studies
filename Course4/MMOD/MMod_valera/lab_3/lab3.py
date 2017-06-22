import math
import numpy as np
from scipy.special import erfinv
from scipy.stats import chi2
from scipy.integrate import quad
import matplotlib.pyplot as plot
from common.plots import draw_probability_density


class UniformDistribution(object):

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


class GausseDistribution(object):

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


class SimpsonDistribution(object):

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


class TriangularDistribution(object):

    @classmethod
    def get_F(cls, a=0, b=1):
        return lambda x: quad(cls.get_f(a, b), 0, x)[0]

    @classmethod
    def get_f(cls, a=0, b=1):
        return lambda x: 2.0*(x-a)/math.pow(b - a, 2)

    @classmethod
    def get_y(cls, a, b, N):
        x = np.zeros(N)
        for i in range(0, N):
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


class ExponentialDistribution(object):

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


def get_estimates(y, level):
    n = len(y)

    m_y = sum(y)/n
    d_y = sum(math.pow(yi - m_y, 2) for yi in y) / (n-1)

    s = n*d_y / (n - 1)
    zy = math.sqrt(2) * erfinv(1 - level)

    toch_m_y = math.sqrt(s) * zy / math.sqrt(n)
    toch_d_y = s * zy * math.sqrt(2/(n-1))

    return m_y, d_y, toch_m_y, toch_d_y


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


def hypothesis(Fx, y, N, alpha):
    chi_table = {0.01: 13.2767, 0.05: 9.4877, 0.1: 7.779}

    y = group_list(y)
    n = N

    if n <= 100:
        m = int(math.sqrt(n))
    else:
        m = int(3 * math.log10(n))

    v = n / m
    y_group = group_y(y, m, v, n)

    ksi = 0
    for item in y_group:
        p = Fx(item[1]) - Fx(item[0])
        ksi += (item[2] - n * p) ** 2 / (n * p)

    ksi_table = chi2(m).interval(1-alpha)[0]  # chi_table.get(round(1-alpha, 2))

    result = "\nPirson's criterion\n\n" + "Ksi = " + str(ksi) + "\nKsi (table) = " + str(ksi_table) + '\n\n'
    if ksi <= ksi_table:
        result += "Hypothesis is confirmed"
    else:
        result += "Hypothesis is not confirmed"
    return result


def draw_hist(y):
    y1 = group_list(y)
    n = N

    if n <= 100:
        m = int(math.sqrt(n))
    else:
        m = int(3 * math.log10(n))

    v = n / m
    y_group = group_y(y1, m, v, n)

    for elem in y_group:
        plot.bar(elem[0], elem[4], width=elem[3])

if __name__ == '__main__':
    N = 5000
    signif_level = 0.90

    # #########
    # ## Gausse
    # ##
    # sigma = 1
    # u = 5
    #
    # m = GausseDistribution.theoretical_m(u)
    # d = GausseDistribution.theoretical_d(sigma)
    # fx = GausseDistribution.get_f(sigma, u)
    # Fx = GausseDistribution.get_F(sigma, u)
    #
    # y = GausseDistribution.get_y(u, sigma, N)
    # ##
    # #########

    # #########
    # ## Uniform
    # ##
    # a = 0
    # b = 1
    #
    # m = UniformDistribution.theoretical_m(a, b)
    # d = UniformDistribution.theoretical_d(a, b)
    # fx = UniformDistribution.get_f(a, b)
    # Fx = UniformDistribution.get_F(a, b)
    #
    # y = UniformDistribution.get_y(a, b, N)
    # ##
    # ########

    # #########
    # ## Simpson
    # ##
    # a = 2
    # b = 5
    #
    # m = SimpsonDistribution.theoretical_m(a, b)
    # d = SimpsonDistribution.theoretical_d(a, b)
    # fx = SimpsonDistribution.get_f(a, b)
    # Fx = SimpsonDistribution.get_F(a, b)
    #
    # y = SimpsonDistribution.get_y(a, b, N)
    # ##
    # ########

    # ##########
    # ## Triangular
    # ##
    a = 0
    b = 5

    m = TriangularDistribution.theoretical_m(a, b)
    d = TriangularDistribution.theoretical_d(a, b)
    fx = TriangularDistribution.get_f(a, b)
    Fx = TriangularDistribution.get_F(a, b)

    y = TriangularDistribution.get_y(a, b, N)
    # ##
    # ########

    #########
    ## Exponential
    ##
    #lambda_ = 1.5
    #
    #m = ExponentialDistribution.theoretical_m(lambda_)
    #d = ExponentialDistribution.theoretical_d(lambda_)
    #fx = ExponentialDistribution.get_f(lambda_)
    #Fx = ExponentialDistribution.get_F(lambda_)

    #y = ExponentialDistribution.get_y(lambda_, N)
    ##
    ########

    x_range = np.linspace(min(y), max(y), num=N)

    bins = int(math.sqrt(N)) if N <= 100 else int(3 * math.log10(N))

    plot.hist(y, bins=bins, normed=True)  # draw_hist(y)

    # draw_probability_density(y, plot)
    plot.plot(x_range, [fx(x) for x in x_range], color='green')

    print('N = {}'.format(N))
    print('significance level = {}'.format(signif_level))
    print

    m_y, d_y, toch_m_y, toch_d_y = get_estimates(y, signif_level)

    print('MO = {}'.format(m))
    print('D = {}'.format(d))

    print('real MO = {}'.format(m_y))
    print('real D = {}'.format(d_y))

    print('doveritelni interval MO = [{}; {}]'.format(m_y - toch_m_y, m_y + toch_m_y))
    print('doveritelni interval D = [{}; {}]'.format(d_y - toch_d_y, d_y + toch_d_y))

    # print(hypothesis(Fx, y, N, signif_level))

    plot.show()
