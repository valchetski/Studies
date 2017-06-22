using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public static class Genre
    {
        public static string AdventureNovel = "приключенческий роман";
        public static string HistoricalNovel = "исторический роман";

        public static List<string> Genres = new List<string> {AdventureNovel, HistoricalNovel};

    }
}
