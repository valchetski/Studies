using System;
using System.Collections.Generic;
using System.Linq;
using GenealogicTree.BusinessLayer;

namespace GenealogicTree
{
    class UIprocessComponent
    {
        private readonly BusinessComponent businessComponent;

        public UIprocessComponent()
        {
            businessComponent = new BusinessComponent();
        }

        public void Registration()
        {
            try
            {
                if (businessComponent.IsRegistated() == false)
                {
                    PrintResultOfOperation(
                        "Добро пожаловать в программу \"Генеалогическое дерево\"!\nСейчас вам будет предложено пройти регистрацию");
                    Add<Me>();
                }
            }
            catch (InvalidOperationException)
            {
                PrintResultOfOperation("База данных была изменена. Используй миграции");
            }
        }

        #region Add
        public void Add<T>() where T : Person, new ()
        {
            //var person = new Person {FirstName = "иван", Patronymic = "sfsfsd", SurName = "vcxvxcvx", IsItMe = true};
            var person = new T();
            try
            {
                Console.Clear();
                Console.Write("Введите имя: ");
                person.FirstName = Console.ReadLine();
                Console.Write("Введите отчество: ");
                person.Patronymic = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                person.SurName = Console.ReadLine();
                Console.Write("Введите дату рождения(ДД.ММ.ГГГГ): ");
                person.BirthDay = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Введите дату смерти(если человек жив, нажмите Enter): ");
                var deadDayString = Console.ReadLine();
                DateTime deadDate;
                DateTime.TryParse(deadDayString, out deadDate);
                person.DeadDay = deadDate;
                Console.Write("Введите краткую биографию: ");
                person.Biography = Console.ReadLine();
                person.IsItMe = (person is Me);
                PrintResultOfOperation(businessComponent.Add(person));
            }
            catch (FormatException)
            {
                PrintResultOfOperation("Неправильный формат даты. Введите дату в виде: ДД.ММ.ГГГГ");
            }
            catch (IncorrectDataEntry incorrectDataEntry)
            {
                PrintResultOfOperation(incorrectDataEntry.Message);
            }
        }

        public void AddRelative()
        {
            var relative = new Relative();
            Console.Clear();
            Console.Write("Введите id человека: ");
            string readline = Console.ReadLine();
            int number;
            if (int.TryParse(readline, out number))
            {
                relative.IdPerson = number;
            }
            Console.Write("Введите id родственника: ");
            readline = Console.ReadLine();
            if (int.TryParse(readline, out number))
            {
                relative.IdHisRelative = number;
            }
            Console.WriteLine("Кем приходится родственник?");
            Console.WriteLine("1 - Папа\n2 - Мама\n3 - Брат\n4 - Сестра\n5 - Муж\n6 - Жена");
            
            readline = Console.ReadLine();
            try
            {
                if (int.TryParse(readline, out number))
                {
                    if ((number >= 1) && (number <= 6))
                    {
                        relative.KindOfRelative = ConvertTo.Stringg((KindOfRelative) (number - 1));
                    }
                    else
                    {
                        throw new IncorrectDataEntry("Нужно ввести число от 1 до 6. Попробуйте еще раз.");
                    }
                }
                PrintResultOfOperation(businessComponent.Add(relative));
            }
            catch (IncorrectDataEntry incorrectDataEntry)
            {
                PrintResultOfOperation(incorrectDataEntry.Message);
            }
        }
        #endregion

        public void Delete()
        {
            var person = (businessComponent.Search(WriteSearchData())).FirstOrDefault();
            if (person != null)
            {
                Console.Clear();
                PrintOne(person);
                Console.Write("Вы действительно хотите удалить этого человека:\n1 - Да\n2 - Нет\nВведите номер операции: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        PrintResultOfOperation(businessComponent.Delete(person));
                        break;
                    case ConsoleKey.D2:
                        PrintResultOfOperation("Удаление отменено");
                        break;
                    default:
                        PrintResultOfOperation("Нужно нажать на клавишу 1 или 2.");
                        break;
                }
            }
            else
            {
                PrintResultOfOperation("Поиск не дал результатов");
            }
        }

