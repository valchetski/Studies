#include "quadraticEquation.h"

#include <math.h>

double *calculateQuadraticEquation(double a, double b, double c)
{
	double result[2];

	double d = pow(b, 2) - 4 * a*c;	
	if (d >= 0 && a != 0)
	{
		result[0] = (-b + sqrt(d)) / (2*a);
		result[1] = (-b - sqrt(d)) / (2 * a);
	}
	else if (a == 0)
	{
		result[0] = -c / b;
	}
	return result;
}