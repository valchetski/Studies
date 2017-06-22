using System;
using System.Collections;
using System.Collections.Generic;

namespace _5.Queue.Generic_Class
{
    class Program 
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите тип элемента, который будет храниться в очереди:\n1 - Строка\n2 - Целое число\n0 - Выход");//\n3 - Вещественное число
                int instruction = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (instruction)
                {
                    case 1://Строка
                            var queue_str = new MyQueue<string>();
                            bool Exit = true;
                            while (Exit)
                            {
                                Console.Write("Очередь со строками\n1 - Добавить элемент в очередь\n2 - Извлечь элемент из очереди\n3 - Очистить очередь\n4 - Поиск\n5 - Поиск по индексу\n6 - Тест\n7 - Назад\n0 - Выход\nВведите номер операции: ");
                                int choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1://добавление
                                        Console.Write("Введите элемент: ");
                                        queue_str.push(Console.ReadLine());
                                        break;
                                    case 2://удаление
                                        string deleted_item = queue_str.pop();
                                        if (deleted_item == default(string))
                                            Console.WriteLine("Ошибка! Очередь пуста!\n");
                                        else
                                            Console.WriteLine("Элемент: " + deleted_item);
                                        break;
                                    case 3://очистка
                                        queue_str.clear();
                                        break;
                                    case 4://поиск
                                        Console.Write("Введите искомый элемент: ");
                                        queue_str.find = Console.ReadLine();
                                        Console.WriteLine(queue_str.find);
                                        break;
                                    case 5://вывод элемента с заданным индексом
                                        Console.WriteLine("Введите индекс: \nРезультат: " + queue_str[int.Parse(Console.ReadLine())]);
                                        break;
                                    case 6://тест
                                        queue_str.clear();
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            Console.Write("Введите элемент: ");
                                            queue_str.push(Console.ReadLine());
                                        }
                                        queue_str.test();
                                        break;
                                    case 7:
                                        Exit = false;
                                        break;
                                    case 0:
                                        return;
                                    default:
                                        Console.WriteLine("Ошибка! Введите число от 0 до 7");
                                        break;
                                }
                            }
                        break;
                    case 2://Целое число
                        var queue_int = new MyQueue<int>();
                        Exit = true;
                        while (Exit)
                        {
                            Console.Write("Очередь с целыми числами\n1 - Добавить элемент в очередь\n2 - Извлечь элемент из очереди\n3 - Очистить очередь\n4 - Поиск\n5 - Поиск по индексу\n6 - Тест\n7 - Назад\n0 - Выход\nВведите номер операции: ");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1://добавление
                                    Console.Write("Введите элемент: ");
                                    int element = int.Parse(Console.ReadLine());
                                    queue_int.push(element);
                                    break;
                                case 2://удаление
                                    int deleted_item = queue_int.pop();
                                    if (deleted_item == default(int))
                                        Console.WriteLine("Ошибка! Очередь пуста!\n");
                                    else
                                        Console.WriteLine("Элемент: " + deleted_item);
                                    break;
                                case 3://очистка
                                    queue_int.clear();
                                    break;
                                case 4://поиск
                                    Console.Write("Введите искомый элемент: ");
                                    queue_int.find = Console.ReadLine();
                                    Console.WriteLine(queue_int.find);
                                    break;
                                case 5://вывод элемента с заданным индексом
                                    Console.WriteLine("Введите индекс: \nРезультат: " + queue_int[int.Parse(Console.ReadLine())]);
                                    break;
                                case 6://тест
                                    queue_int.clear();
                                    for (int i = 1; i <= 4; i++)
                                    {
                                        Console.Write("Введите элемент: ");
                                        element = int.Parse(Console.ReadLine());
                                        queue_int.push(element);
                                    }
                                    queue_int.test();
                                    break;
                                case 7:
                                    Exit = false;
                                    break;
                                case 0:
                                    return;
                                default:
                                    Console.WriteLine("Ошибка! Введите число от 0 до 7");
                                    break;
                            }
                        }
                        break;
                    case 3://Вещественное число
                        var queue_double = new MyQueue<double>();
                        Exit = true;
                        while (Exit)
                        {
                            Console.Write("Очередь с вещественными числами\n1 - Добавить элемент в очередь\n2 - Извлечь элемент из очереди\n3 - Очистить очередь\n4 - Поиск\n5 - Поиск по индексу\n6 - Тест\n7 - Назад\n0 - Выход\nВведите номер операции: ");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1://добавление
                                    Console.Write("Введите элемент: ");
                                    double element = double.Parse(Console.ReadLine());
                                    queue_double.push(element);
                                    break;
                                case 2://удаление
                                    double deleted_item = queue_double.pop();
                                    if (deleted_item == default(double))
                                        Console.WriteLine("Ошибка! Очередь пуста!\n");
                                    else
                                        Console.WriteLine("Элемент: " + deleted_item);
                                    break;
                                case 3://очистка
                                    queue_double.clear();
                                    break;
                                case 4://поиск
                                    Console.Write("Введите искомый элемент: ");
                                    queue_double.find = Console.ReadLine();
                                    Console.WriteLine(queue_double.find);
                                    break;
                                case 5://вывод элемента с заданным индексом
                                    Console.WriteLine("Введите индекс: \nРезультат: " + queue_double[int.Parse(Console.ReadLine())]);
                                    break;
                                case 6://тест
                                    queue_double.clear();
                                    for (int i = 1; i <= 4; i++)
                                    {
                                        Console.Write("Введите элемент: ");
                                        element = double.Parse(Console.ReadLine());
                                        queue_double.push(element);
                                    }
                                    queue_double.test();
                                    break;
                                case 7:
                                    Exit = false;
                                    break;
                                case 0:
                                    return;
                                default:
                                    Console.WriteLine("Ошибка! Введите число от 0 до 7");
                                    break;
                            }
                        }
                        break;
                    case 0://Выход
                        return;
                }
            }
        }
    }
}

