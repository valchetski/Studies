namespace ResourceAllocation
{
    public class ResourceTask
    {
        public int C, N;
        public int[,] F;

        public Solution SolveBellman()
        {
            var sol = new Solution
            {
                C = C, //Capacity
                N = N, //Technologic processes
                B = new int[N, C + 1], // В - value of Bellman function
                Z = new int[N, C + 1], // Z - count of using resourse
            };        
            
            for (var n = 0; n < N; n++)
            {
                for (var c = 0; c <= C; c++)
                {
                    SolveBellmanFunction(sol, n, c);
                }
            }

            return sol;
        }

        private int SolveBellmanFunction(Solution sol, int n, int c)
        {
            if (sol.B[n, c] != 0)
            {
                return sol.B[n, c];
            }

            int result;
            int resultZ;

            if (n == 0)
            {
                result = F[n, c];
                resultZ = c;
            }
            else {
                var bestZ = 0;
                var bestB = 0;
                for (var z = 0; z <= c; z++)
                {
                    var b = F[n, z] + SolveBellmanFunction(sol, n - 1, c - z);
                    if (b > bestB)
                    {
                        bestB = b;
                        bestZ = z;
                    }
                }
                result = bestB;
                resultZ = bestZ;
            }

            sol.B[n, c] = result;
            sol.Z[n, c] = resultZ;
            return result;
        }
    }
}
