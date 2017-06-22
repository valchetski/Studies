using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class TriangularGenerator:Generator
    {
        double A {get;set;}
        double B {get;set;}
        Random baseRandom {get;set;}

        public TriangularGenerator(List<double>GenParams):base(GenParams)
        {
            A=GenParams[0];
            B=GenParams[1];
            baseRandom=new Random();
        }

        public override double GetNext()
        {
            var u = baseRandom.NextDouble();
            var c = B + A / 2;
            return u < (c - A) / (B - A)
                       ? A + Math.Sqrt(u * (B - A) * (c - A))
                       : B - Math.Sqrt((1 - u) * (B - A) * (B - c)) * GeneratorTimeStep.step;       
        }
        
    }
}
