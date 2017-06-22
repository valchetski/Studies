using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generators;

namespace Tester
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //var randomNumbers = NeumanGenerator.Generate(1000000, 41118234);  
        //    var randomNumbers = CongruentGenerator.Generate(100, 41118234, 19, 9999);
        //    var list = UniformityTetser.Test(randomNumbers, 20);
        //    foreach (var d in list)
        //    {
        //        Console.WriteLine(d);
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine(UniformityTetser.GetVariance(randomNumbers));
        //    var list2 = CongruentGenerator.Generate(100, 41122224, 17, 9999);
        //    var k = IndependenceTester.GetCorrelation(randomNumbers, list2);
        //    //k = Math.Floor(k);
        //    Console.WriteLine(k);
        //    Console.ReadLine();
        //}
        static void Main(string[] args)
        {
            int n1 = 10, n2 = 100, s = 3;
            double sum_n1_1 = 0, sum_n1_2 = 0, sum_n2_1 = 0, sum_n2_2 = 0;
            var randomNumbers_n1_1 = CongruentGenerator.Generate(n1, 41118234, 19, 9999);
            var randomNumbers_n1_2 = NeumanGenerator.Generate(n1, 41118234);
            var randomNumbers_n2_1 = CongruentGenerator.Generate(n2, 41118234, 19, 9999);
            var randomNumbers_n2_2 = NeumanGenerator.Generate(n2, 41118234);
            IEnumerable<int> indexes_n1 = Enumerable.Range(0, n1 - s);
            IEnumerable<int> indexes_n2 = Enumerable.Range(0, n2 - s);
            foreach (var i in indexes_n1)
            {
                sum_n1_1 += randomNumbers_n1_1[i] * randomNumbers_n1_1[i + s];
                sum_n1_2 += randomNumbers_n1_2[i] * randomNumbers_n1_2[i + s];
            }
            foreach (var i in indexes_n2)
            {
                sum_n2_1 += randomNumbers_n2_1[i] * randomNumbers_n2_1[i + s];
                sum_n2_2 += randomNumbers_n2_2[i] * randomNumbers_n2_2[i + s];
            }
            var R_n1_1 = 12.0 / (n1 - s) * sum_n1_1 - 3;
            var R_n1_2 = 12.0 / (n1 - s) * sum_n1_2 - 3;
            var R_n2_1 = 12.0 / (n2 - s) * sum_n2_1 - 3;
            var R_n2_2 = 12.0 / (n2 - s) * sum_n2_2 - 3;
            Console.WriteLine(n1);
            Console.WriteLine(R_n1_1);
            Console.WriteLine(R_n1_2);
            Console.WriteLine();
            Console.WriteLine(n2);
            Console.WriteLine(R_n2_1);
            Console.WriteLine(R_n2_2);
            Console.ReadLine();
        }
    }
}
