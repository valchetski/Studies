using System;
using System.IO;

namespace _3.Readers.Files
{
    public abstract class FileBase
    {
        public static string CurrentFileName { get; protected set; }

        public abstract string[, ] Open(string fileName);

        public virtual void Save(string[,] collection, string fileName)
        {
            MainWindow.ipc.FileWasSaved();
        }

        public DateTime GetLastChangeTime(string fileName)
        {
            return File.GetLastWriteTime(fileName);
        }
    }
}
