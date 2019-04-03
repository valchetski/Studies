using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RWC2007.Plays
{
    static class FileOperations
    {
        public static void Save(List<Game> games)
        {
            var serializer = new BinaryFormatter();
            using (var fileStream = File.Create("games.dat"))
            {
                serializer.Serialize(fileStream, games);
            }
        }

        public static List<Game> Open()
        {
            var serializer = new BinaryFormatter();
            List<Game> games = new List<Game>();
            using (var fileStream = File.Open("games.dat", FileMode.OpenOrCreate))
            {
                if (fileStream.Length != 0)
                {
                    games = (List<Game>)serializer.Deserialize(fileStream);
                }
            }
            return games;
        }

    }
}
