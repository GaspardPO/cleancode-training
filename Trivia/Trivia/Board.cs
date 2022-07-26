using System.Collections.Generic;

namespace Trivia
{
    public class Board
    {
        private const int StartingPoint = 0;
        private const int BoardSize = 12;
        private readonly Dictionary<Player, int> _playerPosition = new Dictionary<Player, int>();

        public void PlaceAtStart(Player player)
        {
            _playerPosition.Add(player, StartingPoint);
        }

        public int GetPosition(Player player) => _playerPosition[player];

        public void MoveForward(Player player, int roll)
        {
            _playerPosition[player] += roll;
            _playerPosition[player] %= BoardSize;
        }
    }
}