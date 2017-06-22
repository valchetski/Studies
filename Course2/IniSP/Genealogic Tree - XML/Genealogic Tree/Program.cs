using System;
using System.Collections.Generic;
using GenealogicTree.BusinessLayer;


namespace Genealogic_Tree
{
    static class Program
    {
        private static BusinessComponent businessComponent = new BusinessComponent();
        private static UIprocessComponent uIprocessComponent = new UIprocessComponent();

        private static void Main()
        {
            Person person; List<Person> persons; Dictionary<string, string> searchStrings;
            while (true)
            {
                try
                {
                    Console.Write(
                        "1 - Добавить человека\n2 - Удалить человека\n3 - Вывести всех\n4 - Поиск\n5 - Редактировать\n0 - Выход\nВведите номер операции: ");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            person = uIprocessComponent.Add();
                            businessComponent.Add(person);
                            break;
                        case ConsoleKey.D2:
                            searchStrings = uIprocessComponent.WriteSearchData();
                            persons = businessComponent.Search(searchStrings);
                            businessComponent.Delete(persons);
                            break;
                        case ConsoleKey.D3:
                            persons = businessComponent.GetAll();
                            uIprocessComponent.PrintAll(persons);
                            break;
                        case ConsoleKey.D4:
                            searchStrings = uIprocessComponent.WriteSearchData();
                            persons = businessComponent.Search(searchStrings);
                            uIprocessComponent.PrintAll(persons);
                            break;
                        case ConsoleKey.D5:
                            searchStrings = uIprocessComponent.WriteSearchData();
                            persons = businessComponent.Search(searchStrings);
                            businessComponent.Delete(persons);
                            persons = uIprocessComponent.Editing(persons);
                            foreach (var person1 in persons)
                            {
                                businessComponent.Add(person1);
                            }
                            break;
                        case ConsoleKey.D0:
                            return;
                        default:
                            uIprocessComponent.Error("Нужно ввести число от 0 до 5. Попробуйте еще раз");
                            break;
                    }
                }
                catch (FormatException)
                {
                    uIprocessComponent.Error("Нужно ввести число от 0 до 5. Попробуйте еще раз");
                }
                catch (IncorrectDataEntry incorrectDataEntry)
                {
                    uIprocessComponent.Error(incorrectDataEntry.Message);
                }
                Console.Clear();
            }
        }
    }
}
