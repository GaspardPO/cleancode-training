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

        public Question.Categories CurrentCategory(Player player)
        {
            switch (this.GetPosition(player))
            {
                case 0:
                case 4:
                case 8:
                    return Question.Categories.Pop;
                case 1:
                case 5:
                case 9:
                    return Question.Categories.Science;
                case 2:
                case 6:
                case 10:
                    return Question.Categories.Sports;
                default:
                    return Question.Categories.Rock;
            }
        }
    }
}