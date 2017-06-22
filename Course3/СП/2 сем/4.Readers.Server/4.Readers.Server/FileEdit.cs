using System.Collections.Generic;

namespace _4.Readers.Server
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

        public void Enqueue(T client, int id)
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

        public bool CanIEdit(T client, int clientId, List<string> hzkaknazvatList, string fileName)
        {
            if (hzkaknazvatList.Count > 0)
            {
                if (hzkaknazvatList[0].Contains(clientId.ToString()) && hzkaknazvatList[0].Contains(fileName))
                {
                    WriteQueue.Add(client);
                    hzkaknazvatList.Remove(hzkaknazvatList[0]);
                }
            }
            return WriteQueue.Count == 0 || WriteQueue[0].Equals(client);
        }

        public void FileWasSaved(T client)
        {
            lastClientSavedFile = client;
        }

        public bool DidISaveFile(T client)
        {
            return Equals(lastClientSavedFile, default(T)) || lastClientSavedFile.Equals(client);
        }
    }
}