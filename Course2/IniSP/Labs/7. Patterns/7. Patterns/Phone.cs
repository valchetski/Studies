using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    [Serializable]
    public class Phone
    {
        public string name;
        public double cost;
        public string color;
        public string key;

        public Phone(string _name, double _cost, string _color, string _key)
        {
            name = _name;
            cost = _cost;
            color = _color;
            key = _key;
        }
        public Phone() { } //такой конструктор нужен для сериализации в XML
    }
}
