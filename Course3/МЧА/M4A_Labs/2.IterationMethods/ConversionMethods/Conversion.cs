using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2.ConversionMethods
{
    public abstract class Conversion
    {
        public abstract Solution Transform(int size, DenseMatrix matrixA, DenseVector vectorB);
    }
}
