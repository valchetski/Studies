using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    class Program
    {
        static PhonesList phones = new PhonesList(); 
        static void Main(string[] args)
        {                       
            while(true)
            {               
                Console.Write("1 - Добавить телефон\n2 - Вывести все\n3 - Abstract Factory\n4 - Factory Method\n0 - Выход\nВведите номер операции: ");
                var choice = Console.ReadKey().Key;                
                switch(choice)
                {
                    case ConsoleKey.D1:
                        Console.Write("\nНазвание телефона: ");
                        string name = Console.ReadLine();
                        Console.Write("Цвет телефона: ");
                        string color = Console.ReadLine();
                        Console.Write("Стоимость телефона: ");
                        double cost = int.Parse(Console.ReadLine());
                        phones.Insert(name, cost, color);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(phones.GetAllPhones());
                        break;
                    case ConsoleKey.D3:
                        MethodAbstractFactory();
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                        MethodForFactoryMethod();
                        Console.Clear();
                        break;
                    case ConsoleKey.D0:
                        return;
                }
            }
        }
        static void MethodAbstractFactory()
        {
            Console.Clear();
            var txtFactory = new TXTFactory();
            var binFactory = new BinFactory();
            var xmlFactory = new XMLFactory();
            var abstractFactory = new AbstractFactory();
            var fileTXT = abstractFactory.CreateFile(txtFactory);
            var fileBin = abstractFactory.CreateFile(binFactory);
            var fileXML = abstractFactory.CreateFile(xmlFactory);
            while (true)
            {                
                Console.WriteLine("\tAbstractFactory");
                Console.Write("1 - Сохранить в TXT\n2 - Открыть TXT\n3 - Сохранить в Bin\n4 - Открыть Bin\n5 - Сохранить в XML\n7 - Открыть XML\n9 - Назад\n0 - Выход\nВведите номер операции: ");
                var choice = Console.ReadKey().Key;
                Console.WriteLine();
                switch (choice)
                {
                    case ConsoleKey.D1:
                        fileTXT.Save(phones);
                        break;
                    case ConsoleKey.D2:
                        phones = fileTXT.Load();
                        break;
                    case ConsoleKey.D3:
                        fileBin.Save(phones);
                        break;
                    case ConsoleKey.D4:
                        phones = fileBin.Load();
                        break;
                    case ConsoleKey.D5:
                        fileXML.Save(phones);
                        break;
                    case ConsoleKey.D7:
                        phones = fileXML.Load();
                        break;
                    case ConsoleKey.D9:
                        return;
                    case ConsoleKey.D0:
                        Environment.Exit(1);
                        break;
                }
            }
        }
        static void MethodForFactoryMethod()
        {
            Console.Clear();
            var factoryMethod = new FactoryMethod();
            IReadWrite file = factoryMethod.ChoiceFile(default(int));
            while(true)
            {
                Console.WriteLine("\tFactory Method");
                Console.Write("1 - Работа с TXT\n2 - Работа с Bin\n3 - Работа с XML\n9 - Назад\n0 - Выход\nВведите номер операции: ");
                var choice = Console.ReadKey().Key;
                string toConsole = "";
                Console.Clear();
                switch(choice)
                {
                    case ConsoleKey.D1:
                        toConsole = "\tTXT-файл\n";
                        file = factoryMethod.ChoiceFile(1);
                        break;
                    case ConsoleKey.D2:
                        toConsole = "\tBin-файл\n";
                        file = factoryMethod.ChoiceFile(2);
                        break;
                    case ConsoleKey.D3:
                        toConsole = "\tXML-файл\n";
                        file = factoryMethod.ChoiceFile(3);
                        break;    
                    case ConsoleKey.D9:
                        return;
                    case ConsoleKey.D0:
                        Environment.Exit(1);
                        break;
                }
                bool isExit = false;
                while(!isExit)
                {
                    Console.Write(toConsole + "1 - Сохранить\n2 - Открыть\n9 - Назад\n0 - Выход\nВведите номер операции: ");
                    choice = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch(choice)
                    {
                        case ConsoleKey.D1:
                            file.Save(phones);
                            break;
                        case ConsoleKey.D2:
                            phones = file.Load();
                            break;
                        case ConsoleKey.D9:
                            Console.Clear();
                            isExit = true;
                            break;
                        case ConsoleKey.D0:
                            Environment.Exit(1);
                            break;
                    }
                }
            }
        }
    }
}
