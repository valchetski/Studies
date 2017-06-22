using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1lab
{
    public class Solve
    {
        private double GetP(double x)
        {
            return 0.5 + Math.Pow(Math.Sin(x), 2);
        }

        private double GetQ(double x)
        {
            return 2 * (1 + Math.Pow(x, 2));
        }
        private double GetF(double x)
        {
            return 10 * (1 + Math.Pow(Math.Sin(x), 2));
        }

        public Tuple<double[], double[]> MySolve(int k, int a, int b)
        {
            double ya = 0;
            double yb = 4;

            double h = (b - a) / (double)k;

            var X = new double[k + 1];
            for (int i = 0; i <= k; i++)
            {
                X[i] = a + h * i;
            }

            var A = new double[k+1];
            var B = new double[k+1];
            var C = new double[k+1];
            var D = new double[k+1];
            for (int i = 1; i <= k - 1; i++)
            {
                A[i] = /*2 - GetP(X[i]) * h;*/1 / Math.Pow(h, 2) - GetP(X[i]) / (2 * h);

                B[i] = /*-4 + GetQ(X[i]) * 2 * Math.Pow(h, 2);*/-2 / h + GetQ(X[i]);

                C[i] = /*2 + GetP(X[i]) * h;*/1 / Math.Pow(h, 2) + GetP(X[i]) / (2 * h);

                D[i] = GetF(X[i]); //* 2* Math.Pow(h, 2);
            }

            D[1] -= A[1] * ya;
            D[k - 1] -= C[k - 1] * yb;



            var alpha = new double[k+1];
            alpha[1] = -(C[1] / B[1]);

            var beta = new double[k+1];
            beta[1] = D[1] / B[1];

            for (int i = 2; i <= k - 2; i++)
            {
                alpha[i] = -(C[i] / (B[i] + A[i] * alpha[i - 1]));
                beta[i] = (D[i] - A[i] * beta[i - 1]) / (B[i] + A[i] * alpha[i - 1]);
            }


            var Y = new double[k+1];
            Y[k - 1] = (D[k - 1] - A[k - 1] * beta[k - 2]) / (A[k - 1] * alpha[k - 2] + B[k - 1]);
            for (int i = k - 2; i >= 1; i--)
            {
                Y[i] = Math.Round(alpha[i] * Y[i + 1] + beta[i], 3);
            }
            Y[0] = ya;
            Y[k] = yb;
            return new Tuple<double[], double[]>(X, Y);

        }

        



    }
}
