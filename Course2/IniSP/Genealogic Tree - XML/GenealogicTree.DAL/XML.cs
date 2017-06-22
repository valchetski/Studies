using System;
using System.Collections.Generic;
using System.Xml;

namespace GenealogicTree.DAL
{
    public static class Xml
    {
        public static void Add(List<string> xmlElementNames, List<string> newElement, string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlNode element = xmlDocument.CreateElement(xmlElementNames[0]);
            if (xmlDocument.DocumentElement != null)
            {
                xmlDocument.DocumentElement.AppendChild(element); //родитель
            }
            xmlElementNames.Remove(xmlElementNames[0]);

            for (var i = 0; i < xmlElementNames.Count; i++)//добавляем поля
            {
                XmlNode subElement = xmlDocument.CreateElement(xmlElementNames[i]); 
                subElement.InnerText = newElement[i]; 
                element.AppendChild(subElement);
            }
            xmlDocument.Save(fileName);
        }

        public static void Delete(string nodeName, string tegName, int id, string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlNode root = xmlDocument.DocumentElement;//корневой элемент
            if (root != null)
            {
                XmlNode node = root.SelectSingleNode(String.Format(nodeName + "[tegName='{0}']", id));//ищем удаляемый элемент
                if (node != null)
                {
                    XmlNode outer = node.ParentNode; //получаем родительский узел для удаляемого
                    if (outer != null)
                    {
                        outer.RemoveChild(node);
                        xmlDocument.Save(fileName);
                    }
                }
            }
        }

        public static List<string> ReadOne(ref XmlReader xmlReader)
        {
            var element = new List<string>();
            var name = xmlReader.Name;
            do
            {
                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    element.Add(xmlReader.Value);
                }
                xmlReader.Read();
            } while ((name != xmlReader.Name) && (!xmlReader.EOF));
            xmlReader.Read();//закрывающий тег дочернего элемента
            return element;
        }
    }
}
