using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GenealogicTree.BusinessLayer
{
    public static class ConvertTo
    {
        public static KindOfRelative KindOfRelative(string str)
        {
            switch (str)
            {
                case "Папа":
                    return BusinessLayer.KindOfRelative.Father;
                case "Мама":
                    return BusinessLayer.KindOfRelative.Mother;
                case "Брат":
                    return BusinessLayer.KindOfRelative.Brother;
                case "Сестра":
                    return BusinessLayer.KindOfRelative.Sister;
                case "Муж":
                    return BusinessLayer.KindOfRelative.Husband;
                case "Жена":
                    return BusinessLayer.KindOfRelative.Wife;
                default:
                    return BusinessLayer.KindOfRelative.NotRelative;
            }
        }

        public static string Stringg(KindOfRelative kindOfRelative)
        {
            switch (kindOfRelative)
            {
                case BusinessLayer.KindOfRelative.Father:
                    return "Папа";
                case BusinessLayer.KindOfRelative.Mother:
                    return "Мама";
                case BusinessLayer.KindOfRelative.Brother:
                    return "Брат";
                case BusinessLayer.KindOfRelative.Sister:
                    return "Сестра";
                case BusinessLayer.KindOfRelative.Grandfather:
                    return "Дедушка";
                case BusinessLayer.KindOfRelative.Grandmother:
                    return "Бабушка";
                case BusinessLayer.KindOfRelative.Husband:
                    return "Муж";
                case BusinessLayer.KindOfRelative.Wife:
                    return "Жена";
                case BusinessLayer.KindOfRelative.BrotherInLow:
                    return "Зять(муж сестры)";
                default:
                    return "";
            }
        }

        public static List<Person> Person(List<List<string>> list)
        {
            return list.Select(Person).ToList();
        }
        
        public static Person Person(List<string> list)
        {
            try
            {
                var id = Convert.ToInt32(list[0]);
                var firstName = list[1];
                var patronymic = list[2];
                var surName = list[3];
                var birthDay = Convert.ToDateTime(list[4]);
                var deadDay = Convert.ToDateTime(list[5]);
                var biography = list[6];
                bool isItMe;
                bool.TryParse(list[7], out isItMe);
                return new Person(id, firstName, patronymic, surName, birthDay, deadDay, biography, isItMe);
            }
            catch (ArgumentOutOfRangeException)
            {
                return new Person();
            }
            catch (NullReferenceException)
            {
                return new Person();
            }
        }

        public static Dictionary<string, string> Dictionary(Person person)
        {
            var dictionary = new Dictionary<string, string>();
            if ((person != default(Person)) && (person != new Person()))
            {
                var elementNames = GetElementNames<Person>();
                try
                {
                    dictionary.Add(elementNames[0], Convert.ToString(person.Id));
                    dictionary.Add(elementNames[1], person.FirstName);
                    dictionary.Add(elementNames[2], person.Patronymic);
                    dictionary.Add(elementNames[3], person.SurName);
                    dictionary.Add(elementNames[4], String.Format("{0:yyyy-MM-dd}", person.BirthDay));
                    dictionary.Add(elementNames[5], String.Format("{0:yyyy-MM-dd}", person.DeadDay));
                    dictionary.Add(elementNames[6], person.Biography);
                    dictionary.Add(elementNames[7], Convert.ToString(person.IsItMe));
                }
                catch (IndexOutOfRangeException)
                {
                    dictionary = new Dictionary<string, string>();
                }
            }
            return dictionary;
        }

        public static Dictionary<string, string> Dictionary(Relative relative)
        {
            var dictionary = new Dictionary<string, string>();
            if ((relative != default(Relative)) && (relative != new Relative()))
            {
                var elementNames = GetElementNames<Relative>();
                try
                {
                    dictionary.Add(elementNames[1], Convert.ToString(relative.IdPerson));
                    dictionary.Add(elementNames[2], Convert.ToString(relative.IdHisRelative));
                    dictionary.Add(elementNames[3], Convert.ToString(relative.KindOfRelative));
                }
                catch (IndexOutOfRangeException)
                {
                    dictionary = new Dictionary<string, string>();
                }
            }
            return dictionary;
        }

        public static Dictionary<Person, KindOfRelative> Dictionary(Dictionary<List<string>, string> dictionary)
        {
            return dictionary.ToDictionary(d => Person(d.Key), immediateRelative => KindOfRelative(immediateRelative.Value));
        }

        private static List<string> GetElementNames<T>()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return (properties.Select(addingProperties => addingProperties.Name)).ToList();
        }

    }
}
