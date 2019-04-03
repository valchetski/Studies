using System.Collections.Generic;
using System.Linq;

namespace RWC2007.Plays
{
    public static class TeamPool
    {
        private static readonly Dictionary<string, string> teamPool;
        static TeamPool()
        {
            teamPool = new Dictionary<string, string>
            {
                {"RSA", "A"}, {"Samoa", "A"}, { "USA", "A" }, {"Tonga", "A"}, {"England", "A"},
                {"Australia", "B"}, {"Canada", "B"}, { "Fiji", "B" }, {"Japan", "B"}, {"Wales", "B"},
                {"Italy", "C"}, {"New Zealand", "C"}, { "Portugal", "C" }, {"Romania", "C"}, {"Scotland", "C"},
                {"Argentina", "D"}, {"France", "D"}, { "Geargia", "D" }, {"Ireland", "D"}, {"Namibia", "D"},
            };
        }

        public static List<string> GetTeamsByPool(string pool)
        {
            return teamPool.Where(t => t.Value == pool).Select(group => group.Key).ToList();
        }
    }
}
