from numpy import poly1d, polydiv, polymul, polyadd


class Lagrange:

    last_poly_to_string = ''

    @staticmethod
    def interpolate(x_values, y_values):
        Lagrange.last_poly_to_string = ''

        interpolation_poly = poly1d(0)
        for i, x in enumerate(x_values):
            Lagrange.last_poly_to_string += '{:0.3f}'.format(y_values[i])

            i_base_poly = Lagrange.__build_base_poly__(i, x_values)
            base_poly_mul_y = polymul(i_base_poly, y_values[i])
            interpolation_poly = polyadd(interpolation_poly, base_poly_mul_y)
        Lagrange.last_poly_to_string = Lagrange.last_poly_to_string[:-3]
        return interpolation_poly

    @staticmethod
    def __build_base_poly__(i, x_values):
        numerator = poly1d(1)
        denominator = 1
        for j, x in enumerate(x_values):
            if j != i:
                Lagrange.last_poly_to_string += '*(x {:+0.2})'.format(x)

                numerator = polymul(numerator, poly1d([1, -x]))
                denominator *= x_values[i] - x
        Lagrange.last_poly_to_string += '/{:0.3f} + \n'.format(denominator)
        return polydiv(numerator, denominator)[0]
