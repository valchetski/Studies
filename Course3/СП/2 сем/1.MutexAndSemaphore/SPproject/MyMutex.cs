using System;
using System.Collections.Generic;
using System.Threading;

namespace SPproject
{
    class MyMutex
    {
        private int isHasOwner;
        private Queue<Thread> threadsQueue; 

        public MyMutex()
        {
            isHasOwner = 0;
            threadsQueue = new Queue<Thread>();
        }
        
        public void WaitOne()
        {
            //Interlocked.CompareExchange возвращает исходное значение переменной isHasOwner
            //isHasOwnder сравнивается с 0 и если равен--то принимает значение 1
            if (Interlocked.CompareExchange(ref isHasOwner, 1, 0) != 0)
            {
                Console.WriteLine("Поток {0} зашел в WaitOne() в {1}", Thread.CurrentThread.Name, DateTime.Now.Millisecond);
                threadsQueue.Enqueue(Thread.CurrentThread);
                Console.WriteLine("Поток {0} вышел из WaitOne() в {1}", Thread.CurrentThread.Name, DateTime.Now.Millisecond);
                Thread.CurrentThread.Suspend();
            }
        }

        public void Release()
        {
            if (threadsQueue.Count > 0)
            {
                threadsQueue.Dequeue().Resume();
            }
        }
    }
}
