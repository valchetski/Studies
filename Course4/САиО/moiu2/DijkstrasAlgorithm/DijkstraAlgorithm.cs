using System.Collections.Generic;
using System.Linq;

namespace DijkstrasAlgorithm
{
    public class DijkstraAlgorithm
    {
        #region Private fields
                
        private readonly int[,] _distances; //length of edges
        private readonly long[] _shortestDistances; //shortest length from start vertex to others
        private readonly int[] _previousVertex; //indicies for shortest ways
        private readonly HashSet<int> _unreviewedVertices;

        #endregion

        #region Public fields
        public int N { get; } //vertecies count
        public int StartVertex { get; private set; }
        #endregion

        #region Constructors
        public DijkstraAlgorithm(int n, int[,] distances)
        {
            N = n;
            _distances = distances;
            _shortestDistances = new long[N];
            _previousVertex = new int[N];
            _unreviewedVertices = new HashSet<int>();
        }
        #endregion

        private void InitializeValues()
        {
            for (var i = 0; i < N; i++)
            {
                _shortestDistances[i] = int.MaxValue;
            }

            _shortestDistances[StartVertex] = 0;

            for (var i = 0; i < N; i++)
            {
                _previousVertex[i] = -1;
            }

            _unreviewedVertices.Clear();

            for (var i = 0; i < N; i++)
            {
                _unreviewedVertices.Add(i);
            }
        }

        public long[] GetShortestDistances(int startVertex)
        {
            StartVertex = startVertex;
            InitializeValues();

            var currentVertex = StartVertex;
            while (_unreviewedVertices.Count > 0)
            {
                // find vertex with minimal index
                foreach (var vertex in _unreviewedVertices.Where(vertex => _shortestDistances[vertex] < _shortestDistances[currentVertex]))
                {
                    currentVertex = vertex;
                }

                // find optimal distance between vertecies
                for (var i = 0; i < N; i++)
                {
                    if (_distances[currentVertex, i] != int.MaxValue && _shortestDistances[currentVertex] + _distances[currentVertex, i] < _shortestDistances[i])
                    {
                        _shortestDistances[i] = _shortestDistances[currentVertex] + _distances[currentVertex, i];
                        _previousVertex[i] = currentVertex;
                    }
                }

                // delete checked vertecies
                _unreviewedVertices.Remove(currentVertex);

                if (_unreviewedVertices.Count > 0)
                {
                    currentVertex = _unreviewedVertices.First();
                }
            }

            return _shortestDistances;
        }

        public IEnumerable<int> GetShortestWay(int finishVertex)
        {
            var currentVertex = finishVertex;
            var result = new List<int>();
            while (_previousVertex[currentVertex] != -1 && currentVertex != StartVertex)
            {
                result.Add(currentVertex);
                currentVertex = _previousVertex[currentVertex];
            }
            result.Add(currentVertex);
            return result;
        }
    }
}
