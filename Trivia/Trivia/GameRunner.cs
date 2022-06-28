using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;

        public static void Main(string[] args)
        {
            var aGame = new Game(new Players(new Player("Chet"), new Player("Pat"), new Player("Sue")));

            var rand = new Random();

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    _notAWinner = aGame.WasCorrectlyAnswered();
                }
                else
                {
                    _notAWinner = aGame.WrongAnswer();
                }
            } while (_notAWinner);
        }
    }
}