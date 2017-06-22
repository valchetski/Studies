using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace BusinessLayer
{
    public class BaseApp
    {
        public string Name { get; set; }

        [XmlIgnore]
        public ImageSource DisplayIcon { get; set; }

        public BaseApp() { }
    }
}
