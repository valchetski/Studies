using System;
using System.Threading;

namespace _3.Readers.Watchers
{
    public class FileChangeTimeWatcher : Watcher
    {
        private DateTime lastChangeOfTable;

        public DateTime LastChangeOfTable
        {
            get { return lastChangeOfTable; }
            set
            {
                if (value > lastChangeOfTable)
                {
                    lastChangeOfTable = value;
                }
            }
        }

        private readonly TimeSpan noWorkTimePermission;

        public event WatcherResultEventHandler FileIsNotChangedLong;

        public FileChangeTimeWatcher(int noWorkSeconds) : base("FileChangeTimeWatcher")
        {
            thread.SetApartmentState(ApartmentState.STA);
            noWorkTimePermission = new TimeSpan(0, 0, noWorkSeconds);
        }

        protected override void Watch()
        {
            while (isWork)
            {
                while ((DateTime.Now - LastChangeOfTable) < noWorkTimePermission && isWork)
                {
                    Thread.Sleep(100);
                }
                OnFileIsNotChangedLong(new EventArgs());
                Suspend();
            }
        }

        private void OnFileIsNotChangedLong(EventArgs e)
        {
            WatcherResultEventHandler handler = FileIsNotChangedLong;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}