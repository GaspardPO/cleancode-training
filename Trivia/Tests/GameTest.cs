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
            game.HasRolled(2);
            game.HasRolled(13);
            game.AnswerIsCorrect();
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
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
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
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            Approvals.Verify(fakeconsole.ToString());
        }
    }
}
