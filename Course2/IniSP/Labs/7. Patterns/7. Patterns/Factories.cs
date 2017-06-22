using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    public class TXTFactory : IAbstractFactory
    {
        public IReadWrite CreateFile()
        {
            return new FileTXT();
        }
    }

    public class BinFactory : IAbstractFactory
    {
        public IReadWrite CreateFile()
        {
            return new FileBin();
        }
    }

    public class XMLFactory : IAbstractFactory
    {
        public IReadWrite CreateFile()
        {
            return new FileXML();
        }
    }
}
