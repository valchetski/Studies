using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example
{
    class Program
    {
        static public double[,] array_result = new double[4, 10];
        static public int j = 0;
        static void print()
        {
            Console.WriteLine("\n  x   y   z   Результат");
            for (int k = 0; k < j; ++k)
                Console.WriteLine("{0,3} {1,3} {2,3}   {3,3}\n", array_result[0, k], array_result[1, k], array_result[2, k], array_result[3, k]);
        }
        static void Interface()
        {
            double denominator = Math.Abs (array_result[0, j] - (2 * array_result[1, j]) / (1 + array_result[0, j] * array_result[0, j] * array_result[1, j] * array_result[1, j])); 
            if (denominator == 0 || array_result[2, j] == 0)
                Console.WriteLine("Ошибка! Знаменатель равен нулю!");
            else
            {                                             
                array_result[3, j] = ((1 + Math.Pow(Math.Sin(array_result[0, j] + array_result[1, j]), 2)) / denominator) * Math.Pow(array_result[0, j], Math.Abs(array_result[1, j])) + Math.Pow(Math.Cos(1 / array_result[2, j]), 2);
                Console.WriteLine("Результат: " + array_result[3, j] + "\n");
                j++; 
            }                                
        }
        static void Main(string[] args)
        {
            bool Exit = true;
            while (Exit)
            {
                Console.WriteLine("1 - Вычислить");
                Console.WriteLine("2 - Тестировать");
                Console.WriteLine("3 - Вывести результаты вычислений");
                Console.WriteLine("4 - Выход\n");
                Console.WriteLine("Введите номер операции: ");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("х = " );
                        array_result[0, j] = double.Parse(Console.ReadLine());
                        Console.WriteLine("y = ");
                        array_result[1, j] = double.Parse(Console.ReadLine());
                        Console.WriteLine("z = ");
                        array_result[2, j] = double.Parse(Console.ReadLine());
                        Interface();                                                                            
                        break;
                    case 2:
                        Random rand = new Random(DateTime.Now.Millisecond);                        
                        array_result[0, j] = rand.Next(-10000, 10000) / 100;
                        Console.WriteLine("x = " + array_result[0, j]);
                        array_result[1, j] = rand.Next(-10000, 10000) / 100;
                        Console.WriteLine("y = " + array_result[1, j]);
                        array_result[2, j] = rand.Next(-10000, 10000) / 100;
                        Console.WriteLine("z = " + array_result[2, j]);
                        Interface();
                        print();
                        break;
                    case 3:
                        print();
                        break;
                    case 4:
                        Exit = false;
                        break; 
                    default:
                        Console.WriteLine("\nОшибка! Введите число от 1 до 4!\n");
                        break;
                }
            }
        }
    }
}
