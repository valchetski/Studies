using System;
using System.Collections.Generic;
using System.Linq;
using GenealogicTree.BusinessLayer;

namespace Genealogic_Tree
{
    class UIprocessComponent
    {
        public Person Add()
        {
            var person = new Person();
            try
            {
                Console.Clear();
                Console.Write("Введите имя: ");
                person.FirstName = Console.ReadLine();
                Console.Write("Введите отчество: ");
                person.Patronymic = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                person.SurName = Console.ReadLine();
                Console.Write("Введите дату рождения: ");
                person.BirthDayDateTime = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Введите дату смерти(если человек жив, нажмите Enter): ");
                var deadDayString = Console.ReadLine();
                person.DeadDayDateTime = (deadDayString == "") ? person.liveDateTime : Convert.ToDateTime(deadDayString);
                Console.Write("Введите краткую биографию: ");
                person.Biography = Console.ReadLine();
                return person;
            }
            catch (FormatException)
            {
                Error("Неправильный формат даты. Введите дату в виде: ДД.ММ.ГГГГ");
                return null;
            }
        }

        #region Search
        /// <summary>
        /// Вводятся данные, по которым пользователь хочет найти человека
        /// </summary>
        /// <returns>Возвращается Dictionary. Ключ - параметр поиска,
        /// значение - искомая строка</returns>
        public Dictionary<string, string> WriteSearchData()
        {
            Console.Clear();
            var allSearchParametrs = new List<string> {"1", "2", "3", "4", "5", "6"};
            Console.WriteLine("\nВыберите параметры поиска(введите цифры через пробел):\n\tПоиск по");
            Console.WriteLine(
                "\t\t1 - Имени\n\t\t2 - Отчеству\n\t\t3 - Фамилии\n\t\t4 - Дате рождения\n\t\t5 - Дате смерти\n\t\t6 - Возрасту");
            var writedSearchParametrs = new List<string>();
            var searchParametrsString = Console.ReadLine();
            if (searchParametrsString != null)
            {
                writedSearchParametrs = searchParametrsString.Split(' ').ToList();
                var copyWritedSearchParametrs = writedSearchParametrs;
                foreach (var writedSearchParametr in copyWritedSearchParametrs)
                {
                    if (!allSearchParametrs.Contains(writedSearchParametr))
                    {
                        writedSearchParametrs.Remove(writedSearchParametr);
                    }
                }
            }
            return WriteSearchStrings(writedSearchParametrs);
        }

        private Dictionary<string, string> WriteSearchStrings(List<string> searchParametrs)
        {
            var searchStrings = new Dictionary<string, string>();
            foreach (var searchParametr in searchParametrs)
            {
                switch (searchParametr)
                {
                    case "1" :
                        Console.Write("Введите имя: ");
                        break;
                    case "2":
                        Console.Write("Введите отчество: ");
                        break;
                    case "3":
                        Console.Write("Введите фамилию: ");
                        break;
                    case "4":
                        Console.Write("Введите дату рождения: ");
                        break;
                    case "5":
                        Console.Write("Введите дату смерти: ");
                        break;
                    case "6":
                        Console.Write("Введите возраст: ");
                        break;
                }
                searchStrings.Add(searchParametr, Console.ReadLine());
            }
            return searchStrings;
        }
        #endregion

        public List<Person> Editing(List<Person> personList)
        {
            bool isExit = false;
            for (int i = 0; i < personList.Count; i++)
            {
                while (!isExit)
                {
                    Console.WriteLine("1 - Имя\n2 - Отчество\n3 - Фамилию\n4 - Дату рождения\n5 - Дату смерти\n6 - Биографию\n7 - Закончить редактирование");
                    Console.Write("\nЧто редактируем: ");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Введите новое имя: ");
                            personList[i].FirstName = Console.ReadLine();
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Введите новое отчество: ");
                            personList[i].Patronymic = Console.ReadLine();
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Введите новую фамилию: ");
                            personList[i].SurName = Console.ReadLine();
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Введите новую дату рождения: ");
                            personList[i].BirthDayDateTime = Convert.ToDateTime(Console.ReadLine());
                            break;
                        case ConsoleKey.D5:
                            Console.WriteLine("Введите новую дату смерти: ");
                            personList[i].DeadDayDateTime = Convert.ToDateTime(Console.ReadLine());
                            break;
                        case ConsoleKey.D6:
                            Console.WriteLine("Введите новую биографию: ");
                            personList[i].Biography =Console.ReadLine();
                            break;
                        case ConsoleKey.D7:
                            isExit = true;
                            break;
                    }
                }
            }
            return personList;
        }

        public void PrintAll(List<Person> persons)
        {
            try
            {
                int index = 0; 
                while (true)
                {
                    Console.Clear();
                    PrintOne(persons[index]);
                    Console.WriteLine("\n<-- Предыдущий  --> Следующий     BackSpace - В меню");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (index > 0)
                            {
                                index--;
                            }
                            else
                            {
                                index = persons.Count - 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (index < (persons.Count - 1))
                            {
                                index++;
                            }
                            else
                            {
                                index = 0;
                            }
                            break;
                        case ConsoleKey.Backspace:
                            Console.Clear();
                            return;
                    }
                }
            }
            catch (NullReferenceException)
            {
               Console.WriteLine("Ничего нету");
            }
            
        }

        private void PrintOne(Person person)
        {
            Console.WriteLine("Имя: " + person.FirstName);
            Console.WriteLine("Отчество: " + person.Patronymic);
            Console.WriteLine("Фамилия: " + person.SurName);
            Console.WriteLine("Дата рождения: " + person.BirthDayDateTime.ToShortDateString());
            if (person.isAlive)
            {
                Console.WriteLine("Дата смерти: " + person.DeadDayDateTime.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Дата смерти: жив");
            }
            Console.WriteLine("Возраст: " + person.Age);
            Console.WriteLine("Биография: " + person.Biography + "\n");
        }

        public void Error(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine(errorMessage);
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
