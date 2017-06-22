using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    public class FactoryMethod
    {
        public IReadWrite ChoiceFile(int number)
        {
            switch (number)
            {
                case 1:
                    return new FileTXT();
                case 2:
                    return new FileBin();
                case 3:
                    return new FileXML();
                default:
                    return default(IReadWrite);
            }
        }
    }
}
