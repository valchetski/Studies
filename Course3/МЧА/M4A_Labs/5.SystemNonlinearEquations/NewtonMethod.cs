using System;

namespace _5.SystemNonlinearEquations
{
    public class NewtonMethod
    {
        public static double Iterations { get; set; }
        public static double X { get; set; }
        public static double Y { get; set; }

        private static double a;
        private static double m;
        private static double b;

        private static double df1_dx(double x, double y)
        {
            return y / Math.Pow(Math.Cos(x * y + m), 2) - 1;
        }

        private static double df1_dy(double x, double y)
        {
            return x / Math.Pow(Math.Cos(x * y + m), 2);
        }

        private static double df2_dx(double x, double y)
        {
            return 2 * a * x;
        }

        private static double df2_dy(double x, double y)
        {
            return 2 * b * y;
        }

        private static double Function1(double x, double y)
        {
            return Math.Tan(x * y + m) - x;
        }

        private static double Function2(double x, double y)
        {
            return a * x * x + b * y * y - 1;
        }

        public static void Solve(double newA, double newM, double newB, double epsilon)
        {
            double[] x = { 0.7, 0.6 };
            int k = 0;
            double prevX;
            a = newA;
            m = newM;
            b = newB;
            do
            {
                prevX = x[0];
                double prevY = x[1];
                x[0] = prevX -
                       1/
                       (df1_dx(prevX, prevY)*df2_dy(prevX, prevY) -
                        df1_dy(prevX, prevY)*df2_dx(prevX, prevY))*
                       (df2_dy(prevX, prevY)*Function1(prevX, prevY) -
                        df1_dy(prevX, prevY)*Function2(prevX, prevY));
                x[1] = prevY -
                       1/
                       (df1_dx(prevX, prevY)*df2_dy(prevX, prevY) -
                        df1_dy(prevX, prevY)*df2_dx(prevX, prevY))*
                       (-df2_dx(prevX, prevY)*Function1(prevX, prevY) +
                        df1_dx(prevX, prevY)*Function2(prevX, prevY));
                prevX = Math.Max(Math.Abs(prevX - x[0]), Math.Abs(prevY - x[1]));
                k++;
            } while (prevX > epsilon && k < 100);

            Iterations = k;
            X = x[0];
            Y = x[1];
        }
    }
}
