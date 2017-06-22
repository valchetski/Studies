using System;
using System.Threading;

namespace _6.Player
{
    [Serializable]
    public class Track
    {
        public int id;
        public string name;
        public int length;
        public string artist;
        public Genre genre;
        public int rating;
        public int playingTime;
        public Status status;
        [NonSerialized]
        private Thread thread;

        public Track(string name, int length, string artist, int numberGenre, int rating)
        {
            this.name = name;
            id = name.GetHashCode();
            this.length = length;
            this.artist = artist;
            genre = (Genre)numberGenre;
            this.rating = rating;
            playingTime = 0;
            status = Status.Stop;
        }

        public void StartOfThreadInTrack()
        {
            int interval = 0;
            const int timeToBeep = 5;
            while (true)
            {
                if (playingTime >= length)//проверяет, не закончился ли трек
                {
                    Stop();
                }

                if (status == Status.Play)//если трек воспроизводится
                {
                    playingTime++;
                    interval++;    
                }

                if (interval == timeToBeep)
                {
                    Console.Beep();
                    Console.Beep(1000, 250);
                    Console.Beep(5000, 500);
                    Thread.Sleep(200);
                    interval = 0;
                    continue;
                }
                Thread.Sleep(1000);//поток останавливается на одну секунду
            }
        }

        public void Play()
        {
            if (status == Status.Stop)
            {                
                thread = new Thread(StartOfThreadInTrack) {IsBackground = true};
                thread.Start();
            }
            status = Status.Play;
        }
       
        public void Stop()
        {
            if (thread != null)
            {
                status = Status.Stop;
                playingTime = 0;
                thread.Abort();
            }
        }        
    }

    public enum Status
    {
        Play, Pause, Stop
    }

    public enum Genre
    {
        Trance, Electro, Pop, Rock
    }
}
