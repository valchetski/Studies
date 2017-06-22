using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.Extensions
{
    public static class MatrixExtensions
    {
        public static double AbsMaximumSumOfRows(this DenseMatrix matrix)
        {
            double maxRowSum = -1d;
            for (int row = 0; row < matrix.RowCount; row++)
            {
                double sum = matrix.Row(row).SumMagnitudes();
                if (sum > maxRowSum)
                {
                    maxRowSum = sum;
                }
            }
            return maxRowSum;
        }

        public static double AbsMaximumSumOfColumns(this DenseMatrix matrix)
        {
            double maxColumnSum = -1d;
            for (int column = 0; column < matrix.ColumnCount; column++)
            {
                double sum = matrix.Column(column).SumMagnitudes();
                if (sum > maxColumnSum)
                {
                    maxColumnSum = sum;
                }
            }
            return maxColumnSum;
        }

        public static double SumOfSquares(this DenseMatrix matrix)
        {
            double sumOfSquares = 0d;
            for (int row = 0; row < matrix.RowCount; row++)
            {
                for (int column = 0; column < matrix.ColumnCount; column++)
                {
                    sumOfSquares += matrix[row, column] * matrix[row, column];
                }
            }
            return Math.Sqrt(sumOfSquares);
        }

        public static bool CheckDiagonalElements(this DenseMatrix matrix, Func<double, bool> func)
        {
            for (var row = 0; row < matrix.RowCount; row++)
            {
                if (!func(matrix[row, row]))
                    return false;
            }
            return true;
        }

    }
}