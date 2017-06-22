using System;

namespace _5.SystemNonlinearEquations
{
    public static class IterationsMethod
    {
        private static double a;
        private static double m;
        private static double b;

        public static double X { get; set; }
        public static double Y { get; set; }
        public static double Iterations { get; set; }

        private static double Function1(double x, double y)
        {
            return Math.Tan(x * y + m);
        }

        private static double Function2(double x, double y)
        {
            return Math.Abs(Math.Sqrt((1 - a * x * y) / 2));
            //return Math.Sqrt((1 - a * x * x) / b);
        }

        public static void Solve(double newA, double newM, double newB, double epsilon)
        {
            double[] x = { 0.7, 0.6 };
            var k = 0;
            double yPrev;
            a = newA;
            m = newM;
            b = newB;

            do
            {
                double xPrev = x[0];
                yPrev = x[1];
                x[0] = Function1(x[0], x[1]);
                x[1] = Function2(x[0], x[1]);
                yPrev = Math.Max(Math.Abs(yPrev - x[1]), Math.Abs(xPrev - x[0]));
                k++;
            } while (yPrev > epsilon && k < 1000000);

            if ((x[0] < 1000000) || (x[0] > 0) || (x[1] < 1000000) || (x[1] > 0))
            {
                Iterations = k;
                X = x[0];
                Y = x[1];
            }
        }
    }
}
