namespace Trivia
{
    internal class Board
    {
        
        private const int BoardSize = 12;

        public static int GetPlayerPlace(Player player)
        {
            return player.GetPosition() % BoardSize;
        }
    }
}
