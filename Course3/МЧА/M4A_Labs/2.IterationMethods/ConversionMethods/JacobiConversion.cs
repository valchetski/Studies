using Lab2.Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.ConversionMethods
{
    public class JacobiConversion : Conversion
    {
        public override Solution Transform(int size, DenseMatrix matrixA, DenseVector vectorB)
        {
            if (matrixA.CheckDiagonalElements(DoubleExtensions.IsNotZero))
            {
                var matrixB = new DenseMatrix(size, size);
                var vectorC = new DenseVector(size);

                for (var row = 0; row < size; row++)
                {
                    for (var column = 0; column < size; column++)
                    {
                        if (row != column)
                        {
                            matrixB[row, column] = -(matrixA[row, column] / matrixA[row, row]);
                        }
                    }
                    vectorC[row] = vectorB[row] / matrixA[row, row];
                }

                return new Solution(size, matrixB, vectorC);
            }
            return null;
        }
    }
}