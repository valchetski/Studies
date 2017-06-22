using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace _7.Patterns
{
    class FileXML : IReadWrite
    {
        public void Save(PhonesList phones)
        {
            var serializer = new XmlSerializer(typeof(PhonesList));
            using (Stream writer = new FileStream(@"FileXML.xml", FileMode.Create))
            {
                serializer.Serialize(writer, phones);
            }
        }
        public PhonesList Load()
        {
            var settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            var newPhones = new PhonesList();
            using (var documentXML = XmlReader.Create(@"FileXML.xml", settings))
            {
                var elements = new List<string>();
                while (documentXML.Read())
                {
                    switch (documentXML.NodeType)
                    {
                        case XmlNodeType.Element:
                            continue;
                        case XmlNodeType.EndElement:
                            if (documentXML.Name == "Phone")
                            {
                                if (elements != (new List<string>()))
                                {
                                    var newPhone = new Phone(elements[0], Convert.ToDouble(elements[1]), elements[2], elements[3]);
                                    newPhones.Add(newPhone);
                                }
                                elements = new List<string>();
                            }
                            else
                                continue;
                            break;
                        case XmlNodeType.Text:
                            elements.Add(documentXML.Value);
                            break;
                    }
                }
            }
            return newPhones;
        }
    }
}
