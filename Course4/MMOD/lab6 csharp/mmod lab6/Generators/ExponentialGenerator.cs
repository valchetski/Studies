using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    class ExponentialGenerator:Generator
    {
        private double Lamda { get; set; }
        Random baseRandom { get; set; }

        public override double GetNext()
        {
            var u= baseRandom.NextDouble();
            return -1*Math.Log(1 - u) / Lamda * GeneratorTimeStep.step;
        }

        public ExponentialGenerator(List<double> GenParams):base(GenParams)
        {
            baseRandom = new Random();
            Lamda = GenParams[0];
        }
    }
}
