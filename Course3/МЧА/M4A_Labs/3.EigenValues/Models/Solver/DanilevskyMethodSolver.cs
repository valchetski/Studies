using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Lab3.Models.Helpers;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab3.Models.Solver
{
    public class DanilevskyMethodSolver : IEigenvectorsSolver
    {
        public IList<DenseVector> Solve(DenseMatrix matrixA, out IList<DenseMatrix> matrixAList, out IList<double> eigenvalues)
        {
            DenseMatrix matrixS;
            DenseMatrix matrixF;
            eigenvalues = FindMatrixFandMatrixS(matrixA, out matrixF, out matrixS, out matrixAList);

            if (eigenvalues != null)
                return null;

            eigenvalues = FindEigenvalues(matrixF);
            return FindEigenvectors(matrixF, matrixS, eigenvalues);
        }

        private DenseMatrix CreateMatrixM(DenseMatrix matrixA, int k)
        {
            var matrixM = DenseMatrix.Identity(matrixA.RowCount);

            for (var colIndex = 0; colIndex < matrixM.ColumnCount; colIndex++)
            {
                if (colIndex != k)
                    matrixM[k, colIndex] = (-1) * matrixA[k + 1, colIndex] / matrixA[k + 1, k];
                else
                    matrixM[k, colIndex] = 1 / matrixA[k + 1, k];
            }

            return matrixM;
        }

        private DenseVector CreateEigenvectorOfMatrixF(double eigenvalue, int size)
        {
            var eigenvector = new DenseVector(size);
            for (int i = size - 1; i >= 0; i--)
            {
                eigenvector[i] = Math.Pow(eigenvalue, size - 1 - i);
            }
            return eigenvector;
        }

        private IList<double> FindMatrixFandMatrixS(DenseMatrix matrixA, out DenseMatrix matrixF, out DenseMatrix matrixS,
                                           out IList<DenseMatrix> matrixAList)
        {
            matrixS = DenseMatrix.Identity(matrixA.RowCount);
            matrixAList = new List<DenseMatrix>(matrixA.RowCount);

            matrixAList.Add(matrixA);

            for (var i = matrixA.RowCount - 2; i >= 0; i--)
            {
                if (matrixA[i + 1, i].IsZero())
                {
                    var permutation = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (matrixA[i + 1, j].IsNotZero())
                        {
                            permutation = true;

                            var matrixT = DenseMatrix.Identity(matrixA.RowCount);
                            matrixT[j, j] = matrixT[i, i] = 0;
                            matrixT[j, i] = matrixT[i, j] = 1;

                            matrixA = matrixT * matrixA;
                            matrixA = matrixA * matrixT;

                            break;
                        }
                    }

                    if (!permutation)
                    {
                        var matrixNewF = (DenseMatrix)matrixA.SubMatrix(i + 1, matrixA.ColumnCount - i - 1, i + 1, -1 + matrixA.ColumnCount - i);
                        DenseMatrix s1, s2, f1, f2;
                        IList<DenseMatrix> l;
                        FindMatrixFandMatrixS(matrixNewF, out f1, out s1, out l);

                        var matrixB = (DenseMatrix)matrixA.SubMatrix(0, i + 1, 0, i + 1);
                        FindMatrixFandMatrixS(matrixB, out f2, out s2, out l);

                        var pol1 = f1.Row(0).ToList();
                        pol1 = pol1.Select(x => -1 * x).ToList();
                        pol1.Insert(0, 1);

                        var pol2 = f2.Row(0).ToList();
                        pol2 = pol2.Select(x => -1 * x).ToList();
                        pol2.Insert(0, 1);

                        matrixA.SetSubMatrix(i + 1, matrixA.ColumnCount - i - 1, i + 1, -1 + matrixA.ColumnCount - i, f1);
                        matrixA.SetSubMatrix(0, i + 1, 0, i + 1, f2);

                        matrixS.SetSubMatrix(i + 1, matrixA.ColumnCount - i - 1, i + 1, -1 + matrixA.ColumnCount - i, s2);
                        matrixS.SetSubMatrix(0, i + 1, 0, i + 1, s2);

                        var pol3 = GetEigenVector(pol1.ToArray(), pol2.ToArray());
                        pol3.RemoveAt(0);
                        pol3 = pol3.Select(x => -1 * x).ToList();
                        matrixA.SetRow(0, pol3.ToArray());

                        matrixF = matrixA;
                        matrixAList.Add(matrixA);
                        
                        return FindEigenvalues(matrixA);
                    }
                }

                var m = CreateMatrixM(matrixA, i);
                matrixS = matrixS * m;
                var mI = DenseMatrix.OfMatrix(m.Inverse());

                matrixA = mI * matrixA;
                matrixA = matrixA * m;

                matrixAList.Add(matrixA);
            }

            matrixF = matrixA;
            return null;
        }

        private IList<double> FindEigenvalues(DenseMatrix matrixF)
        {
            var coef = matrixF.Row(0).ToList();
            coef = coef.Select(x => -1 * x).ToList();
            coef.Insert(0, 1);
            coef.Reverse();

            int iterations;
            return new Bisection().FindRoots(new Equation(coef), -1000000000, 1000000000, out iterations, 0.000001).ToList();
        }

        private IList<DenseVector> FindEigenvectors(DenseMatrix matrixF, DenseMatrix matrixS, IList<double> eigenvalues)
        {
            var eigenvectors = new List<DenseVector>(eigenvalues.Count);

            for (int i = 0; i < eigenvalues.Count; i++)
            {
                var y = CreateEigenvectorOfMatrixF(eigenvalues[i], matrixF.RowCount);
                eigenvectors.Add(matrixS * y);
            }
            return eigenvectors;
        }
    
        private IList<double> GetEigenVector(double[] pol1, double[] pol2)
        {
            var text = pol1.Aggregate("", (current, d) => current + d.StringFormat("{0:0.0}") + " ");
            text += " | ";
            text = pol2.Aggregate(text, (current, d) => current + d.StringFormat("{0:0.0}") + " ");

            var start = new ProcessStartInfo
                {
                    Arguments = "/C python2.7 polmul.py \"" + text + "\"",
                    FileName = @"cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

            using (var process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    var pol = reader.ReadToEnd();
                    pol =
                        pol.Replace(". ", ".0 ")
                              .Replace(".]", ".0")
                              .Replace("[", "")
                              .Replace("]", "")
                              .Replace("\r", "")
                              .Replace("\n", "").Trim();

                    var q = pol.Trim().Replace('.', ',').Split(' ');
                    var result = new List<double>(1);
                    foreach (var ch in q)
                    {
                        double n;
                        if (double.TryParse(ch, out n))
                            result.Add(n);
                    }

                    return result;
                }
            }
        }
    }
}
