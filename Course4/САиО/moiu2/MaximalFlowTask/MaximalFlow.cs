using System;
using System.Collections.Generic;
using System.Linq;
using Extensions.GraphHelper;

namespace MaximalFlowTask
{
    public class MaximalFlow
    {
        public Graph Graph { get; set; }
        public string DetailedSolutionMaximalFlow { get; set; }

        public MaximalFlow(int vertexCount)
        {
            Graph = new Graph(vertexCount);
        }

        public MaximalFlow(Graph graph)
        {
            Graph = graph;
        }

        public List<Vertex> FindMaximalFlow(Vertex s, Vertex t)
        {
            while (true)
            {              
                int Ic = 1, It = 1; // counter of iterations and marks                
                var I = s; // current vertex

                var L = new List<Vertex> {s}; // list of marked vertecies. Add starting vertex.
                s.G = 0; // first mark of vertex
                s.P = 1; // second mark of vertex

                while (true)
                {
                    // find not marked vertecies where xij<dij connected with direct edges
                    foreach (var j in from j in Graph.Vertices.Values where !L.Contains(j) let e = Graph.GetConnectingEdge(I, j, true) where e != null && e.Flow < e.Capacity select j)
                    {
                        j.G = I.Id; //marked
                        It++;
                        j.P = It;                       
                        L.Add(j); // add to list of marked
                    }

                    // find not marked vertecies where xij>0 connected with inverse edges
                    foreach (var j in from j in Graph.Vertices.Values where !L.Contains(j) let e = Graph.GetConnectingEdge(j, I, true) where e != null && e.Flow > 0 select j)
                    {
                        j.G = -I.Id; //marked
                        It++;
                        j.P = It;
                        L.Add(j); // add to list of marked
                    }

                    if (L.Contains(t)) // end vertex marked - way found
                    {                        
                        break;
                    }
                   
                    Ic++;  // iterate counter of iterations

                    // choose new current vertex
                    foreach (var j in Graph.Vertices.Values.Where(j => L.Contains(j) && j.P == Ic))
                    {
                        I = j;
                    }
                    // if not found - there isn't increasing ways
                    if (I.P != Ic)
                    {
                        return L;
                    }
                }

                var p = new List<Edge>();
                var n = new List<Edge>();
                var a = int.MaxValue;
                
                RecoveryPath(t, p, n, ref a); // recovering increasing way and find lists of direct and inverse edges and alfa
                
                foreach (var e in p) // increase flow in direct edges
                {
                    e.Flow += a;
                }
                
                foreach (var e in n) // decrease flow in inverse edges
                {
                    e.Flow -= a;
                }
            }
        }

        private void RecoveryPath(Vertex t, List<Edge> p, List<Edge> n, ref int a)
        {           
            if (t.G > 0) // vertex marked as having incoming edge
            {
                var i = Graph.GetVertex(t.G);
                var e = Graph.GetConnectingEdge(i, t, true);               
                a = Math.Min(a, e.Capacity - e.Flow); // find alpha with new count changing flow                
                p.Add(e); 
                RecoveryPath(i, p, n, ref a);
            }            
            if (t.G < 0) // vertex marked as having outgoing edge
            {
                var i = Graph.GetVertex(-t.G);
                var e = Graph.GetConnectingEdge(t, i, true);
                a = Math.Min(a, e.Flow); // find alpha with new count changing flow 
                n.Add(e); // add inverse edge
                RecoveryPath(i, p, n, ref a);
            }
        }
    }
}
