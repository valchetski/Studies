using System;
using System.Collections.Generic;

namespace _1.Products
{
    class Program
    {
        static void Main()
        {
            var goods = new List<Product>();//список товаров
            while (true)
            {
                try
                {
                    var a = new Product();
                    Console.Write("1 - Добавить товар\n2 - Перевести в другую валюту\n3 - Суммировать цену товаров\n4 - Сравнить цену товаров\n0 - Выход\nВведите номер операции: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введите через пробел:\n1) Название товара\n2) Стоимость товара\n3) Название валюты($, Euro, R.R или B.R)");
                            a.Parse();
                            goods.Add(a);//введенный товар добавляется в список
                            break;
                        case 2://конвертация
                            Console.Write("Введите название товара: ");
                            int number = a.Search(Console.ReadLine(), goods);   //номер товара в списке
                            if (!check_presence(number, goods))
                                continue;
                            Console.WriteLine("1 - $\n2 - Euro\n3 - R.R\n4 - B.R\nВведите номер валюты, в которую хотите первести исходную: ");
                            a.Convert(int.Parse(Console.ReadLine()), number, ref goods);//конвертация из одной валюты в другую
                            Console.WriteLine("Название товара: " + goods[number].name + " Цена: " + goods[number].cost + " Валюта: " + goods[number].currency);
                            break;
                        case 3://сумма
                            Console.Write("Введите название первого товара: ");
                            int first = a.Search(Console.ReadLine(), goods);
                            if (!check_presence(first, goods))
                                continue;
                            Console.Write("Введите название второго товара: ");
                            int second = a.Search(Console.ReadLine(), goods);
                            if (!check_presence(second, goods))
                                continue;
                            Console.WriteLine(a.Sum(first, second, ref goods));//суммирование стоимости товаров
                            break;
                        case 4://сравнение
                            Console.Write("Введите название первого товара: ");
                            int first1 = a.Search(Console.ReadLine(), goods);
                            if (!check_presence(first1, goods))
                                continue;
                            Console.Write("Введите название второго товара: ");
                            int second1 = a.Search(Console.ReadLine(), goods);
                            if (!check_presence(second1, goods))
                                continue;
                            Console.WriteLine(a.Compare_products(first1, second1, ref goods));//сравнение цен товаров
                            break;
                        default:
                            Console.WriteLine("Неправильный ввод! Введите число от 0 до 4!");
                            break;
                        case 0:
                            return;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильный ввод! Введите число от 0 до 4!");
                }
            }
        }

        static bool check_presence(int number, List<Product> goods)
        {
            if (number < goods.Count)
            {
                Console.WriteLine("Название товара: " + goods[number].name + " Цена: " + goods[number].cost + " Валюта: " + goods[number].currency);
                return true;
            }
            Console.WriteLine("Такого товара нет в списке!");
            return false;
        }
    }
}