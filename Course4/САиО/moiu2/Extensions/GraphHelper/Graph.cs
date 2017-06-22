using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.GraphHelper
{
    public class Graph
    {
        public Dictionary<int, Vertex> Vertices = new Dictionary<int, Vertex>();
        public List<Edge> Edges = new List<Edge>();

        public Graph(int n)
        {
            for (var i = 0; i < n; i++)
            {
                AddVertex(new Vertex());
            }
        }

        public void AddVertex(Vertex v)
        {
            Vertices[v.Id] = v;
        }

        public void AddEdge(Edge e)
        {
            Edges.Add(e);
        }

        public Vertex GetVertex(int id)
        {
            return Vertices[id];
        }

        // return edges incidental given vertex
        public IEnumerable GetIncidentalEdges(Vertex v)
        {
            return Edges.Where(e => e.From == v || e.To == v);
        }

        // return vertecies that connected with given vertex
        public IEnumerable GetConnectedVertices(Vertex v)
        {
            foreach (Edge e in GetIncidentalEdges(v))
            {
                if (e.From == v)
                {
                    yield return e.To;
                }
                if (e.To == v)
                {
                    yield return e.From;
                }
            }
        }

        public Edge GetConnectingEdge(Vertex a, Vertex b, bool directional = false)
        {
            foreach (Edge e in GetIncidentalEdges(a))
            {
                if (e.From == a && e.To == b)
                {
                    return e;
                }
                if (e.To == a && e.From == b && !directional)
                {
                    return e;
                }
            }
            return null;
        }

        // find potentials recursively begining from vertex start
        public void FindPotentials(Vertex start, int value, Vertex initialStart)
        {
            if (start.Potential.HasValue && start.Potential.Value >= value)
                return;

            start.Potential = value;
            // for all incidental given vertex basic edges
            foreach (var edge in GetIncidentalEdges(start).Cast<Edge>().Where(edge => edge.Flow > 0))
            {
                // direct edge
                if (edge.To != start)
                {
                    if (edge.To != initialStart)
                    {
                        FindPotentials(edge.To, value - edge.Cost, initialStart);
                    }
                }
                else
                {
                    // inversed edge
                    if (edge.From != initialStart)
                    {
                        FindPotentials(edge.From, value + edge.Cost, initialStart);
                    }
                }
            }
        }

        // find and return cycle that starts from vertex vstart and include edge start
        public List<Edge> FindCycle(Edge start, Vertex vstart, List<Edge> oldHistory = null)
        {
            var history = new List<Edge>();
            if (oldHistory != null)
            {
                history.AddRange(oldHistory);
            }
            else
            {
                oldHistory = new List<Edge>();
            }

            // return to start vertex and loop has more than 0 edges
            if (history.Count > 0 && history[0].From == vstart)
            {
                history.Add(start);
                return history;
            }
            if (history.Contains(start))
            {
                return null;
            }

            // remember next edge
            history.Add(start);
                        
            return (from Vertex v in GetConnectedVertices(vstart)
                    let edge = GetConnectingEdge(vstart, v) // iterate incidental edges that doesn't include in cycle
                    where !oldHistory.Contains(edge)
                    where edge.Flow > 0
                    select FindCycle(edge, v, history)).FirstOrDefault(res => res != null); // recursively find cycle using selected edge and all previous
        }

        public override string ToString()
        {
            var es = "Edges information:\n";
            var c = 0;
            var vs = "Vertecies Information:\n";
            vs += Vertices.Values.Aggregate("", (current, v) => current + (v + "\n"));
            foreach (var e in Edges)
            {
                es += e + "\n";
                c += e.Flow * e.Cost;
            }
            return $"Graph:\n{vs}\n{es}\nCost: {c}\n\n";
        }
    }
}
