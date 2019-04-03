using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Shedule
{
    public static class XML
    {
        private static readonly string FileName;

        static XML()
        {
            FileName = @"files\shedule.xml";
        }

        public static void Save(List<Period> shedule)
        {
            var serializer = new XmlSerializer(typeof (List<Period>));
            Stream writer = new FileStream(FileName, FileMode.Create);
            serializer.Serialize(writer, shedule);
            writer.Close();
        }

        public static List<Period> Search(Dictionary<string, string> searchStrings)
        {
            var settings = new XmlReaderSettings {IgnoreComments = true, IgnoreWhitespace = true};
            var periodsList = new List<Period>();
            try
            {
                var xmlReader = XmlReader.Create(FileName, settings);
                xmlReader.Read(); //декларация
                xmlReader.Read(); //коренной элемент
                xmlReader.Read(); //дочерний элемент

                while (!xmlReader.EOF)
                {
                    var element = ReadOne(ref xmlReader);
                    if (IsContain(searchStrings, element))
                    {
                        periodsList.Add(ConvertTo.Period(element));
                    }
                }
                xmlReader.Close();
            }
            catch (FileNotFoundException)
            {
                File.Create(FileName);
            }
            catch (Exception)
            {
                periodsList = null;
            }
            return periodsList;
        }

        private static List<List<string>> ReadOne(ref XmlReader xmlReader)
        {
            var element = new List<List<string>>();
            var values = new List<string>();
            var stack = new Stack<int>();
            var name = xmlReader.Name;
            do
            {
                if (xmlReader.IsEmptyElement)
                {
                    values.Add("");
                }
                else if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    stack.Push(1);
                }
                else if (xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
                else if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    values.Add(xmlReader.Value);
                }
                if ((stack.Count == 1) && (values.Count > 0))
                {
                    element.Add(values);
                    values = new List<string>();
                }
                xmlReader.Read();
            } while ((name != xmlReader.Name) && (!xmlReader.EOF));
            xmlReader.Read(); //закрывающий тег дочернего элемента
            return element;
        }

        private static bool IsContain(Dictionary<string, string> searchStrings, List<List<string>> element)
        {
            bool isFound = false;
            if (element.Count > 0)
            {
                foreach (var searchString in searchStrings)
                {
                    int index = Convert.ToInt32(searchString.Key) - 1;
                    if (element[index].Contains(searchString.Value) || (element[index])[0] == "")
                    {
                        isFound = true;
                    }
                    else
                    {
                        isFound = false;
                        break;
                    }
                }
            }
            return isFound;
        }
    }
}
