using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;
using Extensions;
using DualSimplexMethodModifications;

namespace BranchandBound
{
    public class BranchandBound: DualSimplexMethodModification
    {
        #region Protected fields

        protected int ParentIteration;

        #endregion

        #region Public fields
        public string DetailedSolutionBB { get; set; }

        #endregion

        #region Constructors

        public BranchandBound(double[,] a, double[] b, double[] c, List<int> baseIndexes, double[] dMin, double[] dMax) : base(a, b, c, baseIndexes, dMin, dMax) { }

        public BranchandBound(BranchandBound prevtask)
            : this(
                prevtask._matrixA.ToArray(), prevtask._vectorB.ToArray(), prevtask._vectorC.ToArray(),
                prevtask._baseIndexes, prevtask._dMin.ToArray(), prevtask._dMax.ToArray())
        {
        }


        #endregion

        public DenseVector SolveByBranching()
        {
            DetailedSolutionBB += TaskInformation(this);
            var initial = this;

            var counter = 0;

            // Initial task
            var tasks = new List<BranchandBound> {initial};

            // Initial states
            var r0 = double.NegativeInfinity;           // initial R0 = -∞
            var mu0 = 1;                                // μ0 = 1
            var mu = DenseVector.Create(_matrixA.ColumnCount, i => i);  // μ - vector 1..N

            while (true)
            {
                counter++;

                if (tasks.Count == 0)
                {
                    // Tasks ended
                    if (mu0 == 1) // μ0 = 1, solution finded
                    {
                        DetailedSolutionBB += $"Solution:\nOptimal plan: {mu}\n";
                        return mu;
                    }
                    if (mu0 == 0) // μ0 = 0, solution doesn't exist
                    {
                        DetailedSolutionBB += "Solution doesn't exists";
                        return null;
                    }
                }

                // Pop task from queue 
                var task = tasks[0];
                tasks.RemoveAt(0);

                // Solve task
                DenseVector solution = null; 
                if (task.Solve() != null)
                {
                    solution = DenseVector.OfArray(task.Solve());
                }
                var value = (solution != null) ? task.CalculateTargetFunc(solution) : 0; // Find c'x

                DetailedSolutionBB += "====================\n";
                DetailedSolutionBB += $"TASK #{counter} (parent #{task.ParentIteration}), {tasks.Count} LEFT\n";
                DetailedSolutionBB += TaskInformation(task);
                if (solution != null)
                {
                    DetailedSolutionBB += $"\nSolution: {solution}\n";
                    DetailedSolutionBB += $"Value: {value}\n";
                }
                else
                {
                    DetailedSolutionBB += "Solution doesn't exists\n";
                }

                if (solution == null || value <= r0)
                {
                    // Task hasn't solution or find value < r0
                    continue; // New iteration
                }

                if (solution.IsInteger())
                {
                    // Solution is integer
                    mu = solution; // Put it in μ
                    mu0 = 1; // Set μ0
                    r0 = value; // and R0
                    continue; // New iteration
                }

                // Solution isn't integer
                var j0 = -1;
                for (var i = 0; i < _matrixA.ColumnCount; i++)
                {
                    if (!solution[i].IsInteger())
                    {
                        // Find not integer variable
                        j0 = i; // variable index
                        break;
                    }
                }

                // Find new limitations by variable j0
                var l = Math.Floor(solution[j0]);
                if (l < 0 && l > solution[j0])
                {
                    l -= 1;
                }

                // New task №1
                var taskL = new BranchandBound(task);
                taskL._dMax[j0] = l; // change D*[j0]
                taskL.ParentIteration = counter;
                tasks.Add(taskL); // push task in queue

                // New task №2
                var taskR = new BranchandBound(task);
                taskR._dMin[j0] = l + 1; // change D_*[j0]
                taskR.ParentIteration = counter;
                tasks.Add(taskR); // push task in queue
            }
        }

        private static string TaskInformation(BranchandBound task)
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
