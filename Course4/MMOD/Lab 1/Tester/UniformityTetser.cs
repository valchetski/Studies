using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generators;

namespace Tester
{
    public static class UniformityTetser
    {
        public static double[] Test(List<double> randomNumbers, int k)
        {
            var step = 1.0/k;
            var n = randomNumbers.Count;
            var countList = new int[k];
            var probabilityList = new double[k];
            foreach (var randomNumber in randomNumbers)
            {
                var index = (int)Math.Floor(randomNumber/step);
                countList[index]++;
            }
            var i = 0;
            foreach (var element in countList)
            {
                var p = ((double) element)/n;
                probabilityList[i] = p;
                i++;
            }
            return probabilityList;
        }

        public static double GetExpectation(List<double> randomNumbers)
        {
            var sum = randomNumbers.Sum();
            sum /= randomNumbers.Count;
            return sum;
        }

        public static double GetVariance(List<double> randomNumbers)
        {
            var sum = randomNumbers.Sum(x => x*x);
            sum /= randomNumbers.Count;
            sum -= Math.Pow(GetExpectation(randomNumbers), 2);
            return sum;
        }
    }
}
