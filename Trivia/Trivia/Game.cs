﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{

    /// <summary>
    /// The Game
    /// </summary>
    public class Game
    {
        private const int PenaltyBoxSize = 6;

        private readonly List<Player> _players = new List<Player>();

        private readonly bool[] _inPenaltyBox = new bool[PenaltyBoxSize];

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();

        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
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

        public void Add(string playerName)
        {
            _players.Add(new Player(playerName));
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (PlayerIsNotLeavingPenaltyBox(roll))
            {
                Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                _isGettingOutOfPenaltyBox = false;
                return;
            }

            if (PlayerIsInPenaltyBox())
            {
                //User is getting out of penalty box
                _isGettingOutOfPenaltyBox = true;
                //Write that user is getting out
                Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
            }

            // add roll to place        
            MovePlayer(roll);

            DisplayNewPlayerPlace();
            AskQuestion();
        }
        private bool PlayerIsInPenaltyBox()
        {

            return _inPenaltyBox[_currentPlayer];
        }
        private bool PlayerIsNotLeavingPenaltyBox(int roll)
        {

            return PlayerIsInPenaltyBox() && roll % 2 == 0;
        }

        private void DisplayNewPlayerPlace()
        {
            Console.WriteLine(_players[_currentPlayer]
                + "'s new location is "
                + Board.GetPlayerPlace(_players[_currentPlayer]));
            Console.WriteLine("The category is " + CurrentCategory());
        }

        private void MovePlayer(int roll)
        {
            _players[_currentPlayer].Move(roll);
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
            return (_players[_currentPlayer].GetPosition() % 4) switch
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
        public bool WasCorrectlyAnswered()
        {
            var winner = true;
            if ((PlayerIsInPenaltyBox() && _isGettingOutOfPenaltyBox) || !PlayerIsInPenaltyBox())
            {
                Console.WriteLine("Answer was correct!!!!");
                _players[_currentPlayer].Score();
                Console.WriteLine(_players[_currentPlayer]
                    + " now has "
                    + _players[_currentPlayer].GetScore()
                    + " Gold Coins.");

                winner = _players[_currentPlayer].GetScore() != 6;
            }

            NextPlayer();
            return winner;
        }


        private void NextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            NextPlayer();
            //Must always return false 
            return true;
        }
    }

}
