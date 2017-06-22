using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _1.Gauss.SolutionMethods
{
    public class GaussSolution : Solution
    {
        public GaussSolution(DenseMatrix matrixA, DenseMatrix matrixB, double epsilon)
            : base(matrixA, matrixB, epsilon)
        {
           CheckDiagonalElementsToZero();
        }

        #region Prepare Matrix

        //в конце прямого хода мы придем к треугольной матрице. И на диагонале не может быть нулевых элементов или
        //элементов меньше точности(Epsilon). и если они есть в исходной матрице, то от этого избавляемся меняя строки местами
        private void CheckDiagonalElementsToZero()
        {
            for (int i = 0; i < matrixA.RowCount; i++)
            {
                if (Math.Abs(matrixA[i, i]) <= epsilon)
                {
                    RearrangeRowOfMatrix(i);
                }
            }
        }

        private void RearrangeRowOfMatrix(int rowIndex)
        {
            for (int i = rowIndex; i < matrixA.RowCount; i++)
            {
                if (Math.Abs(matrixA[i, rowIndex] - 0) > epsilon)
                {
                    ExchangeRows(matrixA, matrixB, i, rowIndex);
                    break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Прямой ход
        /// </summary>
        /// <returns></returns>
        protected override Solution ForwardTrace()
        {
            //копируем матрицы
            DenseMatrix newMatrixA = DenseMatrix.OfMatrix(matrixA);
            DenseMatrix newMatrixB = DenseMatrix.OfMatrix(matrixB);

            for (int i = 0; i < matrixA.RowCount; i++)
            {
                if (this is GaussLeadingElementSolution)
                {
                    MaxRowOnTop(newMatrixA, newMatrixB, i);
                }

                double firstLineFirstElement = newMatrixA[i, i];
                determenantMatrixA *= firstLineFirstElement;
                //внутри этого цикла от всех строк отнимется первая строка
                for (int j = i + 1; j < matrixA.RowCount; j++)
                {
                    if (Math.Abs(firstLineFirstElement - 0) >= epsilon)
                    {
                        double currentLineFirstElement = newMatrixA[j, i];
                        //вычитаем из элемента текущей строки столбца свободных членов элемент первой строки
                        double bi = newMatrixB[j, 0];
                        double bk = newMatrixB[i, 0];
                        newMatrixB[j, 0] = bi - currentLineFirstElement / firstLineFirstElement * bk;

                        //вычитаем из элемента текущей строки основной матрицы системы элемент первой строки осн. м. системы
                        for (int k = i; k < matrixA.RowCount; k++)
                        {
                            var firstLineElement = newMatrixA[i, k];
                            var currentLineElement = newMatrixA[j, k];
                            newMatrixA[j, k] = currentLineElement -
                                               currentLineFirstElement/firstLineFirstElement*firstLineElement;
                        }
                    }
                }
            }
            return new GaussSolution(newMatrixA, newMatrixB, epsilon);
        }

        //используется при решение СЛАУ методом Гаусса выбором главного элемента
        protected void MaxRowOnTop(DenseMatrix newMatrixA, DenseMatrix newMatrixB, int i)
        {
            int indexMaxElem = newMatrixA.Column(i, i, matrixA.RowCount - i).AbsoluteMaximumIndex() + i;
            ExchangeRows(newMatrixA, newMatrixB, i, indexMaxElem);
        }

        /// <summary>
        /// Обратный ход
        /// </summary>
        /// <returns></returns>
        protected override DenseMatrix BackTrace()
        {
            if (GetIndexOfZeroLine(forwardTraceSolution.matrixA) != -1)
            {
                return InfinityCase();
            }

            var result = new DenseMatrix(matrixA.RowCount, 1);

            //идем снизу вверх
            for (int row = matrixA.RowCount - 1; row >= 0; row--)
            {
                var sum = 0.0;
                for (int column = matrixA.RowCount - 1; column > row; column--)
                {
                    //умножаем на уже известное значение переменной, находящееся в result[column, 0]
                    sum += forwardTraceSolution.matrixA[row, column] * result[column, 0];
                }
                result[row, 0] = (forwardTraceSolution.matrixB[row, 0] - sum) /
                                 forwardTraceSolution.matrixA[row, row];
            }
            return result;
        }
    }
}