using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NewAttribute:Attribute
    {
        public string Name{ get; set; }
        public NewAttribute(string name)
        {
            Name = name;
        }
    }
}
