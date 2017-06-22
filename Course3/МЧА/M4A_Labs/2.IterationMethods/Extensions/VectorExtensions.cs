using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.Extensions
{
    public static class VectorExtensions
    {
        public static double MaximumNorm(this Vector vector)
        {
            return vector.AbsoluteMaximum();
        }

        public static double SumOfSquares(this Vector vector)
        {
            Double vectorSumOfSquares = vector.Sum(elementValue => elementValue*elementValue);
            Double euclidianNorm = Math.Sqrt(vectorSumOfSquares);
            return euclidianNorm;
        }

        public static double AbsSumOfElements(this Vector vector)
        {
            return vector.Sum(x => Math.Abs(x));
        }
    }
}