using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue_Class;

namespace _6.Queue.Events
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите тип элемента, который будет храниться в очереди:\n1 - Строка\n2 - Целое число\n0 - Выход");
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
                                        queue_str.D = queue_str.clear;
                                        queue_str.with_delegate(queue_str.D);
                                        break;
                                    case 4://поиск
                                        Console.Write("Введите искомый элемент: ");
                                        queue_str.myEvent += search_result;////свойство
                                        queue_str.find = Console.ReadLine();
                                        queue_str.Event_Call(queue_str.find);
                                        break;
                                    case 5://вывод элемента с заданным индексом
                                        Console.Write("Введите индекс: ");
                                        Console.WriteLine("Результат: " + queue_str[int.Parse(Console.ReadLine())]);
                                        break;
                                    case 6://тест
                                        queue_str.clear();
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            Console.Write("Введите элемент: ");
                                            queue_str.push(Console.ReadLine());
                                        }
                                        queue_str.D = queue_str.test;
                                        queue_str.with_delegate(queue_str.D);
                                        break;
                                    case 7://назад
                                        Console.Clear();
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
                                        queue_int.push(int.Parse(Console.ReadLine()));
                                        break;
                                    case 2://удаление
                                        int deleted_item = queue_int.pop();
                                        if (deleted_item == default(int))
                                            Console.WriteLine("Ошибка! Очередь пуста!\n");
                                        else
                                            Console.WriteLine("Элемент: " + deleted_item);
                                        break;
                                    case 3://очистка
                                        queue_int.D = queue_int.clear;
                                        queue_int.with_delegate(queue_int.D);
                                        break;
                                    case 4://поиск
                                        Console.Write("Введите искомый элемент: ");
                                        queue_int.myEvent += search_result;////свойство
                                        queue_int.find = Console.ReadLine();
                                        queue_int.Event_Call(queue_int.find);
                                        break;
                                    case 5://вывод элемента с заданным индексом
                                        Console.Write("Введите индекс: ");
                                        Console.WriteLine("Результат: " + queue_int[int.Parse(Console.ReadLine())]);
                                        break;
                                    case 6://тест
                                        queue_int.clear();
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            Console.Write("Введите элемент: ");
                                            queue_int.push(int.Parse(Console.ReadLine()));
                                        }
                                        queue_int.D = queue_int.test;
                                        queue_int.with_delegate(queue_int.D);
                                        break;
                                    case 7:
                                        Console.Clear();
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
                }//конец try
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }//конец while
        }//конец main
        public static void search_result(string i)
        {
            Console.WriteLine(i);
        }
    }
}


namespace Queue_Class
{
    class MyQueue<T>
    {
        public class Element//элемент очереди
        {
            public T Data;
            public Element Next;
            public static bool operator true(Element a)
            {
                return a != null;
            }
            public static bool operator false(Element a)
            {
                return a == null;
            }
            public static explicit operator T(Element x) //перегрузка явного приведения типов
            {
                return x.Data;
            }
            public static implicit operator Element(T a)
            {
                return new Element { Data = a };
            }
        }

        public delegate void what_to_do();////////////////////ДЕЛЕГАТ
        public what_to_do D;

        private Element head, tail;
        public int size = 0;

        public T this[int x]
        {
            get
            {
                return find_index(x);
            }
        }

        public T find_index(int index)
        {
            if ((index < 0) || (index > (size - 1)))
                throw new ArgumentOutOfRangeException();
            else
            {
                Element temp = head;
                for (int count = 0; count != index; count++)
                    temp = temp.Next;
                T result = (T)temp;//явное приведение типов
                return result;
            }
        }

        public void push(T data)//добавить элемент в очередь
        {
            Element temp = data;//неявное приведение типов
            if (head)//аналогично if (head != null)
            {
                tail.Next = temp;
                tail = temp;
            }
            else
                head = tail = temp;
            size++;
        }

        public T pop()//удалить элемент из очереди
        {
            if (head)
            {
                T result = head.Data;
                head = head.Next;
                size--;
                return result;
            }
            else
                return default(T);
        }

        public void clear()//очистить очередь
        {
            while (head)
                head = head.Next;
            size = 0;
            Console.WriteLine("Очередь очищена!");
        }

        string _find;

        public string find//поиск
        {
            get
            {
                return _find;
            }
            set
            {
                bool there_is = false;
                Element temp = head;
                while (temp)
                {
                    if (temp.Data.ToString() == value)
                    {
                        there_is = true;
                        _find = _find + "Строка: " + temp.Data.ToString() + "\n";
                    }
                    temp = temp.Next;
                }
                if (there_is)
                    _find = "\nРезультаты поиска:\n" + _find;
                else
                    _find = "\nПоиск не дал результатов";
            }
        }

        public delegate void Handler(string value);
        public event Handler myEvent;

        public void Event_Call(string value)//вызов события
        {
            if (myEvent != null)
                myEvent(value);
        }

        public void with_delegate(what_to_do D)
        {
            D();
        }

        public void test()
        {
            Console.Write(pop());
            Console.Write("\nВведите искомый элемент: ");
            find = Console.ReadLine();
            Console.WriteLine(find);
            Console.Write("Введите индекс: ");
            Console.WriteLine("Результат: " + this[int.Parse(Console.ReadLine())]);
            clear();
        }
    }
}