using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;

namespace Lab3.Models.Helpers
{
    public sealed class Sturm
    {
        public Int32 RootsNumber(Equation equation, Double a, Double b)
        {
            var sturmSequence = BuildSturmSequence(equation);
            return EvaluteSturmSequence(sturmSequence, a) - EvaluteSturmSequence(sturmSequence, b);
        }

        public List<Tuple<Double, Double>> SeparateRoots(Equation equation, Double a, Double b)
        {
            if (equation.Order == 1)
                return new[] { new Tuple<Double, Double>(a, b) }.ToList();
            var sturmSequence = BuildSturmSequence(equation);
            var segments = new List<Tuple<Double, Double>>();
            SeparateRootsRecursive(sturmSequence, a, b, segments);
            return segments;
        }

        private void SeparateRootsRecursive(List<Equation> sequence, Double a, Double b, List<Tuple<Double, Double>> segments)
        {
            var rootsNumber = EvaluteSturmSequence(sequence, a) - EvaluteSturmSequence(sequence, b);
            if (rootsNumber == 0)
            {
                return;
            }
            if (rootsNumber == 1)
            {
                segments.Add(new Tuple<double, double>(a, b));
            }
            else
            {
                var center = (a + b) / 2;
                SeparateRootsRecursive(sequence, a, center, segments);
                SeparateRootsRecursive(sequence, center, b, segments);
            }
        }

        private List<Equation> BuildSturmSequence(Equation equation)
        {
            var sequence = new List<Equation> { equation, equation.Derivative() };
            for (Int32 i = 2; i < Int32.MaxValue; i++)
            {
                Equation remainder;
                sequence[i - 2].Deconv(sequence[i - 1], out remainder);
                sequence.Add(remainder.Neg());
                if (remainder.Order == 0)
                {
                    break;
                }
            }
            return sequence;
        }

        private Int32 EvaluteSturmSequence(IEnumerable<Equation> sequence, Double z)
        {
            var values = sequence.Select(equation => equation.Evalute(z)).Where(d => !d.AlmostEqual(0)).ToList();
            var result = 0;
            var sign = Math.Sign(values[0]);
            for (int i = 1; i < values.Count; i++)
            {
                var nextSign = Math.Sign(values[i]);
                if (nextSign != sign)
                {
                    result++;
                    sign = nextSign;
                }
            }
            return result;
        }
    }
}