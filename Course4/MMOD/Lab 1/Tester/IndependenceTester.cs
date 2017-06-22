using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tester
{
    public static class IndependenceTester
    {
        public static double GetCorrelation(List<double> list1, List<double> list2)
        {
            var n = list1.Count;
            var m = list2.Count;
            var exp1 = UniformityTetser.GetExpectation(list1);  // МО первого набора
            var exp2 = UniformityTetser.GetExpectation(list2);  // МО второго набора
            var var1 = UniformityTetser.GetVariance(list1);     // дисперсия первого набора 
            var var2 = UniformityTetser.GetVariance(list2);     // дисперсия второго набора
            var sum = 0.0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    sum += list1[i]*list2[j];
                }
            var exp12 = sum / n / m;                            // M[X*Y] 
            return (exp12 - exp1*exp2)/Math.Sqrt(var1*var2);
        }
    }
}
