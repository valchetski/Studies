using System.Collections.Generic;
using System.Linq;

namespace MaximalLengthWay
{
    public class MaximalLengthTask
    {
        #region Private fields

        private readonly int _n;
        private readonly int[,] _distances;
        private bool[] _checkedVertices;
        private int[] _previousWayVertices;

        #endregion

        #region Public fields
        public string DetailedSolution { get; set; }
        #endregion

        #region Constructors
        public MaximalLengthTask(int n, int[,] distances)
        {
            _n = n;
            _distances = distances;
        }
        #endregion

        public int Solve()
        {
            var topologicalSortedVertices = SortVerticies();

            DetailedSolution = $"Find maximal length way from vertex s = {0}  to vertex t = {topologicalSortedVertices[_n - 1]}\n\n";

            DetailedSolution += "Topological sorted vertices:\n";

            foreach (var vertex in topologicalSortedVertices)
            {
                DetailedSolution += $" {vertex} ";
            }

            DetailedSolution += "\n\n";

            var maxLength = FindMaxLengthWay(topologicalSortedVertices);

            DetailedSolution += $"Maximal length way = {maxLength}\n\n";
            DetailedSolution += "Way:\n";

            string way = $" {topologicalSortedVertices[_n - 1]} ";

            var currentVertex = _previousWayVertices[topologicalSortedVertices[_n - 1]];

            while (currentVertex != 0)
            {
                way = $" {currentVertex} " + way;
                currentVertex = _previousWayVertices[currentVertex];
            }
            way = $" {0} " + way;

            DetailedSolution += way;

            return maxLength;
        }
 
        private List<int> SortVerticies()
        {
            _checkedVertices = new bool[_n];
            var topologicalSortedVertices = new List<int>();

            for (var i = 0; i < _n; i++)
            {
                if (!_checkedVertices[i])
                {
                    topologicalSortedVertices.AddRange(TopologicalSorting(i));
                }
            }

            topologicalSortedVertices.Reverse();
            return topologicalSortedVertices;
        }

        private IEnumerable<int> TopologicalSorting(int currentVertex)
        {
            IEnumerable<int> result = new List<int>();
            _checkedVertices[currentVertex] = true;
            for (var i = 0; i < _n; i++)
            {
                if (!_checkedVertices[i] && _distances[currentVertex, i] < int.MaxValue)
                {
                    var subResult = TopologicalSorting(i);
                    result = result.Concat(subResult);
                }
            }
            return result.Concat(new List<int> { currentVertex });
        }

        // Find max length ways using Bellman function
        private int FindMaxLengthWay(List<int> topologicalSortedVertices)
        {           
            _previousWayVertices = new int[_n]; // Array for build the longest way
            var B = new int[_n]; // Array of way length values - Bellman function

            B[0] = 0; // Values for start vertex
            _previousWayVertices[0] = 0;

            for (var i = 1; i < topologicalSortedVertices.Count; i++)
            {               
                var vertex = topologicalSortedVertices[i]; // Vertex from topological sorted list
                _previousWayVertices[vertex] = -1;
                B[vertex] = int.MinValue;

                for (var j = 0; j < _n; j++)
                {
                    if (_distances[j, vertex] < int.MaxValue) // Check all incoming edges
                    {                   
                        if (B[j] + _distances[j, vertex] > B[vertex]) // Search the longest way
                        {
                            B[vertex] = B[j] + _distances[j, vertex];
                            _previousWayVertices[vertex] = j;
                        }
                    }
                }
            }
            return B[topologicalSortedVertices[_n - 1]];
        }
    }
}
