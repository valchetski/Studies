using System;

namespace Lab4
{
    class Program
    {
        static void Main()
        {
            var myCollection = new CollectionProduct();
            while (true)
            {
                Console.Write("1 - Добавить товар в покупку\n2 - Удалить товар из покупки\n3 - Поиск\n4 - Вывести всю покупку\n5 - Фильтровать\n6 - Все товары\n");
                Console.Write("--------------------------------------------------------\n");
                Console.WriteLine("\tРабота с файлами");
                Console.Write("--------------------------------------------------------");
                Console.Write("\n7 - Открыть XML-файл\n8 - Сохранить в XML-файл\n9 - Открыть bin-файл(десериализация)");
                Console.Write("\n10 - Сохранить в bin-файл(сериализация)\n11 - Открыть XML-файл(десериализация)\n12 - Сохранить в XML-файл(сериализация)");
                Console.Write("\n13 - Проверить наличие в XML файле\n14 - Сериализация контракта данных\n15 - Десериализация контракта данных\n0 - Выход\nВведите номер операции: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите название товара: ");
                        string productName = Console.ReadLine();
                        Console.Write("Введите название бренда: ");
                        string brandName = Console.ReadLine();
                        Console.Write("Введите стоимость товара: ");
                        int cost = int.Parse(Console.ReadLine());
                        myCollection.Insert(productName, brandName, cost);
                        break;
                    case 2:
                        Console.Write("Введите название удаляемого бренда: ");
                        string deleteProduct = Console.ReadLine();
                        string result = myCollection.Delete(deleteProduct);
                        Console.WriteLine(result);
                        break;
                    case 3:
                        Console.Write("Введите название искомого товара: ");
                        string searchName = Console.ReadLine();
                        Console.WriteLine(myCollection.Search(searchName));
                        break;
                    case 4:
                        Console.WriteLine(myCollection.Print_all());
                        break;
                    case 5:
                        Console.Write("Введите минимальную стоимость товара: ");
                        int minCost = int.Parse(Console.ReadLine());
                        string filter = myCollection.Filter(minCost);
                        if (filter != null)
                            Console.WriteLine(myCollection.Filter(minCost));
                        else
                            Console.WriteLine("Остутствуют товары стоимостью больше " + minCost + "руб");
                        break;
                    case 6:
                        Console.WriteLine("Все товары в покупке(без брендов):\n" + myCollection.Projection());
                        break;
                    case 7:
                        myCollection.OpenXML();
                        break;
                    case 8:
                        myCollection.SaveXML();
                        break;
                    case 9:
                        myCollection.DeserializeBin();
                        break;
                    case 10:
                        myCollection.SerializeBin();
                        break;
                    case 11:
                        myCollection.DeserializeXML();
                        break;
                    case 12:
                        myCollection.SerializeXML();
                        break;
                    case 13:
                        Console.Write("Введите имя искомого товара: ");
                        string searchProduct = Console.ReadLine();
                        Console.Write("Введите имя брэнда товара: ");
                        string searchBrand = Console.ReadLine();
                        Console.WriteLine(
                            myCollection.IsFound(searchProduct, searchBrand)
                                ? "Товар <<{0} {1}>> найден"
                                : "Товар <<{0} {1}>> не найден", searchProduct, searchBrand);
                        break;
                    case 14:
                        myCollection.SerializeContract();
                        break;
                    case 15:
                        myCollection.DeserializeContract();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}
