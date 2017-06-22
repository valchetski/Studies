using System;
using System.Threading;

namespace SPproject.Threads
{
    public class MyThread
    {
        protected Thread thread;

        public MyThread(string name, int type)
        {
            ThreadStart threadStart;
            switch (type)
            {
                case 1:
                    threadStart = GetMutex;
                    break;
                case 2:
                    threadStart = GetSemaphore;
                    break;
                case 3:
                    threadStart = GetMyMutex;
                    break;
                case 4:
                    threadStart = GetMySemaphore;
                    break;
                case 5:
                    threadStart = GetMySecondMutex;
                    break;
                default:
                    threadStart = GetMutex;
                    break;
            }
            thread = new Thread(threadStart) { Name = name };
        }

        private void GetMutex()
        {
            Console.WriteLine(thread.Name + " ждет mutex");
            SharedData.Mutex.WaitOne();
            Console.WriteLine("\n{0} получает mutex",thread.Name);

            Prepare();

            Console.WriteLine("\n{0} отдает mutex", thread.Name);
            SharedData.Mutex.ReleaseMutex();
        }

        private void GetSemaphore()
        {
            Console.WriteLine(thread.Name + " ждет семафор");
            SharedData.Semaphore.WaitOne();
            Console.WriteLine("\n" + thread.Name + " получает семафор");

            Prepare();

            Console.WriteLine(thread.Name + " отдает семафор");
            SharedData.Semaphore.Release();
        }

        private void GetMyMutex()
        {
            Console.WriteLine(thread.Name + " ждет мьютекс");
            SharedData.MyMutex.WaitOne();

            Console.WriteLine("\n{0} получает мьютекс", thread.Name);

            Prepare();

            Console.WriteLine("\n{0} отдает мьютекс", thread.Name);
            SharedData.MyMutex.Release();
        }

        private void GetMySecondMutex()
        {
            Console.WriteLine(thread.Name + " ждет второй мьютекс");
            SharedData.SecondMyMutex.WaitOne();

            Console.WriteLine("\n{0} получает второй мьютекс", thread.Name);

            Prepare();

            Console.WriteLine("\n{0} отдает второй мьютекс", thread.Name);
            SharedData.SecondMyMutex.Release();
        }

        private void GetMySemaphore()
        {
            Console.WriteLine(thread.Name + " ждет семафор");
            SharedData.MySemaphore.WaitOne();
            Console.WriteLine("\n" + thread.Name + " получает семафор");

            Prepare();

            Console.WriteLine(thread.Name + " отдает семафор");
            SharedData.MySemaphore.Release();
        }

        protected virtual void Action() { }

        private void Prepare()
        {
            Thread.Sleep(300);
            Console.WriteLine("Старый текст: " + SharedData.Text);

            Action();

            Console.WriteLine("Текст после операции в потоке {0}: {1}", thread.Name, SharedData.Text);
        }

        public void Start()
        {
            if (thread.ThreadState == ThreadState.Unstarted)
            {
                thread.Start();
            }
        }

        public void Join()
        {
            thread.Join();
        }
    }
}
