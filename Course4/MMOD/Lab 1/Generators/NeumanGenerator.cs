using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generators
{
    public static class NeumanGenerator
    {
        public static List<double> Generate(int count, long number)
        {
            var length = number.ToString().Length;
            var list = new List<double>();
            int i = 1;
            list.Add(number*Math.Pow(10, -length));
            do
            {
                var squared = Math.Pow(number, 2);
                var nextNumber = (long) squared/Math.Pow(10, length/2);
                nextNumber = Math.Floor(nextNumber);
                nextNumber %= (long) Math.Pow(10, length);
                list.Add(nextNumber*Math.Pow(10, -length));
                number = (long)nextNumber;
                i++;
            } while (i < count); 
            return list;
        }
    }
}
