using System.Threading;

namespace SPproject
{
    class SharedData
    {
        public static Mutex Mutex;
        public static Semaphore Semaphore;
        public static MyMutex MyMutex;
        public static MyMutex SecondMyMutex;
        public static MySemaphore MySemaphore;
        public static string Text;

        static SharedData()
        {
            Reset();
        }

        public static void Reset()
        {
            Semaphore = new Semaphore(2, 2);
            Mutex = new Mutex();
            MyMutex = new MyMutex();
            SecondMyMutex = new MyMutex();
            MySemaphore = new MySemaphore(2, 2);
            Text = "";
        }
    }
}
