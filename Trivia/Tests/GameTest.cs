using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            game.HasRolled(2);
            game.AnswerIsWrong();
            game.NextPlayer();
            game.HasRolled(2);
            game.HasRolled(3);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(3);
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

        [Fact]
        public void Should_have_a_winner()
        {
            //Arrange
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));

            // Act
            for (var i = 0; i < 11; i++)
            {
                game.HasRolled(1);
                game.AnswerIsCorrect();
                game.NextPlayer();
            }
            
            var hasAWinner = game.HasAWinner();
            
            // Assert
            Assert.True(hasAWinner);
        }
        
        [Theory]
        [InlineData(12)]
        [InlineData(0)]
        public void Should_throw_error_if_roll_is_not_valid(int roll)
        {
            //Arrange
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));

            // Act
            Assert.Throws<ArgumentException>(() => game.HasRolled(roll));
        }

        [Fact]
        public void Should_add_pop_question()
        {
            //Arrange
            var questions = new Questions();
            questions.Add(new PopQuestion("New pop question"));
            
            //Act
            var popQuestion = questions.NextQuestion(Categories.Pop);
            
            //Assert
            Assert.Equal(new PopQuestion("New pop question"), popQuestion);

        }
        
        [Fact]
        public void Should()
        {
            //Arrange
            var questions = new Questions();
            questions.Add(new PopQuestion("New pop question"));
            questions.Add(new ScienceQuestion("New science question"));
            
            //Act
            var scienceQuestion = questions.NextQuestion(Categories.Science);
            
            //Assert
            Assert.Equal(new ScienceQuestion("New science question"), scienceQuestion);

        }
    }

    public class ScienceQuestion : IEquatable<ScienceQuestion>, IQuestion
    {
        private readonly string _label;

        public ScienceQuestion(string label)
        {
            _label = label;
        }

        public Categories GetCategory()
        {
            return Categories.Science;
        }
        
        public bool Equals(ScienceQuestion other)
        {
            return other != null && _label == other._label;
        }
    }

    public interface IQuestion
    {
        Categories GetCategory();
    }

    public class PopQuestion : IEquatable<PopQuestion>, IQuestion
    {
        private readonly string _label;


        public PopQuestion(string label)
        {
            _label = label;
        }

        public Categories GetCategory()
        {
            return Categories.Pop;
        }
        
        public bool Equals(PopQuestion other)
        {
            return other != null && _label == other._label;
        }
        
        public override int GetHashCode()
        {
            return (_label != null ? _label.GetHashCode() : 0);
        }
    }

    public class Questions
    {
        private readonly List<IQuestion> _questions = new List<IQuestion>();

        public void Add(IQuestion question)
        {
            _questions.Add(question);
        }

        public IQuestion NextQuestion(Categories category)
        {
            return _questions.First(question => question.GetCategory().Equals(category));
        }
    }
}
