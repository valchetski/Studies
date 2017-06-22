using System;

namespace _5.SystemNonlinearEquations
{
    class Program
    {
        private static void Main()
        {
            double[] m = {0.0, 0.1, 0.1, 0.2, 0.2, 0.3, 0.3, 0.4, 0.4, 0.1, 0.2, 0.3, 0.2, 0.2};
            double[] a = {0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 0.7, 0.5};

            const double b = 2;
            const double epsilon = 0.00001;

            for (int i = 0; i < a.Length; i++)
            {
                IterationsMethod.Solve(a[i], m[i], b, epsilon);
                Console.WriteLine("ITERATIONS METHOD");
                Console.WriteLine("Iterations : " + IterationsMethod.Iterations);
                Console.WriteLine("X1 : " + IterationsMethod.X);
                Console.WriteLine("X2 : " + IterationsMethod.Y);

                NewtonMethod.Solve(a[i], m[i], b, epsilon);
                Console.WriteLine("NEWTON METHOD");
                Console.WriteLine("Iterations : " + NewtonMethod.Iterations);
                Console.WriteLine("X1 : " + NewtonMethod.X);
                Console.WriteLine("X2 : " + NewtonMethod.Y);

                Console.ReadKey();
            }
        }
    }
}
