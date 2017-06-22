using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMIML_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A(G1)");
            Matrix.Print(Matrix.mtr1);
            Console.WriteLine("A(G2)");
            Matrix.Print(Matrix.mtr2);
            Console.WriteLine("G1 U G2");
            Matrix.Combination();
            Console.WriteLine();
            Console.WriteLine("G1 П G2");
            Matrix.Interfaction();
            Console.WriteLine();
            Console.WriteLine("A(G1(G2)):");
            Matrix.Print(Matrix.Composition(Matrix.mtr1,Matrix.mtr2));
            Console.WriteLine("A(G2(G1)):");
            Matrix.Print(Matrix.Composition(Matrix.mtr2, Matrix.mtr1));
            Console.WriteLine();
            Console.WriteLine("G1 * G2:");
            Matrix.Multiplication();
            Console.WriteLine();
            Console.WriteLine("G1 x G2:");
            Matrix.Decart();
            Console.ReadKey();
        }
    }
}
