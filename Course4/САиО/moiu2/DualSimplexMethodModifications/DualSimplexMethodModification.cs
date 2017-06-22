using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Facet.Combinatorics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DualSimplexMethodModifications
{
    public class DualSimplexMethodModification
    {
        #region Private fields

        protected DenseMatrix _matrixA;
        private DenseMatrix _matrixB;
        protected DenseVector _vectorB;
        protected DenseVector _vectorC;
        private DenseVector _yBaseVector;
        private DenseVector _pseudoPlanB;
        protected List<int> _baseIndexes;
        private List<double> _baseEstimations;
        protected DenseVector _dMin;
        protected DenseVector _dMax;
        private List<int> _jNotBPlus;
        private List<int> _jNotBMinus;
        protected int Rows, Columns;

        private const int MaxIterationsCount = 10000;
        private const double Eps = 0.00001;

        #endregion

        #region Public fields
        public string DetailedSolution { get; private set; }
        #endregion

        #region Constructors

        public DualSimplexMethodModification(double[,] a, double[] b, double[] c, List<int> baseIndexes, double[] dMin, double[] dMax)
        {
            _matrixA = DenseMatrix.OfArray(a);
            _vectorB = DenseVector.OfArray(b);
            _vectorC = DenseVector.OfArray(c);
            _baseIndexes = new List<int>(baseIndexes);
            _baseIndexes.Sort();
            _dMin = DenseVector.OfArray(dMin);
            _dMax = DenseVector.OfArray(dMax);
            Rows = _matrixA.RowCount;
            Columns = _matrixA.ColumnCount;
        }

        #endregion

        #region Public methods

        public double[] Solve()
        {
            DetailedSolution = "";
            DenseVector pseudoPlan = null;

            Step1CalculateB();
            _yBaseVector = GetFirstBasePlan();
            CalculateBaseEstimations();

            var iterationsCount = 0;
            while (iterationsCount++ < MaxIterationsCount)
            {
                DetailedSolution += $"Iteration №:{iterationsCount}\n";
                DetailedSolution += $"m-vector(y base plan):\n{ToString(_yBaseVector)}\n";
                DetailedSolution += $"Jb:\n{_baseIndexes.Aggregate("", (acc, ind) => acc + ind + ", ")}\n";

                Step2CalculatePseudoPlan();
                DetailedSolution += $"Pseudo plan:\n{ToString(_pseudoPlanB)}\n";
                if (Step3CheckForOptimum())
                {
                    pseudoPlan = BuildFullPlan(_pseudoPlanB);
                    DetailedSolution += $"Solution:\nTarget function: {Math.Round(CalculateTargetFunc(pseudoPlan), 2)}\n";
                    DetailedSolution += $"Pseudo: {ToString(pseudoPlan)}";
                    break;
                }

                var k = Step4FindK();
                var jK = _baseIndexes[k];
                int mJk;
                DenseVector deltaY;
                Dictionary<int, double> estimations;
                Step5GetMVectorAndEstimations(k, out deltaY, out estimations, out mJk);

                var step4Res = Step6GetMinimum(estimations);
                var sigma0 = step4Res.Key;
                var j0 = step4Res.Value;
                //step7
                if (sigma0 == double.MaxValue)
                {
                    DetailedSolution += "Solution doesn't exists(inconsistent)";
                    break;
                }


                DetailedSolution += $"Sigma0: {sigma0}\n";
                DetailedSolution += $"j0: {j0}\n";
                Step8RecalculateCoplan(k, jK, estimations, sigma0);
                Step9RecalculatePlan(k, j0);
                Step10(mJk, j0, jK);
                Step1CalculateB();
            }
            return pseudoPlan?.ToArray();
        }

        public IEnumerable<int> GenerateBaseIndexes()
        {
            var indexes = Enumerable.Range(0, _matrixA.ColumnCount).ToList();
            foreach (IEnumerable<int> baseIndexes in new Combinations<int>(indexes, _matrixA.RowCount))
            {
                List<DenseVector> cols = baseIndexes.Select(index => (DenseVector)_matrixA.Column(index)).ToList();
                DenseMatrix baseA = DenseMatrix.OfColumns(_matrixA.RowCount, cols.Count, cols);
                if (Math.Abs(baseA.Determinant()) > 0.001) return baseIndexes;
            }
            return null;
        }

        public double CalculateTargetFunc(DenseVector x)
        {
            if (x == null) return 0;
            var result = _vectorC.Select((t, i) => t*x[i]).Sum();
            if (Math.Abs(result) < 0.0001)
                result = 0;
            return result;
        }

        #endregion

        #region Private methods

        private void CalculateBaseEstimations()
        {
            _baseEstimations = new List<double>(_matrixA.ColumnCount);
            _jNotBPlus = new List<int>();
            _jNotBMinus = new List<int>();

            for (var i = 0; i < _matrixA.ColumnCount; i++)
            {
                _baseEstimations.Add(_yBaseVector * _matrixA.Column(i) - _vectorC[i]);
                if (!_baseIndexes.Contains(i))
                {
                    if (IsZero(_baseEstimations[i]) || _baseEstimations[i] > 0)
                    {
                        _jNotBPlus.Add(i);
                    }
                    else
                    {
                        _jNotBMinus.Add(i);
                    }
                }
            }
        }

        private DenseVector GetFirstBasePlan()
        {
            var cB = new DenseVector(_baseIndexes.Count);

            for (var i = 0; i < _baseIndexes.Count; i++)
            {
                cB[i] = _vectorC[_baseIndexes[i]];
            }
            return cB * _matrixB;
        }

        private DenseVector BuildFullPlan(DenseVector basePlan)
        {
            var fullPlan = new DenseVector(_matrixA.ColumnCount);

            for (var i = 0; i < basePlan.Count; i++)
            {
                fullPlan[_baseIndexes[i]] = basePlan[i];

            }

            for (var i = 0; i < fullPlan.Count; i++)
            {
                if (!_baseIndexes.Contains(i))
                {
                    fullPlan[i] = _jNotBMinus.Contains(i) ? _dMax[i] : _dMin[i];
                }
            }
            return fullPlan;
        }

        private void Step2CalculatePseudoPlan()
        {
            var newB = DenseVector.OfVector(_vectorB);

            for (var i = 0; i < _matrixA.ColumnCount; i++)
            {
                if (!_baseIndexes.Contains(i))
                {
                    var tmp = _jNotBPlus.Contains(i) ? _dMin[i] : _dMax[i];
                    newB = (DenseVector)newB.Add(_matrixA.Column(i) * tmp * (-1));
                }
            }

            _pseudoPlanB = _matrixB * newB;
        }

        private bool Step3CheckForOptimum()
        {
            var isOptimum = true;
            for (var i = 0; i < _pseudoPlanB.Count; i++)
            {
                isOptimum &= IsLessOrEqualZero((_dMin[_baseIndexes[i]] - _pseudoPlanB[i])) && IsGreaterOrEqualZero((_dMax[_baseIndexes[i]] - _pseudoPlanB[i]));
            }
            return isOptimum;
        }

        //return k. 0 <= k < |Jb|. Jb[k] = jK
        private int Step4FindK()
        {
            for (var i = 0; i < _pseudoPlanB.Count; i++)
            {
                if (!(IsLessOrEqualZero((_dMin[_baseIndexes[i]] - _pseudoPlanB[i])) && IsGreaterOrEqualZero((_dMax[_baseIndexes[i]] - _pseudoPlanB[i]))))
                {
                    return i;
                }
            }
            throw new Exception("Step 4 failed");
        }

        private void Step5GetMVectorAndEstimations(int k, out DenseVector deltaY, out Dictionary<int, double> estimations, out int mJk)
        {
            mJk = IsLessZero(_pseudoPlanB[k] - _dMin[_baseIndexes[k]]) ? 1 : -1;

            estimations = new Dictionary<int, double>();

            var eS = new DenseVector(_baseIndexes.Count) { [k] = 1 };
            deltaY = eS * _matrixB * mJk;

            for (var j = 0; j < _matrixA.ColumnCount; j++)
            {
                if (!_baseIndexes.Contains(j))
                {
                    var mJ = deltaY * _matrixA.Column(j);
                    estimations.Add(j, mJ);
                }
            }
        }

        //return (sigma0, j0)
        private KeyValuePair<double, int> Step6GetMinimum(Dictionary<int, double> estimations)
        {
            var sigma0 = double.MaxValue;
            var j0 = -1;

            foreach (var mJ in estimations)
            {
                if ((_jNotBPlus.Contains(mJ.Key) && IsLessZero(mJ.Value)) || (_jNotBMinus.Contains(mJ.Key) && IsGreaterZero(mJ.Value)))
                {
                    var sigma = -_baseEstimations[mJ.Key] / mJ.Value;
                    if (sigma < sigma0)
                    {
                        sigma0 = sigma;
                        j0 = mJ.Key;
                    }
                }
            }
            return new KeyValuePair<double, int>(sigma0, j0);
        }

        private void Step8RecalculateCoplan(int k, int mJk, Dictionary<int, double> estimations, double sigma0)
        {
            for (var i = 0; i < _matrixA.ColumnCount; i++)
            {
                if (_baseIndexes.Contains(i) && _baseIndexes[k] != i)
                {
                    _baseEstimations[i] = 0;
                }
                else
                {
                    double tmp;
                    if (_baseIndexes[k] == i)
                    {
                        tmp = sigma0 * mJk;
                    }
                    else
                    {
                        tmp = sigma0 * estimations[i];
                    }
                    _baseEstimations[i] = _baseEstimations[i] + tmp;
                }
            }
        }

        private void Step9RecalculatePlan(int k, int j0)
        {
            _baseIndexes[k] = j0;
            _baseIndexes.Sort();
        }

        private void Step10(int mJk, int j0, int jK)
        {
            if (mJk == 1)
            {
                if (_jNotBPlus.Contains(j0))
                {
                    _jNotBPlus.Remove(j0);
                    _jNotBPlus.Add(jK);
                }
                else
                {
                    _jNotBPlus.Add(jK);
                }
            }
            else
            {
                if (_jNotBPlus.Contains(j0))
                {
                    _jNotBPlus.Remove(j0);
                }
            }
            _jNotBMinus.Clear();
            for (var i = 0; i < _matrixA.ColumnCount; i++)
            {
                if (!_baseIndexes.Contains(i) && !_jNotBPlus.Contains(i))
                {
                    _jNotBMinus.Add(i);
                }
            }
        }

        private void Step1CalculateB()
        {
            var aB = new DenseMatrix(_matrixA.RowCount, _baseIndexes.Count);//basic matrix

            //aB = (Aj, j belongs jB)
            for (var i = 0; i < _baseIndexes.Count; i++)
            {
                aB.SetColumn(i, _matrixA.Column(_baseIndexes[i]));
            }

            _matrixB = (DenseMatrix)aB.Inverse();
        }

        public static string ToString(DenseMatrix matrix)
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

        public static string ToString(DenseVector vector)
        {
            var result = vector.Aggregate("", (current, t) => current + (Math.Round(t, 2) + " "));
            result += "\n";
            return result;
        }


        #region double comparis

        private static bool IsZero(double d)
        {
            return -Eps < d && d < Eps;
        }
        public static bool IsGreaterZero(double d)
        {
            return d > Eps;
        }
        public static bool IsLessZero(double d)
        {
            return d < -Eps;
        }
        private static bool IsGreaterOrEqualZero(double d)
        {
            return IsZero(d) || IsGreaterZero(d);
        }
        private static bool IsLessOrEqualZero(double d)
        {
            return IsZero(d) || IsLessZero(d);
        }

        #endregion

        #endregion
    }
}
