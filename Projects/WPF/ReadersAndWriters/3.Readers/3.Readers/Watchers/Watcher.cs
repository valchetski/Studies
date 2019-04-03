using System;
using System.Threading;

namespace _3.Readers.Watchers
{
    public abstract class Watcher
    {
        protected readonly Thread thread;

        public delegate void WatcherResultEventHandler( object sender, EventArgs e );

        protected bool isWork;

        protected Watcher(string name) 
        {
            thread = new Thread(Watch) {Name = name};
            isWork = true;
        }

        protected abstract void Watch();

        public virtual void Start()
        {
            if (thread.ThreadState == ThreadState.Unstarted)
            {
                thread.Start();
            }
            else if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
            }
        }

        public void Suspend()
        {
            if (thread.ThreadState == ThreadState.Running)
            {
                thread.Suspend();
            }
        }

        public virtual void Stop()
        {
            if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
            }
            if (thread.ThreadState == ThreadState.Running)
            {
                try
                {
                    thread.Abort();
                }
                catch (ThreadStateException)
                {
                   
                }
                
            }
            isWork = false;
        }
    }
}