using System;
using System.Collections.Generic;
using System.Linq;

namespace RWC2007.Plays
{
    [Serializable]
    public class GameResultForTeam
    {
        public string Name { get; set; }
        public int Goals { get; set; }
        public int Tries { get; set; }
        public int Points { get; set; }

        public static string GetGoals(string firstTeam, string secondTeam)
        {
            List<Game> games = FileOperations.Open();
            Game game = games.FirstOrDefault(g => (g.Item1.Name == firstTeam || g.Item1.Name == secondTeam)
                                                    && (g.Item2.Name == secondTeam || g.Item2.Name == firstTeam));
            string resultString = "";
            if (game != null)
            {
                resultString = firstTeam == game.Item1.Name ?
                    $"{game.Item1.Goals}:{game.Item2.Goals}" :
                    $"{game.Item2.Goals}:{game.Item1.Goals}";
            }
            return resultString;

        }

        public static int GetPoints(int teamGoals, int teamTries, int opponentGoals)
        {
            int points = 0;
            if (teamTries >= 4)
            {
                points = 1;
            }

            if (teamGoals > opponentGoals)
            {
                points += 4;
            }
            else if (teamGoals == opponentGoals)
            {
                points += 2;
            }
            else if (teamGoals + 7 >= opponentGoals)
            {
                points += 1;
            }
            return points;
        }
    }
}
