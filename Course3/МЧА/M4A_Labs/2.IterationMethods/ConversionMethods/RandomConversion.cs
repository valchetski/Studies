using Lab2.Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.ConversionMethods
{
    public class RandomConversion : Conversion
    {
        public double firstValue;
        public double lastValue;
        public double step;

        public override Solution Transform(int size, DenseMatrix matrixA, DenseVector vectorB)
        {
            DenseMatrix identityMatrix = DenseMatrix.CreateIdentity(size);
            DenseMatrix matrixB = null;
            DenseVector vectorC = null;

            for (double t = firstValue; t <= lastValue; t += step)
            {
                matrixB = identityMatrix - t*matrixA;
                vectorC = t*vectorB;
                if (IsConverges(matrixB))
                {
                    break;
                }
            }

            return new Solution(size, matrixB, vectorC);
        }

        private bool IsConverges(DenseMatrix matrixB)
        {
            return matrixB.AbsMaximumSumOfRows() < 1 || matrixB.SumOfSquares() < 1 || matrixB.AbsMaximumSumOfColumns() < 1;
        }
    }
}
