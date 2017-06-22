using MathNet.Numerics.LinearAlgebra.Double;

namespace _1.Gauss.SolutionMethods
{
    public class GaussLeadingElementSolution : GaussSolution
    {
        public GaussLeadingElementSolution(DenseMatrix matrixA, DenseMatrix matrixB, double epsilon)
            : base(matrixA, matrixB, epsilon)
        {
        }
    }
}