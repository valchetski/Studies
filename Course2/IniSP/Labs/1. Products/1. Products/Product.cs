using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Products
{
    class Product : IComparable<Product>, IEquatable<Product>
    {
        public string name;//название товара
        public double cost;//стоимость товара
        public string currency;//наименование валюты
        static readonly double[,] CurrencyTable = { { 1, 0.739, 31.74, 9030 }, { 1.353, 1, 42.953, 12220 }, { 0.0315, 0.0233, 1, 284.5 }, { 0.000111, 0.0000818, 0.00351, 1 } };
        //таблица конвертации валют

        public void Parse()
        {
            try
            {
                string temp = "", str = Console.ReadLine();
                if (str != null)
                {
                    str = str.Trim();//удаляет знаки пробела в начале и в конце
                    foreach (char t in str)
                    {
                        if (t != ' ')
                            temp += t;
                        else
                        {
                            if (name == default(string))
                                name = temp;
                            else if (cost == default(double))
                                cost = int.Parse(temp);
                            else if (currency == default(string))
                            {
                                if (temp != "$" && temp != "Euro" && temp != "R.R" && temp != "B.R")
                                    throw new FormatException("Название валюты введено неправильно!");
                                currency = temp;
                            }
                            temp = "";
                        }
                    }
                }
                if ((temp != "") && (currency == default(string)))
                {
                    if (temp == "$" || temp == "Euro" || temp == "R.R" || temp == "B.R")
                    {
                        currency = temp;
                    }
                    else
                    {
                        throw new FormatException("Название валюты введено неправильно!");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода!");
            }
        }

        public void Convert(int choice, int number, ref List<Product> goods)
        {
            int temp = calculate_number(goods[number].currency);
            switch (choice)
            {
                case 1:
                    goods[number].cost = goods[number] * CurrencyTable[temp, 0];
                    /////////////////////////////////////////// перегрузка *
                    goods[number].currency = "$";
                    break;
                case 2:
                    goods[number].cost = goods[number] * CurrencyTable[temp, 1];
                    goods[number].currency = "Euro";
                    break;
                case 3:
                    goods[number].cost = goods[number] * CurrencyTable[temp, 2];
                    goods[number].currency = "R.R";
                    break;
                case 4:
                    goods[number].cost = goods[number] * CurrencyTable[temp, 3];
                    goods[number].currency = "B.R";
                    break;
            }
        }

        public int Search(string temp, List<Product> goods)//поиск нужного товара по имени
        {
            temp = temp.Trim();
            return goods.TakeWhile(i => i.name != temp).Count();
        }

        public string Sum(int first, int second, ref List<Product> goods)
        {
            string result;
            if (goods[first].currency == goods[second].currency)
                result = "Общая стоиость товаров равна: " + System.Convert.ToString(goods[second] + goods[first]) + goods[first].currency;
            //перегрузка сложения
            else
            {
                double totalValue = goods[first].cost + goods[second].cost * CurrencyTable[calculate_number(goods[second].currency), calculate_number(goods[first].currency)];
                result = "Общая стоиость товаров равна: " + totalValue + goods[first].currency;
                totalValue *= CurrencyTable[calculate_number(goods[first].currency), calculate_number(goods[second].currency)];
                result += " или " + totalValue + goods[second].currency;
            }
            return result;
        }

        int calculate_number(string currency)//подсчет номера валюты в таблице конвертации валют
        {
            switch (currency)
            {
                case "$":
                    return 0;
                case "Euro":
                    return 1;
                case "R.R":
                    return 2;
                case "B.R":
                    return 3;
            }
            return 1000;
        }

        public static double operator +(Product a, Product b) // перегрузка +
        {
            return a.cost + b.cost;
        }

        public static double operator *(Product a, double b) // перегрузка *
        {
            return a.cost * b;
        }

        public string Compare_products(int first, int second, ref List<Product> goods)
        {

            if (goods[first].currency != goods[second].currency)
                goods[second].cost = goods[second].cost * CurrencyTable[calculate_number(goods[second].currency), calculate_number(goods[first].currency)];
            if (goods[first].Equals(goods[second]))
                return "Стоимость товаров одинаковая";
            if (goods[first].CompareTo(goods[second]) < 0)
                return "Стоимость первого товара меньше второго";
            return "Стоимость первого товара больше второго";
        }

        public int CompareTo(Product b)
        {
            if (cost < b.cost)
                return -1;
            if (cost > b.cost)
                return 1;
            return 0;
        }

        public bool Equals(Product b)
        {
            if (cost == b.cost)
                return true;
            return false;
        }
    }
}
