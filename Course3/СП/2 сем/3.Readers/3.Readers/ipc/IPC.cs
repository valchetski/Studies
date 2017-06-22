using System.IO;
using System.Reflection;

namespace _3.Readers.ipc
{
    public abstract class IPC
    {
        public abstract void Enqueue();
        public abstract void Dequeue();

        public abstract void SetFileName(string fileName);
        public abstract bool DidISaveFile();
        public abstract bool CanIEdit();
        public abstract void FileWasSaved();
        public abstract bool IsOk();

        public virtual void Reset()
        {
            Dequeue();
        }

        protected string GetFullPathOfFile(string fileName)
        {
            string folderPath = Assembly.GetExecutingAssembly().Location;
            folderPath = folderPath.Substring(0, folderPath.LastIndexOf('\\'));
            fileName = folderPath + "\\" + Path.GetFileName(fileName);
            return fileName;
        }
    }
}
