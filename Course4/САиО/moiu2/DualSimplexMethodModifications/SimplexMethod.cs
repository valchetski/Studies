using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DualSimplexMethodModifications
{
    public class SimplexMethod
    {
        #region Private fields

        protected DenseMatrix _matrixA;
        private DenseMatrix _matrixB;
        protected DenseVector _vectorB;
        protected DenseVector _vectorC;
        protected DenseVector _xBaseVector;
        protected List<int> _baseIndexes;
        protected int Rows, Columns;
        protected double TargFunc;

        private const int MaxIterationsCount = 10000;
        private const double Eps = 0.0000000000001;

        #endregion

        #region Public fields
        public string DetailedSolution { get; private set; }

        #endregion

        #region Constructors

        public SimplexMethod(double[,] a, double[] c, double[] xBase, List<int> baseIndexes) : this(a, null, c, xBase, baseIndexes)
        {

        }

        public SimplexMethod(double[,] a, double[] b, double[] c, double[] xBase, List<int> baseIndexes)
        {
            _matrixA = DenseMatrix.OfArray(a);
            if (b != null)
            {
                _vectorB = DenseVector.OfArray(b);
            }
            _vectorC = DenseVector.OfArray(c);
            if (xBase != null)
            {
                _xBaseVector = DenseVector.OfArray(xBase);
            }
            else
            {
                //_xBaseVector = DenseVector.Create(_vectorC.Count);
            }
            if (baseIndexes != null)
            {
                _baseIndexes = new List<int>(baseIndexes);
                _baseIndexes.Sort();
            }
            Rows = _matrixA.RowCount;
            Columns = _matrixA.ColumnCount;
        }

        #endregion

        #region Public methods

        public double[] Solve()
        {
            DetailedSolution = "";

            var iterationsCount = 0;
            while (iterationsCount++ < MaxIterationsCount)
            {
                DetailedSolution += $"{iterationsCount} iteration:\n\n";
                DetailedSolution += $"Matrix A:\n\n{ToString(_matrixA)}\n";
                DetailedSolution += $"Basic plan X0:\n\n{ToString(_xBaseVector)}\n";

                Step6CalculateB();//Basic matrix and inverse( matrix B)
                DetailedSolution += $"Matrix B:\n\n{ToString(_matrixB)}\n";

                var estimations = Step1GetEstimations();//potential vector and estimates
                DetailedSolution += "Estimations:\n\n";
                foreach (var deltaI in estimations)
                {
                    DetailedSolution += $"delta{deltaI.Key} = {Math.Round(deltaI.Value, 2)}\n";
                }

                if (Step2IsPlanOptimal(estimations))//check is vector optimal
                {
                    var x = _xBaseVector;
                    DetailedSolution += "\nPlan is optimal";
                    TargFunc = CalculateTargetFunc(_xBaseVector);
                    return x.ToArray();
                }

                var step3Res = Step3GetZAndJ0(estimations);//vector Z and check if high limited(has positive values) 
                if (step3Res == null)
                {
                    return null;
                }

                var z = step3Res.Item1;
                DetailedSolution += $"\nZ vector:\n\n{ToString(z)}";
                int j0 = step3Res.Item2;
                DetailedSolution += $"\nJ0 = {j0}";

                var step4Res = Step4GetNewBaseIndex(z);//find minimum (teta)
                int s = step4Res.Item1;
                double tet0 = step4Res.Item2;
                DetailedSolution += $"\ns = {s}";
                DetailedSolution += $"\nteta0 = {Math.Round(tet0, 2)}";

                Step5RecalculateBasePlanAndBasis(j0, z, s, tet0);//find new basic plan by rules

                DetailedSolution += $"\n\nNew basic plan X0:\n\n{ToString(_xBaseVector)}";
                string baseInd = _baseIndexes.Aggregate("", (current, bi) => current + (bi + ", "));
                DetailedSolution += $"\nJb = {baseInd}\n\n";
            }
            return null;
        }

        public double CalculateTargetFunc(DenseVector x)
        {
            return _vectorC.Select((t, i) => t * x[i]).Sum();
        }

        #endregion

        #region Private methods

        private Dictionary<int, double> Step1GetEstimations()
        {
            var cB = new DenseVector(_baseIndexes.Count);//Basic vector cB = (cj, j belongs jB)

            for (var i = 0; i < _baseIndexes.Count; i++)
            {
                cB[i] = _vectorC[_baseIndexes[i]];
            }

            var u = cB * _matrixB;//vector potentional U


            DetailedSolution += $"Vector potentials U:\n\n{ToString(u)}\n";

            var estimations = new Dictionary<int, double>();//delta j (estimations)
            for (var i = 0; i < _vectorC.Count; i++)
            {
                if (_baseIndexes.Contains(i)) continue;
                var nextEst = u * _matrixA.Column(i) - _vectorC[i]; //deltaJ = u * Aj - cj, j belongs J\jb
                estimations.Add(i, Math.Round(nextEst, 2));
            }
            return estimations;
        }

        private bool Step2IsPlanOptimal(Dictionary<int, double> estimations)
        {
            //deltaJ >= 0, j прин. J\jB => план оптимальный
            return estimations.All(delta => delta.Value >= 0);
        }

        //return (z, j0)
        //return null if no elements matching to condition
        private Tuple<DenseVector, int> Step3GetZAndJ0(Dictionary<int, double> estimations)
        {
            return (from delta in estimations
                    where delta.Value < 0
                    select delta.Key into j0 //find index j0 where deltaJ0 < 0
                    let z = _matrixB * (DenseVector)_matrixA.Column(j0)
                    where z.Any(zi => zi > 0) //if zi > 0 task has solution
                    select new Tuple<DenseVector, int>(z, j0)).FirstOrDefault();
        }

        //return (s, tet0)
        private Tuple<int, double> Step4GetNewBaseIndex(DenseVector z)
        {
            //teta0 = x[j[i]] / z[i], z[i] > 0
            //s - index when conditions is perfomed
            double min = Double.MaxValue;
            var s = -1;
            for (var i = 0; i < z.Count; i++)
            {
                if (z[i] > 0)
                {
                    var jI = _baseIndexes[i];
                    var tet0 = _xBaseVector[jI] / z[i];
                    if (tet0 < min)
                    {
                        min = tet0;
                        s = i;
                    }
                }
            }
            if (s == -1)
            {
                throw new Exception("Step4: s not founded");
            }
            return new Tuple<int, double>(s, min);
        }

        private void Step5RecalculateBasePlanAndBasis(int j0, DenseVector z, int s, double tet0)
        {
            //xj = 0, j belongs Jн\J0
            for (var i = 0; i < _xBaseVector.Count; i++)
            {
                if (!_baseIndexes.Contains(i) && i != j0)
                {
                    _xBaseVector[i] = 0;
                }
            }

            _xBaseVector[j0] = tet0;

            //x[Ji] = x[Ji] - teta0 * zi 
            for (var i = 0; i < z.Count; i++)
            {
                var jI = _baseIndexes[i];
                _xBaseVector[jI] = jI == j0 ? 0 : _xBaseVector[jI] - tet0 * z[i];
            }

            //Jb = (Jb\Js) js = j0
            _baseIndexes[s] = j0;
            _baseIndexes.Sort();
        }

        private void Step6CalculateB()
        {
            var aB = new DenseMatrix(_matrixA.RowCount, _baseIndexes.Count);//basic matrix

            //aB = (Aj, j belongs jB)
            for (var i = 0; i < _baseIndexes.Count; i++)
            {
                aB.SetColumn(i, _matrixA.Column(_baseIndexes[i]));
            }

            _matrixB = (DenseMatrix)aB.Inverse();
        }

        private static string ToString(DenseMatrix matrix)
        {
            var result = "";
            for (var i = 0; i < matrix.RowCount; i++)
            {
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    result += Math.Round(matrix[i, j], 2) + " ";
                }
                result += "\n";
            }
            return result;
        }

        private static string ToString(DenseVector vector)
        {
            var result = vector.Aggregate("", (current, t) => current + (Math.Round(t, 2) + " "));
            result += "\n";
            return result;
        }

        public Tuple<List<int>, DenseVector, string> FirstPhase(DenseMatrix a, DenseVector b, DenseVector c)
        {
            var m = a.RowCount;
            var n = c.Count;
            var changesign = 0;

            for (var i = 0; i < m; i++)
            {
                if (b[i] < -Eps)
                {
                    b[i] *= -1;
                    changesign = i;
                    for (var j = 0; j < a.ColumnCount; j++)
                    {
                        a[i, j] *= -1;
                    }
                }
            }
            var e = DenseMatrix.CreateDiagonal(m, m, 1);//!!!
            var na = DenseMatrix.OfArray(a.ToArray());

            for (var i = 0; i < e.ColumnCount; i++)
            {
                var vect = (DenseVector)e.Column(i);
                na = (DenseMatrix)na.InsertColumn(na.ColumnCount, vect);
            }

            var nc = new DenseVector(n + m);
            for (var i = 0; i < n + m; i++)
            {
                if (i < n)
                {
                    nc[i] = 0;
                }
                else
                {
                    nc[i] = -1;
                }
            }

            var jb = new List<int>();
            for (var i = n; i < n + m; i++)
            {
                jb.Add(i);
            }
            var xb = e * b;
            var xbb = new DenseVector(nc.Count);
            for (var i = 0; i < jb.Count; i++)
            {
                xbb[jb[i]] = xb[i];
            }
            var sm = new SimplexMethod(na.ToArray(), b.ToArray(), nc.ToArray(), xbb.ToArray(), jb);
            var x = sm.Solve();
            var jbb = sm._baseIndexes;
            var baseplan = sm._xBaseVector;

            /*b[changesign] *= -1;
            for (var j = 0; j < a.ColumnCount; j++)
            {
                a[changesign, j] *= -1;
            }*/

            for (var i = n; i < x.Length; i++)
            {
                if (x[i] > Eps)
                {
                    sm.DetailedSolution += "\nМножество допустимых планов пусто";
                    return new Tuple<List<int>, DenseVector, string>(null, null, sm.DetailedSolution);
                }
            }

            while (!(sm._baseIndexes.Max() < n))
            {
                var mm = sm._baseIndexes.Count;
                var nab = e.Transpose();
                var nab_inv = nab.Inverse();

                for (var k = 0; k < mm; k++)
                {
                    if (jbb[k] >= n)
                    {
                        var e_k = new DenseVector(mm);
                        for (var i = 0; i < mm; i++)
                        {
                            if (i == k)
                            {
                                e_k[i] = 1;

                            }
                            else
                            {
                                e_k[i] = 0;
                            }
                        }
                        for (var i = 0; i < n; i++)
                        {
                            if (!jbb.Contains(i))
                            {
                                if (Math.Abs(e_k * nab_inv * a.Column(i)) > Eps)
                                {
                                    jbb[k] = i;
                                    break;
                                }

                            }
                        }
                        sm.DetailedSolution += $"Условие {jbb[k] - n + 1} линейно зависит от других";

                        var jb_k = jbb[k];
                        for (int i = 0; i < mm; i++)
                        {
                            var bb = new DenseVector(b.ToArray());
                            if (i != jb_k - n)
                            {
                                bb[i] = b[i];
                            }
                        }
                        jbb.Remove(jb_k);
                        for (int i = 0; i < jbb.Count; i++)
                        {
                            if (jbb[i] > jb_k)
                            {
                                jbb[i] -= 1;
                            }
                        }

                        /*na = np.array([na[i] for i in range(m) if i != jb_k - n])
                    na = np.array([na[:, i] for i in range(n + m) if i != jb_k]).transpose()*/
                        break;
                    }
                }
            }
            return new Tuple<List<int>, DenseVector, string>(jbb, baseplan, sm.DetailedSolution);
        }
        #endregion
    }
}
