using System.Collections.Generic;

namespace FloydMethod
{
    public class FloydAlgorithm
    {
        #region Public fields

        public int N { get; } //vertecies count

        #endregion

        #region Private fields

        private readonly int[,] _distances; //edges
        private long[,] _shortestDistances; //shortest ways between vertecies
        private int[,] _previousVertex;

        #endregion

        #region Constructors

        public FloydAlgorithm(int n, int[,] distances)
        {
            N = n;
            _distances = distances;
        }

        #endregion

        public void Solve()
        {
            _shortestDistances = new long[N, N];
            _previousVertex = new int[N, N];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    _shortestDistances[i, j] = _distances[i, j];
                    _previousVertex[i, j] = j + 1;
                }
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (_shortestDistances[i, k] + _shortestDistances[k, j] < _shortestDistances[i, j])
                        {
                            _shortestDistances[i, j] = _shortestDistances[i, k] + _shortestDistances[k, j];
                            _previousVertex[i, j] = _previousVertex[i, k];
                        }
                    }
                }
            }
        }

        public int[,] ReturnShortestDistances()
        {
            return TransformMatrixType(_shortestDistances);
        }

        public int[,] ReturnWay()
        {
            return _previousVertex;
        }

        private int[,] TransformMatrixType(long[,] source)
        {
            var result = new int[N, N];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    result[i, j] = (int)source[i, j];
                }
            }
            return result;
        }

        public List<int> BuildWay(int startVertex, int finishVertex)
        {
            var way = new List<int> { startVertex + 1 };

            var currentVertex = startVertex;
            while (_previousVertex[currentVertex, finishVertex] != finishVertex + 1)
            {
                var temp = _previousVertex[currentVertex, finishVertex];
                way.Add(temp);
                currentVertex = temp - 1;
            }

            if (startVertex != finishVertex)
            {
                way.Add(finishVertex + 1);
            }
            return way;
        }
    }
}
