using Lab2.Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.SolveMethods
{
    public class SeidelSleSolver : Solver
    {
        protected override DenseVector SolveWithRelaxation(Solution solution, double accuracy, double w, out int iterations)
        {
            double? relaxationParametr = w;
            return SolveMethod(solution, accuracy, relaxationParametr, out iterations);
        }

        public override DenseVector Solve(Solution solution, double accuracy, out int iterations)
        {
            return SolveMethod(solution, accuracy, null, out iterations);
        }

        private DenseVector SolveMethod(Solution solution, double accuracy, double? w, out int iterations)
        {
            var l = CreateLsemidiagonalMatrix(solution);
            var h = CreateHsemidiagonalMatrix(solution);
            var matrixBNorm = solution.matrixB.SumOfSquares();
            DenseVector vectorX;
            DenseVector vectorXk = DenseVector.OfVector(solution.vectorC);

            DenseMatrix matrix;

            iterations = 0;
            do
            {
                iterations++;
                matrix = DenseMatrix.OfMatrix((DenseMatrix.CreateIdentity(solution.size) - h).Inverse());

                vectorX = vectorXk;
                vectorXk = DenseVector.OfVector(matrix * l * vectorX + matrix * solution.vectorC);

                if (w != null)
                {
                    vectorXk = vectorXk * w.Value + (1 - w.Value) * vectorX;
                }
            } while ((vectorXk - vectorX).SumOfSquares() > (matrixBNorm / (1 - matrixBNorm)) * accuracy &&
                     iterations < maxIteration);

            return vectorXk;
        }

        private DenseMatrix CreateLsemidiagonalMatrix(Solution sle)
        {
            var result = DenseMatrix.OfMatrix(sle.matrixB);
            for (int i = 0; i < result.RowCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    result[i, j] = 0;
                }
            }
            return result;
        }

        private DenseMatrix CreateHsemidiagonalMatrix(Solution sle)
        {
            var result = DenseMatrix.OfMatrix(sle.matrixB);
            for (int i = 0; i < result.RowCount; i++)
            {
                for (int j = i; j < result.ColumnCount; j++)
                {
                    result[i, j] = 0;
                }
            }
            return result;
        }
    }
}