using System.Collections.Generic;
using System.Linq;
using Extensions.GraphHelper;

namespace MinimalCostFlow
{
    public class MinimalCostFlow
    {
        public Graph Graph;
        public string DetailedSolutionMinimalCostFlow { get; set; }

        public MinimalCostFlow(int vertexCount)
        {
            Graph = new Graph(vertexCount);
        }

        public void SolveMinimalCostFlowTask()
        {
            while (true)
            {                              
                // find vertecies potentials
                foreach (var vertex in Graph.Vertices.Values)
                {
                    vertex.Potential = null;
                }

                Graph.FindPotentials(Graph.Vertices[1], 0, Graph.Vertices[1]);

                DetailedSolutionMinimalCostFlow += Graph.ToString();

                // find edge with positive delta
                Edge changedEdge = null;
                foreach (var edge in Graph.Edges.Where(edge => edge.From.Potential.HasValue && edge.To.Potential.HasValue))
                {
                    edge.Delta = edge.From.Potential.Value - edge.To.Potential.Value - edge.Cost;
                    if (edge.Delta > 0 && changedEdge == null)
                    {
                        changedEdge = edge;
                    }
                }

                // all delta is negative, complete solution
                if (changedEdge == null)
                {
                    break;
                }

                // find cycle, contains this edge
                var cycle = Graph.FindCycle(changedEdge, changedEdge.To);

                var positiveEdges = new List<Edge>();
                var negativeEdges = new List<Edge>();
                var lastVertex = changedEdge.From;
                var minTheta = int.MaxValue;
                // iterate cycle
                foreach (var edge in cycle)
                {
                    // find edge with minimal flow (minimal theta)
                    if (edge.Flow < minTheta && edge.Flow > 0)
                    {
                        minTheta = edge.Flow;
                    }
                    // direct edge
                    if (edge.From == lastVertex)
                    {
                        lastVertex = edge.To;
                        positiveEdges.Add(edge);
                    }
                    else
                    {
                        // inversed edge
                        lastVertex = edge.From;
                        negativeEdges.Add(edge);
                    }
                }

                // increase flow in positive edges
                foreach (var edge in positiveEdges)
                {
                    edge.Flow += minTheta;
                }

                // decrease flow in negative edges
                foreach (var edge in negativeEdges)
                {
                    edge.Flow -= minTheta;
                }
            }
        }
    }
}
