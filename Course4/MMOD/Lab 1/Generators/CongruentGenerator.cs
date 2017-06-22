using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generators
{
    public static class CongruentGenerator
    {
        public static List<double> Generate(int count, int number, int k, int m)
        {
            var list = new List<double>();
            var i = 0;
            while (i < count)
            {
                var nextNumber = k * number;
                nextNumber %= m;
                var temp = ((double)nextNumber) / m;
                list.Add(temp);
                number = nextNumber;
                i++;
            }
            return list;
        }
    }
}
