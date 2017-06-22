using System.Collections.Generic;
using System.Linq;
using DualSimplexMethodModifications;
using Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CuttingPlaneMethod
{
    public class Gomory : DualSimplexMethodModification
    {
        #region Public fields
        public string DetailedSolutionGomory { get; set; }
        #endregion

        #region Constructors
         public Gomory(double[,] a, double[] b, double[] c, List<int> baseIndexes, double[] dMin, double[] dMax) : base(a, b, c, baseIndexes, dMin, dMax) { }

          public Gomory(Gomory prevtask)
              : this(
                  prevtask._matrixA.ToArray(), prevtask._vectorB.ToArray(), prevtask._vectorC.ToArray(),
                  prevtask._baseIndexes, prevtask._dMin.ToArray(), prevtask._dMax.ToArray())
          {
          }
        #endregion

        public DenseVector SolveByGomory()
        {
            Gomory oldTask = null;
            _baseIndexes = GenerateBaseIndexes() as List<int>;
            var task = this;
            DenseVector solution;
            int iteration = 0;

            while (true)
            {
                iteration++;
                solution = task.Solve();
                if (solution == null) return null;

                DetailedSolutionGomory += TaskInformation(task);
                DetailedSolutionGomory += $"Solution: {solution} \n";
                DetailedSolutionGomory += $"Indecies: {string.Join(" ", task._baseIndexes)} \n";

                var colIndex = task._matrixA.ColumnCount - 1;
                while (colIndex >= _matrixA.ColumnCount)
                {
                    if (task._baseIndexes.Contains(colIndex))
                    {
                        var rowIndex = GetAfficientIndex(task, colIndex);

                        var rows = Enumerable.Range(0, task._matrixA.RowCount).Where(value => value != rowIndex).ToList();
                        var cols = Enumerable.Range(0, task._matrixA.ColumnCount).Where(value => value != colIndex).ToList();

                        task._matrixA = task._matrixA.SelectRows(rows).SelectColumns(cols);
                        task._vectorB = task._vectorB.Select(rows);
                        task._vectorC = task._vectorC.Select(cols);
                        task._baseIndexes.Remove(colIndex);
                    }
                    colIndex--;
                }

                if (solution.IsInteger())
                {
                    return DenseVector.Create(_matrixA.ColumnCount, i => solution[i]);
                }

                var k = -1;
                if(true)
                //if (oldTask != null && oldTask.CalculateTargetFunc(oldTask.Solve()) == task.CalculateTargetFunc(solution))
                {
                    for (int i = 0; i < solution.Count; i++)
                    {
                        if (!solution[i].IsInteger())
                        {
                            k = i;
                            break;
                        }
                    }
                }
                else
                {
                    double maxFractional = 0.0;
                    foreach (var baseIndex in task._baseIndexes)
                    {
                        if (!solution[baseIndex].IsInteger())
                        {
                            double fractional = solution[baseIndex].Frac();
                            if (fractional > maxFractional)
                            {
                                k = baseIndex;
                                maxFractional = fractional;
                            }
                        }
                    }
                }

                var AbInverse = task._matrixA.SelectColumns(task._baseIndexes).Inverse();
                var y = AbInverse.Row(task._baseIndexes.IndexOf(k));
                var temp = y*task._vectorB;
                double fractionalBeta = (y * task._vectorB).Frac();


                var temp1 = (AbInverse*task._matrixA).Row(task._baseIndexes.IndexOf(k));

                DenseVector vectorFj = DenseVector.Create(task._matrixA.ColumnCount,
                    i => -(AbInverse*task._matrixA).Row(task._baseIndexes.IndexOf(k))[i].Frac());
                oldTask = new Gomory(task);

                DenseMatrix matrixA = (DenseMatrix)task._matrixA.InsertRow(task._matrixA.RowCount, vectorFj);
                matrixA = (DenseMatrix)matrixA.InsertColumn(task._matrixA.ColumnCount, new DenseVector(matrixA.RowCount) { [matrixA.RowCount - 1] = 1 });
                DenseVector vectorB = task._vectorB.Insert(-fractionalBeta);
                DenseVector vectorC = task._vectorC.Insert();
                DenseVector dMin = task._dMin.Insert();
                DenseVector dMax = task._dMax.Insert(double.PositiveInfinity);
                task._baseIndexes.Add(matrixA.ColumnCount - 1);
                task = new Gomory(matrixA.ToArray(), vectorB.ToArray(), vectorC.ToArray(), task._baseIndexes, dMin.ToArray(), dMax.ToArray());              
            }
        }


        private static int GetAfficientIndex(Gomory task, int colIndex)
        {
            int index = -1;
            for (int i = 0; i < task._matrixA.RowCount; i++)
            {
                if (task._matrixA.Row(i)[colIndex] == 1)
                    index = i;
            }
            return index;
        }

        private static string TaskInformation(Gomory task)
        {
            var s = "--------------\nTask:\n";
            s += "C:\n" + task._vectorC.ToVectorString(99, 99) + "\n";
            s += "A:\n" + task._matrixA.ToMatrixString(99, 99) + "\n";
            s += "B:\n" + task._vectorB.ToVectorString(99, 99) + "\n";
            /*for (int i = 0; i < _matrixA.ColumnCount; i++)
            {
                //s += string.Format ("{0} <= X{1} <= {2}\n", task.DL [i], task.i, task.DR [i]);
            }*/
            return s;
        }
    }
}
