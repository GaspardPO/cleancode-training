using System;
using System.Collections.Generic;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using Trivia;
using Xunit;

namespace Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GameRunnerTest
    {
        [Fact]
        public void non_regression_sur_partie_trois_joueurs_1()
        {
            int seed = 5;
            List<string> players = new List<string> { "Chet", "Pat", "Sue" };
            
            var result = runGame(players, seed);
            Approvals.Verify(result);
        }
        
        [Fact]
        public void non_regression_sur_partie_trois_joueurs_2()
        {
            int seed = 6;
            List<string> players = new List<string> { "Chet", "Pat", "Sue" };
            
            var result = runGame(players, seed);
            Approvals.Verify(result);
        }
        
        [Fact]
        public void non_regression_sur_partie_deux_joueurs()
        {
            int seed = 6;
            List<string> players = new List<string> { "Chet", "Pat" };
            
            var result = runGame(players, seed);
            Approvals.Verify(result);
        }

        private static string runGame(List<string> players, int seed)
        {
            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);

            var _notAWinner = false;

            var aGame = new Game();

            foreach (string player in players)
            {
                aGame.Add(player);
            }

            var rand = new Random(seed);

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

            string result = sw.ToString();
            return result;
        }
    }
}