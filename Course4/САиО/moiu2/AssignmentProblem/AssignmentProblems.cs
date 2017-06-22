using System;
using System.Collections.Generic;
using System.Linq;
using Extensions.GraphHelper;
using MaximalFlowTask;

namespace AssignmentProblem
{
    public class AssignmentProblems
    {
        #region Public fields

        public int N { get; set; }
        public int[,] C { get; set; }
        public string DetailedSolutionAssignment { get; set; }

        #endregion
        
        public Dictionary<int, int> Solve()
        {
            // in all rows find minimal value and subtract from all row elements
            for (var i = 0; i < N; i++)
            {
                var min = int.MaxValue;
                for (var j = 0; j < N; j++)
                {
                    min = Math.Min(min, C[i, j]);
                }
                for (var j = 0; j < N; j++)
                {
                    C[i, j] -= min;
                }
            }
            LogMatrixC();

            // in all columns find minimal value and subtract from all column elements
            for (var i = 0; i < N; i++)
            {
                var min = int.MaxValue;
                for (var j = 0; j < N; j++)
                {
                    min = Math.Min(min, C[j, i]);
                }
                for (var j = 0; j < N; j++)
                {
                    C[j, i] -= min;
                }
            }
            LogMatrixC();

            var ic = 0;
            while (true)
            {
                ic += 1;

                DetailedSolutionAssignment += $"Iteration {ic}\n";
                LogMatrixC();

                Vertex.ResetIndexes();
                // create graph with 2N+2 vertecies 
                var g = new Graph(N * 2 + 2);
                var S = g.GetVertex(N * 2 + 1);
                var T = g.GetVertex(N * 2 + 2);

                // add edges from vertecies to s and t
                for (var i = 0; i < N; i++)
                {
                    g.AddEdge(new Edge { From = S, To = g.GetVertex(i + 1), Capacity = 1 });
                    g.AddEdge(new Edge { From = g.GetVertex(N + i + 1), To = T, Capacity = 1 });
                }
                // add edges between task and executors where Cij = 0
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (C[i, j] == 0)
                        {
                            g.AddEdge(new Edge {From = g.GetVertex(i + 1), To = g.GetVertex(N + j + 1), Capacity = 1});
                        }
                    }
                }

                // find maximal flow and list of marked vertecies 
                var maxFlow = new MaximalFlow(g);
                var L = maxFlow.FindMaximalFlow(S, T);

                /*foreach (var x in L)
                {
                    DetailedSolutionAssignment += $"{x} ";
                }*/

                // find summary flow in s
                var s = g.GetIncidentalEdges(T).Cast<Edge>().Sum(e => e.Flow);


                DetailedSolutionAssignment += $"Flow {s}\n\n";

                //flow = N, task solved
                if (s == N)
                {
                    var result = new Dictionary<int, int>();
                    for (var i = 0; i < N; i++)
                    {
                        for (var j = 0; j < N; j++)
                        {
                            var e = g.GetConnectingEdge(g.GetVertex(i + 1), g.GetVertex(N + j + 1));
                            if (e != null && e.Flow > 0)
                            {
                                result[i] = j;
                            }
                        }
                    }
                    return result;
                }

                var N1 = new List<int>();
                var N2 = new List<int>();
                // add to lists N1, N2 marked vrticies
                for (var i = 0; i < N; i++)
                {
                    if (L.Contains(g.GetVertex(i + 1)))
                    {
                        N1.Add(i);
                    }
                    if (L.Contains(g.GetVertex(N + i + 1)))
                    {
                        N2.Add(i);
                    }
                }

                var alpha = int.MaxValue;
                // find alpha from edges started in N1 and not finished in N2
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (N1.Contains(i) && !N2.Contains(j))
                        {
                            alpha = Math.Min(alpha, C[i, j]);
                        }
                    }
                }

                // subtract alpha from rows in N1
                foreach (var i in N1)
                {
                    for (var j = 0; j < N; j++)
                    {
                        C[i, j] -= alpha;
                    }
                }

                // add alpha to columns in N2
                foreach (var i in N2)
                {
                    for (var j = 0; j < N; j++)
                    {
                        C[j, i] += alpha;
                    }
                }
            }
        }

        public void LogMatrixC()
        {
            DetailedSolutionAssignment += "\nMatrix C:\n";
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    DetailedSolutionAssignment += $"{C[i, j]} ";
                }
                DetailedSolutionAssignment += "\n";
            }
            DetailedSolutionAssignment += "\n";
        }
    }
}
