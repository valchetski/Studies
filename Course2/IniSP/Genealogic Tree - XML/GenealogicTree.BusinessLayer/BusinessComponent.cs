using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GenealogicTree.DAL;

namespace GenealogicTree.BusinessLayer
{
    public class BusinessComponent
    {
        private Dac dac;
        private List<string> xmlElementNames;

        public BusinessComponent()
        {
            dac = new Dac();
            xmlElementNames = GetElementNames();
        }

        public void Add(Person person)
        {
            if (person != null)
            {
                dac.Add(xmlElementNames, ConvertTo.ListString(person));
            }
        }

        public void Delete(List<Person> personList)
        {
            foreach (var person in personList)
            {
                var nodeName = typeof (Person).Name;
                const string tegName = "Id";
                dac.Delete(nodeName, tegName, person.Id);
            }
        }

        public List<Person> GetAll()//возвращает все элементы
        {
            var allElements = dac.GetAll();
            var personsList = new List<Person>();
            foreach (var element in allElements)
            {
                personsList.Add(ConvertTo.Person(element));
            }
            return personsList;
        }
        public List<Person> Search(Dictionary<string, string> searchStrings)
        {
            var elementList = dac.Search(searchStrings);
            return elementList.Select(ConvertTo.Person).ToList();
        }

        /// <summary>
        /// Возвращает имена всех свойств
        /// В файл сохряняются ТОЛЬКО значения свойств
        /// </summary>
        private static List<string> GetElementNames()
        {
            var properties = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var elementNames = new List<string> {typeof (Person).Name};
            elementNames.AddRange(properties.Select(addingProperties => addingProperties.Name));//добавляет имена свойств в список
            return elementNames;
        }
    }
}
