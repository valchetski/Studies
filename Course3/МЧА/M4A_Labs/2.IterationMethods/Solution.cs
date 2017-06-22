using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2
{
    public class Solution
    {
        public readonly int size;
        public readonly DenseMatrix matrixB;
        public readonly DenseVector vectorC;

        public Solution(int size, double[] matrixB, double[] vectroC)
            : this(size, new DenseMatrix(size, size, matrixB), new DenseVector(vectroC))
        {
        }

        public Solution(int size, DenseMatrix matrixB, DenseVector vectorC)
        {
            this.size = size;
            this.vectorC = vectorC;
            this.matrixB = matrixB;
        }
    }
}