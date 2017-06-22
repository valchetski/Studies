using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _1.Gauss.SolutionMethods
{
    public abstract class Solution
    {
        public double epsilon;
        public DenseMatrix matrixA;
        public DenseMatrix matrixB;
        public DenseMatrix solution;
        public double determenantMatrixA;
        public Solution forwardTraceSolution;

        protected Solution(DenseMatrix matrixA, DenseMatrix matrixB, double epsilon)
        {
            this.matrixA = matrixA;
            this.matrixB = matrixB;
            this.epsilon = epsilon;

            determenantMatrixA = 1;
        }

        public virtual void Solve()
        {
            forwardTraceSolution = ForwardTrace();
            solution = BackTrace();
        }

        protected abstract Solution ForwardTrace();
        protected abstract DenseMatrix BackTrace();

        protected void ExchangeRows(DenseMatrix oldMatrixA, DenseMatrix oldMatrixB, int i, int j)
        {
            if (i != j)
            {
                var r1 = oldMatrixA.Row(i);
                var r2 = oldMatrixA.Row(j);
                oldMatrixA.SetRow(j, r1);
                oldMatrixA.SetRow(i, r2);

                var temp = oldMatrixB[i, 0];
                oldMatrixB[i, 0] = oldMatrixB[j, 0];
                oldMatrixB[j, 0] = temp;

                //определитель меняет свой знак при перестановке строк местами
                determenantMatrixA *= -1;
            }
        }

        public SolutionType GetSolutionType()
        {
            SolutionType solutionType;
            var extendedMatrix = DenseMatrix.OfMatrix(matrixA).Append(matrixB);
            if (matrixA.Rank() == extendedMatrix.Rank())
            {
                solutionType = matrixA.Rank() == matrixA.ColumnCount ? SolutionType.OneSolution : SolutionType.InfinitySolutions;
            }
            else
            {
                solutionType = SolutionType.NoSolution;
            }
            return solutionType;
        }

        #region Methods for infinity case

        protected DenseMatrix InfinityCase()
        {
            Matrix<double> matrixAWithoutZeroLines = DenseMatrix.OfMatrix(forwardTraceSolution.matrixA);
            Matrix<double> matrixBWithoutZeroLines = DenseMatrix.OfMatrix(forwardTraceSolution.matrixB);
            RemoveZeroRows(ref matrixAWithoutZeroLines, ref matrixBWithoutZeroLines);

            //Каждая строка результуриющей матрицы соответствует общему значению переменной
            //поэтому количество строк рез. матрицы равно количеству переменных системы--т.е. количеству столбцов матрицы А
            var resultMatrix = new DenseMatrix(matrixA.RowCount, matrixA.ColumnCount + matrixB.ColumnCount);
            for (int i = 0; i < resultMatrix.RowCount; i++)
            {
                resultMatrix[i, i] = 1;
            }

            if (matrixAWithoutZeroLines != null)
            {
                for (int i = matrixAWithoutZeroLines.RowCount - 1; i >= 0; i--)
                {
                    int indexOfNotZeroElementOfRow = GetIndexOfNotZeroElement(matrixAWithoutZeroLines.Row(i));
                    var resultPolynomVector = new DenseVector(matrixAWithoutZeroLines.ColumnCount + matrixBWithoutZeroLines.ColumnCount);
                    Vector<double> rowOfMatrixA = matrixAWithoutZeroLines.Row(i);
                    for (int j = indexOfNotZeroElementOfRow + 1; j < rowOfMatrixA.Count; j++)
                    {
                        if (Math.Abs(rowOfMatrixA[indexOfNotZeroElementOfRow]) != epsilon)
                        {
                            resultPolynomVector[j] = (rowOfMatrixA[j] * -1) / rowOfMatrixA[indexOfNotZeroElementOfRow];
                        }
                    }
                    resultPolynomVector[resultPolynomVector.Count - 1] = matrixBWithoutZeroLines[i, 0];

                    resultMatrix.SetRow(indexOfNotZeroElementOfRow, resultPolynomVector);
                }
            }

            for (int rowIndex = resultMatrix.RowCount - 1; rowIndex >= 0; rowIndex--)
            {
                for (int previousRowIndex = rowIndex + 1; previousRowIndex < resultMatrix.RowCount; previousRowIndex++)
                {
                    var row = resultMatrix.Row(rowIndex);
                    var previousRow = resultMatrix.Row(previousRowIndex);

                    double value = previousRow[previousRowIndex] == 1 ? row[previousRowIndex] : 0;

                    previousRow = previousRow * row[previousRowIndex];
                    row = row + previousRow;

                    row[previousRowIndex] = value;

                    resultMatrix.SetRow(rowIndex, row);
                }
            }

            return resultMatrix;
        }

        private void RemoveZeroRows(ref Matrix<double> firstMatrix, ref Matrix<double> secondMatrix)
        {
            int index = GetIndexOfZeroLine(firstMatrix);
            while (index != -1)
            {
                if (firstMatrix.RowCount == 1)
                {
                    firstMatrix = null;
                    secondMatrix = null;
                    break;
                }
                firstMatrix = firstMatrix.RemoveRow(index);
                secondMatrix = secondMatrix.RemoveRow(index);
                index = GetIndexOfZeroLine(firstMatrix);
            }
        }

        private int GetIndexOfNotZeroElement(Vector<double> row)
        {
            for (int i = 0; i < row.Count; i++)
            {
                if (!row[i].Equals(0.0))
                {
                    return i;
                }
            }
            return -1;
        }

        protected int GetIndexOfZeroLine(Matrix<double> matrix)
        {
            for (int row = 0; row < matrix.RowCount; row++)
            {
                bool isThereZeroLine = true;
                for (int column = 0; column < matrix.ColumnCount; column++)
                {
                    if (!matrix[row, column].Equals(0.0))
                    {
                        isThereZeroLine = false;
                        break;
                    }
                }

                if (isThereZeroLine)
                {
                    return row;
                }
            }
            return -1;
        }

        #endregion
    }
}
