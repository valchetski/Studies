using System;
using System.Collections.Generic;

namespace Lab3.Models.Helpers
{
    public sealed class Bisection
    {
        private readonly Sturm _sturm;
        private const Int32 MAX_ITERATIONS = 1000 * 1000;

        public Bisection()
        {
            _sturm = new Sturm();
        }

        public Double FindRoot(Equation equation, Double a, Double b, out Int32 iterations, Double accuracy)
        {
            Double root;
            if (TryFindRoot(equation, a, b, accuracy, out root, out iterations))
            {
                return root;
            }
            throw new ArgumentException("Cannot fine root.");
        }

        public IReadOnlyCollection<Double> FindRoots(Equation equation, Double a, Double b, out Int32 iterations, Double accuracy)
        {
            var segments = _sturm.SeparateRoots(equation, a, b);
            var roots = new List<Double>(segments.Count);
            iterations = 0;
            for (int i = 0; i < segments.Count; i++)
            {
                var segment = segments[i];
                Int32 oneRootIterations;
                roots.Add(FindRoot(equation, segment.Item1, segment.Item2, out oneRootIterations, accuracy));
                iterations += oneRootIterations;
            }
            return roots.AsReadOnly();
        }


        private static Boolean TryFindRoot(Equation equation, Double a, Double b, Double accuracy, out Double root, out Int32 iterations)
        {
            double num1 = equation.Evalute(a);
            double num2 = equation.Evalute(b);
            iterations = -1;
            if (Math.Abs(num1) < accuracy)
            {
                root = a;
                return true;
            }
            if (Math.Abs(num2) < accuracy)
            {
                root = b;
                return true;
            }
            root = 0.5 * (a + b);
            if (Math.Sign(num1) == Math.Sign(num2))
                return false;
            for (iterations = 0; iterations < MAX_ITERATIONS; iterations++)
            {
                var center = (a + b) / 2;
                var y1 = Math.Sign(equation.Evalute(a));
                var y2 = Math.Sign(equation.Evalute(center));
                var y3 = Math.Sign(equation.Evalute(b));
                if (y2 == 0 || (b - a) < accuracy)
                {
                    root = center;
                    return true;
                }
                if (y1 == y2)
                    a = center;
                else if (y2 == y3)
                    b = center;
            }
            return false;
        }
    }
}