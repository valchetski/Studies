using System;

namespace _6.Player
{
    class Program
    {
        static void Main()
        {
            var player = new Player();
            while (true)
            {
                try
                {                    
                    Console.WriteLine("1 - Добавить плейлист\n2 - Сохранить плейлист\n3 - Открыть все плейлисты\n4 - Добавить трек\n5 - Перейти в проигрыватель\n0 - Выход\nВведите номер операции: ");
                    var choice = Console.ReadKey(true).Key; 
                    switch (choice)
                    {
                        case ConsoleKey.D1:
                            Console.Write("Введите имя плейлиста: ");
                            string playlistName = Console.ReadLine();
                            player.AddPlaylist(playlistName);
                            break;
                        case ConsoleKey.D2:
                            player.SaveToFile();
                            break;
                        case ConsoleKey.D3:
                            player = player.LoadFromFile();
                            break;
                        case ConsoleKey.D4:
                            Console.Write("Введите имя плейлиста: ");
                            playlistName = Console.ReadLine();
                            Console.Write("Введите название трека: ");
                            string trackName = Console.ReadLine();                            
                            Console.Write("Введите имя артиста: ");
                            string artistName = Console.ReadLine();
                            Console.Write("Введите длину трека: ");
                            int length = int.Parse(Console.ReadLine());
                            Console.Write("Жанры:\n1 - Trance\n2 - Electro\n3 - Pop\n4 - Rock\nВведите номер жанра: ");
                            int numberOfGenre = int.Parse(Console.ReadLine()) - 1;
                            Console.Write("Введите оценку трека: ");
                            int rating = int.Parse(Console.ReadLine());
                            player.AddTrack(playlistName, trackName, length, artistName, numberOfGenre, rating);
                            break;
                        case ConsoleKey.D5:
                            Console.Clear();
                            player.Initialisation();
                            player.WorkWithPlayer();
                            break;
                        case ConsoleKey.D0:
                            return;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Список плейлистов пуст!");
                }
            }
        }
    }
}
