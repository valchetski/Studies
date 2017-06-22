using System;
using GenealogicTree.BusinessLayer;

namespace GenealogicTree
{
    static class Program
    {
        private static UIprocessComponent uIprocessComponent;

        private static void Main()
        {
            try
            {
                uIprocessComponent = new UIprocessComponent();
            }
            catch (ArgumentException)
            {
                Console.Write("Ошибка. Проверьте строку подключения\nНажмите любую клавишу для выхода из программы...");
                Console.ReadKey();
                return;
            }
            uIprocessComponent.Registration();
            while (true)
            {
                Console.Clear();
                Console.Write(
                    "1 - Добавить человека\n2 - Добавить родственника\n3 - Удалить человека\n4 - Вывести всех\n5 - Вывести моих родственников\n6 - Поиск\n7 - Редактировать\n0 - Выход\nВведите номер операции: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        uIprocessComponent.Add<Person>();
                        break;
                    case ConsoleKey.D2:
                        uIprocessComponent.AddRelative();
                        break;
                    case ConsoleKey.D3:
                        uIprocessComponent.Delete();
                        break;
                    case ConsoleKey.D4:
                        uIprocessComponent.PrintAll();
                        break;
                    case ConsoleKey.D5:
                        uIprocessComponent.PrintMyRelatives();
                        break;
                    case ConsoleKey.D6:
                        uIprocessComponent.Search();
                        break;
                    case ConsoleKey.D7:
                        uIprocessComponent.Edit();
                        break;
                    case ConsoleKey.D0:
                        return;
                    default:
                        uIprocessComponent.PrintResultOfOperation("Нужно ввести число от 0 до 7. Попробуйте еще раз");
                        break;
                }
            }
        }
    }
}