        public void Edit()
        {
            bool isExit = false;
            var person = SearchById();
            if ((person != null) && (person != new Person()))
            {
                #region Change Fields
                while (!isExit)
                {
                    Console.Clear();
                    PrintOne(person);
                    Console.WriteLine(
                        "1 - Имя\n2 - Отчество\n3 - Фамилию\n4 - Дату рождения\n5 - Дату смерти\n6 - Биографию\n7 - Закончить редактирование");
                    Console.Write("\nЧто редактируем: ");
                    try
                    {
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                                Console.Write("\nВведите новое имя: ");
                                person.FirstName = Console.ReadLine();
                                break;
                            case ConsoleKey.D2:
                                Console.Write("\nВведите новое отчество: ");
                                person.Patronymic = Console.ReadLine();
                                break;
                            case ConsoleKey.D3:
                                Console.Write("\nВведите новую фамилию: ");
                                person.SurName = Console.ReadLine();
                                break;
                            case ConsoleKey.D4:
                                Console.Write("\nВведите новую дату рождения: ");
                                person.BirthDay = Convert.ToDateTime(Console.ReadLine());
                                break;
                            case ConsoleKey.D5:
                                Console.Write("\nВведите новую дату смерти: ");
                                person.DeadDay = Convert.ToDateTime(Console.ReadLine());
                                break;
                            case ConsoleKey.D6:
                                Console.Write("\nВведите новую биографию: ");
                                person.Biography = Console.ReadLine();
                                break;
                            case ConsoleKey.D7:
                                isExit = true;
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        PrintResultOfOperation("Неправильный формат даты. Введите дату в виде: ДД.ММ.ГГГГ");
                    }
                    catch (IncorrectDataEntry incorrectDataEntry)
                    {
                        PrintResultOfOperation(incorrectDataEntry.Message);
                    }
                }
                businessComponent.Update(person);
                #endregion
            }
        }

        #region Search

