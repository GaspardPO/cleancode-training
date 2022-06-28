using System;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using Trivia;
using Xunit;


namespace Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GameTest
    {
        [Fact]
        public void Test1()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game(new Players(new Player("Cedric")));
            game.HasRolled(12);
            game.AnswerIsWrong();
            game.NextPlayer();
            game.HasRolled(2);
            game.HasRolled(13);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(13);
            Approvals.Verify(fakeconsole.ToString());
        }
        
        [Fact]
        public void Test2()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));
            game.HasRolled(1);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            Approvals.Verify(fakeconsole.ToString());
        }
        
        [Fact]
        public void Test3()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));
            game.HasRolled(1);
            game.AnswerIsWrong();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            Approvals.Verify(fakeconsole.ToString());
        }

        [Fact]
        public void Should_not_have_winner_when_game_starts()
        {
            // Arrange
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));

            // Act
            var hasAWinner = game.HasAWinner();

            // Assert
            Assert.False(hasAWinner);
        }
    }
}
