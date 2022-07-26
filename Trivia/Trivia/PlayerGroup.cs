using System.Collections.Generic;

namespace Trivia
{
    internal class PlayerGroup
    {
        private int _currentPlayerIndex = 0;
        private readonly List<Player> _players = new List<Player>();
        public int Count => _players.Count;

        public void Add(Player player)
        {
            _players.Add(player);
        }

        public Player GetCurrent()
        {
            return _players[_currentPlayerIndex];
        }
        
        public void ChangePlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
        }
    }
}