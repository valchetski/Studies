using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.ConversionMethods
{
    public class IdentityMatrixConversion : Conversion
    {
        public override Solution Transform(int size, DenseMatrix matrixA, DenseVector vectorB)
        {
            var matrixB = DenseMatrix.CreateIdentity(size) - matrixA;
            var vectorC = vectorB;

            return new Solution(size, matrixB, vectorC);
        }
    }
}