using System;
using System.Diagnostics;
using SPproject.Threads;

namespace SPproject
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Задание:\nЕсть 3 потока: AddThread, RemoveThread, ClearThread.\nКаждый имеет доступ к общим данным(строке).\nФункции потоков:");
            Console.WriteLine("AddThread : добавляет текст к строке");
            Console.WriteLine("RemoveThread : удаляет последнее слово в строке");
            Console.WriteLine("ClearThread : очищает строку");

            Console.ForegroundColor = ConsoleColor.White;
            bool isExit = false;
            while (isExit == false)
            {
                Console.WriteLine("\nЧто используем?\n1 - Mutex\n2 - Семафор\n3 - Мой мьютекс\n4 - Мой семафор");
                Console.Write("5 - Два мьютекса\n6 - Mutex vs MyMutex\n7 - Semaphore vs MySemaphore\n0 - Выход\nВведите номер: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nВы выбрали mutex\n");
                        break;
                    case 2:
                        Console.WriteLine("\nВы выбрали семафор\n");
                        break;
                    case 3:
                        Console.WriteLine("\nВы выбрали мой мьютекс\n");
                        break;
                    case 4:
                        Console.WriteLine("\nВы выбрали мой семафор\n");
                        break;
                    case 5:
                        Console.WriteLine("\nВы выбрали два мьютекса\n");
                        break;
                    case 6:
                        Console.WriteLine("\nВы выбрали сравнение Mutex и MyMutex\n");
                        break;
                    case 7:
                        Console.WriteLine("\nВы выбрали сравнение Semaphore и MySemaphore\n");
                        break;
                    case 0:
                        isExit = true;
                        break;
                }

                if (choice >= 1 && choice <= 5)
                {
                    ThreadsWork(choice);
                }
                else if(choice == 6)//сравнение мьютексов
                {
                    var stopwatch = new Stopwatch();

                    //здесь работаем с помощью Mutex
                    stopwatch.Start();
                    ThreadsWork(1);
                    stopwatch.Stop();
                    TimeSpan mutexWorkTime = stopwatch.Elapsed;

                    //здесь работаем с помощью MyMutex
                    stopwatch.Start();
                    ThreadsWork(3);
                    stopwatch.Stop();
                    TimeSpan myMutexWorkTime = stopwatch.Elapsed;
                    Console.Clear();
                    Console.WriteLine("Mutex проработал {0}", mutexWorkTime);
                    Console.WriteLine("MyMutex проработал {0}", myMutexWorkTime);
                }
                else if (choice == 7)//сравнение семафоров
                {
                    var stopwatch = new Stopwatch();

                    //здесь работаем с помощью Semaphore
                    stopwatch.Start();
                    ThreadsWork(2);
                    stopwatch.Stop();
                    TimeSpan mutexWorkTime = stopwatch.Elapsed;

                    //здесь работаем с помощью MySemaphore
                    stopwatch.Start();
                    ThreadsWork(4);
                    stopwatch.Stop();
                    TimeSpan myMutexWorkTime = stopwatch.Elapsed;
                    Console.Clear();
                    Console.WriteLine("Semaphore проработал {0}", mutexWorkTime);
                    Console.WriteLine("MySemaphore проработал {0}", myMutexWorkTime);
                }

                if (choice >= 1 && choice <= 7)
                {
                    SharedData.Reset();
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        static void ThreadsWork(int choice)
        {
            if (choice >= 1 && choice <= 4)
            {
                var addThread = new AddThread("AddThread", choice);
                var removeThread = new RemoveThread("RemoveThread", choice);
                var clearThread = new ClearThread("ClearThread", choice);

                addThread.Start();
                removeThread.Start();
                clearThread.Start();

                addThread.Join();
                removeThread.Join();
                clearThread.Join();
            }
            if (choice == 5)//выбрали два мьютекса
            {
                var addThread = new AddThread("AddThread", 3);
                var removeThread = new RemoveThread("RemoveThread", 3);

                var addThread2 = new AddThread("AddThread2", choice);
                var removeThread2 = new RemoveThread("RemoveThread2", choice);

                addThread.Start();
                removeThread.Start();
                addThread2.Start();
                removeThread2.Start();

                addThread.Join();
                removeThread.Join();
                addThread2.Join();
                removeThread2.Join();
            }
        }
    }
}
