using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace _3.Readers.ipc
{
    /// <summary>
    /// IPC -- Inter Process Communication
    /// </summary>
    public  class FileIPC : IPC
    {
        private  string QueueFileName { get; set; }

        private  string IdOfLastProccessWhoSavedExcelFileName { get; set; }

        private  int CurrentProcessId { get { return Process.GetCurrentProcess().Id; } }

        public override  void SetFileName(string fileName)
        {
            QueueFileName = GetFullPathOfFile(Path.GetFileNameWithoutExtension(fileName) + "processesQueue.dat");
            IdOfLastProccessWhoSavedExcelFileName = GetFullPathOfFile(Path.GetFileNameWithoutExtension(fileName) + "lastSavedProcessId.dat");
        }

        #region Queue of proccesses

        /// <summary>
        /// Проверяет, может ли процесс открыть файл в режиме редактирования
        /// </summary>
        public override bool CanIEdit()
        {
            CheckFileExist(QueueFileName);

            List<string> lines = ReadAllLinesFromFile().ToList();
            int startCount = lines.Count;
            for (int i = 0; i < lines.Count; i++)
            {
                try
                {
                    Process.GetProcessById(Convert.ToInt32(lines[i]));
                }
                catch (ArgumentException)
                {
                    lines.Remove(lines[i]);
                    i--;
                }
            }
            if (startCount > lines.Count)
            {
                File.WriteAllLines(QueueFileName, lines);
            }

            return (lines.Count == 0 || lines[0] == "" || lines[0].Contains(CurrentProcessId.ToString()));
        }

        /// <summary>
        /// Добавляет процесс в очередь на ожидание. Кто первый в очереди -- тот редактирует 
        /// </summary>
        public override void Enqueue()
        {
            CheckFileExist(QueueFileName);
            IEnumerable<string> lines = ReadAllLinesFromFile();
            if (lines.Contains(CurrentProcessId.ToString()) == false)
            {
                using (var writer = new StreamWriter(QueueFileName, true))
                {
                    bool isOk = false;
                    while (isOk == false)
                    {
                        try
                        {
                            writer.WriteLine(CurrentProcessId);
                            isOk = true;
                        }
                        catch (Exception)
                        {
                            isOk = false;
                            Thread.Sleep(100);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Процесс прекращает свою работу в принципе или 
        /// прекращает работу с файлом
        /// </summary>
        public override void Dequeue()
        {
            if (File.Exists(QueueFileName))
            {
                IEnumerable<string> stream = ReadAllLinesFromFile().Where(line => line != CurrentProcessId.ToString());
                IEnumerable<string> enumerable = stream as string[] ?? stream.ToArray();
                if (enumerable.Any())
                {
                    bool isOk = false;
                    while (isOk == false)
                    {
                        try
                        {
                            File.WriteAllLines(QueueFileName, enumerable);
                            isOk = true;
                        }
                        catch (Exception)
                        {
                            isOk = false;
                            Thread.Sleep(100);
                        }
                    }
                }
                else
                {
                    File.Delete(QueueFileName);
                }
            }
        }

        /// <summary>
        /// Создает файл, если его не существует
        /// </summary>
        private  void CheckFileExist(string fileName)
        {
            if (File.Exists(fileName) == false)
            {
                try
                {
                    File.Create(fileName).Close();
                }
                catch (IOException)
                {

                }

            }
        }

        private  IEnumerable<string> ReadAllLinesFromFile()
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(QueueFileName);
            }
            catch (IOException)
            {
                lines = null;
            }
            return lines;
        }

        public override void Reset()
        {
            base.Reset();
            
            if (IdOfLastProccessWhoSavedExcelFileName != null && File.Exists(IdOfLastProccessWhoSavedExcelFileName) && File.Exists(QueueFileName) == false)
            {
                File.Delete(IdOfLastProccessWhoSavedExcelFileName);
            }
        }

        #endregion


        #region Check which proccess saved file last

        public override void FileWasSaved()
        {
            File.WriteAllText(IdOfLastProccessWhoSavedExcelFileName, CurrentProcessId.ToString());
        }

        public override bool IsOk()
        {
            return true;
        }

        public override bool DidISaveFile()
        {
            if (File.Exists(IdOfLastProccessWhoSavedExcelFileName) == false)
            {
                return true;
            }
            string[] pidStrings = File.ReadAllLines(IdOfLastProccessWhoSavedExcelFileName);
            return pidStrings.Length == 0 || (pidStrings.Length != 0 && pidStrings[0] == CurrentProcessId.ToString());
        }

        #endregion
    }
}
