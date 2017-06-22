using MathNet.Numerics.LinearAlgebra.Double;

namespace _1.Gauss.SolutionMethods
{
    public class MatrixMethodSolution : GaussJordanSolution
    {
        public DenseMatrix matrixInverse;

        public MatrixMethodSolution(DenseMatrix matrixA, DenseMatrix matrixB, double epsilon) : base(matrixA, matrixB, epsilon)
        {
        }

        public override void Solve()
        {
            if (matrixA.Determinant() != 0)
            {
                matrixInverse = new DenseMatrix(matrixA.RowCount, matrixA.ColumnCount);
                for (int i = 0; i < matrixA.RowCount; i++)
                {
                    matrixInverse[i, i] = 1;
                }

                DenseMatrix backupMatrixA = DenseMatrix.OfMatrix(matrixA);
                DenseMatrix oldMatrixB = DenseMatrix.OfMatrix(matrixB);
                matrixA = DenseMatrix.OfMatrix(matrixA.Append(matrixInverse));
                base.Solve(); //выполняем для нахождения обратной матрицы

                DenseMatrix newMatrix = forwardTraceSolution.matrixA;

                matrixA = DenseMatrix.OfMatrix(backupMatrixA);

                matrixInverse =
                    DenseMatrix.OfMatrix(newMatrix.SubMatrix(0, newMatrix.RowCount, newMatrix.ColumnCount / 2,
                        newMatrix.ColumnCount / 2));

                forwardTraceSolution = new MatrixMethodSolution(matrixInverse, oldMatrixB, epsilon);
                solution = DenseMatrix.OfMatrix(matrixInverse * oldMatrixB);
            }
            else
            {
                determenantMatrixA = 0;
            }
        }
    }
}