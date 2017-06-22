#include "radians.h"

#include <math.h>

double degreeToRadian(double degree)
{
	double radian = (degree * 3.14) / 180.0;
	return radian;
}