        private Person SearchById()
        {
            Console.Clear();
            Console.Write("Введите ID для поиска человека:");
            int id;
            Person person;
            try
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new IncorrectDataEntry(
                        "ID должно состоять только из цифр \nи его длина не должна превышать 10-ти цифр");
                }
                person = businessComponent.SearchById(id);
                if ((person == null) || (person.Id == 0))
                {
                    throw new IncorrectDataEntry(String.Format("Человек с ID = {0} не найден", id));
                }
            }
            catch (IncorrectDataEntry incorrectDataEntry)
            {
                PrintResultOfOperation(incorrectDataEntry.Message);
                person = null;
            }
            return person;
        }

        public void Search()
        {
            var persons = businessComponent.Search(WriteSearchData());
            if (persons.Count != 0)
            {
                PrintSomebodies(persons);
            }
            else
            {
                PrintResultOfOperation("Поиск не дал результатов");
            }
        }

        /// <summary>
        /// Вводятся данные, по которым пользователь хочет найти человека
        /// </summary>
        /// <returns>Возвращается Dictionary. Ключ - параметр поиска,
        /// значение - искомая строка</returns>
        private Dictionary<string, string> WriteSearchData()
        {
            Console.Clear();
            var allSearchParametrs = new List<string> {"1", "2", "3", "4", "5", "6", "7"};
            Console.WriteLine("Поиск по:\n\t1 - ID\n\t2 - Имени\n\t3 - Отчеству\n\t4 - Фамилии\n\t5 - Дате рождения\n\t6 - Дате смерти\n\t7 - Возрасту");
            Console.Write("\nВыберите параметры поиска(введите цифры через пробел): ");
            var readLine = Console.ReadLine();
            var searchParametrs = new List<string>();
            if (readLine != null)
            {
                searchParametrs = readLine.Split(' ').Where(allSearchParametrs.Contains).ToList();
                searchParametrs = searchParametrs.Distinct().ToList();//удаляет повторяющиеся элементы
            }
            return WriteSearchStrings(searchParametrs);
        }

        private Dictionary<string, string> WriteSearchStrings(List<string> searchParametrs)
        {
            var searchStrings = new Dictionary<string, string>();
            foreach (var searchParametr in searchParametrs)
            {
                switch (searchParametr)
                {
                    case "1":
                        Console.Write("Введите ID: ");
                        break;
                    case "2" :
                        Console.Write("Введите имя: ");
                        break;
                    case "3":
                        Console.Write("Введите отчество: ");
                        break;
                    case "4":
                        Console.Write("Введите фамилию: ");
                        break;
                    case "5":
                        Console.Write("Введите дату рождения: ");
                        break;
                    case "6":
                        Console.Write("Введите дату смерти: ");
                        break;
                    case "7":
                        Console.Write("Введите возраст: ");
                        break;
                }
                searchStrings.Add(GetParametrsNames(searchParametr), Console.ReadLine());
            }
            return searchStrings;
        }

        private string GetParametrsNames(string searchParametr)
        {
            switch (searchParametr)
            {
                case "1":
                    searchParametr = "Id";
                    break;
                case "2":
                    searchParametr = "FirstName";
                    break;
                case "3":
                    searchParametr = "Patronymic";
                    break;
                case "4":
                    searchParametr = "SurName";
                    break;
                case "5":
                    searchParametr = "BirstDay";
                    break;
                case "6":
                    searchParametr = "DeadDay";
                    break;
                case "7":
                    searchParametr = "Age";
                    break;
            }
            return searchParametr;
        }
        #endregion


        #region Print

        public void PrintResultOfOperation(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.Write("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void PrintAll()
        {
            PrintSomebodies(businessComponent.GetAll());
        }

        public void PrintMyRelatives()
        {
            var myRelatives = businessComponent.GetMyRelatives();
            try
            {
                int index = 0;
                var keys = myRelatives.Keys.ToList();
                var values = myRelatives.Values.ToList();
                while (true)
                {
                    Console.Clear();
                    var keyAndValue = new KeyValuePair<Person, KindOfRelative>(keys[index], values[index]);
                    Console.WriteLine("[{0}/{1}]", index + 1, myRelatives.Count);
                    PrintOne(keyAndValue);
                    Console.WriteLine("\n<-- Предыдущий  --> Следующий     BackSpace - В меню");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            index = (index > 0) ? (index - 1) : (keys.Count - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            index = (index < (keys.Count - 1)) ? index + 1 : 0;
                            break;
                        case ConsoleKey.Backspace:
                            return;
                    }
                }
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException) { }
            Console.WriteLine("Ничего нету\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        private void PrintSomebodies(List<Person> persons)
        {
            try
            {
                int index = 0;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[{0}/{1}]", index + 1, persons.Count);
                    PrintOne(persons[index]);
                    Console.WriteLine("\n<-- Предыдущий  --> Следующий     BackSpace - В меню");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            index = (index > 0) ? (index - 1) : (persons.Count - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            index = (index < (persons.Count - 1)) ? index + 1 : 0;
                            break;
                        case ConsoleKey.Backspace:
                            return;
                    }
                }
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException) { }
            PrintResultOfOperation("Ничего нет");
        }

        private void PrintOne(Person person)
        {
            if((person != null) && (person != new Person()))
            {
                Console.WriteLine("ID: " + person.Id);
                Console.WriteLine("Имя: " + person.FirstName);
                Console.WriteLine("Отчество: " + person.Patronymic);
                Console.WriteLine("Фамилия: " + person.SurName);
                Console.WriteLine("Дата рождения: " + person.BirthDay.ToShortDateString());
                Console.WriteLine("Дата смерти: {0}", person.isAlive ? "жив" : person.DeadDay.ToShortDateString());
                Console.WriteLine("Возраст: " + person.Age);
                Console.WriteLine("Биография: " + person.Biography + "\n");
            }
        }

        private void PrintOne(KeyValuePair<Person,KindOfRelative> myRelative)
        {
            PrintOne(myRelative.Key);
            Console.WriteLine("Кем приходится: " + ConvertTo.Stringg(myRelative.Value) + "\n");
        }
        #endregion
    }
}
