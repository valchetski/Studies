using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Shedule.BusinessLayer;

namespace Shedule.DAL
{
    public static class XML
    {
        private const string sheduleFileName = @"shedule.xml";
        private const string tasksFileName = @"tasks.xml";

        private delegate bool Check(DayOfWeek dayOfWeek, int numberOfWeek, string subgroup, List<string> element);

        public static void Save(List<Period> shedule)
        {
            var serializer = new XmlSerializer(typeof (List<Period>));
            Stream writer = new FileStream(sheduleFileName, FileMode.Create);
            serializer.Serialize(writer, shedule);
            writer.Close();
        }

        public static void Save(List<Task> tasks)
        {
            var serializer = new XmlSerializer(typeof(List<Task>));
            Stream writer = new FileStream(tasksFileName, FileMode.Create);
            serializer.Serialize(writer, tasks);
            writer.Close();
        }

        public static List<List<string>> GetTasks()
        {
            return GetList(tasksFileName, null);
        }

        /// <summary>
        /// Ищем нужное расписание на день
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="numberOfWeek"></param>
        /// <param name="subgroup"></param>
        /// <returns></returns>
        public static List<List<string>> GetShedule(DayOfWeek dayOfWeek, int numberOfWeek, string subgroup)
        {
            return GetList(sheduleFileName, IsContain, dayOfWeek, numberOfWeek, subgroup);
        }

        private static List<List<string>> GetList(string fileName, Check check, DayOfWeek dayOfWeek = DayOfWeek.Monday, int numberOfWeek = -1, string subgroup = "-1")
        {
            var settings = new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true };
            var elementsList = new List<List<string>>();
            try
            {
                var xmlReader = XmlReader.Create(fileName, settings);
                xmlReader.Read(); //декларация
                xmlReader.Read(); //коренной элемент
                xmlReader.Read(); //дочерний элемент
                while (!xmlReader.EOF)
                {
                    List<string> element = ReadOne(ref xmlReader);
                    if ((check == null && element != null && element.Count > 0) ||
                        (check != null && check(dayOfWeek, numberOfWeek, subgroup, element)))
                    {
                        elementsList.Add(element);
                    }
                }
                xmlReader.Close();
            }
            catch (FileNotFoundException)
            {
                File.Create(fileName);
            }
            catch (Exception)
            {
                elementsList = null;
            }

            return elementsList;
        }

        private static List<string> ReadOne(ref XmlReader xmlReader)
        {
            var element = new List<string>();
            var name = xmlReader.Name;
            do
            {
                if (xmlReader.IsEmptyElement)
                {
                    element.Add("");
                }
                else if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    element.Add(xmlReader.Value);
                }
                xmlReader.Read();
            } while ((name != xmlReader.Name) && (!xmlReader.EOF));
            xmlReader.Read(); //закрывающий тег дочернего элемента
            return element;
        }

        /// <summary>
        /// Проверяет, содержится ли в element значения первых 3-ех параметров
        /// </summary>
        private static bool IsContain(DayOfWeek dayOfWeek, int numberOfWeek, string subgroup, List<string> element)
        {
            return (element.Count > 7) && 
                ((element[7] == ConvertTo.Day(dayOfWeek)) && 
                ((element[0] == "") || (element[0].Contains(Convert.ToString(numberOfWeek))))
                   && ((element[3] == "") || (subgroup == element[3])));
        }
    }
}