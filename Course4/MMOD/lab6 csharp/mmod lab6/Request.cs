using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class Request
    {
        public bool IsCompleted { get; set; }
        public double StartTime { get; set; }      
        public double CompleteTime { get; set; }
        public ModelObject CurrentObject { get; set; }
        public List<double> PhasesTimes { get; set; }

        public  Request()
        {
            PhasesTimes = new List<double>();
        }
    }
}
