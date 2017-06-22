using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.SolveMethods
{
    public abstract class Solver
    {
        public int maxIteration = 200;

        public abstract DenseVector Solve(Solution solution, double accuracy, out int iterations);

        public DenseVector SolveWithRelaxation(Solution solution, double accuracy, out int iterations)
        {
            DenseVector answer;
            DenseVector minAnswer = null;
            int minIterations = int.MaxValue;
            for (double w = 0.1; w < 2; w += 0.1)
            {
                if (w.Equals(1) == false)
                {
                    answer = SolveWithRelaxation(solution, accuracy, w, out iterations);
                    if (iterations < minIterations)
                    {
                        minIterations = iterations;
                        minAnswer = answer;
                    }
                }
            }

            iterations = minIterations;
            return minAnswer;
        }

        protected abstract DenseVector SolveWithRelaxation(Solution sle, double accuracy, double w, out int iterations);
    }
}