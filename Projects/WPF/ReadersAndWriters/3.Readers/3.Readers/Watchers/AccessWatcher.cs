using System;
using System.Threading;

namespace _3.Readers.Watchers
{
    /// <summary>
    /// Следит за тем, может ли текущий процесс редактировать файл
    /// Генерирует событие, когда может
    /// </summary>
    public class AccessWatcher  : Watcher
    {
        public event WatcherResultEventHandler FileIsFree;

        public AccessWatcher() : base("AccessWatcher"){}

        protected override void Watch()
        {
            while (isWork)
            {
                while (MainWindow.ipc.CanIEdit() == false && isWork)
                {
                    Thread.Sleep(100);
                }
                if (isWork)
                {
                    OnFileIsFree(new EventArgs());
                    Suspend(); 
                }
            }
        }

        private void OnFileIsFree(EventArgs e)
        {
            WatcherResultEventHandler handler = FileIsFree;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
