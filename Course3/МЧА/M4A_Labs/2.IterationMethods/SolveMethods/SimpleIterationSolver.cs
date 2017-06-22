using System;
using Lab2.Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.SolveMethods
{
    public class SimpleIterationSleSolver : Solver
    {
        public override DenseVector Solve(Solution solution, double accuracy, out int iterations)
        {
            return SolveMethod(solution, accuracy, out iterations, null);
        }

        protected override DenseVector SolveWithRelaxation(Solution solution, double accuracy, double w, out int iterations)
        {
            double? relaxationParametr = w;
            return SolveMethod(solution, accuracy, out iterations, relaxationParametr);
        }

        private DenseVector SolveMethod(Solution solution, double accuracy, out int iterations, double? w)
        {
            Double matrixBNorm = solution.matrixB.SumOfSquares();
            DenseVector vectorX;
            DenseVector vectorXk = DenseVector.OfVector(solution.vectorC);
            iterations = 0;
            do
            {
                iterations++;
                vectorX = vectorXk;
                vectorXk = solution.matrixB * vectorX + solution.vectorC;
                if (w != null)
                {
                    vectorXk = vectorXk * w.Value + (1 - w.Value) * vectorX;
                }
            } while ((vectorXk - vectorX).SumOfSquares() >(matrixBNorm / (1 - matrixBNorm)) * accuracy && iterations < maxIteration);
            return vectorXk;
        }
    }
}