using System.IO;

namespace _3.Readers.Files
{
    public class FileTxt : FileBase
    {
        public override string[,] Open(string fileName)
        {
            CurrentFileName = fileName;
            var fileInfo = new string[,] {};
            if (File.Exists(fileName))
            {
                var f = File.ReadAllLines(fileName);
                fileInfo = new string[f.GetLength(0),1];
                for (int i = 0; i < f.GetLength(0); i++)
                {
                    fileInfo[i, 0] = f[i];
                }
            }
            return fileInfo;
        }

        public override void Save(string[,] collection, string fileName)
        {
            string toFile = "";
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                toFile += collection[i, 0];
            }

            using (var file = new StreamWriter(fileName, false))
            {
                file.WriteLine(toFile);
                base.Save(collection, fileName);
            }
        }
    }
}
