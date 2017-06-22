using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lab3.Models.Helpers;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab3.Models.Solver
{
    public sealed class JacobiMethoSolver : IEigenvectorsSolver
    {
        public double Epsilon = 0.0000001;

        public IList<DenseVector> Solve(DenseMatrix matrixA, out IList<DenseMatrix> matrixAList,
            out IList<double> eigenvalues)
        {
            int iteration;
            return Solve(matrixA, Epsilon, out matrixAList, out eigenvalues, out iteration);
        }

        public IList<DenseVector> Solve(DenseMatrix matrixA, double epsilon, out IList<DenseMatrix> matrixAList,
            out IList<double> eigenvalues, out int iterations)
        {
            if (!IsSymmetricMatrix(matrixA))
                throw new ArgumentException();

            iterations = 0;
            matrixAList = new List<DenseMatrix>();

            var matrixV = DenseMatrix.Identity(matrixA.RowCount);
            do
            {
                DenseMatrix matrixVk;
                matrixA = CalculateNextMatrixAk(matrixA, out matrixVk);
                Trace.WriteLine(matrixA);
                matrixV *= matrixVk;

                iterations++;
                matrixAList.Add(matrixA);
            } while (MaxNonDiagonalElement(matrixA).Item3 > epsilon);

            eigenvalues = matrixA.Diagonal().ToArray();

            return matrixV.ColumnEnumerator().Select(column => column.Item2).Select(DenseVector.OfVector).ToList();
        }

        private DenseMatrix CalculateNextMatrixAk(DenseMatrix matrixAk, out DenseMatrix matrixVk)
        {
            var order = matrixAk.RowCount;
            var maxElementIndexes = MaxNonDiagonalElement(matrixAk);
            var row = maxElementIndexes.Item1;
            var col = maxElementIndexes.Item2;
            var pk = CalculatePk(matrixAk, row, col);
            var cosFk = CalculateCosFk(pk);
            var sinFk = CalculateSinFk(pk);
            matrixVk = DenseMatrix.Identity(order);
            matrixVk[row, row] = cosFk;
            matrixVk[col, col] = cosFk;
            matrixVk[row, col] = -sinFk;
            matrixVk[col, row] = sinFk;
            var matrixB = new DenseMatrix(order);
            for (int s = 0; s < order; s++)
            {
                matrixB[s, row] = matrixAk[s, row] * cosFk + matrixAk[s, col] * sinFk;
                matrixB[s, col] = -matrixAk[s, row] * sinFk + matrixAk[s, col] * cosFk;
            }
            for (int s = 0; s < order; s++)
                for (int p = 0; p < order; p++)
                    if (p != row && p != col)
                        matrixB[s, p] = matrixAk[s, p];
            var nextMatrixAk = new DenseMatrix(order);
            for (int s = 0; s < order; s++)
            {
                nextMatrixAk[row, s] = matrixB[row, s] * cosFk + matrixB[col, s] * sinFk;
                nextMatrixAk[col, s] = -matrixB[row, s] * sinFk + matrixB[col, s] * cosFk;
            }
            for (int s = 0; s < order; s++)
                for (int p = 0; p < order; p++)
                    if (s != row && s != col)
                        nextMatrixAk[s, p] = matrixB[s, p];
            return nextMatrixAk;
        }

        private double CalculatePk(DenseMatrix matrixAk, int maxElementRow, int maxElementCol)
        {
            return 2 * matrixAk[maxElementRow, maxElementCol] /
                   (matrixAk[maxElementRow, maxElementRow] - matrixAk[maxElementCol, maxElementCol]);
        }

        private double CalculateCosFk(double pk)
        {
            return Math.Sqrt(0.5 * (1 + Math.Pow(1 + pk * pk, -0.5)));
        }

        private double CalculateSinFk(double pk)
        {
            return Math.Sign(pk) * Math.Sqrt(0.5 * (1 - Math.Pow(1 + pk * pk, -0.5)));
        }

        private Tuple<int, int, double> MaxNonDiagonalElement(DenseMatrix matrix)
        {
            int row = -1, col = -1;
            double maxElementValue = double.MinValue;
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = i + 1; j < matrix.ColumnCount; j++)
                {
                    var absElementValue = Math.Abs(matrix[i, j]);
                    if (!(absElementValue > maxElementValue)) continue;
                    maxElementValue = absElementValue;
                    row = i;
                    col = j;
                }
            }
            return new Tuple<int, int, double>(row, col, maxElementValue);
        }

        private bool IsSymmetricMatrix(DenseMatrix matrix)
        {
            for (int y = 0; y < matrix.RowCount; y++)
            {
                for (int x = y; x < matrix.ColumnCount; x++)
                {
                    if (Math.Abs(matrix[x, y] - matrix[y, x]) > DoubleHelper.EPSILON)
                        return false;
                }
            }
            return true;
        } 
    }
}
