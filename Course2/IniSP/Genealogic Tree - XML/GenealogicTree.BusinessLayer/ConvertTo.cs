using System;
using System.Collections.Generic;

namespace GenealogicTree.BusinessLayer
{
    static class ConvertTo
    {
        public static Person Person(List<string> list)
        {
            try
            {
                var firstName = list[0];
                var patronymic = list[1];
                var surName = list[2];
                var birthDay = Convert.ToDateTime(list[3]);
                var deadDay = Convert.ToDateTime(list[4]);
                var biography = list[7];
                return new Person(firstName, patronymic, surName, birthDay, deadDay, biography);
            }
            catch (ArgumentOutOfRangeException)
            {
                return new Person();
            }
        }

        public static List<string> ListString(Person person)
        {
            if ((person != default (Person)) && (person != new Person()))
            {
                var list = new List<string>
                {
                    person.FirstName,
                    person.Patronymic,
                    person.SurName,
                    String.Format("{0:dd/MM/yyyy}", person.BirthDayDateTime),
                    String.Format("{0:dd/MM/yyyy}", person.DeadDayDateTime),
                    Convert.ToString(person.Age),
                    Convert.ToString(person.Id),
                    person.Biography
                };
                return list;
            }
            return null;
        }
    }
}