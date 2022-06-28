using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Players
    {
        private readonly List<Player> _players = new List<Player>();
        private int _currentPosition = 0;

        public Players(params Player[] players)
        {
            _players.AddRange(players);
        }

        public int Count => _players.Count;

        public void Add(Player player)
        {
            _players.Add(player);
        }

        public Player Current()
        {
            return _players[_currentPosition];
        }

        public void Next()
        {
            _currentPosition = (_currentPosition + 1) % _players.Count;
        }

        public Dictionary<string, int> GetPositions()
        {
            return _players.ToDictionary(player => player.GetName(), player => _players.IndexOf(player)+1);
        }
    }
}