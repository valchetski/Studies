import bisect
from interpolation.helper import poly
import numpy as np


class CubicSpline:

    class SplineTuple:
        a, b, c, d, x = [0., 0., 0., 0., 0.]

    splines = []

    def __init__(self, x_values, y_values):
        CubicSpline.splines = CubicSpline.__build_splines__(x_values, y_values)

    @staticmethod
    def __build_splines__(x_values, y_values):
        n = len(x_values)
        splines = []
        for i in range(0, n):
            spline = CubicSpline.SplineTuple()
            spline.x, spline.a = x_values[i], y_values[i]
            splines.append(spline)
        splines[0].c = splines[n - 1].c = 0.

        alpha = [0.]
        beta = [0.]
        for i in range(1, n - 1):
            dx_previous = x_values[i] - x_values[i - 1]
            dx_next = x_values[i + 1] - x_values[i]
            a = dx_previous
            b = dx_next
            c = 2. * (dx_previous + dx_next)
            f = 6. * ((y_values[i + 1] - y_values[i]) / dx_next - (y_values[i] - y_values[i - 1]) / dx_previous)
            z = (a * alpha[i - 1] + c)
            alpha.append(-b / z)
            beta.append((f - a * beta[i - 1]) / z)

        for i in range(n - 2, 0, -1):
            splines[i].c = alpha[i] * splines[i + 1].c + beta[i]

        for i in range(n - 1, 0, -1):
            dxi = x_values[i] - x_values[i - 1]
            splines[i].d = (splines[i].c - splines[i - 1].c) / dxi
            splines[i].b = dxi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y_values[i] - y_values[i - 1]) / dxi
        return splines

    @staticmethod
    def interpolate(x):
        distribution = sorted([s.x for s in CubicSpline.splines])
        index = bisect.bisect_left(distribution, x)
        s = CubicSpline.splines[index]
        dx = x - s.x
        return s.a + s.b * dx + s.c * dx ** 2 / 2. + s.d * dx ** 3 / 6.0

    @staticmethod
    def to_string():
        s = ''
        for i, t in enumerate(CubicSpline.splines):
            s += 'S{}(x) = '.format(i)
            s += '{:0.3f} {:+0.3f}*(x {x:+0.3f}) {:+0.3f}*(x {x:+0.3f})^2 {:+0.3f}*(x {x:+0.3f})^3\n'.format(t.a, t.b, t.c, t.d, x=-t.x)
            p = np.poly1d([t.a])
            p = np.polyadd(p, np.poly1d([t.b, -t.x*t.b]))
            q = np.poly1d([1, -t.x])
            q = np.polymul(q, q)
            p = np.polyadd(p, np.polymul(q, t.c))
            q = np.polymul(q, np.poly1d([1, -t.x]))
            p = np.polyadd(p, np.polymul(q, t.d))
            s += '= {}\n'.format(poly.poly_to_string(p))
        return s
