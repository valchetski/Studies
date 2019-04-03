using System;
using System.Collections.Generic;
using System.Linq;

namespace RWC2007.Plays
{
    [Serializable]
    public class Game : Tuple<GameResultForTeam, GameResultForTeam>
    {
        public string Pool { get; set; }
        public Game(GameResultForTeam home, GameResultForTeam visitor) : base(home, visitor)
        {
        }

        public Game() : base(null, null)
        {
            
        }

        public static IOrderedEnumerable<KeyValuePair<string, int>> GetTeamsAndPoints(string pool)
        {
            List<string> teams = TeamPool.GetTeamsByPool(pool);
            teams.Sort();
            var teamAndPoints = teams.ToDictionary(t => t, t => 0);

            List<Game> games = FileOperations.Open().Where(g => g.Pool == pool).ToList();
            foreach (var game in games)
            {
                teamAndPoints[game.Item1.Name] += game.Item1.Points;
                teamAndPoints[game.Item2.Name] += game.Item2.Points;
            }

            IOrderedEnumerable<KeyValuePair<string, int>> items = from pair in teamAndPoints orderby pair.Value descending select pair;
            return items;
        }
    }
}
