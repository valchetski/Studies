using System;
using System.Collections.Generic;
using System.Xml;

namespace GenealogicTree.DAL
{
    public class Dac
    {
        private const string fileName = "allPeople.xml";

        public void Add(List<string> xmlElementNames, List<string> newElement)
        {
            Xml.Add(xmlElementNames, newElement, fileName);
        }

        public void Delete(string nodeName, string tegName, int id)
        {
            Xml.Delete(nodeName, tegName, id, fileName);
        }

        public List<List<string>> GetAll()
        {
            var settings = new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true };
            var xmlReader = XmlReader.Create(fileName, settings);
            xmlReader.Read(); //декларация
            xmlReader.Read(); //коренной элемент
            xmlReader.Read(); //дочерний элемент
            var elements = new List<List<string>>();
            while (!xmlReader.EOF)
            {
                var element = Xml.ReadOne(ref xmlReader);
                if (element.Count > 0)
                {
                    elements.Add(element);
                }
            }
            return elements;
        }

        public List<List<string>> Search(Dictionary<string, string> searchStrings)
        {
            var settings = new XmlReaderSettings {IgnoreComments = true, IgnoreWhitespace = true};
            var xmlReader = XmlReader.Create(fileName, settings);
            xmlReader.Read(); //декларация
            xmlReader.Read(); //коренной элемент
            xmlReader.Read(); //дочерний элемент

            var elements = new List<List<string>>();
            while (!xmlReader.EOF)
            {
                var element = Xml.ReadOne(ref xmlReader);
                if (IsContain(searchStrings, element))
                {
                    elements.Add(element);
                }
                
            }
            xmlReader.Close();
            return elements;
        }

        private bool IsContain(Dictionary<string, string> searchStrings, List<string> element)
        {
            bool isFound = false;
            if (element.Count > 0)
            {
                foreach (var searchString in searchStrings)
                {
                    int index = Convert.ToInt32(searchString.Key) - 1;
                    if (searchString.Value == element[index])
                    {
                        isFound = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return isFound;
        }
    }
}
