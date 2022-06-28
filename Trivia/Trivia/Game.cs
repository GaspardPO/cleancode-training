using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{

    /// <summary>
    /// The Game
    /// </summary>
    public class Game
    {
        private readonly Players _players = new Players();

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();

        private bool _isGettingOutOfPenaltyBox;

        public Game(Players players)
        {
            _players = players;
            foreach (var (name, position) in _players.GetPositions())
            {
                Console.WriteLine(name + " was added"); 
                Console.WriteLine("They are player number " + position);
            }
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast("Science Question " + i);
                _sportsQuestions.AddLast("Sports Question " + i);
                _rockQuestions.AddLast("Rock Question " + i);
            }
            
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }
        
        private int HowManyPlayers()
        {
            return _players.Count;
        }

        public void HasRolled(int roll)
        {
            Console.WriteLine(_players.Current() + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (PlayerIsNotLeavingPenaltyBox(roll))
            {
                Console.WriteLine(_players.Current() + " is not getting out of the penalty box");
                _isGettingOutOfPenaltyBox = false;
                return;
            }

            if (PlayerIsInPenaltyBox())
            {
                //User is getting out of penalty box
                _isGettingOutOfPenaltyBox = true;
                //Write that user is getting out
                Console.WriteLine(_players.Current() + " is getting out of the penalty box");
            }

            // add roll to place        
            MovePlayer(roll);

            DisplayNewPlayerPlace();
            AskQuestion();
        }
        private bool PlayerIsInPenaltyBox()
        {

            return _players.Current().IsInPenaltyBox;
        }
        private bool PlayerIsNotLeavingPenaltyBox(int roll)
        {

            return PlayerIsInPenaltyBox() && roll % 2 == 0;
        }

        private void DisplayNewPlayerPlace()
        {
            Console.WriteLine(_players.Current()
                + "'s new location is "
                + Board.GetPlayerPlace(_players.Current()));
            Console.WriteLine("The category is " + CurrentCategory());
        }

        private void MovePlayer(int roll)
        {
            _players.Current().Move(roll);
        }

        private void AskQuestion()
        {
            var currentCategory = CurrentCategory();
            string question = NextQuestion(currentCategory);

            Console.WriteLine(question);
        }

        private string NextQuestion(Categories currentCategory)
        {
            var questions = currentCategory switch
            {
                Categories.Pop => _popQuestions,
                Categories.Sports => _sportsQuestions,
                Categories.Rock => _rockQuestions,
                Categories.Science => _scienceQuestions,
                _ => throw new NotImplementedException()
            };

            var question = questions.First();
            questions.RemoveFirst();
            return question;
        }

        private Categories CurrentCategory()
        {
            return (_players.Current().GetPosition() % 4) switch
            {
                0 => Categories.Pop,
                1 => Categories.Science,
                2 => Categories.Sports,
                _ => Categories.Rock
            };
        }


        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool AnswerIsCorrect()
        {
            var winner = true;
            if ((PlayerIsInPenaltyBox() && _isGettingOutOfPenaltyBox) || !PlayerIsInPenaltyBox())
            {
                Console.WriteLine("Answer was correct!!!!");
                _players.Current().Score();
                Console.WriteLine(_players.Current()
                    + " now has "
                    + _players.Current().GetScore()
                    + " Gold Coins.");

                winner = _players.Current().GetScore() != 6;
            }

            NextPlayer();
            return winner;
        }


        private void NextPlayer()
        {
            _players.Next();
        }

        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool AnswerIsWrong()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.Current() + " was sent to the penalty box");
            _players.Current().GoToPenaltyBox();

            NextPlayer();
            //Must always return false 
            return true;
        }
    }

}
