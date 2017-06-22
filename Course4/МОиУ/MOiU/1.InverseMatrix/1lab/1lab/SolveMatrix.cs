using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;

namespace _1lab
{
    class SolveMatrix
    {
        private List<int> listJ;
        private DenseMatrix matrixB;
        private DenseMatrix matrixC1;
        private DenseMatrix matrixC;
        private List<int> listS;
        private int matrixSize;

        public string Report { get; private set; }

        public double[,] Solve(double[,] matrix)
        {
            Report = "";

            matrixC1 = DenseMatrix.OfArray(matrix);
            matrixSize = matrixC1.RowCount;

            matrixC = IdentityMatrix();
            matrixB = IdentityMatrix();

            listJ = new List<int>();
            for(int i = 0; i < matrixSize; i++)
            {
                listJ.Add(i);                
            }

            listS = new List<int>();
            for (int i = 0; i < matrixSize; i++)
            {
                listS.Add(0);
            }

            Report += string.Format("Исходные данные:\n C(0) =\n{0}\n B(0) =\n{1}\n J(0) = {2}\n s(0) = {3}",
                        MatrixToString(matrixC), MatrixToString(matrixB), ListToString(listJ), ListToString(listS));

            for (int iteration = 0; iteration < matrixSize; iteration++)
            {
                int k = GetK(iteration);
                if(k > -1)
                {
                    for(int i = 0; i < matrixSize; i++)
                    {
                        matrixC[i, iteration] = matrixC1[i, k];
                    }

                    listJ.Remove(k);

                    listS[k] = iteration;

                    matrixB = GetNextB(iteration);

                    Report += string.Format("\nИтерация: {0}\n C({1}) =\n{2}\n B({1}) =\n{3}\n J({1}) = {4}\n s({1}) = {5}",
                        iteration, iteration + 1, MatrixToString(matrixC), MatrixToString(matrixB), ListToString(listJ), ListToString(listS));            
                }
                else
                {
                    return null;
                }
            }

            DenseMatrix newMatrixB = new DenseMatrix(matrixSize, matrixSize);
            for (int i = 0; i < listS.Count; i++)
            {
                var vector = matrixB.Row(listS[i]);
                for(int j = 0; j < listS.Count; j++)
                {
                    newMatrixB[i, j] = vector[j];
                }
            }

            return newMatrixB.ToArray();
        }

        private DenseMatrix GetNextB(int iteration)
        {
            var vectorK = matrixB * matrixC.Column(iteration);
            double vectorKi = vectorK[iteration];
            vectorK[iteration] = -1;
            vectorK = -(1 / vectorKi) * vectorK;

            DenseMatrix matrixD = IdentityMatrix();
            for (int i = 0; i < matrixSize; i++)
            {
                matrixD[i, iteration] = vectorK[i];
            }

            DenseMatrix nextMatrixB = matrixD * matrixB;
            return nextMatrixB;
        }

        private int GetK(int iteration)
        {
            int k = -1;
            for (int i = 0; i < listJ.Count; i++)
            {
                double alpha = IdentityVector(iteration) * matrixB * matrixC1.Column(listJ[i]);
                if(alpha != 0)
                {
                    k = listJ[i];
                    break;
                }
            }
            return k;
        }

        private DenseMatrix IdentityMatrix()
        {
            DenseMatrix matrix = new DenseMatrix(matrixSize, matrixSize);
            for(int i = 0; i < matrixSize; i++)
            {
                matrix[i, i] = 1;
            }
            return matrix;
        }

        private DenseVector IdentityVector(int positionOfOne)
        {
            DenseVector vector = new DenseVector(matrixSize);
            vector[positionOfOne] = 1;
            return vector;
        }

        private string MatrixToString(DenseMatrix matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    result += matrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }

        private string ListToString(List<int> list)
        {
            string result = "";

            for (int i = 0; i < list.Count; i++)
            {
                result += list[i] + " ";
            }
            result += "\n";

            return result;
        }

    }
}
