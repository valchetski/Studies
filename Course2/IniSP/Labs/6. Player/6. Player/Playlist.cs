using System;
using System.Collections.Generic;

namespace _6.Player
{
    [Serializable]  
    public class Playlist : List<Track>
    {        
        public int id;
        public string name;
        public int allLength;
        public double middleRating;
        public int selectedTrack;
        public Playlist(string name)
        {
            this.name = name;
            id = name.GetHashCode();
            allLength = 0;
            middleRating = 0;
            selectedTrack = 0;
        }

        public void AbortAllThreads()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].Stop();
            }
        }
    }
}
