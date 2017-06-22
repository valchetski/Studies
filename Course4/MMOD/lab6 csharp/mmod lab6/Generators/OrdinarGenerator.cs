using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6

{
    class OrdinarGenerator:Generator
    {
        private double A { get; set; }
        private double B { get; set; }
        private Random baseRandom { get; set; }

        public override double GetNext()
        {
            return A + (B - A) * baseRandom.NextDouble() * GeneratorTimeStep.step;
        }

        public OrdinarGenerator(List<double> GenParams):base(GenParams)
        {
            baseRandom = new Random();
            A = GenParams[0];
            B = GenParams[1];
        }
    }
}
