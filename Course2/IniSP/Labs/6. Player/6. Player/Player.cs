using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace _6.Player
{
    [Serializable]
    class Player 
    {
        readonly List<Playlist> allPlaylists = new List<Playlist>();
        [NonSerialized]
        int selectedPlaylist;
        [NonSerialized]
        private Thread thread;

        public void WorkWithPlayer()
        {
            try
            {
                while (true)
                {
                    int numberTracks = allPlaylists[selectedPlaylist].Count;
                    int numberPlaylists = allPlaylists.Count;
                    int selectedTrack = allPlaylists[selectedPlaylist].selectedTrack;
                    var choice = Console.ReadKey(true).Key;                    
                    switch (choice)
                    {
                        case ConsoleKey.S://следующий трек
                            if (selectedTrack < numberTracks - 1)
                            {
                                allPlaylists[selectedPlaylist].selectedTrack++;
                            }
                            break;
                        case ConsoleKey.A://предыдущий трек
                            if (selectedTrack > 0)
                            {
                                allPlaylists[selectedPlaylist].selectedTrack--;
                            }
                            break;
                        case ConsoleKey.W://следующий плейлист
                            if (selectedPlaylist < numberPlaylists - 1)
                            {
                                selectedPlaylist++;
                                allPlaylists[selectedPlaylist].selectedTrack = 0;
                            }
                            break;
                        case ConsoleKey.Q://предыдущий плейлист
                            if (selectedPlaylist > 0)
                            {
                                selectedPlaylist--;
                                allPlaylists[selectedPlaylist].selectedTrack = 0;
                            }
                            break;                        
                        case ConsoleKey.Spacebar://воспроизвести/пауза
                            if ((allPlaylists[selectedPlaylist])[selectedTrack].status == Status.Play)
                            {
                                (allPlaylists[selectedPlaylist])[selectedTrack].status = Status.Pause;
                            }
                            else
                            {
                                (allPlaylists[selectedPlaylist])[selectedTrack].Play();
                            }
                            break;
                        case ConsoleKey.Z://Стоп                            
                            (allPlaylists[selectedPlaylist])[selectedTrack].Stop();
                            break;
                        case ConsoleKey.X://назад
                            Console.Clear();
                            thread.Abort();
                            return;
                        case ConsoleKey.E:
                            AbortAllThreads();
                            Environment.Exit(0);
                            break;

                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                thread.Abort();
            }
        }

        public void Initialisation()//выполняется после выбора "Перейти в проигрыватель"
        {
            selectedPlaylist = 0;
            thread = new Thread(StartOfThreadInPlayer) {IsBackground = true};
            thread.Start();
        }

        public void AbortAllThreads()
        {
            for (int i = 0; i < allPlaylists.Count; i++)
            {
                allPlaylists[i].AbortAllThreads();
            }
        }

        public void StartOfThreadInPlayer()
        {
            var locker = new object();
            while (true)
            {
                lock (locker)
                {
                    PrintInformation();
                }
                Thread.Sleep(100);
            }
        }

        public void PrintInformation()
        {                       
            string stime; 
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\t\t\t\tПлейлисты:");
            foreach (var playlist in allPlaylists)
            {
                string toConsole = "";
                bool isSelectedPlaylist;
                if (allPlaylists[selectedPlaylist] == playlist)
                {
                    toConsole += ">";
                    isSelectedPlaylist = true;
                }
                else
                {
                    toConsole += " ";
                    isSelectedPlaylist = false;
                }
                toConsole += playlist.name;
                Console.WriteLine(toConsole);
                foreach (var track in playlist)
                {
                    toConsole = "";
                    if ((playlist[playlist.selectedTrack] == track) && isSelectedPlaylist)
                        toConsole += ">>";
                    else
                        toConsole += "  ";
                    toConsole += track.artist + " - " + track.name;
                    stime = GetTime(track.playingTime) + "/" + GetTime(track.length);
                    toConsole += new string(' ', 79 - stime.Length - toConsole.Length);
                    if (track.playingTime >= track.length)
                    {

                        (allPlaylists[selectedPlaylist])[allPlaylists[selectedPlaylist].selectedTrack].Stop();
                        allPlaylists[selectedPlaylist].selectedTrack++;
                        if (allPlaylists[selectedPlaylist].selectedTrack > allPlaylists[selectedPlaylist].Count - 1)
                        {
                            allPlaylists[selectedPlaylist].selectedTrack = 0;
                        }
                        (allPlaylists[selectedPlaylist])[allPlaylists[selectedPlaylist].selectedTrack].Play();
                    }
                    toConsole += stime;
                    Console.WriteLine(toConsole);
                    Console.WriteLine("\tЖанр: " + track.genre + " Оценка: " + track.rating);
                }                
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Общая длина {0} Средняя оценка {1}", playlist.allLength, playlist.middleRating);
                Console.WriteLine("--------------------------------------------------------");
            }
            Console.WriteLine("w - Следующий плейлист\nq - Предыдущий плейлист\ns - Следующий трек\na - Предыдущий трек\nSpace - Воспроизвести/Пауза\nz - Стоп\nx - Назад\ne - Выход");
        }
        
        private string GetTime(int time)
        {            
            return String.Format("[{0:00}:{1:00}]", time / 60, time % 60);
        }

        public void AddPlaylist(string playlistName)
        {
            var newPlaylist = new Playlist(playlistName);
            allPlaylists.Add(newPlaylist);
        }

        public void AddTrack(string playlistName, string trackName, int length, string artist, int numberGenre, int rating)
        {
            try
            {
                var newTrack = new Track(trackName, length, artist, numberGenre, rating);
                if (allPlaylists.Count == 0)
                {
                    throw new NullReferenceException();
                }
                int index = allPlaylists.TakeWhile(playlist => playlist.name != playlistName).Count();
                allPlaylists[index].Add(newTrack);
                allPlaylists[index].allLength += newTrack.length;
                int sumRating = allPlaylists[index].Sum(track => track.rating);
                allPlaylists[index].middleRating = (double)sumRating / allPlaylists[index].Count;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Плейлист не найден!");
            }
        }

        public void SaveToFile()
        {
            var formatter = new BinaryFormatter();
            using (Stream s = File.Create("player.dat"))
                formatter.Serialize(s, this);
        }
        public Player LoadFromFile()
        {
            var formatter = new BinaryFormatter();
            Player newPlayer;
            using (Stream s = File.OpenRead("player.dat"))
            {
                newPlayer = (Player)formatter.Deserialize(s);
            }
            return newPlayer;
        }
    }
}
