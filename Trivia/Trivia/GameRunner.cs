using System;

namespace Trivia
{
    public class GameRunner
    {
        public static void Main(string[] args)
        {
            var aGame = new Game(new Players(new Player("Chet"), new Player("Pat"), new Player("Sue")));

            var rand = new Random();

            do
            {
                aGame.HasRolled(rand.Next(5) + 1);
                
                // Ask question if not in penalty box

                if (rand.Next(9) == 7)
                {
                    aGame.AnswerIsCorrect();
                }
                else
                {
                    aGame.AnswerIsWrong();
                }
                aGame.NextPlayer();
            } while (!aGame.HasAWinner());  // !aGame.HasAWinner()
        }
    }
}