def poly_to_string(poly):
    i = len(poly.coeffs) - 1
    result = ''
    for coeff in poly:
        result += ' {:+0.3f}'.format(coeff)
        if i != 0:
            result += '*x^' + str(i)
            i -= 1
    return result[2:]
