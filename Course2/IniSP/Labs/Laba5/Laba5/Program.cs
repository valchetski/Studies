using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace Laba5
{
    class Program
    {
        static IRepository plugin1;
        static IStatistics plugin2;
        static void Main(string[] args)
        {
            LoadPlugins();
            int choise = 0;
            string name;
            string num;
            Student st=null;
            for (; ; )
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.Write("1-Создать студента\n2-Загрузить студента\n3-Сохранить студента\n4-Средний балл студента\n5-Максимальные баллы студента\n6-Минимальные баллы студента\n7-Показать плагины\n8-Выход\nВыберите пункт меню: ");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Dictionary<string, int> t = new Dictionary<string, int>();
                        Console.WriteLine("Введите фамилию студента");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите номер группы студента");
                        num = Console.ReadLine();
                        Console.WriteLine("Введите оценку по Мат.Анализу");
                        t.Add("Мат.Анализ", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Введите оценку по Дискретной Математике");
                        t.Add("Дискретная Математика", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Введите оценку по Программированию(С#)");
                        t.Add("Программирование(С#)", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Введите оценку по Программированию(С++)");
                        t.Add("Программирование(С++)", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Введите оценку по Философии");
                        t.Add("Философия", int.Parse(Console.ReadLine()));
                        st = new Student(name, num, t);
                        break;
                    case 2: st = plugin1.LoadFromFile("Data.txt");
                        break;
                    case 3: if (st == null)
                            Console.WriteLine("Создайте студента или загрузите из файла");
                        else
                            plugin1.SaveToFile(st, "Data.txt");
                        break;
                    case 4: if (st == null)
                            Console.WriteLine("Создайте студента или загрузите из файла");
                        else
                            Console.WriteLine("Средний балл студнета " + st.Name + " :" + plugin2.GPA(st));
                        break;
                    case 5: if (st == null)
                            Console.WriteLine("Создайте студента или загрузите из файла");
                        else
                        {
                            Console.WriteLine("Лучшие баллы студента " + st.Name + ":");
                            foreach (var r in plugin2.Highest_score(st))
                            {
                                Console.WriteLine("{0}-{1}", r.Key, r.Value);
                            }
                        }
                        break;
                    case 6: if (st == null)
                            Console.WriteLine("Создайте студента или загрузите из файла");
                        else
                        {
                            Console.WriteLine("Худшие баллы студента " + st.Name + ":");
                            foreach (var r in plugin2.Lowest_score(st))
                            {
                                Console.WriteLine("{0}-{1}", r.Key, r.Value);
                            }
                        }
                        break;
                    case 7: DisplayPlugins();
                        break;
                    case 8: Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Некорректный ввод");
                        break;

                }
            }
        }

        static void DisplayPlugins()
        {
            string folder = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["PluginFolder"];
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (var filename in files)
            {
                Assembly asm = Assembly.LoadFrom(filename);
                Console.WriteLine(asm.FullName);//полное имя сборки
                var types = asm.GetTypes();
                var plugname = Attribute.GetCustomAttribute(types[0], typeof(NewAttribute));
                var atr = (NewAttribute)plugname;
                Console.WriteLine("Plugin name: " + atr.Name);
                Console.WriteLine("Типы:");
                foreach (var type in types)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine(type.FullName);
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Методы:");
                    foreach (var meth in type.GetMethods())
                    {
                        if (meth.IsPrivate)
                            Console.Write("private ");
                        if (meth.IsPublic)
                            Console.Write("public ");
                        Console.Write(meth.Name + "(");
                        string s = "";
                        foreach (var param in meth.GetParameters())
                            s += param.ParameterType.Name + " " + param.Name + ", ";
                        if (s != "")
                            s = s.Remove(s.Length - 2);
                        Console.Write(s);
                        Console.WriteLine(")");
                    }
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("----------------------------------------------");
                }
            }
        }

        static void LoadPlugins()
        {
            try
            {
                string folder = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["PluginFolder"];
                string[] files = Directory.GetFiles(folder, "*.dll");
                foreach (var filename in files)
                {
                    Assembly asm = Assembly.LoadFrom(filename);
                    foreach (var type in asm.GetTypes())
                    {
                        if (type.GetInterface("IStatistics") != null)
                            plugin2 = (IStatistics)Activator.CreateInstance(type);
                        if (type.GetInterface("IRepository") != null)
                            plugin1 = (IRepository)Activator.CreateInstance(type);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some error while loading plugins!");
            }
        }
    }
}


