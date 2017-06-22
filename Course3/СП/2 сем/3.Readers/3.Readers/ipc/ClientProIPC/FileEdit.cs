using System.Collections.Generic;
using System.Linq;

namespace _3.Readers.ipc.ClientProIPC
{
    class FileEdit<T>
    {
        public List<T> WriteQueue { get; private set; }

        private T lastClientSavedFile;

        public FileEdit()
        {
            WriteQueue = new List<T>();
            lastClientSavedFile = default(T);
        }

        public void Enqueue(T client)
        {
            if (WriteQueue.Contains(client) == false)
            {
                WriteQueue.Add(client);
            }
        }

        public void Dequeue(T client)
        {
            if (WriteQueue.Contains(client))
            {
                WriteQueue.Remove(client);
            }
        }

        public bool CanIEdit(T client)
        {
            return WriteQueue.Count == 0 || WriteQueue.First().Equals(client);
        }

        public void FileWasSaved(T client)
        {
            lastClientSavedFile = client;
        }

        public bool DidISaveFile(T client)
        {
            return lastClientSavedFile.Equals(default(T)) || lastClientSavedFile.Equals(client);
        }
    }
}