class MyQueue<T> //ТУТА
{
    private class Element//элемент очереди
    {
        public T Data;//ТУТА
        public Element Next;
    }

    private Element head, tail;
    public int size = 0;

    public T this[int x]//ТУТА
    {
        get
        {
            return find_index(x);
        }
    }

    public T find_index(int index)//ТУТА
    {
        while ((index < 0) || (index > (size - 1)))
        {
            Console.Write("Ошибка! Элемента с заданным индексом не существует!\nВведите индекс еще раз: ");
            index = int.Parse(Console.ReadLine());
        }
        Element temp = head;
        for (int count = 0; count != index; count++)
            temp = temp.Next;
        return temp.Data;
    }

    public void push(T data)//добавить элемент в очередь//ТУТА
    {
        var newelm = new Element();
        if (head == null)
        {
            head = tail = newelm;
            head.Data = data;
        }
        else
        {
            tail.Next = newelm;
            tail = newelm;
            tail.Data = data;
        }
        size++;
    }

    public T pop()//удалить элемент из очереди//ТУТА
    {
        if (head == null)
            return default(T);
        else
        {
            T result = head.Data;
            head = head.Next;
            size--;
            return result;
        }
    }

    public void clear()//очистить очередь
    {
        while (head != null)
            head = head.Next;
        size = 0;
        Console.WriteLine("Очередь очищена!");
    }

    private string result;

    public string find//поиск
    {
        get
        {
            return result;
        }
        set
        {
            bool there_is = false;
            Element temp = head;
            while (temp != null)
            {
                string element = temp.Data.ToString();
                if (element == value)
                {
                    there_is = true;
                    result = result + "Строка: " + temp.Data + "\n";
                }
                temp = temp.Next;
            }
            if (there_is)
                result = "\nРезультаты поиска:\n" + result;
            else
                result = "\nПоиск не дал результатов";
        }
    }

    public void test()
    {
        Console.WriteLine(pop());
        Console.Write("Введите искомый элемент: ");
        find = Console.ReadLine();
        Console.WriteLine(find);
        Console.Write("Введите индекс: ");
        Console.WriteLine("Результат: " + this[int.Parse(Console.ReadLine())]);
        clear();
    }
}