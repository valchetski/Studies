using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    class AbstractFactory 
    {
        public IReadWrite CreateFile(IAbstractFactory factory)
        {
            return factory.CreateFile();
        }
    }
}