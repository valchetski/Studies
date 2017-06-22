using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class GauseGenerator:Generator
    {
        private double Mat{get;set;}
        private double Sigma{get;set;}

        private Random baseRandom { get; set; }

        public override double GetNext()
        {
            var u1 = baseRandom.NextDouble();
            var u2 = baseRandom.NextDouble();
            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            var rand_normal = Mat + Sigma * rand_std_normal;
            return rand_normal * GeneratorTimeStep.step;
        }
        public GauseGenerator(List<double> GenParams):base(GenParams)
        {
            Mat = GenParams[0];
            Sigma = GenParams[1];
            baseRandom = new Random();
        }
    }


}
