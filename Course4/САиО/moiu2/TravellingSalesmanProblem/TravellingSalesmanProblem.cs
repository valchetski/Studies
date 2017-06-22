using System.Collections.Generic;
using System.Linq;
using AssignmentProblem;

namespace TravellingSalesmanProblem
{
    public class TravellingSalesmanProblem
    {
        #region Public fields

        public int N { get; set; }
        public int[,] C { get; set; }
        public int[,] X { get; set; }
        public string DetailedSolutionTravellingSalesman { get; set; }

        #endregion

        #region Copy constructor

        public TravellingSalesmanProblem CopyProblem(TravellingSalesmanProblem previousProplem)
        {
            var newProblem = new TravellingSalesmanProblem
            {
                N = N,
                C = new int[N, N],
                X = new int[N, N]
            };

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    newProblem.C[i, j] = C[i, j];
                }
            }
            return newProblem;
        }

        #endregion

        public List<int> SolveProblemByBranching()
        {
            for (var i = 0; i < N; i++)
            {
                C[i, i] = 99999;
            }
            
            var R0 = int.MaxValue; // starting estimation          
            List<int> bestSolution = null; // best solution        
            var problems = new Queue<TravellingSalesmanProblem>(); // task queue
            
            problems.Enqueue(CopyProblem(this));

            while (true)
            {
                DetailedSolutionTravellingSalesman += "Task\n";

                // no problems, end solution
                if (problems.Count == 0)
                {
                    break;
                }

                var problem = problems.Dequeue();

                // create assignment problem and solve it
                var assignments = new AssignmentProblems { C = problem.C, N = N };
                var solution = assignments.Solve();

                DetailedSolutionTravellingSalesman += assignments.DetailedSolutionAssignment;

                var totalCost = 0;              
                for (var i = 0; i < N; i++) // find way cost 
                {
                    totalCost += C[i, solution[i]];
                }

                if (totalCost >= R0) // cost don't less then current, solve another problem
                {
                    continue;
                }

                // create matrix X from answer of assignment problem
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        problem.X[i, j] = solution[i] == j ? 1 : 0;
                    }
                }

                // if cycle length == N, remember solution
                if (problem.FindCycle(0).Count == N)
                {
                    R0 = totalCost;
                    bestSolution = problem.FindCycle(0);
                    continue;
                }

                var minCycle = problem.FindCycle(0);                
                for (var i = 0; i < N; i++)  // find minimal length cycle
                {
                    var cycle = problem.FindCycle(i);
                    if (cycle.Count < minCycle.Count)
                    {
                        minCycle = cycle;
                    }
                }

                // for all edges in minimal cycle set big cost and put in queue
                for (var i = 0; i < minCycle.Count; i++)
                {
                    var newProblem = CopyProblem(problem);
                    newProblem.C[minCycle[i], minCycle[(i + 1) % minCycle.Count]] = 99999;
                    problems.Enqueue(newProblem);
                }
            }
            return bestSolution;
        }

        public List<int> FindCycle(int start)
        {
            var res = new List<int>();
            var i = start;
            while (true)
            {
                if (res.Contains(i))
                {
                    break;
                }
                res.Add(i);

                for (var j = 0; j < N; j++)
                {
                    if (X[i, j] == 1)
                    {
                        i = j;
                        break;
                    }
                }
            }
            return res;
        }

        public int GetCycleCost(List<int> cycle)
        {
            var totalCost = 0;
            for (var i = 0; i < N; i++)
            {
                totalCost += C[cycle[i], cycle[(i + 1)%cycle.Count]];
            }
            return totalCost;
        }

        public string ToStringCycle(List<int> cycle)
        {
            var s = cycle.Aggregate("", (current, i) => current + (" -> " + (i + 1)));
            s += " = " + GetCycleCost(cycle);
            return s;
        }
    }
}
