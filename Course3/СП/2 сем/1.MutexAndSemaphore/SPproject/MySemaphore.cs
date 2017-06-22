using System.Collections.Generic;
using System.Threading;

namespace SPproject
{
    class MySemaphore
    {
        //private object forWaitOne;
        private int maxCount;
        private int currentCount;

        private Queue<Thread> threadsQueue; 


        public MySemaphore(int initialCount, int maxCount)
        {
            this.maxCount = maxCount;
            currentCount = maxCount - initialCount;

            threadsQueue = new Queue<Thread>();

            //forWaitOne = new object();
        }
        
        public void WaitOne()
        {
            /*lock (forWaitOne)
            {
                while (currentCount >= maxCount){}
                currentCount++;
            }*/
            if (currentCount < maxCount)
            {
                currentCount++;

            }
            else
            {
                threadsQueue.Enqueue(Thread.CurrentThread);
                Thread.CurrentThread.Suspend();
            }
        }

        public void Release()
        {
            /*lock (forWaitOne)
            {
                if (currentCount > 0)
                {
                    currentCount--;
                } 
            }*/
            if (threadsQueue.Count > 0)
            {

                threadsQueue.Dequeue().Resume();
            }
            if (currentCount > 0)
            {
                currentCount--;
            } 
        }
    }
}
