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
                Console.Write("1 - Добавить товар в покупку\n2 - Удалить товар из покупки\n3 - Поиск\n4 - Вывести всю покупку\n5 - Фильтровать\n6 - Все товары\n0 - Выход\nВведите номер операции: ");
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
                    case 0:
                        return;
                }
            }
        }
    }
}
