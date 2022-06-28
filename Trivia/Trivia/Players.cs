using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Players
    {
        private readonly List<Player> _players = new List<Player>();

        public Players(params Player[] players)
        {
            _players.AddRange(players);
        }

        public int Count => _players.Count;

        public void Add(Player player)
        {
            _players.Add(player);
        }
    }
}