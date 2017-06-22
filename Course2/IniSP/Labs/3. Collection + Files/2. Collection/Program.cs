using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            var my_collection = new Collection_Product();
            while (true)
            {
                Console.WriteLine("1 - Добавить товар в покупку\n2 - Удалить товар из покупки\n3 - Поиск\n4 - Вывести всю покупку\n5 - Фильтровать\n6 - Все товары\n0 - Выход");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Работа с файлами\n7 - Открыть txt-файл\n8 - Сохранить в txt-файл\n9 - Открыть bin-файл\n10 - Сохранить bin-файл\n11 - Сохранить с сжатием\n12 - Открыть сжатый файл\n13 - Запуск мониторинга файла\n14 - Результат мониторинга файла");
                Console.WriteLine("15 - Создать копию файла\n16 - Переименовать");
                Console.Write("----------------------------------------------------------\nВведите номер операции: ");
                int choice = int.Parse(Console.ReadLine());
                var temp_product = new Product();
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите название товара: ");
                        string product_name = Console.ReadLine();                        
                        Console.Write("Введите название бренда: ");
                        string brand_name = Console.ReadLine();
                        Console.Write("Введите стоимость товара: ");
                        int cost = int.Parse(Console.ReadLine());
                        my_collection.Insert(product_name, brand_name, cost);
                        break;
                    case 2:
                        Console.Write("Введите название удаляемого бренда: ");
                        string delete_product = Console.ReadLine();
                        string result = my_collection.Delete(delete_product);
                        Console.WriteLine(result);
                        break;
                    case 3:
                        Console.Write("Введите название искомого товара: ");
                        string search_name = Console.ReadLine();
                        Console.WriteLine(my_collection.Search(search_name));
                        break;
                    case 4:
                        Console.WriteLine(my_collection.Print_all());
                        break;
                    case 5:
                        Console.Write("Введите минимальную стоимость товара: ");
                        int min_cost = int.Parse(Console.ReadLine());
                        string filter = my_collection.Filter(min_cost);
                        if (filter != null)
                            Console.WriteLine(my_collection.Filter(min_cost));
                        else
                            Console.WriteLine("Остутствуют товары стоимостью больше " + min_cost + "руб");
                        break;
                    case 6:
                        Console.WriteLine("Все товары в покупке(без брендов):\n" + my_collection.Projection());
                        break;
                    case 7:
                        my_collection = new Collection_Product();
                        PrintResult(my_collection.Open_txt());
                        break;
                    case 8:
                        PrintResult(my_collection.Save_txt());
                        break;
                    case 9:
                        my_collection = new Collection_Product();
                        PrintResult(my_collection.BinaryOpen());
                        break;
                    case 10:
                        PrintResult(my_collection.BinarySave());
                        break;
                    case 11:
                       PrintResult( my_collection.Save_compression());
                        break;
                    case 12:
                        my_collection = new Collection_Product();
                        PrintResult(my_collection.Open_compression());
                        break;
                    case 13:
                        Console.WriteLine("Мониторинг файла запущен");
                        my_collection.Watcher();
                        break;
                    case 14:
                        Console.WriteLine(my_collection.Change_output());
                        break;
                    case 15:
                        Console.Write("Введите название копируемого файла: ");
                        string copyFile = Console.ReadLine();
                        PrintResult(my_collection.CopyFile(copyFile));
                        break;
                    case 16:
                        Console.Write("Введите старое название файла: ");
                        string oldName = Console.ReadLine();
                        Console.Write("Введите новое название файла: ");
                        string newName = Console.ReadLine();
                        PrintResult(my_collection.Rename(oldName, newName));
                        break;
                    case 17:
                        my_collection.Clear();
                        break;
                    case 0:
                        return;
                }
            }
        }

        static void PrintResult(bool Bool)
        {
            if (Bool == true)
                Console.WriteLine("Операция с файлом успешно завершена!");
            else
                Console.WriteLine("Файл не найден!");
        }
    }
}
