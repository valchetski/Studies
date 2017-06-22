using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _1.Gauss.SolutionMethods
{
    public class GaussJordanSolution : Solution
    {
        public GaussJordanSolution(DenseMatrix matrixA, DenseMatrix matrixB, double epsilon)
            : base(matrixA, matrixB, epsilon)
        {
        }

        protected override Solution ForwardTrace()
        {
            for (int i = 0; i < matrixA.RowCount; i++)
            {
                //Выбирают первый слева столбец матрицы, в котором есть хоть одно отличное от нуля значение.
                //Если самое верхнее число в этом столбце ноль, то меняют всю первую строку матрицы 
                //с другой строкой матрицы, где в этой колонке нет нуля.
                int columnIndex = GetIndexOfNotZeroColumn(matrixA, i);
                if (columnIndex > 0 && Math.Abs(matrixA[i, columnIndex] - 0) <= epsilon)
                {
                    for (int x = i; x < matrixA.RowCount; x++)
                    {
                        if (Math.Abs(matrixA[x, columnIndex] - 0) >= epsilon)
                        {
                            ExchangeRows(matrixA, matrixB, x, i);
                            break;
                        }
                    }
                }

                //Все элементы первой строки делят на верхний элемент выбранного столбца
                double higherColumnElement = columnIndex != -1 ? matrixA[i, columnIndex] : 0;
                if (higherColumnElement != 0)
                {
                    for (var col = 0; col < matrixA.ColumnCount; col++)
                    {
                        matrixA[i, col] /= higherColumnElement;
                    }
                    matrixB[i, 0] /= higherColumnElement;
                }
                determenantMatrixA *= higherColumnElement;

                //Из оставшихся строк вычитают первую строку, умноженную на первый элемент соответствующей строки, 
                //с целью получить первым элементом каждой строки (кроме первой) ноль.
                for (var rowIndex = i + 1; rowIndex < matrixA.RowCount; rowIndex++)
                {
                    double firstElementOfRow = matrixA[rowIndex, i];

                    Vector<double> rowA = matrixA.Row(rowIndex) - matrixA.Row(i)*firstElementOfRow;
                    matrixA.SetRow(rowIndex, rowA);

                    Vector<double> rowB = matrixB.Row(rowIndex) - matrixB.Row(i)*firstElementOfRow;
                    matrixB.SetRow(rowIndex, rowB);
                }
            }
            return new GaussSolution(matrixA, matrixB, epsilon);
        }

        protected override DenseMatrix BackTrace()
        {
            //Вычитают из предпоследней строки последнюю строку, умноженную на соответствующий коэффициент, 
            //с тем, чтобы в предпоследней строке осталась только 1 на главной диагонали.
        	//Повторяют предыдущий шаг для последующих строк. В итоге получают единичную матрицу и 
            //решение на месте свободного вектора (с ним необходимо проводить все те же преобразования).

            for (var rowIndex = forwardTraceSolution.matrixA.RowCount - 1; rowIndex >= 1; rowIndex--)
            {
                for (int rowIndex2 = rowIndex - 1; rowIndex2 >= 0; rowIndex2--)
                {
                    double factor = forwardTraceSolution.matrixA[rowIndex2, rowIndex];

                    Vector<double> rowA = forwardTraceSolution.matrixA.Row(rowIndex2) -
                                          forwardTraceSolution.matrixA.Row(rowIndex)*factor;
                    forwardTraceSolution.matrixA.SetRow(rowIndex2, rowA);

                    Vector<double> rowB = forwardTraceSolution.matrixB.Row(rowIndex2) -
                                          forwardTraceSolution.matrixB.Row(rowIndex)*factor;
                    forwardTraceSolution.matrixB.SetRow(rowIndex2, rowB);
                }
            }

            if (GetIndexOfZeroLine(forwardTraceSolution.matrixA) != -1)
            {
                return InfinityCase();
            }

            return forwardTraceSolution.matrixB;
        }

        
        //Выбирают первый слева столбец матрицы, в котором есть хоть одно отличное от нуля значение.
	    //Если самое верхнее число в этом столбце ноль, то меняют всю первую строку матрицы с другой 
        //строкой матрицы, где в этой колонке нет нуля.

        protected int GetIndexOfNotZeroColumn(DenseMatrix oldMatrixA, int column)
        {
            for (; column < oldMatrixA.ColumnCount; column++)
            {
                for (var row = column; row < oldMatrixA.RowCount; row++)
                {
                    if (Math.Abs(oldMatrixA[row, column] - 0) > epsilon)
                    {
                        return column;
                    }
                }
            }
            return -1;
        }
    }
}