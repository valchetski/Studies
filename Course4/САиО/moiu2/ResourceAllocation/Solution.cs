namespace ResourceAllocation
{
    public class Solution
    {
        public int C, N;
        public int[,] B, Z;

        public override string ToString()
        {
            var s = $"{"X",-9}";
            for (var j = 0; j <= C; j++)
            {
                s += $"{j,-11}";
            }
            s += "\n";

            for (var i = 0; i < N; i++)
            {
                s += $"B{i,-3}";
                for (var j = 0; j <= C; j++)
                {
                    s += $"{B[i, j],5}({Z[i, j],-2}) ";
                }
                s += "\n";
            }

            s += "\nBest: ";
            var best = "";

            var c = C;
            for (var i = N - 1; i >= 0; i--)
            {
                best = Z[i, c] + " " + best;
                c -= Z[i, c];
            }
            s += best + "\n";
            return s;
        }
    }
}
