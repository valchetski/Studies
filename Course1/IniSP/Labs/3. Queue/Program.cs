using System;

namespace _3.Queue
{
    class Program
    {
        static void Main()
        {
            var queue = new MyQueue();
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("\n1 - Добавить строку в очередь");
                Console.WriteLine("2 - Извлечь строку из очереди");
                Console.WriteLine("3 - Очистить очередь");
                Console.WriteLine("4 - Поиск");
                Console.WriteLine("5 - Поиск по индексу");
                Console.WriteLine("6 - Тест");
                Console.WriteLine("0 - Выход");
                Console.Write("Введите номер операции: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1://добавление
                        Console.Write("Введите строку: ");
                        queue.Push(Console.ReadLine());
                        break;
                    case 2://удаление
                        Console.Write(queue.Pop());
                        break;
                    case 3://очистка
                        queue.Clear();
                        Console.WriteLine("Очередь очищена!");
                        break;
                    case 4://поиск
                        Console.Write("Введите искомую строку: ");
                        queue.Find = Console.ReadLine();
                        Console.WriteLine(queue.Find);
                        break;
                    case 5://вывод элемента с заданным индексом
                        Console.Write("Введите индекс: ");
                        Console.WriteLine("Результат: " + queue[int.Parse(Console.ReadLine())]);
                        break;
                    case 6://тест
                        queue.Clear();
                        for (int i = 1; i <= 4; i++)
                        {
                            Console.Write("Введите строку: ");
                            queue.Push(Console.ReadLine());
                        }
                        Console.Write(queue.Pop());
                        Console.Write("Введите искомую строку: ");
                        queue.Find = Console.ReadLine();
                        Console.WriteLine(queue.Find);
                        Console.Write("Введите индекс: ");
                        Console.WriteLine("Результат: " + queue[int.Parse(Console.ReadLine())]);
                        queue.Clear();
                        Console.WriteLine("Очередь очищена!");
                        break;
                    case 0:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка! Введите число от 0 до 4");
                        break;
                }
            }
        }
    }
}

class MyQueue
{
    private class Element//элемент очереди
    {
        public string data;
        public Element next;
    }

    private Element head, tail;
    public int size = 0;

    public string this[int x]
    {
        get
        {
            return FindString(x);
        }
    }

    public string FindString(int index)
    {
        if ((index > 0) || (index < (size - 1)))
        {
            Element temp = head;
            for (int count = 0; count != index; count++)
                temp = temp.next;
            return temp.data;
        }
        return "Элемента с таким индексом не существует";
    }

    public void Push(string data)//добавить элемент в очередь
    {
        var newelm = new Element();
        if (head == null)
        {
            head = tail = newelm;
            head.data = data;
        }
        else
        {
            tail.next = newelm;
            tail = newelm;
            tail.data = data;
        }
        size++;
    }

    public string Pop() //удалить элемент из очереди
    {
        if (head != null)
        {
            string result = "Строка: " + head.data + "\n";
            head = head.next;
            size--;
            return result;
        }
        return "Ошибка! Очередь пуста!\n";
    }

    public void Clear()//очистить очередь
    {
        while (head != null)
            head = head.next;
        size = 0;
    }

    private string find = "";

    public string Find//поиск
    {
        get
        {
            return find;
        }
        set
        {
            bool thereIs = false;
            Element temp = head;
            while (temp != null)
            {
                if (temp.data == value)
                {
                    thereIs = true;
                    find = find + "Строка: " + temp.data + "\n";
                }
                temp = temp.next;
            }
            if (thereIs)
                find = "\nРезультаты поиска:\n" + find;
            else
                find = "\nПоиск не дал результатов";
        }
    }
}