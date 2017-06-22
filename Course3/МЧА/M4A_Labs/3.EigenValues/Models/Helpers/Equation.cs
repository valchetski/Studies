using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MathNet.Numerics;

namespace Lab3.Models.Helpers
{
    public sealed class Equation
    {
        private readonly Double[] _factors;

        public Equation(IEnumerable<Double> factors)
        {
            _factors = factors.ToArray();
        }

        public Int32 Order
        {
            get { return _factors.Length - 1; }
        }

        public Equation Deconv(Equation divisor, out Equation remainder)
        {
            if (_factors.Last().AlmostEqual(0))
            {
                throw new ArithmeticException("Старший член многочлена делимого не может быть 0");
            }
            if (divisor._factors.Last().AlmostEqual(0))
            {
                throw new ArithmeticException("Старший член многочлена делителя не может быть 0");
            }
            var divisorFactors = divisor._factors;
            var remainderFactors = (Double[])_factors.Clone();
            var quotientFactors = new Double[remainderFactors.Length - divisorFactors.Length + 1];
            for (int i = 0; i < quotientFactors.Length; i++)
            {
                double coeff = remainderFactors[remainderFactors.Length - i - 1] / divisorFactors.Last();
                quotientFactors[quotientFactors.Length - i - 1] = coeff;
                for (int j = 0; j < divisorFactors.Length; j++)
                {
                    remainderFactors[remainderFactors.Length - i - j - 1] -= coeff * divisorFactors[divisorFactors.Length - j - 1];
                }
            }
            remainder = new Equation(remainderFactors.TakeWhile(d => !d.AlmostEqual(0)));
            return new Equation(quotientFactors);
        }

        public Equation Derivative()
        {
            var factors = new Double[_factors.Length - 1];
            for (int i = 1; i < _factors.Length; i++)
            {
                factors[i - 1] = _factors[i] * (i);
            }
            return new Equation(factors);
        }

        public Equation Neg()
        {
            return new Equation(_factors.Select(d => -d).ToArray());
        }

        public Double Evalute(Double z)
        {
            return Evaluate.Polynomial(z, _factors);
        }

        public override String ToString()
        {
            if (_factors.Length == 0)
                return "Zero equation";
            var sb = new StringBuilder();
            for (int i = _factors.Length - 1; i > 1; i--)
            {
                sb.Append(_factors[i].ToString(CultureInfo.InvariantCulture) + "*x^" + i + " + ");
            }
            if (_factors.Length >= 2)
            {
                sb.Append(_factors[1].ToString(CultureInfo.InvariantCulture) + "*x" + " + ");
            }
            sb.Append(_factors[0].ToString(CultureInfo.InvariantCulture));
            sb.Append(" = 0");
            return sb.ToString();
        }
    }
}