using System;
using System.Threading;
using _3.Readers.Files;

namespace _3.Readers.Watchers
{
    public class FileIsChangedWatcher : Watcher
    {
        private DateTime lastChangeOfFile;
        public event WatcherResultEventHandler FileIsChanged;
        public FileBase file;

        public FileIsChangedWatcher() : base("FileWasChangedWatcher")
        {
        }

        protected override void Watch()
        {
            if (lastChangeOfFile == new DateTime())
            {
                lastChangeOfFile = file.GetLastChangeTime(FileBase.CurrentFileName);
            }
            while (isWork)
            {
                while (lastChangeOfFile == file.GetLastChangeTime(FileBase.CurrentFileName))
                {
                    Thread.Sleep(100);
                }
                lastChangeOfFile = file.GetLastChangeTime(FileBase.CurrentFileName);
                OnFileIsChanged(new EventArgs());
            }
        }

        private void OnFileIsChanged(EventArgs e)
        {
            WatcherResultEventHandler handler = FileIsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
