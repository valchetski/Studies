using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab3.Models.Solver
{
    public interface IEigenvectorsSolver
    {
        IList<DenseVector> Solve(DenseMatrix matrixA, out IList<DenseMatrix> matrixAList, out IList<double> eigenvalues);
    }
}