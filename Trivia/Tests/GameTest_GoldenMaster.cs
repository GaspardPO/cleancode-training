using ApprovalTests;
using ApprovalTests.Reporters;
using System;
using System.IO;
using Trivia;
using Xunit;


namespace Tests
{
    [Collection("Sequential")]
    [UseReporter(typeof(DiffReporter))]
    public class GameTest_GoldenMaster
    {
        private Game game;

        public GameTest_GoldenMaster()
        {
            game = new Game();
        }

        [Fact]
        public void Test1()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            game.AddPlayer("Cedric");
            game.AddPlayer("Eloïse");
            game.Roll(12);
            game.WasWronglyAnswered();
            game.Roll(2);
            game.Roll(13);
            game.WasCorrectlyAnswered();
            game.Roll(13);
            Approvals.Verify(fakeconsole.ToString());
        }

        [Fact]
        public void Test2()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            game.AddPlayer("Cedric");
            game.AddPlayer("Eloïse");
            game.Roll(1);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            Approvals.Verify(fakeconsole.ToString());
        }

        [Fact]
        public void Test3()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            game.AddPlayer("Cedric");
            game.AddPlayer("Eloïse");
            game.Roll(1);
            game.WasWronglyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            Approvals.Verify(fakeconsole.ToString());
        }
    }
}
